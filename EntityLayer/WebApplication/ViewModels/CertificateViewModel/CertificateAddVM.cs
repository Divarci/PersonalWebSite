using EntityLayer.WebApplication.ViewModels.ResumeViewModel;
using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.CertificateViewModel
{
    public class CertificateAddVM
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

        //Relation With Resume(Parent)
        public int ResumeId { get; set; }

    }
}
