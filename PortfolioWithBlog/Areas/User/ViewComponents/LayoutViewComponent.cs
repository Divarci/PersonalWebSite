using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Identity.Services.Abstract;
using System.Security.Claims;
using System.Security.Principal;

namespace PortfolioWithBlog.Areas.User.ViewComponents
{
    [Authorize]
    [Area("User")]
    public class LayoutViewComponent : ViewComponent
    {
        private readonly IUserAuthenticationService _userAuthenticationService;

        public LayoutViewComponent(IUserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string user)
        {
            //we receive this user string from user edit action via viewbags
            if (user == null)
            {
                user = User.Identity!.Name!;
            }
            var image = await _userAuthenticationService.GetUserImageAsync(user);
            return View(image);
        }
    }
}
