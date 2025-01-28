using AutoMapper;
using MercadoCapitales.API.Precios.Aplicacion.MarketData.Commands;
using MercadoCapitales.API.Precios.Models;
using MercadoCapitales.API.Precios.Models.Dto;
using System.Linq;
using Model = MercadoCapitales.API.Precios.Models;

namespace MercadoCapitales.API.Precios.Mappings.MarketData
{
    public class MarketDataMappingProfile : Profile
    {
        public MarketDataMappingProfile()
        {
            CreateMap<MarketDataDto, Model.MarketData>()
                .ForMember(dest => dest.Market, opt => opt.MapFrom(src => src.Market))
                .ForMember(dest => dest.Symbol, opt => opt.MapFrom(src => src.Symbol))
                .ForMember(dest => dest.ACP, opt => opt.MapFrom(src => src.ACP))
                .ForMember(dest => dest.BI, opt => opt.MapFrom(src => src.BI))
                .ForMember(dest => dest.CL, opt => opt.MapFrom(src => src.CL))
                .ForMember(dest => dest.EV, opt => opt.MapFrom(src => src.EV))
                .ForMember(dest => dest.HI, opt => opt.MapFrom(src => src.HI))
                .ForMember(dest => dest.IV, opt => opt.MapFrom(src => src.IV))
                .ForMember(dest => dest.LA, opt => opt.MapFrom(src => src.LA))
                .ForMember(dest => dest.LO, opt => opt.MapFrom(src => src.LO))
                .ForMember(dest => dest.NV, opt => opt.MapFrom(src => src.NV))
                .ForMember(dest => dest.OF, opt => opt.MapFrom(src => src.OF))
                .ForMember(dest => dest.OI, opt => opt.MapFrom(src => src.OI))
                .ForMember(dest => dest.OP, opt => opt.MapFrom(src => src.OP))
                .ForMember(dest => dest.SE, opt => opt.MapFrom(src => src.SE))
                .ForMember(dest => dest.TV, opt => opt.MapFrom(src => src.TV))
                .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.Timestamp))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type)).ReverseMap();

            // Mapeo para BidDto a BidOffer
            CreateMap<BidDto, Bid>()
                .ReverseMap();

            // Mapeo para OfferDto a Offer
            CreateMap<OfferDto, Offer>()
                .ReverseMap();

            // Mapeo para OpenInterestDto a OpenInterest
            CreateMap<OpenInterestDto, OpenInterest>()
                .ReverseMap();

            // Mapeo para SettlementDto a Settlement
            CreateMap<SettlementDto, Settlement>()
                .ReverseMap();

            // Mapeo para LastPriceDto a LastPrice
            CreateMap<LastPriceDto, LastPrice>()
                .ReverseMap();


            CreateMap<Primary.Data.MarketData, MarketDataDto>()
           .ForMember(dest => dest.Market, opt => opt.MapFrom(src => src.InstrumentId.Market))
           .ForMember(dest => dest.Symbol, opt => opt.MapFrom(src => src.InstrumentId.Symbol))
           .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.Timestamp))
           .ForMember(dest => dest.Type, opt => opt.MapFrom(_ => "MarketData"))

           // Bid Mapping
           .ForMember(dest => dest.BI, opt => opt.MapFrom(src =>
               src.Data.Bids.Select(bid => new BidDto
               {
                   Price = bid.Price,
                   Size = bid.Size
               }).ToList()))

           // Offer Mapping
           .ForMember(dest => dest.OF, opt => opt.MapFrom(src =>
               src.Data.Offers.Select(offer => new OfferDto
               {
                   Price = offer.Price,
                   Size = offer.Size
               }).ToList()))

           // Last Price Mapping
           .ForMember(dest => dest.LA, opt => opt.MapFrom(src => new LastPriceDto
           {
               Price = src.Data.Last.Price//,
               //Date = src.Data.Last?.Date
           }))

           // Open Interest Mapping
           .ForMember(dest => dest.OI, opt => opt.MapFrom(src => new OpenInterestDto
           {
               Size = src.Data.OpenInterest.Size//,
               //Date = src.Data.OpenInterest?.Date
           }))

           // Settlement Mapping
           .ForMember(dest => dest.SE, opt => opt.MapFrom(src => new SettlementDto
           {
               Price = src.Data.SettlementPrice.Price//,
               //Date = src.Data.SettlementPrice?.Date
           }))

           // Direct Property Mappings
           .ForMember(dest => dest.ACP, opt => opt.Ignore()) // You might need custom logic
           .ForMember(dest => dest.CL, opt => opt.MapFrom(src => src.Data.Close.Price))
           .ForMember(dest => dest.EV, opt => opt.MapFrom(src => (int)(src.Data.EffectiveVolume ?? 0)))
           .ForMember(dest => dest.HI, opt => opt.MapFrom(src => src.Data.SessionHighPrice))
           .ForMember(dest => dest.IV, opt => opt.MapFrom(src => src.Data.IndexValue))
           .ForMember(dest => dest.LO, opt => opt.MapFrom(src => src.Data.SessionLowPrice))
           .ForMember(dest => dest.NV, opt => opt.MapFrom(src => (int)(src.Data.NominalVolume ?? 0)))
           .ForMember(dest => dest.OP, opt => opt.MapFrom(src => src.Data.Open))
           .ForMember(dest => dest.TV, opt => opt.MapFrom(src => (int)(src.Data.Volume ?? 0)));

        }
    }
}
