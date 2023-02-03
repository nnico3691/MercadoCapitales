using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using MercadoCapitales.API.Clientes.Modelo;
using MercadoCapitales.API.Clientes.Persistencia;
using System.ComponentModel.DataAnnotations;

namespace MercadoCapitales.API.Clientes.Aplicacion
{
    public class CrearRegistro
    {
        public class Ejecuta : IRequest
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string TipoDNI { get; set; }
            public string DNI { get; set; }
            public string Telefono { get; set; }
            public string Usuario { get; set; }
            public string Clave { get; set; }
            public int IdCliente { get; set; }
            [EmailAddress]
            [Required]
            public string Email { get; set; }

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
                var cliente = new Cliente
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    TipoDNI = request.TipoDNI,
                    DNI = request.DNI,
                    Telefono = request.Telefono,
                    Email = request.Email

                    
                };

                _contexto.Cliente.Add(cliente);

                var value = await _contexto.SaveChangesAsync();

                var login = new Login
                {
                    Usuario = request.Usuario,
                    Clave = request.Clave,
                    Cliente = cliente.ClienteId
                };

                _contexto.Login.Add(login);

                value = await _contexto.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Errores en la inserción del Nuevo Cliente");



            }
        }
    }
}
