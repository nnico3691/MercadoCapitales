using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MercadoCapitales.API.Clientes.Persistencia;
using MercadoCapitales.API.Clientes.Dto;
using Microsoft.EntityFrameworkCore;
using MercadoCapitales.API.Clientes.Modelo;

namespace MercadoCapitales.API.Clientes.Aplicacion
{
    public class ConsultaClientes
    {
        public class ListaClientes : IRequest<List<ClienteDto>> { }

        public class Manejador : IRequestHandler<ListaClientes, List<ClienteDto>>
        {
            private readonly ContextCliente _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextCliente contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<List<ClienteDto>> Handle(ListaClientes request, CancellationToken cancellationToken)
            {
                var lista = await _contexto.Cliente.ToListAsync();
                var listaDto = _mapper.Map<List<Cliente>, List<ClienteDto>>(lista);

                return listaDto;
            }
        }

    }
}
