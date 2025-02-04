using Primary.Data;
using Primary;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Configuration;
using MercadoCapitales.API.Precios.Models.Dto;
using AutoMapper;
using System.Linq;
using MediatR;
using MercadoCapitales.API.Precios.Aplicacion.MarketData.Commands;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using MercadoCapitales.API.Precios.Services;

namespace MercadoCapitales.API.Precios.Aplicacion
{
    public class Socket
    {

        private readonly IConfiguration _configuration;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IInstrumentService _instrumentService;
        private readonly IMapper _mapper;
        public Socket(IConfiguration iconfig, IServiceScopeFactory serviceScopeFactory, IInstrumentService instrumentService, IMapper mapper)
        {
            _configuration = iconfig;
            _serviceScopeFactory = serviceScopeFactory;
            _instrumentService = instrumentService;
            _mapper = mapper;
        }

        public async Task RunSocket(object state)
        {
            int hora_actual = DateTime.Now.Hour;

            Console.WriteLine("Connecting to ReMarkets...");

            var api = new Api(Api.DemoEndpoint);
            await api.Login(Api.DemoUsername, Api.DemoPassword);

            // Get a all dollar futures
            Console.WriteLine("Getting available instruments...");

            var allIInstruments = await api.GetAllInstruments();

            // Subscribe to bids and offers
            var entries = new[] { Entry.Bids, Entry.Offers,Entry.Last, Entry.Open, Entry.Close,Entry.SettlementPrice,Entry.SessionHighPrice,Entry.SessionLowPrice, Entry.Volume,Entry.OpenInterest, Entry.EffectiveVolume, Entry.NominalVolume };

            Console.WriteLine("Connecting to market data...");

            var instrumentDtos = (await _instrumentService.GetAllInstrumentsAsync())
                .Where(i => i.Active == true)
                .ToList();


            // Crear una lista para almacenar los instrumentos
            var instrumentIds = _mapper.Map<List<InstrumentId>>(instrumentDtos);

            // Pasar la lista directamente al método CreateMarketDataSocket
            var socket = api.CreateMarketDataSocket(instrumentIds, entries, 1, 2);

            socket.OnData = async (api, marketData) =>
            {
                try
                {
                    await OnMarketData(api, marketData);
                }
                catch (Exception ex)
                {
                    // Log error
                    Console.WriteLine($"Socket data processing error: {ex.Message}");
                }
            };

            ;
            Console.WriteLine("Start Socket...");

            var socketTask = await socket.Start();

            await socketTask;
        }


        private async Task OnMarketData(Api api, Primary.Data.MarketData marketData)
        {
            try
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                    var marketDataDto = _mapper.Map<MarketDataDto>(marketData);
                    var command = new CreateMarketDataCommand(marketDataDto);

                    await mediator.Send(command);
                }
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error processing market data: {ex.Message}");
            }
        }
    }
}
