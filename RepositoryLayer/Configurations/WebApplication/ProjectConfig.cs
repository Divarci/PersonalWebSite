using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configurations.WebApplication
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            //Project Section
            builder.Property(x => x.Description).HasMaxLength(2500).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(150).IsRequired();
            builder.Property(x => x.ProjectDate).HasMaxLength(10).IsRequired();

            //Check Constraint
            builder.Property(x => x.RowVersion).IsRowVersion();

            //Information
            builder.Property(x => x.CreatedDate).HasMaxLength(10).IsRequired();
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);

            //Relation
            builder.HasMany(x => x.Images).WithOne(x => x.Project).OnDelete(DeleteBehavior.Restrict);

            //Seeding Area
            builder.HasData(new Project
            {
                Id = 1,
                CreatedDate = DateTime.Now.ToString("d"),
                Title = "Flight Ticket",
                Description = "I'm excited to share details about my new project, which played a pivotal role in advancing my C# skills. This project had a strong emphasis on developing dynamic buttons with assigned dynamic missions, all accomplished through the implementation of complex algorithms. By implementing these complex algorithms, I not only expanded my knowledge of algorithmic concepts but also strengthened my problem-solving abilities. I gained valuable experience in analyzing complex problems, devising efficient solutions, and translating them into clean and well-structured code. This project served as a significant milestone in my C# journey, allowing me to consolidate my skills, broaden my horizons, and tackle more intricate programming challenges. I am proud of the achievements and growth I attained throughout this project, and I eagerly look forward to utilizing the knowledge and experiences gained to create innovative solutions in future endeavors. I'm excited about the opportunities that lie ahead and can't wait to continue expanding my expertise in C# and tackling even more advanced projects.",
                ProjectDate = "2022 June",
                ProjectCategoryId = 1,
            }, new Project
            {
                Id = 2,
                CreatedDate = DateTime.Now.ToString("d"),
                Title = "Education Portal",
                Description = "I am thrilled to share the details of my new project, which represents a significant milestone in my journey as a developer. Building upon the foundational skills I acquired in my first project, I dedicated this endeavor to two key areas: database connections and C# algorithms. In this project, I focused on establishing connections to databases, leveraging the capabilities of SQL and database query languages to interact with data effectively. I invested time and effort in learning about database design, normalization, and the principles of relational databases. I grasped concepts such as tables, primary keys, foreign keys, and relationships, which enabled me to design efficient and well-structured database schemas. Using C#, I honed my skills in implementing database connectivity through frameworks or libraries such as ADO.NET or Entity Framework. I gained proficiency in executing SQL queries, retrieving and manipulating data, and handling transactions to ensure data integrity. I am proud of the progress I made during this project, and I am excited to continue expanding my skills in database management, algorithmic problem-solving, and other facets of software development in future endeavors.",
                ProjectDate = "2022 July",
                ProjectCategoryId = 1,

            }, new Project
            {
                Id = 3,
                CreatedDate = DateTime.Now.ToString("d"),
                Title = "Portfolio Web Site",
                Description = "I'm thrilled to share details about my latest project, a potential professional endeavor, developed using ASP.NET Core 6 MVC. This project represents a significant milestone in my journey as a developer, as it showcases my ability to apply solid disciplines, design patterns, clean code rules, and utilize various libraries and features. Throughout the development process, I prioritized adhering to solid disciplines. By applying this principle, I ensured a well-structured and maintainable codebase, enabling future modifications and enhancements with ease. In pursuit of clean code, I followed established coding conventions and guidelines, emphasizing readability, maintainability, and self-documentation. I employed meaningful naming conventions, utilized appropriate code comments, and organized the codebase logically to enhance collaboration and understandability. To handle user authentication and authorization, I leveraged identity libraries provided by ASP.NET Core, ensuring secure access control and user management. I implemented notification mechanisms to keep users informed about relevant updates, ensuring an engaging and interactive experience. With ASP.NET Core 6 MVC , I am confident in my ability to create innovative, scalable solutions that meet the evolving needs of the industry.",
                ProjectDate = "2022 May",
                ProjectCategoryId = 2,
            }, new Project
            {
                Id = 4,
                CreatedDate = DateTime.Now.ToString("d"),
                Title = "Portfolio Web Site",
                Description = "I'm thrilled to share details about my latest project, a potential professional endeavor, developed using ASP.NET Core 6 MVC. This project represents a significant milestone in my journey as a developer, as it showcases my ability to apply solid disciplines, design patterns, clean code rules, and utilize various libraries and features. Throughout the development process, I prioritized adhering to solid disciplines. By applying this principle, I ensured a well-structured and maintainable codebase, enabling future modifications and enhancements with ease. In pursuit of clean code, I followed established coding conventions and guidelines, emphasizing readability, maintainability, and self-documentation. I employed meaningful naming conventions, utilized appropriate code comments, and organized the codebase logically to enhance collaboration and understandability. To handle user authentication and authorization, I leveraged identity libraries provided by ASP.NET Core, ensuring secure access control and user management. I implemented notification mechanisms to keep users informed about relevant updates, ensuring an engaging and interactive experience. With ASP.NET Core 6 MVC , I am confident in my ability to create innovative, scalable solutions that meet the evolving needs of the industry.",
                ProjectDate = "2022 April",
                ProjectCategoryId = 2,
            });

        }
    }
}
