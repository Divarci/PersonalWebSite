
using EntityLayer.WebApplication.ViewModels.ResumeViewModel;

namespace EntityLayer.WebApplication.ViewModels.EducationViewModel
{
    public class EducationAdminListVM
    {
        //Primary Key
        public int Id { get; set; }

        //Information
        public string CreatedDate { get; set; } = null!;
        public string? UpdatedDate { get; set; }

        //Status
        public bool IsPublished { get; set; }

        //Education Section
        public string Title { get; set; } = null!;  
        public string Date { get; set; } = null!;
        public string Location { get; set; } = null!;
        public short Priorty { get; set; }
    }
}
