using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModes;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Helpers.ModelStateHelper;
using ServiceLayer.Services.Identity.Abstract;

namespace PortfolioWithBlog.Areas.User.Controllers
{
    [Authorize(Roles = "SuperAdmin,Member")]
    [Area("User")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IValidator<UserEditVM> _validatorUserEdit;
        private readonly IUserAuthenticationService _userAuthenticationService;

        public UserController(SignInManager<AppUser> signInManager, IValidator<UserEditVM> validatorUserEdit, IUserAuthenticationService userAuthenticationService, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _validatorUserEdit = validatorUserEdit;
            _userAuthenticationService = userAuthenticationService;
            _userManager = userManager;
        }


        //LogOut
        public async Task<IActionResult> LogOut(string returnUrl)
        {
            //i used return url instead of redirectoaction please have a look the button
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        //User Edit
        [HttpGet]
        public async Task<IActionResult> UserEdit()
        {
            var currentUser = await _userAuthenticationService.GetUserByNameAsync(User);
            return View(currentUser);
        }
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserEditVM request)
        {
            //Find User and valitate request
            var user = await _userManager.FindByNameAsync(User.Identity!.Name);               
            var resultModelValidation = await _validatorUserEdit.ValidateAsync(request);
            if (!resultModelValidation.IsValid)
            {
                resultModelValidation.AddToModelState(this.ModelState);
                return View();
            }

            //Password check
            var resultPasswordCheck = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!resultPasswordCheck)
            {
                ViewBag.Result = "Failed";
                ModelState.AddModelErrorList(new List<string> { "You entered wrong password" });
                return View();
            }

            //Is there any new password?
            if (request.NewPassword != null)
            {
                //if it is so, changes
                var resultChangePassword = await _userManager.ChangePasswordAsync(user, request.Password, request.NewPassword);
                if (!resultChangePassword.Succeeded)
                {
                    ViewBag.Result = "Failed";
                    ModelState.AddModelErrorList(resultChangePassword.Errors);
                    return View();
                }
            }

            //we received our datas from service layer with a tuple.
            var resultUpdateUser = await _userAuthenticationService.UserEditAsync(request, User);
            if (!resultUpdateUser.Succeeded)
            {
                               
                ViewBag.Result = "Failed";
                ModelState.AddModelErrorList(resultUpdateUser.Errors);
                ModelState.AddModelErrorList(new List<string> { "Password Has not been Updated" });
                return View();
            }
           
            //i send the username information to a viewcomponent which needs username as it isnot  able to take new username from cookie. Look at layout
            ViewBag.Username = user.UserName;

            return View();
        }
    }
}
