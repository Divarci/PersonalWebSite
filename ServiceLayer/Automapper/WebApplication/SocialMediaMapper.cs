using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.SocialMediaViewModel;

namespace ServiceLayer.Automapper.WebApplication
{
    public class SocialMediaMapper : Profile
    {
        public SocialMediaMapper()
        {
            //mapping operations
            CreateMap<SocialMediaListVM, SocialMedia>().ReverseMap();
            CreateMap<SocialMediaUpdateVM, SocialMedia>().ReverseMap();
            CreateMap<SocialMediaAddVM, SocialMedia>().ReverseMap();
        }
    }
}
