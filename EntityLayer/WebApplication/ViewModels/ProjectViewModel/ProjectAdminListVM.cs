using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.ProjectCategoryViewModel;

namespace EntityLayer.WebApplication.ViewModels.ProjectViewModel
{
    public class ProjectAdminListVM
    {
        //Primary Key
        public int Id { get; set; }

        //Information
        public string CreatedDate { get; set; } = null!;
        public string? UpdatedDate { get; set; }

        //Project Section
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ProjectDate { get; set; } = null!;

        //Relation with ProjectCategory(Parent)
        public ProjectCategoryForProjectVM Category { get; set; } = null!;

        
    }
}
