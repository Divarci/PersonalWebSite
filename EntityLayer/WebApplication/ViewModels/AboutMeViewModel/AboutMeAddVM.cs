using EntityLayer.WebApplication.ViewModels.ContactViewModel;
using EntityLayer.WebApplication.ViewModels.FactViewModel;
using EntityLayer.WebApplication.ViewModels.SocialMediaViewModel;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.WebApplication.ViewModels.AboutMeViewModel
{
    public class AboutMeAddVM
    {
        //AboutMe Section        
        [DisplayName("Title")]
        public string Title { get; set; } = null!;
        [DisplayName("Description")]
        public string Description { get; set; } = null!;

        //Status
        public bool IsPublished { get; set; }

        //Picture Section
        public string FileName { get; set; } = null!;
        public string FileType { get; set; } = null!;

        //Relation With Resume(Parent)
        public int ResumeId { get; set; }

        //Relation with other viewModels
        public FactAddVM Fact { get; set; } = null!;
        public ContactAddVM Contact { get; set; } = null!;
        public SocialMediaAddVM SocialMedia { get; set; } = null!;

        //Helper to pick file from cshtml
        [DisplayName("Photo")]
        public IFormFile Photo { get; set; } = null!;
    }
}
