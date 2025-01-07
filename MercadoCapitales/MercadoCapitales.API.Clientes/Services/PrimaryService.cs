using Microsoft.AspNetCore.Mvc; // Asegúrate de tener esta directiva usando
using Primary;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoCapitales.API.Clientes.Services
{
    public class PrimaryService : IMarketConnectService
    {
        private Api _api;

        public void SetApiEndpoint()
        {
            _api = new Api(Api.DemoEndpoint);
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            SetApiEndpoint();
            if (_api == null)
            {
                throw new InvalidOperationException("API endpoint not set.");
            }

            return await _api.Login(username, password);
        }

        public async Task<IActionResult> GetPositionsAsync(string account)
        {
            if (_api == null)
            {
                return new BadRequestObjectResult("API endpoint not set.");
            }

            try
            {
                var positions = await _api.GetPositions(account); // Asegúrate de que este método esté implementado en Api

                if (positions == null || positions.Count == 0)
                {
                    return new NotFoundObjectResult("No positions found for the specified account.");
                }

                return new OkObjectResult(positions); // Devuelve un 200 OK con las posiciones
            }
            catch (Exception ex)
            {
                // Manejo de errores: devuelve un 500 Internal Server Error
                return new StatusCodeResult(500); // O puedes incluir el mensaje de error: new ObjectResult(ex.Message) { StatusCode = 500 };
            }
        }
    }
}
