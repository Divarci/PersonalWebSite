using EntityLayer.WebApplication.ViewModels.ContactViewModel;
using EntityLayer.WebApplication.ViewModels.FactViewModel;
using EntityLayer.WebApplication.ViewModels.SocialMediaViewModel;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.AboutMeViewModel
{
    public class AboutMeUpdateVM
    {
        //Primary Key
        public int Id { get; set; }

        //Status
        public bool IsPublished { get; set; }
        public bool IsEdited { get; set; }

        //Check Constraint
        public byte[] RowVersion { get; set; } = null!;

        //AboutMe Section
        [DisplayName("Title")]
        public string Title { get; set; } = null!;
        [DisplayName("Description")]
        public string Description { get; set; } = null!;

        //Picture Section
        public string FileName { get; set; } = null!;
        public string FileType { get; set; } = null!;

        //Relation With Resume
        public int ResumeId { get; set; }

        //Relation With other viewModels
        public int FactId { get; set; }
        public FactUpdateVM Fact { get; set; } = null!;
        public int ContactId { get; set; }
        public ContactUpdateVM Contact { get; set; } = null!;
        public int SocialMediaId { get; set; }
        public SocialMediaUpdateVM SocialMedia { get; set; } = null!;

        //Helper to pick file from cshtml
        [DisplayName("Photo")]
        public IFormFile? Photo { get; set; } 

    }
}
