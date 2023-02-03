using MediatR;
using MercadoCapitales.API.Clientes.Aplicacion.Requests;
using MercadoCapitales.API.Clientes.Modelo;
using MercadoCapitales.API.Clientes.Persistencia;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Primitives;

namespace MercadoCapitales.API.Clientes.Aplicacion
{
    public class StartRecovery
    {
        public class Ejecuta : IRequest<Login>
        {
            public StartRecoveryRequest StartRecoveryRequest { get; set; }

        }

        public class Manejador : IRequestHandler<Ejecuta, Login>
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
                    /*HAY QUE HACER EL AUTOMAPPER VER EJEMPLO*/

                    string token = GetSha256(Guid.NewGuid().ToString());

                }
                catch (Exception ex)
                {
                    throw new Exception("Ha ocurrido un error al intentar loguearse: " + ex.Message);
                }


                throw new Exception("Error en el Login");



            }

            #region HELPERS
            private string GetSha256(string str) 
            {
                SHA256 sha256 = SHA256Managed.Create();
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] stream = null;
                StringBuilder sb = new StringBuilder(); 
                stream = sha256.ComputeHash(Encoding.UTF8.GetBytes(str));

                for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
                return sb.ToString();
            
            }
            #endregion
        }
    }
}
