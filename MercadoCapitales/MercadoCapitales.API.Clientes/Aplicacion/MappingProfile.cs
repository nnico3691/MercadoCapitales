using AutoMapper;
using Model = MercadoCapitales.API.Clientes.Modelo;
using MercadoCapitales.API.Clientes.Modelo.Dto;

namespace MercadoCapitales.API.Clientes.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Model.Cliente, ClienteDto>();


            // Mapeo de Position a PositionDto
            CreateMap<Model.Position, PositionDto>()
                .ForMember(dest => dest.InstrumentId, opt => opt.MapFrom(src => src.InstrumentId))
                .ForMember(dest => dest.Symbol, opt => opt.MapFrom(src => src.Symbol))
                .ForMember(dest => dest.BuySize, opt => opt.MapFrom(src => src.BuySize))
                .ForMember(dest => dest.BuyPrice, opt => opt.MapFrom(src => src.BuyPrice))
                .ForMember(dest => dest.SellSize, opt => opt.MapFrom(src => src.SellSize))
                .ForMember(dest => dest.SellPrice, opt => opt.MapFrom(src => src.SellPrice))
                .ForMember(dest => dest.TotalDailyDiff, opt => opt.MapFrom(src => src.TotalDailyDiff))
                .ForMember(dest => dest.TotalDiff, opt => opt.MapFrom(src => src.TotalDiff))
                .ForMember(dest => dest.TradingSymbol, opt => opt.MapFrom(src => src.TradingSymbol)).ReverseMap();

            CreateMap<PositionDto, Model.Position>()
           .ForMember(dest => dest.PrimaryUserId, opt => opt.MapFrom(src => src.PrimaryUserId));
        }

    }  
}
