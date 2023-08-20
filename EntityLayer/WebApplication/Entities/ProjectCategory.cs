using CoreLayer.BaseEntity;

namespace EntityLayer.WebApplication.Entities
{
    public class ProjectCategory : BaseEntity
    {
        //Project Category Section
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        //Status
        public bool IsPublished { get; set; }
        public bool IsEdited { get; set; }


        //Relation with Resume(parent)
        public int ResumeId { get; set; }
        public Resume Resume { get; set; } = null!;

        //Relation with Project(child)
        public ICollection<Project> Projects { get; set; } = null!;

     

    }
}
