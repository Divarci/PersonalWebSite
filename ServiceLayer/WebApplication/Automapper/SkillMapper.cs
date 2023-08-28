using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.SkillViewModel;

namespace ServiceLayer.WebApplication.Automapper
{
    public class SkillMapper : Profile
    {
        public SkillMapper()
        {
            //mapping operations for admin side
            CreateMap<SkillAdminListVM, Skill>().ReverseMap();
            CreateMap<SkillAddVM, Skill>().ReverseMap();
            CreateMap<SkillUpdateVM, Skill>().ReverseMap();

            //mapping operations for user side
            CreateMap<SkillUserListVM, Skill>().ReverseMap();

        }
    }
}
