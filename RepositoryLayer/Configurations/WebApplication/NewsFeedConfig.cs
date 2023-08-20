using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configurations.WebApplication
{
    public class NewsFeedConfig : IEntityTypeConfiguration<NewsFeed>
    {
        public void Configure(EntityTypeBuilder<NewsFeed> builder)
        {
            //Check Constraint Settings
            builder.Property(x => x.RowVersion).IsRowVersion();

            //Information Settings
            builder.Property(x => x.CreatedDate).HasMaxLength(10).IsRequired();
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);

            //NewsFeed Section Settings
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(2500).IsRequired();

            //Picture Settings
            builder.Property(x => x.FileName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.FileType).HasMaxLength(30).IsRequired();
        }
    }
}
