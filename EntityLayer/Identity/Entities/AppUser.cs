using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Identity.Entities
{
    public class AppUser : IdentityUser
    {
        //extra properties added
        public string? FileName { get; set; }
        public string? FileType { get; set; }
        public short? EmailConfirm { get; set; }

    }
}
