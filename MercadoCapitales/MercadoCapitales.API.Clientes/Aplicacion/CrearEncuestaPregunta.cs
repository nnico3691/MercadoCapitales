using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using MercadoCapitales.API.Clientes.Modelo;
using MercadoCapitales.API.Clientes.Persistencia;
using System.Collections.Generic;
using MercadoCapitales.API.Clientes.Aplicacion.Requests;

namespace MercadoCapitales.API.Clientes.Aplicacion
{
    public class CrearEncuestaPregunta
    {
        public class Ejecuta : IRequest
        {
            public List<EncuestaPreguntaRequest> ListadoPreguntasRespuestas { get; set; }

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

                foreach (var ob in request.ListadoPreguntasRespuestas) 
                {
                    var ep = new EncuestaPregunta
                    {
                        Titulo = ob.Titulo,
                        Pregunta = ob.Pregunta

                    };

                    _contexto.EncuestaPregunta.Add(ep);
                    await _contexto.SaveChangesAsync();

                    foreach (var subob in ob.ListaRespuesta)
                    {
                        var er = new EncuestaRespuesta 
                        {
                            Respuesta = subob.Respuesta,
                            Puntos = subob.Puntos,
                            NameInput = subob.NameInput,
                            TipoInput = subob.TipoInput ,
                            EncuestaPreguntaId = ep.EncuestaPreguntaId
                        };

                        _contexto.EncuestaRespuesta.Add(er);
                    }
                }

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
