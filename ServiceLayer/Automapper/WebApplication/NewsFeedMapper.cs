using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.NewsFeedVM;

namespace ServiceLayer.Automapper.WebApplication
{
    public class NewsFeedMapper : Profile
    {
        public NewsFeedMapper()
        {
            //mapping operations for admin side
            CreateMap<NewsFeed,NewsFeedAddVM>().ReverseMap();
            CreateMap<NewsFeed,NewsFeedUpdateVM>().ReverseMap();
            CreateMap<NewsFeed,NewsFeedAdminListVM>().ReverseMap();

            //mapping operations for user side
            CreateMap<NewsFeed, NewsFeedUserListVM>().ReverseMap();
        }
    }
}
