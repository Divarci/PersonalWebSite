namespace ServiceLayer.Helpers.EmailHelper
{
    public interface IEmailHelper
    {
        //signature for helper method
        Task SendResetPasswordEmail(string resetEmailLink, string To);
    }
}
