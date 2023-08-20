using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.SocialMediaViewModel
{
    public class SocialMediaUpdateVM
    {
        //Primary Key
        public int Id { get; set; }

        //Information
        public string CreatedDate { get; set; } = null!;

        //check Constraint
        public byte[] RowVersion { get; set; } = null!;

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
