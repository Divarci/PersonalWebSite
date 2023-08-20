using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.ProjectCategoryViewModel
{
    public class ProjectCategoryAddVM
    {
        //Project Category Section
        [DisplayName("Title")]
        public string Title { get; set; } = null!;
        [DisplayName("Description")]
        public string Description { get; set; } = null!;

        //Status
        public bool IsPublished { get; set; }

        //Relation with Resume(parent)
        public int ResumeId { get; set; }

    }
}
