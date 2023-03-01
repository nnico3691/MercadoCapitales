using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using MercadoCapitales.API.Clientes.Modelo;
using MercadoCapitales.API.Clientes.Persistencia;

namespace MercadoCapitales.API.Clientes.Aplicacion
{
    public class CrearClienteEncuestas
    {
        public class Ejecuta : IRequest
        {
            public Guid? EncuestaRespuesta { get; set; }
            public string ClieKey { get; set; }

        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ContextCliente _contexto;

            public Manejador(ContextCliente contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var ce = new ClienteEncuestas
                {
                    EncuestaRespuesta = request.EncuestaRespuesta,
                    ClieKey = request.ClieKey

                };

                _contexto.ClienteEncuestas.Add(ce);

                var value = await _contexto.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Errores en la inserción de la Encuesta Pregunta");

            }
        }
    }
}
