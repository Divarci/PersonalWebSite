using EntityLayer.WebApplication.ViewModels.AboutMeViewModel;
using EntityLayer.WebApplication.ViewModels.ContactViewModel;

namespace ServiceLayer.WebApplication.Services.Abstract
{
    public interface IAboutMeService
    {

        //ADMIN SIDE SERVICES-----------------

        //Signatures for methods
        Task<IEnumerable<AboutMeAdminListVM>> GetAboutMeWithAllChildrenAsync();
        Task<AboutMeUpdateVM> GetAboutMeWithAllChildrenByIdAsync(int id);
        Task UpdateAboutMeAsync(AboutMeUpdateVM request);
        Task AddAboutMeAsync(AboutMeAddVM request);
        Task DeleteAboutMeAsync(int id);



        //USER SIDE SERVICES-------------------

        //Signatures for methods
        Task<IEnumerable<AboutMeUserListVM>> GetAboutMeWithAllChildrenForUserAsync();
        Task<IEnumerable<AboutMeForContactVM>> GetContactListForUserAsync();
    }
}
