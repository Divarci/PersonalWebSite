using EntityLayer.WebApplication.ViewModels.ContactViewModel;
using EntityLayer.WebApplication.ViewModels.FactViewModel;
using EntityLayer.WebApplication.ViewModels.SocialMediaViewModel;

namespace EntityLayer.WebApplication.ViewModels.AboutMeViewModel
{
    public class AboutMeUserListVM
    {
        //AboutMe Section
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        //Picture Section
        public string FileName { get; set; } = null!;


        //Relation with other vewModels
        public FactAdminListVM Fact { get; set; } = null!;
        public ContactAdminListVM Contact { get; set; } = null!;
        public SocialMediaListVM SocialMedia { get; set; } = null!;
    }
}
