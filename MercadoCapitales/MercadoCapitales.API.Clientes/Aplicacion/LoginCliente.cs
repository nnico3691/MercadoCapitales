using MediatR;
using MercadoCapitales.API.Clientes.Modelo;
using MercadoCapitales.API.Clientes.Persistencia;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Linq;
using MercadoCapitales.API.Clientes.Dto;

namespace MercadoCapitales.API.Clientes.Aplicacion
{
    public class LoginCliente
    {
        public class Ejecuta : IRequest<Login>
        {
            public string Usuario { get; set; }
            public string Clave { get; set; }

        }

        public class Manejador : IRequestHandler<Ejecuta,Login>
        {
            private readonly ContextCliente _contexto;

            public Manejador(ContextCliente contexto)
            {
                _contexto = contexto;
            }

            public async Task<Login> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                try
                {
                    var usuario = _contexto.Login.Where(x => request.Usuario == x.Usuario && request.Clave == x.Clave).FirstOrDefault();

                    if (usuario != null)
                        return usuario;

                }
                catch(Exception ex)
                {
                    throw new Exception("Ha ocurrido un error al intentar loguearse: " + ex.Message);
                }


                throw new Exception("Error en el Login");



            }
        }
    }
}
