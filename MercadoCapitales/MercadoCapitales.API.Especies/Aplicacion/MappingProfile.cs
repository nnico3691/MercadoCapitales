using AutoMapper;
using MercadoCapitales.API.Especies.Aplicacion.Dto;
using MercadoCapitales.API.Especies.Modelo;

namespace MercadoCapitales.API.Especies.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Instrumento, InstrumentoDto>();
        }
    }
}
