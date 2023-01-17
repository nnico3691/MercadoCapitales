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
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
             
                foreach (var instrumento in allIInstruments) 
                {
                    var i = new Instrumento
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
                        FechaAlta = DateTime.Now

                    };

                    _contexto.Instrumento.Add(i);
                    var value = await _contexto.SaveChangesAsync();

                    if (value <= 0)
                    {
                        throw new Exception("Errores en la inserción del Nuevos Instrumentos.");
                    }

                    foreach (var item in instrumento.orderTypes) 
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

                    foreach (var item in instrumento.timesInForce)
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
