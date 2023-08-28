namespace ServiceLayer.Identity.Helpers.EmailHelper
{
    public interface IEmailHelper
    {
        //signature for helper method
        Task SendResetPasswordEmail(string resetEmailLink, string To);
    }
}
