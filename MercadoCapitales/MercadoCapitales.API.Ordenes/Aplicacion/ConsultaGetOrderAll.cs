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

namespace MercadoCapitales.API.Ordenes.Aplicacion
{
    public class ConsultaGetOrderAll
    {
        public class ListaOrdenes : IRequest<List<OrderStatus>> { }

        public class Manejador : IRequestHandler<ListaOrdenes, List<OrderStatus>>
        {
            private readonly ContextOrden _contexto;

            public Manejador(ContextOrden contexto)
            {
                _contexto = contexto;
            }
            public async Task<List<OrderStatus>> Handle(ListaOrdenes request, CancellationToken cancellationToken)
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


                    /*
                        // Configurar el mapeador
                    var configuration = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
                    var mapper = configuration.CreateMapper();

                    var order = mapper.Map<List<Modelo.Orden>>(result.Orders);
                    var orderStatuses = mapper.Map<List<Modelo.OrderStatus>>(result.Orders);

                    // Suponiendo que 'order' es una lista de 'Modelo.Orden' que has mapeado
                    var clientOrderIds = order.Select(o => o.ClientOrderId).ToList();

                    // Filtrar las órdenes en el contexto que coinciden con los ClientOrderId
                    var filteredOrders = await _contexto.Orden
                        .Where(o => clientOrderIds.Contains(o.ClientOrderId))
                        .ToListAsync(cancellationToken); 
                     */

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
                        .Where(of => !statusOrders.Any(so => so.OrdenId == of.OrdenId && so.StatusText == of.OrderStatus.StatusText))
                        .ToList();

                    // Configurar el mapeador
                    var configuration = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
                    var mapper = configuration.CreateMapper();

                    // Obtener solo la lista de Primary.Data.Orders.OrderStatus
                    //var orderStatusesPrimary = filteredOrdenes.Select(of => of.OrderStatus).ToList();


                    var orderStatuses = mapper.Map<List<Modelo.OrderStatus>>(filteredOrdenes);

                    // Agregar los objetos mapeados al contexto y guardar cambios
                    await _contexto.OrderStatus.AddRangeAsync(orderStatuses);
                    await _contexto.SaveChangesAsync(cancellationToken); // Guardar 

                    return result.Orders; // Retornar solo los nuevos estados agregados
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
