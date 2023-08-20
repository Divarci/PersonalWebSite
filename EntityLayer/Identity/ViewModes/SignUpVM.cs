using System.ComponentModel;

namespace EntityLayer.Identity.ViewModes
{
    public class SignUpVM
    {
        [DisplayName("Username")]
        public string UserName { get; set; } = null!;

        [DisplayName("E-Mail")]
        public string Email { get; set; } = null!;

        [DisplayName("Password")]
        public string Password { get; set; } = null!;

        [DisplayName("Password Confirm")]
        public string PasswordConfirm { get; set; } = null!;

        public short EmailConfirm { get; set; }

        public bool TermsConditions { get; set; } 
    }
}
