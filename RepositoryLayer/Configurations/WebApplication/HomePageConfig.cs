using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configurations.WebApplication
{
    public class HomePageConfig : IEntityTypeConfiguration<HomePage>
    {
        public void Configure(EntityTypeBuilder<HomePage> builder)
        {
            //HomePage Section Settings
            builder.Property(x => x.FullName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.VideoUrl).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired();

            //Check Constraint Settings
            builder.Property(x => x.RowVersion).IsRowVersion();

            //Information Settings
            builder.Property(x => x.CreatedDate).HasMaxLength(10).IsRequired();
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);

            //Status Settings
            builder.Property(x => x.IsPublished).IsRequired();
            builder.Property(x => x.IsEdited).HasDefaultValue(true).IsRequired();

            //index
            builder.HasIndex(x => x.IsPublished);
            builder.HasIndex(x => x.IsEdited);

            //ResumeCv Picture Section
            builder.Property(x => x.ResumeCvFileName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ResumeCvFileType).HasMaxLength(30).IsRequired();

            //Seeding Area
            builder.HasData(new HomePage
            {
                Id = 1,
                FullName = "Hasan Divarci",
                VideoUrl = "https://youtu.be/RKKoABC31zk'",
                Description = "As a recent graduate in architecture with a passion for technology, I am excited to begin a new journey in the field of coding. Despite my lack of professional experience in this field.",
                CreatedDate = DateTime.Now.ToString("d"),
                ResumeCvFileName = "Add Pcture",
                ResumeCvFileType = "Add Pcture",
                IsPublished = true,
                IsEdited = false,
                ResumeId = 1,



            }, new HomePage
            {
                Id = 2,
                FullName = "Hasan Divarci",
                VideoUrl = "https://youtu.be/RKKoABC31zk'",
                Description = "As a recent graduate in architecture with a passion for technology, I am excited to begin a new journey in the field of coding. Despite my lack of professional experience in this field.",
                CreatedDate = DateTime.Now.ToString("d"),
                ResumeCvFileName = "Add Pcture",
                ResumeCvFileType = "Add Pcture",
                IsPublished = false,
                IsEdited = true,
                ResumeId = 2,


            });
        }
    }
}
