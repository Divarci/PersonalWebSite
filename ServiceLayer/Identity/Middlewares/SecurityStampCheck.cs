using EntityLayer.Identity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ServiceLayer.Identity.Middlewares
{
    public class SecurityStampCheck
    {
        private readonly RequestDelegate _next;

        public SecurityStampCheck(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, UserManager<AppUser> userManager)
        {
            if (context.User.Identity == null)
            {
                await _next(context);
                return;
            }

            if (context.User.Identity.IsAuthenticated)
            {
                var securityStampCookie = context.User.Claims.First(x => x.Type.Contains("SecurityStamp")).Value;
                var user = await userManager.GetUserAsync(context.User);
                if (securityStampCookie != user.SecurityStamp)
                {
                    context.Response.Cookies.Delete("HasanDivarci");
                    context.Response.Redirect("/Authentication/SignIn?errorMessage=Your critical informations has been changed. Please Login again.");
                }
            }
            await _next(context);
            return;

        }

    }
}
