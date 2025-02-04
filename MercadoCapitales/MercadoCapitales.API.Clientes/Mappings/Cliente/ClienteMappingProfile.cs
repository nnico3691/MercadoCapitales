using AutoMapper;
using Model = MercadoCapitales.API.Clientes.Models;
using MercadoCapitales.API.Clientes.Models.Dto;

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
