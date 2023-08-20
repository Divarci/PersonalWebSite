using System.ComponentModel;

namespace EntityLayer.Identity.ViewModes
{
    public class SignInVM
    {
        [DisplayName("E-Mail")]
        public string Email { get; set; } = null!;

        [DisplayName("Password")]
        public string Password { get; set; } = null!;

        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
    }
}
