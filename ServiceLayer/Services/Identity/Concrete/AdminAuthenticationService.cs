using AutoMapper;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using ServiceLayer.Helpers.ToastyMessages;
using ServiceLayer.Services.Identity.Abstract;
using System.Security.Claims;

namespace ServiceLayer.Services.Identity.Concrete
{
    public class AdminAuthenticationService : IAdminAuthenticationService
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toasty;
        private readonly IIdentityMessages _messages;

        public AdminAuthenticationService(UserManager<AppUser> userManager, IMapper mapper, IToastNotification toasty, IIdentityMessages messages, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _toasty = toasty;
            _messages = messages;
            _signInManager = signInManager;
        }


        //User List
        public async Task<IEnumerable<UserVM>> GetUserListWithRoles()
        {
            var users = await _userManager.Users.ToListAsync();
            var userVM = _mapper.Map<List<UserVM>>(users);

            //rolls and claim are added to each user
            for (int i = 0; i < users.Count; i++)
            {
                var roles = await _userManager.GetRolesAsync(users[i]);
                var claims = await _userManager.GetClaimsAsync(users[i]);
                userVM[i].AppRoles = roles.ToList();
                userVM[i].ClaimValue = claims.ToList();
            }

            return userVM;
        }

        //Trial Re-Activate
        public async Task TrialActivateAsync(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            var claims = await _userManager.GetClaimsAsync(user);
            var existingClaim = claims.First(x => x.Type.ToString() == "TrialExpireDate");

            var newClaim = new Claim("TrialExpireDate", DateTime.Now.AddDays(1).ToString());

            var renewClaimResult = await _userManager.ReplaceClaimAsync(user, existingClaim,newClaim);
            if (!renewClaimResult.Succeeded)
            {
                _toasty.AddErrorToastMessage(_messages.Denied(), new ToastrOptions { Title = "Opps!!" });
                return;
            }
            _toasty.AddSuccessToastMessage(_messages.Add(newClaim.Type), new ToastrOptions { Title = "Congratulations" });
            return ;
        }

        //Observe Permission Grant
        public async Task ObserveActivateAsync(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            var claims = await _userManager.GetClaimsAsync(user);
            var existingClaim = claims.First(x => x.Type.ToString() == "AdminObserveExpireDate");

            var newClaim = new Claim("AdminObserveExpireDate", DateTime.Now.AddDays(1).ToString());

            var renewClaimResult = await _userManager.ReplaceClaimAsync(user, existingClaim, newClaim);
            if (!renewClaimResult.Succeeded)
            {
                _toasty.AddErrorToastMessage(_messages.Denied(), new ToastrOptions { Title = "Opps!!" });
                return;
            }
            _toasty.AddSuccessToastMessage(_messages.Add(newClaim.Type), new ToastrOptions { Title = "Congratulations" });
            return;
        }

    }
}
