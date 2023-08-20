using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.ExperienceViewModel
{
    public class ExperienceUpdateVM
    {
        //Primary Key
        public int Id { get; set; }

        //Information
        public string CreatedDate { get; set; } = null!;
        public string? UpdatedDate { get; set; }

        //Status
        public bool IsPublished { get; set; }
        public bool IsEdited { get; set; }

        //Check Constraint
        public byte[] RowVersion { get; set; } = null!;

        //Certificate Section
        [DisplayName("Title")]
        public string Title { get; set; } = null!;
        [DisplayName("Date")]
        public string Date { get; set; } = null!;
        [DisplayName("Location")]
        public string Location { get; set; } = null!;
        [DisplayName("Priority")]
        public short Priorty { get; set; }

        //Relation with Resume(Parent)
        public int ResumeId { get; set; }
    }
}
