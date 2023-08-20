using EntityLayer.WebApplication.ViewModels.HomePageViewModel;

namespace ServiceLayer.Services.WebApplication.Abstract
{
    public interface IHomePageService
    {
        //ADMIN SIDE INTERFACES-------------------------------------
        Task<IEnumerable<HomePageAdminListVM>> GetHomePageListAsync();
        Task AddHomePageAsync(HomePageAddVM request);
        Task DeleteHomePageAsync(int id);
        Task UpdateHomePageAsync(HomePageUpdateVM request);
        Task<HomePageUpdateVM> GetHomePageByIdAsync(int id);


        //USER SIDE INTERFACES-------------------------------------
        Task<List<HomePageUserListVM>> HomePagePublishAsync();
    }
}
