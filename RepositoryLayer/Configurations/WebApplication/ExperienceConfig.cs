using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configurations.WebApplication
{
    public class ExperienceConfig : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            //Experience section
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
            builder.HasData(new Experience
            {
                Id = 1,
                Title = "Trainee Software Developer",
                Location = "Freelance, London",
                Date = "February 2023 - Present",
                Priorty = 1,
                ResumeId = 1,
                IsEdited = false,
                IsPublished = true,
                CreatedDate = DateTime.Now.ToString("d"),

            },
             new Experience
             {
                 Id = 2,
                 Title = "Architect (Director)",
                 Location = "B&H Design Ltd, London",
                 Date = "April 2019 - Present",
                 Priorty = 2,
                 ResumeId = 1,
                 IsEdited = false,
                 IsPublished = true,
                 CreatedDate = DateTime.Now.ToString("d"),
             },
             new Experience
             {
                 Id = 3,
                 Title = "Architect (Director)",
                 Location = "Gul-Na Architecture, Turkey",
                 Date = "July 2011 - April 2019",
                 Priorty = 1,
                 ResumeId = 2,
                 IsEdited = true,
                 IsPublished = false,
                 CreatedDate = DateTime.Now.ToString("d"),
             },
             new Experience
             {
                 Id = 4,
                 Title = "Architectural Assistant",
                 Location = "Engiz Architecture, Turkey",
                 Date = "June 2010 - June 2011",
                 Priorty = 2,
                 ResumeId = 2,
                 IsEdited = true,
                 CreatedDate = DateTime.Now.ToString("d"),
             });


        }
    }
}
