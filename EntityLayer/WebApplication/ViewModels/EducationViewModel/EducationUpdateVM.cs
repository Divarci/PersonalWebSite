using EntityLayer.WebApplication.ViewModels.ResumeViewModel;
using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.EducationViewModel
{
    public class EducationUpdateVM
    {
        //Primary Key
        public int Id { get; set; }

        //Status
        public bool IsPublished { get; set; }
        public bool IsEdited { get; set; }

        //Check Constraint
        public byte[] RowVersion { get; set; } = null!;

        //Certificate Section
        [DisplayName("School")]
        public string Title { get; set; } = null!;
        [DisplayName("Date")]
        public string Date { get; set; } = null!;
        [DisplayName("Location")]
        public string Location { get; set; } = null!;
        [DisplayName("Priority")]
        public short Priorty { get; set; }

        //Relation With Resume(Parent)
        public int ResumeId { get; set; }
    }
}
