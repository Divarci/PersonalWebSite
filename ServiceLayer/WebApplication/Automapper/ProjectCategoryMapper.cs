using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.ProjectCategoryViewModel;

namespace ServiceLayer.WebApplication.Automapper
{
    public class ProjectCategoryMapper : Profile
    {
        public ProjectCategoryMapper()
        {
            //mapping operations for admin side
            CreateMap<ProjectCategoryAdminListVM, ProjectCategory>().ReverseMap();
            CreateMap<ProjectCategoryAddVM, ProjectCategory>().ReverseMap();
            CreateMap<ProjectCategoryUpdateVM, ProjectCategory>().ReverseMap();
            CreateMap<ProjectCategoryForProjectVM, ProjectCategory>().ReverseMap();

            //mapping operations for user side
            CreateMap<ProjectCategoryForUserListVM, ProjectCategory>().ReverseMap();


        }
    }
}
