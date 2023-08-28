using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.FactViewModel;

namespace ServiceLayer.WebApplication.Automapper
{
    public class FactMapper : Profile
    {
        public FactMapper()
        {
            //mapping operations
            CreateMap<FactAdminListVM, Fact>().ReverseMap();
            CreateMap<FactUpdateVM, Fact>().ReverseMap();
            CreateMap<FactAddVM, Fact>().ReverseMap();
        }
    }
}
