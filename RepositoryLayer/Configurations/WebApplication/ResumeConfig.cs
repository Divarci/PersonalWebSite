using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configurations.WebApplication
{
    public class ResumeConfig : IEntityTypeConfiguration<Resume>
    {
        public void Configure(EntityTypeBuilder<Resume> builder)
        {
            //Resume Section
            builder.Property(x => x.Description).HasMaxLength(75).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();

            //Check Constraint
            builder.Property(x => x.RowVersion).IsRowVersion();

            //Information
            builder.Property(x => x.CreatedDate).HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);

            //Status
            builder.Property(x => x.IsPublished).HasDefaultValue(false).IsRequired();
            builder.Property(x => x.IsEdited).HasDefaultValue(false).IsRequired();
            builder.Property(x => x.IsDeleted).HasDefaultValue(false).IsRequired();

            //index
            builder.HasIndex(x => x.IsPublished);
            builder.HasIndex(x => x.IsEdited);

            //index
            builder.HasIndex(x => x.IsEdited);
            builder.HasIndex(x => x.IsPublished);

            //Relation
            builder.HasMany(x => x.Certificates).WithOne(x => x.Resume).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Educations).WithOne(x => x.Resume).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.ProjectCategories).WithOne(x => x.Resume).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Skills).WithOne(x => x.Resume).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Experiences).WithOne(x => x.Resume).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.AboutMe).WithOne(x => x.Resume).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.HomePage).WithOne(x => x.Resume).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Messages).WithOne(x => x.Resume).OnDelete(DeleteBehavior.Restrict);

            //Seeding Area
            builder.HasData(new Resume
            {
                Id = 1,
                CreatedDate = DateTime.Now.ToString("d"),
                IsPublished = true,
                IsDeleted = false,
                IsEdited = false,

                Title = "Software Developer London Resume",
                Description = "This is the best resume for now. Continue to use it."


            }, new Resume
            {
                Id = 2,
                CreatedDate = DateTime.Now.ToString("d"),
                IsPublished = false,
                IsDeleted = false,
                IsEdited = true,

                Title = "Software Developer Manchester Resume",
                Description = "This is prepared for after ILR. Do not use this for now."


            });

        }
    }
}
