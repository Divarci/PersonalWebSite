using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configurations.WebApplication
{
    public class ProjectImageConfig : IEntityTypeConfiguration<ProjectImage>
    {
        public void Configure(EntityTypeBuilder<ProjectImage> builder)
        {
            //ProjectImage Section
            builder.Property(x => x.FileName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.FileType).HasMaxLength(30).IsRequired();

            //Ceck Constraint
            builder.Property(x => x.RowVersion).IsRowVersion();

            //Information
            builder.Property(x => x.CreatedDate).HasMaxLength(10).IsRequired();
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);

            //Seeding Area
            builder.HasData(new ProjectImage
            {
                Id = 1,
                FileName = "Add New File",
                FileType = "Add New File",
                ProjectId = 1,
                CreatedDate = DateTime.Now.ToString("d"),
            }, new ProjectImage
            {
                Id = 2,
                FileName = "Add New File",
                FileType = "Add New File",
                ProjectId = 1,
                CreatedDate = DateTime.Now.ToString("d"),
            }, new ProjectImage
            {
                Id = 3,
                FileName = "Add New File",
                FileType = "Add New File",
                ProjectId = 2,
                CreatedDate = DateTime.Now.ToString("d"),
            }, new ProjectImage
            {
                Id = 4,
                FileName = "Add New File",
                FileType = "Add New File",
                ProjectId = 2,
                CreatedDate = DateTime.Now.ToString("d"),
            }, new ProjectImage
            {
                Id = 5,
                FileName = "Add New File",
                FileType = "Add New File",
                ProjectId = 3,
                CreatedDate = DateTime.Now.ToString("d"),
            }, new ProjectImage
            {
                Id = 6,
                FileName = "Add New File",
                FileType = "Add New File",
                ProjectId = 3,
                CreatedDate = DateTime.Now.ToString("d"),
            }, new ProjectImage
            {
                Id = 7,
                FileName = "Add New File",
                FileType = "Add New File",
                ProjectId = 4,
                CreatedDate = DateTime.Now.ToString("d"),
            }, new ProjectImage
            {
                Id = 8,
                FileName = "Add New File",
                FileType = "Add New File",
                ProjectId = 4,
                CreatedDate = DateTime.Now.ToString("d"),
            });



        }
    }
}
