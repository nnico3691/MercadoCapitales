using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using MercadoCapitales.API.Precios.Persistencia;
using MercadoCapitales.API.Precios.Modelo;

namespace MercadoCapitales.API.Precios.Aplicacion
{
    public class NuevoAccion
    {
        public class Ejecuta : IRequest
        {
            public string Ticker { get; set; }
            public float? Precio { get; set; }
            public float? VarPorcentual { get; set; }
            public float? PrecioA { get; set; }
            public float? CCompra { get; set; }
            public float? PCompra { get; set; }
            public float? PVenta { get; set; }
            public float? CVenta { get; set; }
            public float? Min { get; set; }
            public float? Max { get; set; }
            public string Ajuste { get; set; }
            public string VolNom { get; set; }
            public float? Monto { get; set; }
            public int? Oper { get; set; }
            public string Hora { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ContextPrecio _contexto;

            public Manejador(ContextPrecio contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var accion = new CotizacionAccion
                {
                    Ticker = request.Ticker,
                    Precio = request.Precio,
                    VarPorcentual = request.VarPorcentual,
                    PrecioA = request.PrecioA,
                    CCompra = request.CCompra,
                    PCompra = request.PCompra,
                    PVenta = request.PVenta,
                    CVenta = request.CVenta,
                    Min = request.Min,
                    Max = request.Max,
                    Ajuste = request.Ajuste,
                    VolNom = request.VolNom,
                    Monto = request.Monto,
                    Oper = request.Oper,
                    Hora = request.Hora

                };

                _contexto.CotizacionAccion.Add(accion);
                var value = await _contexto.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Errores en la inserción del carrito de compras");
                


            }
        }
    }
}
