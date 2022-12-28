using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using MercadoCapitales.API.Ordenes.Persistencia;
using MercadoCapitales.API.Ordenes.Modelo;
using System.Numerics;

namespace MercadoCapitales.API.Ordenes.Aplicacion
{
    public class CrearOrden
    {
        public class Ejecuta : IRequest
        {
            public string OrdenCodigo { get; set; } /*BYMA, FCI, LICITACIONES, ROFEX, CAUCION*/
            public string TipoCompraVenta { get; set; } /*COMPRA, VENTA*/

            /*COMITENTE - CLIENTE*/
            public string Comitente { get; set; }
            public string Cliente { get; set; }
            public int ComitenteId { get; set; }
            public int ClienteId { get; set; }
            public string Ticker { get; set; }
            public float Cantidad { get; set; }
            public string TipoDeOrden { get; set; } /*Limite, Stop con limite*/
            public float Precio { get; set; }
            public float Importe { get; set; }
            public int ValidezOferta { get; set; } /* 0- Hasta el día 1- Hasta Cancelar */
            public DateTime? FechaVencimiento { get; set; }
            public int Plazo { get; set; } /*48 hs - C.I*/
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ContextOrden _contexto;

            public Manejador(ContextOrden contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var orden = new Orden
                {
                    OrdenCodigo = request.OrdenCodigo,
                    TipoCompraVenta = request.TipoCompraVenta,
                    Comitente = request.Comitente,
                    ClienteId = request.ClienteId,
                    Cliente = request.Cliente,
                    ComitenteId = request.ComitenteId,
                    Ticker = request.Ticker,
                    Cantidad = request.Cantidad,
                    TipoDeOrden = request.TipoDeOrden,
                    Precio = request.Precio,
                    Importe = request.Importe,
                    ValidezOferta = request.ValidezOferta,
                    FechaVencimiento = request.FechaVencimiento,
                    Plazo = request.Plazo,
                };

                _contexto.Orden.Add(orden);
                var value = await _contexto.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Errores en la inserción de la Orden");



            }
        }

    }
}
