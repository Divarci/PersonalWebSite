using EntityLayer.WebApplication.ViewModels.ProjectViewModel;

namespace EntityLayer.WebApplication.ViewModels.ProjectImageViewModel
{
    public class ProjectImageAdminListVM
    {
        //Primary Key
        public int Id { get; set; }

        //ProjectImage Section
        public string FileName { get; set; } = null!;
        public string FileType { get; set; } = null!;

        //Relation with Project(parent)
        public ProjectForImageVM Project { get; set; } = null!;

        //Information
        public string CreatedDate { get; set; } = null!;
        public string? UpdatedDate { get; set; }

    }
}
