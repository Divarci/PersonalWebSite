using EntityLayer.WebApplication.ViewModels.SocialMediaViewModel;

namespace EntityLayer.WebApplication.ViewModels.HomePageViewModel
{
    public class HomePageUserListVM
    {

        //HomePage Section
        public string FullName { get; set; }
        public string VideoUrl { get; set; }
        public string Description { get; set; }
   
        //Resume Picture Section
        public string? ResumeCvFileName { get; set; }

        //SocialMedia ViewModel
        public SocialMediaListVM SocialMediaListVM { get; set;}

        //Relation With Resume(Parent)
        public int ResumeId { get; set; }
    }
}
