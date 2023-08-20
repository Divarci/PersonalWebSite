using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.FactViewModel;

namespace ServiceLayer.Automapper.WebApplication
{
    public class FactMapper : Profile
    {
        public FactMapper()
        {
            //mapping operations
            CreateMap<FactAdminListVM,Fact>().ReverseMap();
            CreateMap<FactUpdateVM,Fact>().ReverseMap();
            CreateMap<FactAddVM,Fact>().ReverseMap();
        }
    }
}
