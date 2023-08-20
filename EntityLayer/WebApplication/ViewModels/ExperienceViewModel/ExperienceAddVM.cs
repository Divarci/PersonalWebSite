using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.ExperienceViewModel
{
    public class ExperienceAddVM
    {
        //Certificate Section
        [DisplayName("Title")]
        public string Title { get; set; } = null!;
        [DisplayName("Date")]
        public string Date { get; set; } = null!;
        [DisplayName("Location")]
        public string Location { get; set; } = null!;
        [DisplayName("Priority")]
        public short Priorty { get; set; }

        //Status
        public bool IsPublished { get; set; }

        //Relation with Resume(Parent)
        public int ResumeId { get; set; }

    }
}
