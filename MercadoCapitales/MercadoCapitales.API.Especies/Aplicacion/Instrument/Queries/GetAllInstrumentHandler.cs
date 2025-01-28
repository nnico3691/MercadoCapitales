using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MercadoCapitales.API.Especies.Persistencia;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Primary;
using System;
using MercadoCapitales.API.Especies.Models.Dto;
using Modelo = MercadoCapitales.API.Especies.Models;
using Microsoft.Extensions.Logging;

namespace MercadoCapitales.API.Especies.Aplicacion.Instrument.Queries
{
    public class GetAllInstrumentHandler
    {
        public class ListaInstrumentos : IRequest<List<InstrumentoDto>> { }

        public class Manejador : IRequestHandler<ListaInstrumentos, List<InstrumentoDto>>
        {
            private readonly Context _context;
            private readonly IMapper _mapper;
            private readonly ILogger<GetAllInstrumentHandler> _logger;

            public Manejador(Context contexto, IMapper mapper, ILogger<GetAllInstrumentHandler> logger)
            {
                _context = contexto;
                _mapper = mapper;
                _logger = logger;
            }
            public async Task<List<InstrumentoDto>> Handle(ListaInstrumentos request, CancellationToken cancellationToken)
            {
                try 
                {
                    var api = new Api(Api.DemoEndpoint);
                    await api.Login(Api.DemoUsername, Api.DemoPassword);

                    var allIInstruments = await api.GetAllInstruments();

                    // Obtener símbolos de instrumentos actuales
                    var currentSymbols = allIInstruments.Select(x => new { x.Market, x.Symbol }).ToHashSet();

                    // Obtener instrumentos existentes en base de datos
                    var existingInstruments = await _context.Instrument
                        .Where(x => x.Active)
                        .ToListAsync();

                    // Desactivar instrumentos que no están en la lista actual
                    var instrumentsToDeactivate = existingInstruments
                        .Where(x => !currentSymbols.Contains(new { x.Market, x.Symbol }))
                        .ToList();

                    foreach (var instrumentToDeactivate in instrumentsToDeactivate)
                    {
                        instrumentToDeactivate.Active = false;
                        instrumentToDeactivate.DeletedAt = DateTime.Now;
                        instrumentToDeactivate.DeletedBy = "AUT";

                        _context.Instrument.Update(instrumentToDeactivate);
                    }

                    foreach (var instrumento in allIInstruments)
                    {

                        // Buscar instrumento existente por Market y Symbol
                        var existingInstrument = await _context.Instrument
                            .FirstOrDefaultAsync(x =>
                                x.Market == instrumento.Market &&
                                x.Symbol == instrumento.Symbol);

                        if (existingInstrument == null)
                        {
                            var i = new Modelo.Instrument
                            {
                                Market = instrumento.Market,
                                Symbol = instrumento.Symbol,
                                MarketSegmentId = instrumento.segment.MarketSegmentId,
                                marketId = instrumento.segment.marketId,
                                lowLimitPrice = instrumento.lowLimitPrice,
                                highLimitPrice = instrumento.highLimitPrice,
                                minPriceIncrement = instrumento.minPriceIncrement,
                                minTradeVol = instrumento.minTradeVol,
                                maxTradeVol = instrumento.maxTradeVol,
                                tickSize = instrumento.tickSize,
                                contractMultiplier = instrumento.contractMultiplier,
                                roundLot = instrumento.roundLot,
                                PriceConversionFactor = instrumento.PriceConversionFactor,
                                MaturityDate = instrumento.MaturityDate,
                                Currency = instrumento.Currency,
                                securityType = instrumento.securityType,
                                settlType = instrumento.settlType,
                                instrumentPricePrecision = instrumento.instrumentPricePrecision,
                                instrumentSizePrecision = instrumento.instrumentSizePrecision,
                                securityId = instrumento.securityId,
                                securityIdSource = instrumento.securityIdSource,
                                Description = instrumento.Description,
                                cficode = instrumento.cficode,
                                CreatedAt = DateTime.Now,
                                CreatedBy = "AUT",
                                Active = true,
                            };

                            _context.Instrument.Add(i);

                            foreach (var item in instrumento.orderTypes)
                            {
                                var orderType = new Modelo.InstrumentOrderType
                                {
                                    Codigo = item,
                                    Instrument = i
                                };

                                _context.InstrumentOrderType.Add(orderType);

                            }

                            foreach (var item in instrumento.timesInForce)
                            {
                                var timeInForce = new Modelo.InstrumentTimeInForce
                                {
                                    Codigo = item,
                                    Instrument = i
                                };

                                _context.InstrumentTimeInForce.Add(timeInForce);
                            }
                        }
                        else
                        {
                            existingInstrument.lowLimitPrice = instrumento.lowLimitPrice;
                            existingInstrument.highLimitPrice = instrumento.highLimitPrice;
                            existingInstrument.ModifiedAt = DateTime.Now;
                            existingInstrument.ModifiedBy = "AUT";

                            _context.Instrument.Update(existingInstrument);
                        }

                    }

                    await _context.SaveChangesAsync();

                    var lista = await _context.Instrument.Where(x => (x.cficode == "FXXXXX" || x.cficode == "FXXXSX") && (x.MarketSegmentId == "DDF" || x.MarketSegmentId == "DUAL")).OrderBy(x => x.Symbol).ToListAsync();
                    var listaDto = _mapper.Map<List<Modelo.Instrument>, List<InstrumentoDto>>(lista);

                    return listaDto;
                }
                catch (Exception ex)
                {
                    // Generic error handling
                    _logger.LogError($"Unexpected Error: {ex.Message}");
                    throw new ApplicationException("An unexpected error occurred during instrument synchronization", ex);
                }

            }
        }
    }
}
