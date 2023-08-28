using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.ProjectImageViewModel;

namespace ServiceLayer.WebApplication.Automapper
{
    public class ImageMapper : Profile
    {
        public ImageMapper()
        {
            //mapping operations for admin side
            CreateMap<ProjectImageAddVM, ProjectImage>().ReverseMap();
            CreateMap<ProjectImageAdminListVM, ProjectImage>().ReverseMap();
            CreateMap<ProjectImageUpdateVM, ProjectImage>().ReverseMap();
            CreateMap<ProjectImageUpdateVM, string>().ReverseMap();

            //mapping operations for user side
            CreateMap<ProjectImageUserListVM, ProjectImage>().ReverseMap();


        }
    }
}
