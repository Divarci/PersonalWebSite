using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.EducationViewModel;
using EntityLayer.WebApplication.ViewModels.ExperienceViewModel;

namespace ServiceLayer.Automapper.WebApplication
{
    public class ExperienceMapper : Profile
    {
        public ExperienceMapper()
        {
            //mapping operations for admin side
            CreateMap<ExperienceAdminListVM, Experience>().ReverseMap();
            CreateMap<ExperienceAddVM, Experience>().ReverseMap();
            CreateMap<ExperienceUpdateVM, Experience>().ReverseMap();

            //mapping operations for user side
            CreateMap<ExperienceUserListVM, Experience>().ReverseMap();
        }
    }
}
