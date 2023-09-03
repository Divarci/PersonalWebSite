using EntityLayer.Identity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ServiceLayer.Identity.Middlewares
{
    public class RefreshCookie
    {
        private readonly RequestDelegate _next;

        public RefreshCookie(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            if (!context.User.Claims.Any())
            {
                await _next(context);
                return;
            }

            if (context.User!.IsInRole("SuperAdmin"))
            {
                await _next(context);
                return;
            }
            var trialExpireDateClaim = context.User.Claims.FirstOrDefault(x => x.Type.Contains("TrialExpireDate"))!;
            var trialExpireDate = trialExpireDateClaim.Value;
            var adminObserveExpireDateClaim = context.User.Claims.FirstOrDefault(x => x.Type.Contains("AdminObserveExpireDate"))!;
            var adminObserveExpireDate = adminObserveExpireDateClaim.Value;

            var user = await userManager.FindByNameAsync(context.User.Identity!.Name);
            var db_userClaims = await userManager.GetClaimsAsync(user);
            var db_trialExpireDate = db_userClaims.First(x => x.Type.Contains("TrialExpireDate")).Value;
            var db_adminObserveExpireDate = db_userClaims.First(x => x.Type.Contains("AdminObserveExpireDate")).Value;

            if (trialExpireDate == db_trialExpireDate && adminObserveExpireDate == db_adminObserveExpireDate)
            {
                await _next(context);
                return;
            }

            await signInManager.SignOutAsync();
            await signInManager.SignInAsync(user, isPersistent: false);
                        
            await _next(context);
            return;

        }
    }
}
