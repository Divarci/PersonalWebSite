using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.ResumeViewModel
{
    public class ResumeUpdateVM
    {
        //Primary Key
        public int Id { get; set; }

        //Check Constrain
        public byte[] RowVersion { get; set; } = null!;

        //Resume Section
        [DisplayName("Title")]
        public string Title { get; set; } = null!;
        [DisplayName("Description")]
        public string Description { get; set; } = null!;


    }
}
