using EntityLayer.WebApplication.ViewModels.ProjectViewModel;

namespace EntityLayer.WebApplication.ViewModels.ProjectCategoryViewModel
{
    public class ProjectCategoryForUserListVM
    {
        //Project Category Section
        public string Title { get; set; } = null!;

        //Relation with Project(child)
        public ICollection<ProjectUserVM> Projects { get; set; } = null!;
    }
}
