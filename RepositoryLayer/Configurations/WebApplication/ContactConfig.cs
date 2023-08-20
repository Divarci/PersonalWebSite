using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configurations.WebApplication
{
    public class ContactConfig : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            //Contact Section
            builder.Property(x => x.Address).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(15).IsRequired();
            builder.Property(x => x.LocationUrl).IsRequired();

            //Check Constraint
            builder.Property(x => x.RowVersion).IsRowVersion();

            //Information
            builder.Property(x => x.CreatedDate).HasMaxLength(10).IsRequired();
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);

            //Seeding Area
            builder.HasData(new Contact
            {
                Id = 1,
                CreatedDate = DateTime.Now.ToString("d"),
                Address = "20 Cosmopolitan Court, 67 Main Avenue, Enfield, EN1 1GD",
                Email = "hasan@gmail.com",
                Phone = "0785463212540",
                LocationUrl = "1",
                AboutMeId = 1,

            }, new Contact
            {
                Id = 2,
                CreatedDate = DateTime.Now.ToString("d"),
                Address = "44 Dowsett Road, Manchester, N17 9DD",
                Email = "hasan@gmail.com",
                LocationUrl = "2",
                Phone = "0785463212540",
                AboutMeId = 2,

            });

        }
    }
}
