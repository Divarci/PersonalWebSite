using EntityLayer.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace ServiceLayer.IdentityCustomization.Validators
{
    //we use here to add extra validations to our Identity User
    public class CustomUserValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            var errors = new List<IdentityError>();

            var isNumeric = int.TryParse(user.UserName[0].ToString(), out _);
            if (isNumeric)
            {
                errors.Add(new() { Code = "UsernameFirstCharIsDigit", Description = "Username can not start with a digit" });
            }


            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
