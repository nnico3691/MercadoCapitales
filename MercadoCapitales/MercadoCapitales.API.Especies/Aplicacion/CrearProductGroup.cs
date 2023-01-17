using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MercadoCapitales.API.Especies.Persistencia;
using Primary;
using Newtonsoft.Json;
using MercadoCapitales.API.Especies.Modelo;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MercadoCapitales.API.Especies.Aplicacion.Requests;

namespace MercadoCapitales.API.Especies.Aplicacion
{
    public class CrearProductGroup
    {
        public class Ejecuta : IRequest 
        {
            public List<ProductGroupRequest> Lista { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ContextEspecie _contexto;
         
            public Manejador(ContextEspecie contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                foreach (var i in request.Lista) 
                {
                    var productGroup = new ProductGroup 
                    {
                        Descripcion = i.Descripcion,
                        Mercado = i.Mercado,
                    };

                    _contexto.ProductGroup.Add(productGroup);
                }

                var value = await _contexto.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Errores en la inserción del ProductGroup");

            }


        }
    }
}
