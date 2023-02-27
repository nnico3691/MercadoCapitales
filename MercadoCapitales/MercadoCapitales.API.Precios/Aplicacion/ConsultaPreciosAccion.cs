using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MercadoCapitales.API.Precios.Dto;
using MercadoCapitales.API.Precios.Modelo;
using MercadoCapitales.API.Precios.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace MercadoCapitales.API.Precios.Aplicacion
{
    public class ConsultaPreciosAccion
    {
        public class ListaCotizacionAccion : IRequest<List<CotizacionAccionDto>> { }

        public class Manejador : IRequestHandler<ListaCotizacionAccion, List<CotizacionAccionDto>>
        {
            private readonly ContextPrecio _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextPrecio contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<List<CotizacionAccionDto>> Handle(ListaCotizacionAccion request, CancellationToken cancellationToken)
            {
                var lista = await _contexto.CotizacionAccion.ToListAsync();
                var listaDto = _mapper.Map<List<CotizacionAccion>, List<CotizacionAccionDto>>(lista);

                return listaDto;
            }
        }
    }
}
