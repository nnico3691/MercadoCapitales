using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Linq;
using MercadoCapitales.API.Clientes.Models.Dto;

namespace MercadoCapitales.API.Clientes.Services
{
    public class InstrumentService : IInstrumentService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;

        public InstrumentService(IConfiguration configuration, ILogger<InstrumentService> logger, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<InstrumentDto>> GetAllInstrumentsAsync()
        {

            // Suponiendo que la API tiene un endpoint como /api/clientes/{username}
            var response = await _httpClient.GetAsync($"/api/Instrument/");

            if (response.IsSuccessStatusCode)
            {

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase // Para usar camelCase
                };

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<InstrumentDto>>(jsonResponse, options);

            }

            // Manejo de errores según sea necesario
            return null; // O lanzar una excepción según tu lógica
        }

    }
}
