using Microsoft.AspNetCore.Identity;

namespace ServiceLayer.Identity.Customization.ErrorDescriber
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        //we can change the error descriptions below.
        /*
        public override IdentityError UserAlreadyHasPassword()
        {
            //We can also create a different message class and use them here.
            return new() { Code = "errorCode", Description="ErrorDescription" };

            //return base.UserAlreadyHasPassword();
        }
        */
    }
}
