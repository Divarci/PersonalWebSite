using EntityLayer.Identity.ViewModes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Security.Principal;

namespace ServiceLayer.Services.Identity.Abstract
{
    public interface IUserAuthenticationService
    {
        //signatures for methods
        Task<UserEditVM> GetUserByNameAsync(ClaimsPrincipal signedInUser);
        Task<IdentityResult> UserEditAsync(UserEditVM request, ClaimsPrincipal signedInUser);
        Task<UserThumbnailVM> GetUserImageAsync(string signedInUser);
    }
}
