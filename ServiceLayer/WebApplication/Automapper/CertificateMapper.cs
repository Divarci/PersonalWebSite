using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.CertificateViewModel;
using EntityLayer.WebApplication.ViewModels.ExperienceViewModel;

namespace ServiceLayer.WebApplication.Automapper
{
    public class CertificateMapper : Profile
    {
        public CertificateMapper()
        {
            //mapping operations for admin side
            CreateMap<CertificateAdminListVM, Certificate>().ReverseMap();
            CreateMap<CertificateAddVM, Certificate>().ReverseMap();
            CreateMap<CertificateUpdateVM, Certificate>().ReverseMap();

            //mapping operations for user side
            CreateMap<CertificateUserListVM, Certificate>().ReverseMap();
        }
    }
}
