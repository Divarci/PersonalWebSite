using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace EntityLayer.Identity.ViewModes
{
    public class UserEditVM
    {
        [DisplayName("Username")]
        public string UserName { get; set; } = null!;

        [DisplayName("E-Mail")]
        public string Email { get; set; } = null!;

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; } = null!;

        [DisplayName("Current Password")]
        public string Password { get; set; } = null!;

        [DisplayName("New Password")]
        public string? NewPassword { get; set; } 

        [DisplayName("New Password Confirm")]
        public string? NewPasswordConfirm { get; set; }

        //keeps file path
        public string? FileName { get; set; }
        public string? FileType { get; set; }


        [DisplayName("Profile Photo")]
        public IFormFile? Photo { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}
