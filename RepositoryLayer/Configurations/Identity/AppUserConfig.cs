using EntityLayer.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configurations.Identity
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            //Picture Settings
            builder.Property(x => x.FileName).HasMaxLength(100);
            builder.Property(x => x.FileType).HasMaxLength(30);
            builder.Property(x => x.EmailConfirm).HasMaxLength(5);

            //Email Setting
            builder.Property(x=>x.Email).IsRequired();
           
        }
    }
}
