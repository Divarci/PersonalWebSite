using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.ResumeViewModel;

namespace ServiceLayer.WebApplication.Automapper
{
    public class ResumeMapper : Profile
    {
        public ResumeMapper()
        {
            //mapping operations
            CreateMap<ResumeAdminListVM, Resume>().ReverseMap();
            CreateMap<ResumeAddVM, Resume>().ReverseMap();
            CreateMap<ResumeUpdateVM, Resume>().ReverseMap();
            CreateMap<ResumeIdVM, Resume>().ReverseMap();
        }
    }
}
