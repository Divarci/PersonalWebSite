using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.SocialMediaViewModel
{
    public class SocialMediaAddVM
    {
        //Socia Media Section
        [DisplayName("GitHub")]
        public string? GitHub { get; set; }
        [DisplayName("Twitter")]
        public string? Twitter { get; set; }
        [DisplayName("LinkedIn")]
        public string? LinkedIn { get; set; }
        [DisplayName("Youtube")]
        public string? Youtube { get; set; }
    }
}
