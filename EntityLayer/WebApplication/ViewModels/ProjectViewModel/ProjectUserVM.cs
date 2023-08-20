using EntityLayer.WebApplication.ViewModels.ProjectImageViewModel;

namespace EntityLayer.WebApplication.ViewModels.ProjectViewModel
{
    public class ProjectUserVM
    {
        //Primary Key
        public int Id { get; set; }

        //Project Section
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ProjectDate { get; set; } = null!;

        //Relation with ProjectCategory(Child)
        public ICollection<ProjectImageUserListVM> Images { get; set; } = null!;
    }
}
