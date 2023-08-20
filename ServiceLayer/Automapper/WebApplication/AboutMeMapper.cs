using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutMeViewModel;

namespace ServiceLayer.Automapper.WebApplication
{
    public class AboutMeMapper : Profile
    {
        public AboutMeMapper()
        {
            //mapping operations for admin side
            CreateMap<AboutMeAdminListVM, AboutMe>().ReverseMap();
            CreateMap<AboutMeAddVM, AboutMe>().ReverseMap();
            CreateMap<AboutMeUpdateVM, AboutMe>().ReverseMap();


            //mapping operations for user side
            CreateMap<AboutMeUserListVM, AboutMe>().ReverseMap();
            CreateMap<AboutMeForContactVM, AboutMe>().ReverseMap();


        }
    }
}
