using MediatR;
using MercadoCapitales.API.Precios.Models;
using MercadoCapitales.API.Precios.Persistencia;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Model = MercadoCapitales.API.Precios.Models;
using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MercadoCapitales.API.Precios.Services;

namespace MercadoCapitales.API.Precios.Aplicacion.MarketData.Commands
{
    public class CreateMarketDataCommandHandler : IRequestHandler<CreateMarketDataCommand, Guid>
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly IInstrumentService _instrumentService;

        public CreateMarketDataCommandHandler(Context context, IMapper mapper, IInstrumentService instrumentService)
        {
            _context = context;
            _mapper = mapper;
            _instrumentService = instrumentService;
        }
        public async Task<Guid> Handle(CreateMarketDataCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var marketData = _mapper.Map<Model.MarketData>(request.MarketData);
                marketData.Date = DateTime.Today;

                marketData.CreatedAt = DateTime.Now;
                marketData.CreatedBy = "AUT";

                _context.MarketData.Add(marketData);
                var Instrumentos = await _instrumentService.GetAllInstrumentsAsync();

                // Configura las claves foráneas y establece el índice para Bid
                if (marketData.BI != null)
                {
                    for (int i = 0; i < marketData.BI.Count; i++)
                    {
                        var bo = marketData.BI[i];
                        bo.MarketData = marketData;
                        bo.Index = i; // Establecer el índice basado en la posición
                        _context.Bid.Add(bo);
                    }
                }

                // Configura las claves foráneas y establece el índice para Offer
                if (marketData.OF != null)
                {
                    for (int i = 0; i < marketData.OF.Count; i++)
                    {
                        var of = marketData.OF[i];
                        of.MarketData = marketData;
                        of.Index = i; // Establecer el índice basado en la posición
                        _context.Offer.Add(of);
                    }
                }

                if (marketData.OI != null)
                {
                    marketData.OI.MarketData = marketData;
                    _context.OpenInterests.Add(marketData.OI);
                }

                if (marketData.SE != null)
                {
                    marketData.SE.MarketData = marketData;
                    _context.Settlements.Add(marketData.SE);
                }

                if (marketData.LA != null)
                {
                    marketData.LA.MarketData = marketData;
                    _context.LastPrice.Add(marketData.LA);
                }

                await _context.SaveChangesAsync(cancellationToken);
                return marketData.Id;
            }
            catch (DbUpdateException ex)
            {
                // Manejo específico para errores de actualización en la base de datos
                // Aquí puedes registrar el error, lanzar una excepción personalizada, etc.
                Console.WriteLine($"Error al actualizar la base de datos: {ex.Message}");
                throw; // Vuelve a lanzar la excepción si es necesario
            }
            catch (Exception ex)
            {
                // Manejo general de excepciones
                Console.WriteLine($"Se produjo un error: {ex.Message}");
                throw; // Vuelve a lanzar la excepción si es necesario
            }
        }

    }
}
