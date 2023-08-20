using EntityLayer.WebApplication.ViewModels.ResumeViewModel;

namespace EntityLayer.WebApplication.ViewModels.ExperienceViewModel
{
    public class ExperienceAdminListVM
    {
        //Primary key
        public int Id { get; set; }

        //Inforation
        public string CreatedDate { get; set; } = null!;
        public string? UpdatedDate { get; set; }

        //Status
        public bool IsPublished { get; set; }

        //Experience Section
        public string Title { get; set; } = null!;
        public string Date { get; set; } = null!;
        public string Location { get; set; } = null!;
        public short Priorty { get; set; }
    }
}
