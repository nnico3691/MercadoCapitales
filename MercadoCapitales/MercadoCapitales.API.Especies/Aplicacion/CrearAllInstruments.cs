using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MercadoCapitales.API.Especies.Persistencia;
using Primary;
using Newtonsoft.Json;
using MercadoCapitales.API.Especies.Modelo;
using System;

namespace MercadoCapitales.API.Especies.Aplicacion
{
    public class CrearAllInstruments
    {
        public class Ejecuta : IRequest { }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ContextEspecie _contexto;
         
            public Manejador(ContextEspecie contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var api = new Api(Api.DemoEndpoint);
                await api.Login(Api.DemoUsername, Api.DemoPassword);
                
                var allIInstruments = await api.GetAllInstruments();

                foreach (var instumento in allIInstruments) 
                {
                    var i = new Instrumento 
                    {
                        Market = instumento.Market,
                        Symbol = instumento.Symbol,
                        MarketSegmentId = instumento.segment.MarketSegmentId,
                        marketId = instumento.segment.marketId,
                        lowLimitPrice = instumento.lowLimitPrice,
                        highLimitPrice = instumento.highLimitPrice,
                        minPriceIncrement = instumento.minPriceIncrement,
                        minTradeVol = instumento.minTradeVol,
                        maxTradeVol = instumento.maxTradeVol,
                        tickSize = instumento.tickSize,
                        contractMultiplier = instumento.contractMultiplier,
                        roundLot = instumento.roundLot,
                        PriceConversionFactor = instumento.PriceConversionFactor,
                        MaturityDate = instumento.MaturityDate,
                        Currency = instumento.Currency,
                        securityType = instumento.securityType,
                        settlType = instumento.settlType,
                        instrumentPricePrecision = instumento.instrumentPricePrecision,
                        instrumentSizePrecision = instumento.instrumentSizePrecision,
                        securityId = instumento.securityId,
                        securityIdSource = instumento.securityIdSource,
                        Description = instumento.Description,
                        cficode = instumento.cficode,
                        
                    };

                    _contexto.Instrumento.Add(i);
                    var value = await _contexto.SaveChangesAsync();

                    if (value <= 0)
                    {
                        throw new Exception("Errores en la inserción del Nuevos Instrumentos.");
                    }

                    foreach (var item in instumento.orderTypes) 
                    {
                        var orderType = new InstrumentOrderType
                        {
                            Codigo = item,
                            InstrumentoId = i.InstrumentoId
                        };
                        
                        _contexto.InstrumentOrderType.Add(orderType);
                        value = await _contexto.SaveChangesAsync();

                        if (value <= 0)
                        {
                            throw new Exception("Errores en la inserción del Nuevos OrderType.");
                        }
                    }

                    foreach (var item in instumento.timesInForce)
                    {
                        var timeInForce = new InstrumentTimeInForce
                        {
                            Codigo = item,
                            InstrumentoId = i.InstrumentoId
                        };

                        _contexto.InstrumentTimeInForce.Add(timeInForce);
                        value = await _contexto.SaveChangesAsync();

                        if (value <= 0)
                        {
                            throw new Exception("Errores en la inserción del Nuevos TimeInForce.");
                        }
                    }

                }

                return Unit.Value;
                
            }
        }
    }
}
