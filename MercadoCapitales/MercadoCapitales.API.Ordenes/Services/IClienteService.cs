using MercadoCapitales.API.Ordenes.Models.Dto;
using System;
using System.Threading.Tasks;

namespace MercadoCapitales.API.Ordenes.Services
{
    public interface IClienteService
    {
        Task<PrimaryUserDto> GetPrimaryUserAsync(string UserName);
    }
}
