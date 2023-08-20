using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configurations.WebApplication
{
    public class SocialMediaConfig : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            //SocialMedia Settings
            builder.Property(x => x.GitHub).HasMaxLength(1500);
            builder.Property(x => x.Twitter).HasMaxLength(1500);
            builder.Property(x => x.LinkedIn).HasMaxLength(1500);
            builder.Property(x => x.Youtube).HasMaxLength(1500);

            //Check Constraint
            builder.Property(x => x.RowVersion).IsRowVersion();

            //Information
            builder.Property(x => x.CreatedDate).HasMaxLength(10).IsRequired();
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);

            //Seeding Area
            builder.HasData(new SocialMedia
            {

                Id = 1,
                CreatedDate = DateTime.Now.ToString("d"),
                GitHub = "https://github.com/",
                Twitter = "https://twitter.com/",
                LinkedIn = "https://linkdin.com/",
                Youtube = "https://youtube.com/",
                AboutMeId = 1
            }, new SocialMedia
            {

                Id = 2,
                CreatedDate = DateTime.Now.ToString("d"),
                GitHub = "https://github.com/",
                Twitter = "https://twitter.com/",
                LinkedIn = "https://linkdin.com/",
                Youtube = "https://youtube.com/",
                AboutMeId = 2
            });
        }
    }
}
