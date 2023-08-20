using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configurations.WebApplication
{
    public class AboutMeConfig : IEntityTypeConfiguration<AboutMe>
    {
        public void Configure(EntityTypeBuilder<AboutMe> builder)
        {
            //Check Constraint Settings
            builder.Property(x => x.RowVersion).IsRowVersion();

            //Information Settings
            builder.Property(x => x.CreatedDate).HasMaxLength(10).IsRequired();
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);

            //AboutMe Section Settings
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();

            //Status Settings
            builder.Property(x => x.IsPublished).IsRequired();
            builder.Property(x => x.IsEdited).HasDefaultValue(true).IsRequired();

            //index
            builder.HasIndex(x => x.IsPublished);
            builder.HasIndex(x => x.IsEdited);

            //Picture Settings
            builder.Property(x => x.FileName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.FileType).HasMaxLength(30).IsRequired();

            //Relations
            builder.HasOne(x => x.Contact).WithOne(x => x.AboutMe).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Fact).WithOne(x => x.AboutMe).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.SocialMedia).WithOne(x => x.AboutMe).OnDelete(DeleteBehavior.Cascade);

            //Seeding Area
            builder.HasData(new AboutMe
            {
                Id = 1,
                Title = "Software Developer London",
                Description = "As a recent graduate in architecture with a passion for technology, I am excited to begin a new journey in the field of coding. Despite my lack of professional experience in this field, I am highly motivated and eager to learn and grow.I am committed to dedicating myself to studying coding concepts, practicing my skills, and seeking out opportunities to apply my knowledge to real-world projects. My background in architecture has equipped me with valuable skills such as creativity, problem-solving, and attention to detail, which I believe will be invaluable in my pursuit of a career in coding. My eagerness to learn and my passion for coding are what drive me. I am always eager to take on new challenges and to push myself to the limit in order to achieve my goals. Through my dedication and hard work, I am confident that I can make a meaningful contribution to any team or project that I am a part of.",
                CreatedDate = DateTime.Now.ToString("d"),
                IsPublished = true,
                IsEdited = false,
                ResumeId = 1,
                FileName = "Add Picture",
                FileType = "Add Picture",


            }, new AboutMe
            {
                Id = 2,
                Title = "Software Developer Manchester",
                Description = "As a recent graduate in architecture with a passion for technology, I am excited to begin a new journey in the field of coding. Despite my lack of professional experience in this field, I am highly motivated and eager to learn and grow.I am committed to dedicating myself to studying coding concepts, practicing my skills, and seeking out opportunities to apply my knowledge to real-world projects. My background in architecture has equipped me with valuable skills such as creativity, problem-solving, and attention to detail, which I believe will be invaluable in my pursuit of a career in coding. My eagerness to learn and my passion for coding are what drive me. I am always eager to take on new challenges and to push myself to the limit in order to achieve my goals. Through my dedication and hard work, I am confident that I can make a meaningful contribution to any team or project that I am a part of.",
                CreatedDate = DateTime.Now.ToString("d"),
                IsPublished = false,
                IsEdited = true,
                ResumeId = 2,
                FileName = "Add Picture",
                FileType = "Add Picture",

            });

        }
    }
}
