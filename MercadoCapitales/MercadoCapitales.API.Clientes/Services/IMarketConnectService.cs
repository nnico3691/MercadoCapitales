
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Primary.Data.PrimaryRiskAPI;

namespace MercadoCapitales.API.Clientes.Services
{
    public interface IMarketConnectService
    {
        Task<bool> LoginAsync(string username, string password);
        Task<IActionResult> GetPositionsAsync(string account);
        void SetApiEndpoint(); 
    }
}
