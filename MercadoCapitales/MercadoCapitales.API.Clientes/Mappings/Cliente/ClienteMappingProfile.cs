using AutoMapper;
using Model = MercadoCapitales.API.Clientes.Modelo;
using MercadoCapitales.API.Clientes.Modelo.Dto;

namespace MercadoCapitales.API.Clientes.Mappings.Cliente
{
    public class ClienteMappingProfile:Profile
    {
        public ClienteMappingProfile() 
        {
            CreateMap<Model.Cliente, ClienteDto>();
        }
    }
}
