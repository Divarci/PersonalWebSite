using CoreLayer.BaseEntity;
using EntityLayer.Identity.Entities;
using EntityLayer.WebApplication.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace RepositoryLayer.Context
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        //constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Sql Tables
        public DbSet<HomePage> HomePages { get; set; }
        public DbSet<AboutMe> AboutMes { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Fact> Facts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public DbSet<ProjectImage> Images { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<NewsFeed> NewsFeeds { get; set; }

        //override for seeking assemblies
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
      
        }

        //override for savechanges. added create and update time
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entity)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDate = DateTime.Now.ToString("d");
                            break;
                        case EntityState.Modified:
                            Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                            entity.UpdatedDate = DateTime.Now.ToString("d");
                            break;
                        default:
                            break;
                    }
                }

            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
