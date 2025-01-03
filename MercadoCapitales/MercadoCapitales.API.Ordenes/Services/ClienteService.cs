using MercadoCapitales.API.Ordenes.Models.Dto;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MercadoCapitales.API.Ordenes.Services
{
    public class ClienteService : IClienteService
    {
        private readonly HttpClient _httpClient;

        public ClienteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PrimaryUserDto> GetPrimaryUserAsync(string UserName)
        {

            // Suponiendo que la API tiene un endpoint como /api/clientes/{username}
            var response = await _httpClient.GetAsync($"/api/Primaryuser/{UserName}");

            if (response.IsSuccessStatusCode)
            {

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase // Para usar camelCase
                };

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<PrimaryUserDto>(jsonResponse, options);

            }

            // Manejo de errores según sea necesario
            return null; // O lanzar una excepción según tu lógica
        }
    }
}
