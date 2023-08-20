namespace EntityLayer.WebApplication.ViewModels.ProjectCategoryViewModel
{
    public class ProjectCategoryAdminListVM
    {
        //Primary Key
        public int Id { get; set; }

        //Information
        public string CreatedDate { get; set; } = null!;
        public string? UpdatedDate { get; set; }

        //Project Category Section
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        //Status
        public bool IsPublished { get; set; }
    }
}
