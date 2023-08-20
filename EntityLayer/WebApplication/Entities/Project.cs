using CoreLayer.BaseEntity;

namespace EntityLayer.WebApplication.Entities
{
    public class Project : BaseEntity
    {
        //Project Section
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ProjectDate { get; set; } = null!;

        //Relation with ProjectCategory(Parent)
        public int ProjectCategoryId { get; set; }
        public ProjectCategory Category { get; set; } = null!;

        //Relation with ProjectCategory(Child)
        public ICollection<ProjectImage> Images { get; set; } = null!;

       
    }
}
