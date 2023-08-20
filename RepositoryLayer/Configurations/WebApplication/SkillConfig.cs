using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configurations.WebApplication
{
    public class SkillConfig : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            //Skill Section
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Value).HasMaxLength(2).IsRequired();

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

            builder.HasData(new Skill
            {
                Id = 1,
                CreatedDate = DateTime.Now.ToString("d"),
                IsPublished = true,
                IsEdited = false,
                Title = "C# Coding Language",
                Value = 65,
                ResumeId = 1,

            }, new Skill
            {
                Id = 2,
                CreatedDate = DateTime.Now.ToString("d"),
                IsPublished = true,
                IsEdited = false,
                Title = "Asp.Net Core 6 Mvc",
                Value = 85,
                ResumeId = 1,

            }, new Skill
            {
                Id = 3,
                CreatedDate = DateTime.Now.ToString("d"),
                IsPublished = false,
                IsEdited = true,
                Title = "HTML",
                Value = 45,
                ResumeId = 2,

            }, new Skill
            {
                Id = 4,
                CreatedDate = DateTime.Now.ToString("d"),
                IsPublished = false,
                IsEdited = true,
                Title = "CSS",
                Value = 65,
                ResumeId = 2

            });
        }
    }
}
