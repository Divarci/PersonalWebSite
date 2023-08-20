using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.ResumeViewModel
{
    public class ResumeAddVM
    {
        //Resume Section
        [DisplayName("Title")]
        public string Title { get; set; } = null!;
        [DisplayName("Description")]
        public string Description { get; set; } = null!;


    }
}
