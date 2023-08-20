using EntityLayer.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace PortfolioWithBlog.RoleClaimSeed
{
    public static class RoleSeed
    {

        public static async Task RoleAdd(RoleManager<AppRole> roleManager)
        {
            var hasSuperdminRole = await roleManager.RoleExistsAsync("SuperAdmin");
            if (!hasSuperdminRole)
            {
                await roleManager.CreateAsync(new AppRole { Name = "SuperAdmin" });

            }
            var hasMember = await roleManager.RoleExistsAsync("Member");

            if (!hasMember)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Member" });

            }

        }
    }
}
