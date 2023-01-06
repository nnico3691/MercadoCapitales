using AutoMapper;
using MediatR;
using MercadoCapitales.API.Clientes.Dto;
using MercadoCapitales.API.Clientes.Modelo;
using MercadoCapitales.API.Clientes.Persistencia;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MercadoCapitales.API.Clientes.Aplicacion
{
    public class ConsultaEncuestaPreguntasRespuestas
    {
        public class ListaEncuestaPreguntasRespuestas : IRequest<List<EncuestaPreguntaDto>> { }

        public class Manejador : IRequestHandler<ListaEncuestaPreguntasRespuestas, List<EncuestaPreguntaDto>>
        {
            private readonly ContextCliente _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextCliente contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<List<EncuestaPreguntaDto>> Handle(ListaEncuestaPreguntasRespuestas request, CancellationToken cancellationToken)
            {
                var listaPregunta = await _contexto.EncuestaPregunta.ToListAsync();
                var listaRespuesta = await _contexto.EncuestaRespuesta.ToListAsync();

                var listaEncuestaPreguntaDTO = new List<EncuestaPreguntaDto>();

                foreach (var item in listaPregunta) 
                {
                    var encuestaPreguntaDTO = new EncuestaPreguntaDto
                    {
                        EncuestaPreguntaId = item.EncuestaPreguntaId,
                        Titulo = item.Titulo,
                        Pregunta = item.Pregunta,
                        encuestaRespuestas = listaRespuesta.Where(x=> x.EncuestaPreguntaId == item.EncuestaPreguntaId).ToList(),
                    };

                    listaEncuestaPreguntaDTO.Add(encuestaPreguntaDTO);
                }

                return listaEncuestaPreguntaDTO;
            }
        }
    }
}
