using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configurations.WebApplication
{
    public class MessageConfig : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            //AboutMe Section Settings
            builder.Property(x => x.Sender).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Subject).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();

            //Check Constraint Settings
            builder.Property(x => x.RowVersion).IsRowVersion();

            //Information Settings
            builder.Property(x => x.CreatedDate).HasMaxLength(10).IsRequired();
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);

            //Status Settings
            builder.Property(x => x.IsEdited).IsRequired();

            //Seeding Area
            builder.HasData(new Message
            {
                Id = 1,
                CreatedDate = DateTime.Now.ToString("d"),
                IsEdited = false,
                Sender = "Melih Canatan",
                Subject = "Deneme Mesaji",
                Email = "adanali@adamlar.geldi",
                Description = "Welcome to the My Study Projects category. ",
                ResumeId = 1,
            }, new Message
            {
                Id = 2,
                CreatedDate = DateTime.Now.ToString("d"),
                IsEdited = false,
                Sender = "Tarik Canatan",
                Subject = "Deneme Mesaji 2",
                Email = "mallar@adamlar.geldi",
                Description = "Welcome to the My Study Projects category2. ",
                ResumeId = 1,
            }, new Message
            {
                Id = 3,
                CreatedDate = DateTime.Now.ToString("d"),
                IsEdited = false,
                Sender = "Kazim Canatan",
                Subject = "Deneme Mesaji 3",
                Email = "antalyali@adamlar.geldi",
                Description = "Welcome to the My Study Projects category3. ",
                ResumeId = 2,
            }, new Message
            {
                Id = 4,
                CreatedDate = DateTime.Now.ToString("d"),
                IsEdited = false,
                Sender = "Veli Canatan",
                Subject = "Deneme Mesaji 4",
                Email = "bursali@adamlar.geldi",
                Description = "Welcome to the My Study Projects category4. ",
                ResumeId = 2,
            });
        }
    }
}
