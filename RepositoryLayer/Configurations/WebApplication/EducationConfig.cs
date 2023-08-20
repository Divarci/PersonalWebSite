using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configurations.WebApplication
{
    public class EducationConfig : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            //Education Section
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
            builder.HasData(new Education
            {
                Id = 1,
                Title = "ARCHITECTURE",
                Date = "2005 - 2010",
                Location = "YILDIZ TECHNICAL UNIVERSITY",
                Priorty = 1,
                ResumeId = 1,
                IsPublished = true,
                IsEdited = false,
                CreatedDate = DateTime.Now.ToString("d"),


            },
           new Education
           {
               Id = 2,
               Title = "SCIENCE AND MATH",
               Date = "2001 - 2005",
               Location = "ATATURK HIGH SCHOOL",
               Priorty = 2,
               ResumeId = 1,
               IsPublished = true,
               IsEdited = false,
               CreatedDate = DateTime.Now.ToString("d"),

           }, new Education
           {
               Id = 3,
               Title = "ARCHITECTURE",
               Date = "2005 - 2010",
               Location = "YILDIZ TECHNICAL UNIVERSITY",
               Priorty = 1,
               ResumeId = 2,
               IsPublished = false,
               IsEdited = true,
               CreatedDate = DateTime.Now.ToString("d"),


           },
           new Education
           {
               Id = 4,
               Title = "SCIENCE AND MATH",
               Date = "2001 - 2005",
               Location = "ATATURK HIGH SCHOOL",
               Priorty = 2,
               ResumeId = 2,
               IsPublished = false,
               IsEdited = true,
               CreatedDate = DateTime.Now.ToString("d"),

           });

        }
    }
}
