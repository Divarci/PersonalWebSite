using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configurations.WebApplication
{
    public class ProjectCategoryConfig : IEntityTypeConfiguration<ProjectCategory>
    {
        public void Configure(EntityTypeBuilder<ProjectCategory> builder)
        {
            //Project Category Section
            builder.Property(x => x.Description).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();

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

            //relations
            builder.HasMany(x => x.Projects).WithOne(x => x.Category).OnDelete(DeleteBehavior.Restrict);

            //Seeding Area
            builder.HasData(new ProjectCategory
            {
                Id = 1,
                CreatedDate = DateTime.Now.ToString("d"),
                IsPublished = true,
                IsEdited = false,
                Title = "Study",
                Description = "Welcome to the My Study Projects category. ",

                ResumeId = 1,


            }, new ProjectCategory
            {
                Id = 2,
                CreatedDate = DateTime.Now.ToString("d"),
                IsPublished = false,
                IsEdited = true,
                Title = "Real",
                Description = "Welcome to the Real-World Projects category, where I present a series of practical.",

                ResumeId = 2,


            });
        }
    }
}
