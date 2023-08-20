using EntityLayer.Identity.ViewModes;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace ServiceLayer.Helpers.EmailHelper
{
    public class EmailHelper : IEmailHelper
    {
        //keeps provider info
        private readonly EmailOptionsVM  _emailOptions;

        public EmailHelper(IOptions<EmailOptionsVM> emailOptions)
        {
            _emailOptions = emailOptions.Value;
        }

        public async Task SendResetPasswordEmail(string resetPasswordEmailLink, string toEmail)
        {
            //smtpClient Prperties
            var smtpClient = new SmtpClient();

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Host = _emailOptions.Host;
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(_emailOptions.Email,_emailOptions.Password);
            smtpClient.EnableSsl = true;

            //mailMessage properties
            var mailMessage = new MailMessage();

            mailMessage.From= new MailAddress(_emailOptions.Email);
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = "LocalHost | Password Reset Link";                        
            mailMessage.Body = $@"<h4>Click the Link to reser your password</h4>
                                  <p><a href='{resetPasswordEmailLink}'>Reset Password</a></p>";
            mailMessage.IsBodyHtml = true;


            await smtpClient.SendMailAsync(mailMessage);

        }
    }
}
