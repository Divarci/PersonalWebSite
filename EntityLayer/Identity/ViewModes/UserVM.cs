using EntityLayer.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.Security.Claims;

namespace EntityLayer.Identity.ViewModes
{
    public class UserVM
    {
        //User List for admin
        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public IList<string>? AppRoles { get; set; }

        public IList<Claim>? ClaimValue { get; set; }
    }
}
