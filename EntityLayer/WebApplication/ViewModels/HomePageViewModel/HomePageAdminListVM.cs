using EntityLayer.WebApplication.Entities;

namespace EntityLayer.WebApplication.ViewModels.HomePageViewModel
{
    public class HomePageAdminListVM
    {
        //Primary Key
        public int Id { get; set; }

        //Information
        public string CreatedDate { get; set; } = null!;
        public string? UpdatedDate { get; set; }

        //HomePage Section
        public string FullName { get; set; } = null!;
        public string VideoUrl { get; set; } = null!;
        public string Description { get; set; } = null!;

        //Status
        public bool IsPublished { get; set; }
      
        //Resume Picture Section
        public string ResumeCvFileName { get; set; } = null!;


    }
}
