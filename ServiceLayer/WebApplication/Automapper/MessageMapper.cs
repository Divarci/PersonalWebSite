using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.MessageViewModel;

namespace ServiceLayer.WebApplication.Automapper
{
    public class MessageMapper : Profile
    {
        public MessageMapper()
        {
            //mapping operations for admin side
            CreateMap<MessageAdminListVM, Message>().ReverseMap();
            CreateMap<MessageAdminListForDashboardVM, Message>().ReverseMap();

            //mapping operations for user side
            CreateMap<MessageAddVM, Message>().ReverseMap();


        }
    }
}
