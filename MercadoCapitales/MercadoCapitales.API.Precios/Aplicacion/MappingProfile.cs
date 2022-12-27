using AutoMapper;
using MercadoCapitales.API.Precios.Dto;
using MercadoCapitales.API.Precios.Modelo;

namespace MercadoCapitales.API.Precios.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CotizacionAccion, CotizacionAccionDto>();
        }
    }
}
