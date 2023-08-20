using CoreLayer.BaseEntity;

namespace EntityLayer.WebApplication.Entities
{
    public class Resume : BaseEntity
    {
        //Resume Section
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        //Status
        public bool IsPublished { get; set; }
        public bool IsEdited { get; set; }
        public bool IsDeleted { get; set; }

        //Relation with Other Entities(Child)
        public AboutMe AboutMe { get; set; } = null!;
        public HomePage HomePage { get; set; } = null!;
        public ICollection<Education> Educations { get; set; } = null!;
        public ICollection<Certificate> Certificates { get; set; } = null!;
        public ICollection<Experience> Experiences { get; set; } = null!;
        public ICollection<ProjectCategory> ProjectCategories { get; set; } = null!;
        public ICollection<Skill> Skills { get; set; } = null!;
        public ICollection<Message>? Messages { get; set; }

    }
}
