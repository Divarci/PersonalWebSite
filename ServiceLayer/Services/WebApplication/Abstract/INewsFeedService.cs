using EntityLayer.WebApplication.ViewModels.NewsFeedVM;

namespace ServiceLayer.Services.WebApplication.Abstract
{
    public interface INewsFeedService
    {
        //ADMIN SIDE SERVICES-------------------

        //signature of methods
        Task<List<NewsFeedAdminListVM>> GetNewsListForAdminAsync();
        Task AddNewsFeed(NewsFeedAddVM request);
        Task UpdateNewsFeed(NewsFeedUpdateVM request);
        Task DeleteNewsFeedById(int id);
        Task<NewsFeedUpdateVM> GetNewsByIdAsync(int id);


        //USER SIDE SERVICES-------------------

        //Signatures for methods
        IQueryable<NewsFeedUserListVM> GetNewsListForUserAsync();
    }
}
