using EntityLayer.Identity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Identity.Abstract;

namespace PortfolioWithBlog.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAdminAuthenticationService _adminAuthenticationService;

        public AdminController(UserManager<AppUser> userManager, IAdminAuthenticationService adminAuthenticationService)
        {
            _userManager = userManager;
            _adminAuthenticationService = adminAuthenticationService;
        }

        //List
        public async Task<IActionResult> UserList()
        {
            var userListWithRoles = await _adminAuthenticationService.GetUserListWithRoles();
            return View(userListWithRoles);
        }

        //Trial Activate
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> TrialActivate(string userName)
        {
            await _adminAuthenticationService.TrialActivateAsync(userName);
            return Redirect(nameof(UserList));
        }

        //Observe Activate
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> ObserveActivate(string userName)
        {
            await _adminAuthenticationService.ObserveActivateAsync(userName);
            return Redirect(nameof(UserList));
        }



    }
}
