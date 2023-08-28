using AutoMapper;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Identity.Helpers.EmailHelper;
using ServiceLayer.Identity.Services.Abstract;
using System.Security.Claims;

namespace ServiceLayer.Identity.Services.Concrete
{
    public class CustomAuthenticationService : ICustomAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IEmailHelper _emailHelper;

        public CustomAuthenticationService(UserManager<AppUser> userManager, IMapper mapper, IEmailHelper emailHelper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _emailHelper = emailHelper;
        }


        //Sign Up
        public async Task<IdentityResult> CreateUserAsync(SignUpVM request)
        {
            //confirmation numbers
            Random randomNumber = new();
            request.EmailConfirm = Convert.ToInt16(randomNumber.Next(1000, 9999));

            //create user
            var user = _mapper.Map<AppUser>(request);
            var userCreateResult = await _userManager.CreateAsync(user, request.Password);
            if (!userCreateResult.Succeeded)
            {
                return userCreateResult;
            }

            //add role to user. if it not succeed delete user
            var roleAddToUserResult = await _userManager.AddToRoleAsync(user, "Member");
            if (!roleAddToUserResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                return roleAddToUserResult;
            }

            //add claims to user. if it not succeed delete user with role
            var trialClaim = new Claim("TrialExpireDate", DateTime.Now.AddDays(1).ToString());
            var adminObserveClaim = new Claim("AdminObserveExpireDate", DateTime.Now.ToString());
            var claimAddToUserResult = await _userManager.AddClaimsAsync(user, new[] { trialClaim, adminObserveClaim });
            if (!claimAddToUserResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);
            }

            return claimAddToUserResult;
        }


        //Send Password Reset Link With Token
        public async Task SendMessageWithLinkAndToken(AppUser user, IUrlHelper url, HttpContext httpContext)
        {
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetLink = url.Action("ResetPassword", "Authentication", new { userId = user.Id, Token = passwordResetToken }, httpContext.Request.Scheme);
            await _emailHelper.SendResetPasswordEmail(passwordResetLink!, user.Email);
        }


    }
}
