using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configurations.WebApplication
{
    public class FactConfig : IEntityTypeConfiguration<Fact>
    {
        public void Configure(EntityTypeBuilder<Fact> builder)
        {
            //Fact Section
            builder.Property(x => x.DaysOfStudy).HasMaxLength(4).IsRequired();
            builder.Property(x => x.Project).HasMaxLength(3).IsRequired();
            builder.Property(x => x.CodingLanguage).HasMaxLength(2).IsRequired();
            builder.Property(x => x.Certificate).HasMaxLength(2).IsRequired();

            //Check Constraint
            builder.Property(x => x.RowVersion).IsRowVersion();

            //Information
            builder.Property(x => x.CreatedDate).HasMaxLength(10).IsRequired();
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);

            //Seeding Area
            builder.HasData(new Fact
            {
                Id = 1,
                CreatedDate = DateTime.Now.ToString("d"),
                DaysOfStudy = 180,
                Project = 12,
                CodingLanguage = 3,
                Certificate = 8,
                AboutMeId = 1,


            }, new Fact
            {
                Id = 2,
                CreatedDate = DateTime.Now.ToString("d"),
                DaysOfStudy = 120,
                Project = 15,
                CodingLanguage = 2,
                Certificate = 10,
                AboutMeId = 2,


            });


        }
    }
}
