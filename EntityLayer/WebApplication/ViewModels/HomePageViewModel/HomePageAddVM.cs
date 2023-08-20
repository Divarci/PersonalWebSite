using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.HomePageViewModel
{
    public class HomePageAddVM
    {
        //HomePage Section
        [DisplayName("Full Name")]
        public string FullName { get; set; } = null!;
        [DisplayName("Video URL")]
        public string VideoUrl { get; set; } = null!;
        [DisplayName("Description")]
        public string Description { get; set; } = null!;

        //Status
        public bool IsPublished { get; set; }

        //Resume Picture Section
        public string? ResumeCvFileName { get; set; }
        public string? ResumeCvFileType { get; set; }

        //Relation With Resume(Parent)
        public int ResumeId { get; set; }

        //Helper to pick file from cshtml
        [DisplayName("Resume")]
        public IFormFile PhotoResumeCv { get; set; } = null!;
    }
}
