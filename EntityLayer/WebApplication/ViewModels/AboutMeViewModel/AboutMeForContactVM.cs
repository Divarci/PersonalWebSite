using EntityLayer.WebApplication.ViewModels.ContactViewModel;
using EntityLayer.WebApplication.ViewModels.FactViewModel;
using EntityLayer.WebApplication.ViewModels.SocialMediaViewModel;

namespace EntityLayer.WebApplication.ViewModels.AboutMeViewModel
{
    public class AboutMeForContactVM
    {
        //Relation with other viewModels
        public ContactUserListVM Contact { get; set; } = null!;
    }
}
