using EntityLayer.WebApplication.ViewModels.ResumeViewModel;
using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.EducationViewModel
{
    public class EducationAddVM
    {
        //Certificate Section
        [DisplayName("School")]
        public string Title { get; set; } = null!;
        [DisplayName("Date")]
        public string Date { get; set; } = null!;
        [DisplayName("Location")]
        public string Location { get; set; } = null!;
        [DisplayName("Priority")]
        public short Priorty { get; set; }

        //Status
        public bool IsPublished { get; set; }

        //Relation With Resume(Parent)
        public int ResumeId { get; set; }
    }
}
