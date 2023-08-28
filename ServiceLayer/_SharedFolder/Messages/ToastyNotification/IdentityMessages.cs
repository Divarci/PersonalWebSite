namespace ServiceLayer._SharedFolder.Messages.ToastyNotification
{
    // special messages added for Identity

    public interface IIdentityMessages : IGenericMessages
    {
        string SuccessfulLogin(string username);
        string PasswordResetLink();
        string PasswordReset();
    }
    public class IdentityMessages : GenericMessages, IIdentityMessages
    {
        public string SuccessfulLogin(string username)
        {
            return $"{username}, please have a look all applications!!";
        }
        public string PasswordResetLink()
        {
            return "Password reset link has been sent to your e-mail!";
        }

        public string PasswordReset()
        {
            return "Password reset has been succeeded";
        }


    }
}
