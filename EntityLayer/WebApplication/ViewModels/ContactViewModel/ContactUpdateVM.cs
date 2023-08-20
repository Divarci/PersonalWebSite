using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.ContactViewModel
{
    public class ContactUpdateVM
    {
        //Primary Key
        public int Id { get; set; }
               
        //Check Constraint
        public byte[] RowVersion { get; set; } = null!;

        //Contact Section
        [DisplayName("Address")]
        public string Address { get; set; } = null!;
        [DisplayName("Email")]
        public string Email { get; set; } = null!;
        [DisplayName("Phone Number")]
        public string Phone { get; set; } = null!;
        [DisplayName("Location URL")]
        public string LocationUrl { get; set; } = null!;
    }
}
