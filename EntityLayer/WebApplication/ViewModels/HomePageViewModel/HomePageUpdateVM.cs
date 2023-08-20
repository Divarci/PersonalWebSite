using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.HomePageViewModel
{
    public class HomePageUpdateVM
    {
        //Primary Key
        public int Id { get; set; }

        //HomePage Section
        [DisplayName("Full Name")]
        public string FullName { get; set; } = null!;
        [DisplayName("Video URL")]
        public string VideoUrl { get; set; } = null!;
        [DisplayName("Description")]
        public string Description { get; set; } = null!;

        //Status
        public bool IsPublished { get; set; }
        public bool IsEdited { get; set; }

        //Check Constraint
        public byte[] RowVersion { get; set; } = null!;

        //Resume Picture Section
        public string ResumeCvFileName { get; set; } = null!;
        public string ResumeCvFileType { get; set; } = null!;

        //Helper to pick file from cshtml
        [DisplayName("Resume")]
        public IFormFile? PhotoResumeCv { get; set; }

        //Relation With Resume(Parent)
        public int ResumeId { get; set; }


    }
}
