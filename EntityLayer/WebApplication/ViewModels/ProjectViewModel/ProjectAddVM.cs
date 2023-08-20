using EntityLayer.WebApplication.ViewModels.ProjectCategoryViewModel;
using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.ProjectViewModel
{
    public class ProjectAddVM
    {
        //Project Section
        [DisplayName("Title")]
        public string Title { get; set; } = null!;
        [DisplayName("Description")]
        public string Description { get; set; } = null!;
        [DisplayName("Project Date")]
        public string ProjectDate { get; set; } = null!;


        //Relation with ProjectCategory(Parent)
        public int ProjectCategoryId { get; set; }
        public List<ProjectCategoryForProjectVM> Categories { get; set; } = null!;
    }

}
