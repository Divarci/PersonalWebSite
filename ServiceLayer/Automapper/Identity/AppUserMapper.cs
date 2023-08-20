using AutoMapper;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModes;

namespace ServiceLayer.Automapper.Identity
{
    public class AppUserMapper : Profile
    {
        public AppUserMapper()
        {           
            //mapping operations for identity
            CreateMap<SignUpVM, AppUser>().ReverseMap();
            CreateMap<UserVM, AppUser>().ReverseMap();
            CreateMap<UserEditVM, AppUser>().ReverseMap();
            CreateMap<UserThumbnailVM, AppUser>().ReverseMap();
        }
    }
}
