using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sales.web.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderFormViewModel>().ReverseMap();

            CreateMap<Client, SelectListItem>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.FullName));

            CreateMap<Item, SelectListItem>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Title));

            CreateMap<Client, ClientFormViewModel>().ReverseMap();

            CreateMap<Item, ItemFormViewModel>().ReverseMap();

            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<Account, AccountViewModel>().ReverseMap();

        }
    }
}
