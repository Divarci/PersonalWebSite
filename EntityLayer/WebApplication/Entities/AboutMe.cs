using CoreLayer.BaseEntity;

namespace EntityLayer.WebApplication.Entities
{
    public class AboutMe : BaseEntity
    {

        //AboutMe Section
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        //Status
        public bool IsPublished { get; set; }
        public bool IsEdited { get; set; }

        //Picture Section
        public string FileName { get; set; } = null!;
        public string FileType { get; set; } = null!;

        //Relation With Resume(Parent)
        public int ResumeId { get; set; }
        public Resume Resume { get; set; } = null!;

        //relation with extensions(Child)
        public Fact Fact { get; set; } = null!;
        public Contact Contact { get; set; } = null!;
        public SocialMedia SocialMedia { get; set; } = null!;

    }
}
