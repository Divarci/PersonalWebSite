using EntityLayer.WebApplication.Entities;

namespace EntityLayer.WebApplication.ViewModels.ProjectCategoryViewModel
{
    public class ProjectCategoryForProjectVM
    {
        //Primary Key
        public int Id { get; set; }

        //Project Category Section
        public string Title { get; set; } = null!;

        //Status
        public bool IsPublished { get; set; }

       


    }
}
