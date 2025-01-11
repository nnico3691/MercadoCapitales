using AutoMapper;
using Model = MercadoCapitales.API.Ordenes.Models;
using static MercadoCapitales.API.Ordenes.Aplicacion.Order.Queries.GetOrdersQueryHandler;

namespace MercadoCapitales.API.Ordenes.Mappings.Order
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile() 
        {
            CreateMap<Primary.Data.Orders.Order, Model.Order>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignorar si deseas generar un nuevo Id
                .ForMember(dest => dest.Proprietary, opt => opt.Ignore()) // Ajusta según sea necesario
                .ForMember(dest => dest.ClientOrderId, opt => opt.Ignore()) // Ajusta según sea necesario
                .ForMember(dest => dest.CancelPrevious, opt => opt.MapFrom(src => false)) // Ajusta según sea necesario
                .ForMember(dest => dest.Iceberg, opt => opt.MapFrom(src => false)) // Ajusta según sea necesario
                .ForMember(dest => dest.DisplayQuantity, opt => opt.MapFrom(src => 0)) // Ajusta según sea necesario
                .ForMember(dest => dest.Market, opt => opt.MapFrom(src => src.InstrumentId.Market)) // Mapeo para Mercado de la Especie
                .ForMember(dest => dest.Symbol, opt => opt.MapFrom(src => src.InstrumentId.Symbol)) // Mapeo para el Simbolo de la Especie
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price)) // Mapeo para Price
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity)) // Mapeo para Quantity
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type)) // Mapeo para Type
                .ForMember(dest => dest.Side, opt => opt.MapFrom(src => src.Side)) // Mapeo para Side
                .ForMember(dest => dest.Expiration, opt => opt.MapFrom(src => src.Expiration)) // Mapeo para Expiration
                .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.ExpirationDate)); // Mapeo para ExpirationDate

            CreateMap<Primary.Data.Orders.OrderStatus, Model.Order>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignorar si deseas generar un nuevo Id
                .ForMember(dest => dest.Proprietary, opt => opt.MapFrom(src => src.Proprietary)) // Ajusta según sea necesario
                .ForMember(dest => dest.ClientOrderId, opt => opt.MapFrom(src => src.ClientOrderId)); // Ajusta según sea necesario

            // Si necesitas mapear OrderStatus también, puedes hacerlo aquí.
            CreateMap<Primary.Data.Orders.OrderStatus, Models.OrderStatus>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignorar si deseas generar un nuevo Id
                .ForMember(dest => dest.ExecutionId, opt => opt.MapFrom(src => src.ExecutionId))
                .ForMember(dest => dest.TransactionTime, opt => opt.MapFrom(src => src.TransactionTime))
                .ForMember(dest => dest.AveragePrice, opt => opt.MapFrom(src => src.AveragePrice))
                .ForMember(dest => dest.LastPrice, opt => opt.MapFrom(src => src.LastPrice))
                .ForMember(dest => dest.LastQuantity, opt => opt.MapFrom(src => src.LastQuantity))
                .ForMember(dest => dest.CumulativeQuantity, opt => opt.MapFrom(src => src.CumulativeQuantity))
                .ForMember(dest => dest.LeavesQuantity, opt => opt.MapFrom(src => src.LeavesQuantity))
                .ForMember(dest => dest.StatusText, opt => opt.MapFrom(src => src.StatusText));

            CreateMap<OrdenFiltrada, Models.OrderStatus>()
             .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignorar si deseas generar un nuevo Id
                .ForMember(dest => dest.ExecutionId, opt => opt.MapFrom(src => src.OrderStatus.ExecutionId))
                .ForMember(dest => dest.TransactionTime, opt => opt.MapFrom(src => src.OrderStatus.TransactionTime))
                .ForMember(dest => dest.AveragePrice, opt => opt.MapFrom(src => src.OrderStatus.AveragePrice))
                .ForMember(dest => dest.LastPrice, opt => opt.MapFrom(src => src.OrderStatus.LastPrice))
                .ForMember(dest => dest.LastQuantity, opt => opt.MapFrom(src => src.OrderStatus.LastQuantity))
                .ForMember(dest => dest.CumulativeQuantity, opt => opt.MapFrom(src => src.OrderStatus.CumulativeQuantity))
                .ForMember(dest => dest.LeavesQuantity, opt => opt.MapFrom(src => src.OrderStatus.LeavesQuantity))
                .ForMember(dest => dest.StatusText, opt => opt.MapFrom(src => src.OrderStatus.StatusText)) // Mapea propiedades específicas
                .ForMember(dest => dest.OrdenId, opt => opt.MapFrom(src => src.OrdenId)); // Asegúrate de mapear OrdenId

        }
    }
}
