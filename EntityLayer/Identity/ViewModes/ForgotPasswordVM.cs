using System.ComponentModel;

namespace EntityLayer.Identity.ViewModes
{
    public class ForgotPasswordVM
    {
        [DisplayName("E-Mail")]
        public string Email { get; set; } = null!;
    }
}
