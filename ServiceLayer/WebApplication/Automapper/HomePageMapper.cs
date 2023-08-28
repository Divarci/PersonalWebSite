using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.HomePageViewModel;
using EntityLayer.WebApplication.ViewModels.SkillViewModel;

namespace ServiceLayer.WebApplication.Automapper
{
    public class HomePageMapper : Profile
    {
        public HomePageMapper()
        {
            //mapping operations for admin side
            CreateMap<HomePageAdminListVM, HomePage>().ReverseMap();
            CreateMap<HomePageAddVM, HomePage>().ReverseMap();
            CreateMap<HomePageUpdateVM, HomePage>().ReverseMap();

            //mapping operations for user side
            CreateMap<HomePageUserListVM, HomePage>().ReverseMap();

        }
    }
}
