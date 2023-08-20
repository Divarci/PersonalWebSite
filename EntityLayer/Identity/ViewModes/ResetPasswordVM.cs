using System.ComponentModel;

namespace EntityLayer.Identity.ViewModes
{
    public class ResetPasswordVM
    {
        [DisplayName("New Password")]
        public string Password { get; set; } = null!;

        [DisplayName("New Password Confirm")]
        public string PasswordConfirm { get; set; } = null!;
    }
}
