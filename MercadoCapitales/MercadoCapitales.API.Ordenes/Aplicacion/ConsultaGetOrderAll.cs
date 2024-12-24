using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using static Primary.Api;
using MercadoCapitales.API.Ordenes.Persistencia;
using Primary;
using Primary.Data;
using Primary.Data.Orders;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using MercadoCapitales.API.Ordenes.Dto;
using MercadoCapitales.API.Ordenes.Modelo;

namespace MercadoCapitales.API.Ordenes.Aplicacion
{
    public class ConsultaGetOrderAll
    {
        public class ListaOrdenes : IRequest<List<OrderDto>> { }

        public class Manejador : IRequestHandler<ListaOrdenes, List<OrderDto>>
        {
            private readonly ContextOrden _contexto;

            public Manejador(ContextOrden contexto)
            {
                _contexto = contexto;
            }
            public async Task<List<OrderDto>> Handle(ListaOrdenes request, CancellationToken cancellationToken)
            {
                try
                {
                    var api = new Api(Api.DemoEndpoint);
                    await api.Login(Api.DemoUsername, Api.DemoPassword);

                    Account account = new Account
                    {
                        accountId = Api.DemoAccount
                    };

                    var result = await api.GetOrderAll(account);

                    var Ordenes = result.Orders;

                    var OrderBdIds = await _contexto.Orden
                        .Select(o => new { o.ClientOrderId, o.Id })
                        .ToListAsync(cancellationToken);

                    // Construir la lista de OrdenFiltrada uniendo OrderBdIds y Ordenes por ClientOrderId
                    var ordenesFiltradas = (from order in Ordenes
                                            join orderBd in OrderBdIds on order.ClientOrderId equals orderBd.ClientOrderId
                                            select new OrdenFiltrada
                                            {
                                                OrderStatus = order, // Asignar el objeto OrderStatus
                                                OrdenId = orderBd.Id // Asignar el Id correspondiente
                                            })
                                            .ToList();


                    // Obtener los OrdenId y sus estados existentes en _context.StatusOrder
                    var statusOrders = await _contexto.OrderStatus
                        .Select(os => new { os.OrdenId, os.Status, os.StatusText }) // Asegúrate de que estas propiedades sean correctas
                        .ToListAsync(cancellationToken);

                    // Filtrar las órdenes que no existen en StatusOrder y prepararlas para la inserción
                    var filteredOrdenes = ordenesFiltradas
                        .Where(of => !statusOrders.Any(so => so.OrdenId == of.OrdenId && so.Status == of.OrderStatus.Status))
                        .ToList();

                    // Configurar el mapeador
                    var configuration = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
                    var mapper = configuration.CreateMapper();

                    var orderStatuses = mapper.Map<List<Modelo.OrderStatus>>(filteredOrdenes);

                    // Agregar los objetos mapeados al contexto y guardar cambios
                    await _contexto.OrderStatus.AddRangeAsync(orderStatuses);
                    await _contexto.SaveChangesAsync(cancellationToken); // Guardar 

                    // Obtener las órdenes junto con sus estados desde el contexto
                    var newOrders = await _contexto.Orden
                        .Where(o => _contexto.OrderStatus.Select(os => os.OrdenId).Contains(o.Id)) // Filtrar por los IDs de las órdenes agregadas
                        .Include(o => o.StatusHistory) // Incluir el historial de estados
                        .Include(o => o.InstrumentId) 
                        .ToListAsync(cancellationToken);

                    // Mapear las órdenes y sus estados a DTOs antes de retornar
                    var orderDtos = newOrders.Select(os => new OrderDto
                    {
                        Id = os.Id,
                        Proprietary = os.Proprietary,
                        ClientOrderId = os.ClientOrderId,
                        CancelPrevious = os.CancelPrevious,
                        Iceberg = os.Iceberg,
                        DisplayQuantity = os.DisplayQuantity,
                        InstrumentId = new InstrumentDto 
                        {
                            Id = os.InstrumentId.Id,
                            Market = os.InstrumentId.Market,
                            Symbol = os.InstrumentId.Symbol,
                        
                        },
                        Price = os.Price,
                        Quantity = os.Quantity,
                        Type = os.Type,
                        Side = os.Side,
                        Expiration = os.Expiration,
                        ExpirationDate = os.ExpirationDate,
                        StatusHistory = os.StatusHistory.Select(s => new OrderStatusDto
                        {
                            Id = s.Id,
                            Account = s.Account,
                            ExecutionId = s.ExecutionId,
                            TransactionTime = s.TransactionTime,
                            AveragePrice = s.AveragePrice,
                            LastPrice = s.LastPrice,
                            LastQuantity = s.LastQuantity,
                            CumulativeQuantity = s.CumulativeQuantity,
                            LeavesQuantity = s.LeavesQuantity,
                            Status = s.Status,
                            StatusText = s.StatusText
                        }).ToList()
                    }).ToList();

                    return orderDtos; // Retornar solo los nuevos estados 

                }
                catch (DbUpdateException dbEx)
                {
                    // Manejar excepciones relacionadas con la base de datos
                    // Por ejemplo, puedes registrar el error o lanzar una excepción personalizada
                    throw new Exception("Error al actualizar la base de datos: " + dbEx.Message, dbEx);
                }
                catch (Exception ex)
                {
                    // Manejar otras excepciones generales
                    throw new Exception("Ocurrió un error inesperado: " + ex.Message, ex);
                }
            }

        }

        public class OrdenFiltrada
        {
            public Primary.Data.Orders.OrderStatus OrderStatus { get; set; }
            public Guid OrdenId { get; set; }
            // Agrega aquí otras propiedades relevantes de OrderStatus si es necesario
        }
    }
}
