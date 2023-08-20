using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configurations.WebApplication
{
    public class CertificateConfig : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            //Certificate section
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Date).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Location).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Priorty).HasMaxLength(3).IsRequired();

            //Check Constraint
            builder.Property(x => x.RowVersion).IsRowVersion();

            //Information
            builder.Property(x => x.CreatedDate).HasMaxLength(10).IsRequired();
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);

            //Status
            builder.Property(x => x.IsPublished).IsRequired();
            builder.Property(x => x.IsEdited).HasDefaultValue(true).IsRequired();

            //index
            builder.HasIndex(x => x.IsPublished);
            builder.HasIndex(x => x.IsEdited);

            //Seeding Area
            builder.HasData(new Certificate
            {
                Id = 1,
                CreatedDate = DateTime.Now.ToString("d"),
                IsPublished = true,
                IsEdited = false,
                Title = "Step by Step C#",
                Date = "February 2023",
                Location = "Udemy Course",
                Priorty = 1,
                ResumeId = 1,

            },
          new Certificate
          {
              Id = 2,
              CreatedDate = DateTime.Now.ToString("d"),
              IsPublished = true,
              IsEdited = false,
              Title = "Ms SQL with querries",
              Date = "March 2023",
              Location = "Udemy Course",
              Priorty = 2,
              ResumeId = 1,

          },
          new Certificate
          {
              Id = 3,
              CreatedDate = DateTime.Now.ToString("d"),
              IsPublished = false,
              IsEdited = true,
              Title = "ASP.NET Framework MVC5",
              Date = "April 2023",
              Location = "Udemy Course",
              Priorty = 1,
              ResumeId = 2,
          },
          new Certificate
          {
              Id = 4,
              CreatedDate = DateTime.Now.ToString("d"),
              IsPublished = false,
              IsEdited = true,
              Title = "ASP.NET Core 6 MVC",
              Date = "May 2023",
              Location = "Udemy Course",
              Priorty = 2,
              ResumeId = 2,

          });

        }
    }
}
