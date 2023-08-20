using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.EducationViewModel;

namespace ServiceLayer.Automapper.WebApplication
{
    public class EducationMapper : Profile
    {
        public EducationMapper()
        {
            //mapping operations for admin side
            CreateMap<EducationAdminListVM, Education>().ReverseMap();
            CreateMap<EducationAddVM,Education>().ReverseMap();
            CreateMap<EducationUpdateVM,Education>().ReverseMap();

            //mapping operations for user side
            CreateMap<EducationUserListVM,Education>().ReverseMap();
        }
    }
}
