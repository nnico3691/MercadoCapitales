using AutoMapper;
using Modelo = MercadoCapitales.API.Especies.Models;
using MercadoCapitales.API.Especies.Models.Dto;

namespace MercadoCapitales.API.Especies.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Modelo.Instrument, InstrumentoDto>();
        }
    }
}
