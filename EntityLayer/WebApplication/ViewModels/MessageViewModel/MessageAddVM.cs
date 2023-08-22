using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.MessageViewModel
{
    public class MessageAddVM
    {
        //Message Section
        [DisplayName("Sender")]
        public string Sender { get; set; } = null!;
        [DisplayName("Subject")]
        public string Subject { get; set; } = null!;
        [DisplayName("Description")]
        public string Description { get; set; } = null!;
        [DisplayName("Email")]
        public string Email { get; set; } = null!;
       
        [DisplayName("Captcha")]
        public int CatpchaGenerated { get; set; }
        [DisplayName("Confirm")]
        public int CatpchaConfirm { get; set; }

    }
}
