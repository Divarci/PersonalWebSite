using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.ContactViewModel;

namespace ServiceLayer.Automapper.WebApplication
{
    public class ContactMapper : Profile
    {
        public ContactMapper()
        {
            //mapping operations for admin side
            CreateMap<ContactAdminListVM, Contact>().ReverseMap();
            CreateMap<ContactUpdateVM, Contact>().ReverseMap();
            CreateMap<ContactAddVM, Contact>().ReverseMap();

            //mapping operations for user side
            CreateMap<ContactUserListVM, Contact>().ReverseMap();

        }
    }
}
