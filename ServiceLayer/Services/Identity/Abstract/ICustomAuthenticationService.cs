using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Services.Identity.Abstract
{
    public interface ICustomAuthenticationService
    {
        //signatures for methods
        Task<IdentityResult> CreateUserAsync(SignUpVM request);
        Task SendMessageWithLinkAndToken(AppUser user, IUrlHelper url, HttpContext httpContext);
   }
}
