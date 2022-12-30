using AutoMapper;
using MercadoCapitales.API.Clientes.Dto;
using MercadoCapitales.API.Clientes.Modelo;

namespace MercadoCapitales.API.Clientes.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDto>();
        }
    }
}
