using EntityLayer.WebApplication.ViewModels.ProjectImageViewModel;

namespace EntityLayer.WebApplication.ViewModels.ProjectViewModel
{
    public class ProjectListDashboardVM
    {
        //Project Section
        public string Title { get; set; } = null!;
        public string ProjectDate { get; set; } = null!;

        //Relation with ProjectCategory(Child)
        public ICollection<ProjectImageUserListVM> Images { get; set; } = null!;
    }
}
