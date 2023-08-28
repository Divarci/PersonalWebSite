using AutoMapper;
using EntityLayer.Identity.Entities;
using EntityLayer.WebApplication.ViewModels.UserVM;
using Microsoft.AspNetCore.Identity;
using ServiceLayer.WebApplication.Services.Abstract;
using System.Security.Principal;

namespace ServiceLayer.WebApplication.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<ClaimListVM>> ClaimList(IPrincipal user)
        {
            var userSignedIn = await _userManager.FindByNameAsync(user.Identity!.Name);
            var adminObserverClaimExpireDate = await _userManager.GetClaimsAsync(userSignedIn);

            List<ClaimListVM> claimList = new();

            for (int i = 0; i < adminObserverClaimExpireDate.Count; i++)
            {
                claimList.Add(new ClaimListVM
                {
                    ClaimName = adminObserverClaimExpireDate[i].Type.ToString(),
                    ClaimExpire = adminObserverClaimExpireDate[i].Value.ToString(),
                });
            }

            return claimList;
        }
    }
}
