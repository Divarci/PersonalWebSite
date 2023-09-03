using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModes;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using ServiceLayer._SharedFolder.Helpers.ModalStateHelper;
using ServiceLayer._SharedFolder.Messages.ToastyNotification;
using ServiceLayer.AuthServer.Services.Abstract;
using ServiceLayer.Identity.Services.Abstract;

namespace PortfolioWithBlog.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ICustomAuthenticationService _authentication;
        private readonly IToastNotification _toasty;
        private readonly IIdentityMessages _messages;
        private readonly IValidator<SignUpVM> _validatorSignUp;
        private readonly IValidator<SignInVM> _validatorSignIn;
        private readonly IValidator<ForgotPasswordVM> _validatorForgot;
        private readonly IValidator<ResetPasswordVM> _validatorReset;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenAuthenticationService _tokenService;


        public AuthenticationController(ICustomAuthenticationService authentication, IToastNotification toasty, IIdentityMessages messages, IValidator<SignUpVM> validatorSignUp, IValidator<SignInVM> validatorSignIn, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IValidator<ForgotPasswordVM> validatorForgot, IValidator<ResetPasswordVM> validatorReset, ITokenAuthenticationService tokenService)
        {
            _authentication = authentication;
            _toasty = toasty;
            _messages = messages;
            _validatorSignUp = validatorSignUp;
            _validatorSignIn = validatorSignIn;
            _userManager = userManager;
            _signInManager = signInManager;
            _validatorForgot = validatorForgot;
            _validatorReset = validatorReset;
            _tokenService = tokenService;
        }



        //SignIn
        [HttpGet]
        public IActionResult SignIn(string? errorMessage)
        {
            if(errorMessage != null)
            {
                ViewBag.Result = "SecurityIssue";
                ModelState.AddModelError(string.Empty, errorMessage);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInVM request, string? returnUrl = null)
        {
            //we have a return url. if we dont have a return url, it directs us to url.action
            returnUrl = returnUrl ?? Url.Action("Index", "Dashboard", new { Area = ("User") });

            //validate  the model(we have client side validation as well)
            var modelValidation = await _validatorSignIn.ValidateAsync(request);
            if (!modelValidation.IsValid)
            {
                ViewBag.Result = "Failed";
                modelValidation.AddToModelState(this.ModelState);
                return View();
            }

            //Find the user
            var hasUser = await _userManager.FindByEmailAsync(request.Email);
            if (hasUser == null)
            {
                ViewBag.Result = "Failed";
                ModelState.AddModelErrorList(new List<string> { "Email or Password is wrong" });
                return View();
            }

            //Sign In
            var signInResult = await _signInManager.PasswordSignInAsync(hasUser, request.Password, request.RememberMe, true);
            if (signInResult.Succeeded)
            {
                await _tokenService.CreateTokenAsync(hasUser);
                _toasty.AddSuccessToastMessage(_messages.SuccessfulLogin(hasUser.UserName), new ToastrOptions { Title = "Welcome" });
                return Redirect(returnUrl!);
            }

            //Lock Out
            if (signInResult.IsLockedOut)
            {
                ViewBag.Result = "Lockout";
                ModelState.AddModelErrorList(new List<string> { "Your account has been locked out for 60 seconds" });
                return View();
            }

            //Failed Login
            ViewBag.Result = "Failed";
            ModelState.AddModelErrorList(new List<string> { "Email or Password is wrong", $"Failed login : {await _userManager.GetAccessFailedCountAsync(hasUser)}" });
            return View();

        }

        //SignUp
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpVM request)
        {
            //validate the model
            var modelValidation = await _validatorSignUp.ValidateAsync(request);
            if (!modelValidation.IsValid)
            {
                modelValidation.AddToModelState(this.ModelState);
                return View();
            }

            //create user
            var userCreateResult = await _authentication.CreateUserAsync(request);
            if (!userCreateResult.Succeeded)
            {
                ViewBag.Result = "Failed";
                ModelState.AddModelErrorList(userCreateResult.Errors);
                return View();
            }

            //if succeed
            _toasty.AddSuccessToastMessage(_messages.Add(request.UserName), new ToastrOptions { Title = "Congratulations" });
            return RedirectToAction("SignIn", "Authentication");
         
        }

        //Forgot Password
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM request)
        {

            //validate user
            var modelValidation = await _validatorForgot.ValidateAsync(request);
            if (!modelValidation.IsValid)
            {
                modelValidation.AddToModelState(this.ModelState);
                return View();
            }

            //find user
            var hasUser = await _userManager.FindByEmailAsync(request.Email);
            if (hasUser == null)
            {
                ViewBag.Result = "Failed";
                ModelState.AddModelErrorList(new List<string> { "User does not Exist!" });
                return View();
            }

            //send reset link with token to user
            await _authentication.SendMessageWithLinkAndToken(hasUser, Url, HttpContext);
            _toasty.AddInfoToastMessage(_messages.PasswordResetLink(), new ToastrOptions { Title = ("Congratulations") });

            //forgot password page
            return RedirectToAction(nameof(ForgotPassword));
        }

        //Reset Password
        [HttpGet]
        public IActionResult ResetPassword(string userId, string token, List<string> errors)
        {
            //we receive error messages with List<string> errors if we have while we posting)
            TempData["userId"] = userId;
            TempData["token"] = token;
            if (errors.Any())
            {
                ViewBag.Result = "Failed";
                ModelState.AddModelErrorList(errors);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM request)
        {
            //Tempdatas came from httpget area
            var userId = TempData["userId"];
            var token = TempData["token"];

            //if user and token are null. we have error
            if (userId == null || token == null)
            {
                _toasty.AddErrorToastMessage(_messages.Denied(), new ToastrOptions { Title = ("User or Token does not Exist!") });
                return RedirectToAction("SignIn", "Authentication");
            }

            //validation check
            var modelValidation = await _validatorReset.ValidateAsync(request);
            if (!modelValidation.IsValid)
            {
                //we send error to httpget area if we have them. because when we refresh page errors are gone.
                List<string> errors = modelValidation.Errors.Select(x => x.ErrorMessage).ToList();
                return RedirectToAction("ResetPassword", "Authentication", new { userId, token, errors });
            }

            //check user exist
            var hasUser = await _userManager.FindByIdAsync(userId.ToString());
            if (hasUser == null)
            {
                _toasty.AddErrorToastMessage(_messages.Denied(), new ToastrOptions { Title = ("User does not Exist!") });
                return RedirectToAction("SignIn", "Authentication");
            }

            //reset password
            var resetPasswordResult = await _userManager.ResetPasswordAsync(hasUser!, token.ToString(), request.Password);
            if (resetPasswordResult.Succeeded)
            {
                _toasty.AddSuccessToastMessage(_messages.PasswordReset(), new ToastrOptions { Title = ("Congratulations") });
                return RedirectToAction("SignIn", "Authentication");
            }
            else
            {
                List<string> errors = resetPasswordResult.Errors.Select(x => x.Description).ToList();
                return RedirectToAction("ResetPassword", "Authentication", new { userId, token, errors });
            }

        }

        //Access Denied
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
