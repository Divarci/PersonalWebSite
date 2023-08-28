using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutMeViewModel;
using EntityLayer.WebApplication.ViewModels.ProjectViewModel;

namespace ServiceLayer.WebApplication.Automapper
{
    public class ProjectMapper : Profile
    {
        public ProjectMapper()
        {
            //mapping operations for admin side
            CreateMap<ProjectAdminListVM, Project>().ReverseMap();
            CreateMap<ProjectAddVM, Project>().ReverseMap();
            CreateMap<ProjectUpdateVM, Project>().ReverseMap();
            CreateMap<ProjectForImageVM, Project>().ReverseMap();
            CreateMap<ProjectListDashboardVM, Project>().ReverseMap();

            //mapping operations for user side
            CreateMap<ProjectUserVM, Project>().ReverseMap();

        }
    }
}
