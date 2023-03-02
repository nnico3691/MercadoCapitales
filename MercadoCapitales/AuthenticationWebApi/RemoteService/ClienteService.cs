using AuthenticationWebApi.RemoteInterface;
using AuthenticationWebApi.RemoteModel;
using System.Net.Http;
using System.Text.Json;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using MediatR;

namespace AuthenticationWebApi.RemoteService
{
    public class ClienteService : IClientesService
    {

        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<ClienteService> _logger;

        public ClienteService(IHttpClientFactory httpClient, ILogger<ClienteService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(bool resultado, LoginRemote Info, string ErrorMessage)> ValidarLogin(string Usuario,string Clave)
        {
            try
            {
                var cliente = _httpClient.CreateClient("Clientes");

                var data = new
                {
                    Usuario = Usuario,
                    Clave = Clave
                };

                JsonContent content = JsonContent.Create(data);

                var response = await cliente.PostAsync($"api/Cliente/Login", content);

                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<LoginRemote>(contenido, options);

                    return (true, resultado, null);
                }

                return (false, new LoginRemote(), response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, new LoginRemote(), e.Message);
            }
        }
    }
}
