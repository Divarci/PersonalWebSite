using EntityLayer.AuthServer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.Configurations.AuthServer
{
    public class AccessTokenConfig : IEntityTypeConfiguration<AccessToken>
    {
        public void Configure(EntityTypeBuilder<AccessToken> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.Code).IsRequired();
        }
    }
}
