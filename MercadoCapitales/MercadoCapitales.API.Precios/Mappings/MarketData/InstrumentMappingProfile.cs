using AutoMapper;
using MercadoCapitales.API.Precios.Models.Dto;

namespace MercadoCapitales.API.Precios.Mappings.MarketData
{
    public class InstrumentMappingProfile : Profile
    {
        public InstrumentMappingProfile() 
        {
            CreateMap<InstrumentDto, Primary.Data.InstrumentId>()
                .ForMember(dest => dest.Market, opt => opt.MapFrom(src => src.Market))
                .ForMember(dest => dest.Symbol, opt => opt.MapFrom(src => src.Symbol)).ReverseMap();

        }
    }
}
