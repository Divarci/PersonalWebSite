using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace PortfolioWithBlog.Areas.User.ViewComponents
{
    public class ClaimsViewComponent : ViewComponent
    {
        private readonly IUserService _userService;

        public ClaimsViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimList =await _userService.ClaimList(User);
            return View(claimList);
        }
    }
}
