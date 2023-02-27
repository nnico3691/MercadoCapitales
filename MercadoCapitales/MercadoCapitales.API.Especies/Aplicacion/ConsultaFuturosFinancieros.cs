using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MercadoCapitales.API.Especies.Persistencia;
using MercadoCapitales.API.Especies.Modelo;
using Microsoft.EntityFrameworkCore;
using MercadoCapitales.API.Especies.Aplicacion.Dto;
using System.Linq;

namespace MercadoCapitales.API.Especies.Aplicacion
{
    public class ConsultaFuturosFinancieros
    {
        public class ListaInstrumentos : IRequest<List<InstrumentoDto>> { }

        public class Manejador : IRequestHandler<ListaInstrumentos, List<InstrumentoDto>>
        {
            private readonly ContextEspecie _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextEspecie contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<List<InstrumentoDto>> Handle(ListaInstrumentos request, CancellationToken cancellationToken)
            {
                var lista = await _contexto.Instrumento.Where(x => (x.cficode == "FXXXXX" || x.cficode == "FXXXSX") && (x.MarketSegmentId == "DDF" || x.MarketSegmentId == "DUAL")).OrderBy(x=> x.Symbol).ToListAsync();
                var listaDto = _mapper.Map<List<Instrumento>, List<InstrumentoDto>>(lista);

                return listaDto;
            }
        }
    }
}
