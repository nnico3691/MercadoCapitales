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
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity;
using System.Net;
using MercadoCapitales.API.Clientes.Services;

namespace MercadoCapitales.API.Clientes.Aplicacion
{
    public class Recovery
    {
        public class Ejecuta : IRequest<string> 
        {
            public string Token { get; set; }
            public string Email { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, string>
        {

            private readonly ContextCliente _contexto;

            public Manejador(ContextCliente contexto)
            {
                _contexto = contexto;
            }
            public async Task<string> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                try
                {
                    var oUser = _contexto.Cliente.Where(x => x.Email == request.Email).ToList().FirstOrDefault();
                    var oLogin= _contexto.Login.Where(x => x.Cliente == oUser.ClienteId).ToList().FirstOrDefault();

                    oLogin.Clave = Password.GenerarPassword(16);

                    _contexto.Update(oLogin);
                    _contexto.SaveChanges();

                    return "Sistma Mercado de Capitales - Contraseña Autogerada es: " + oLogin.Clave;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ha ocurrido un error al intentar Autenticar el Email del Usuario : " + ex.Message);
                }

                throw new Exception("Error en la Auenticación del Email");

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

            private void SendEmail(MailRequest mail)
            {
               



            }    

        }
    }

    public static class Password
    {
        public static string GenerarPassword(int longitud)
        {
            string contraseña = string.Empty;
            string[] letras = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "ñ", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
            Random EleccionAleatoria = new Random();

            for (int i = 0; i < longitud; i++)
            {
                int LetraAleatoria = EleccionAleatoria.Next(0, 100);
                int NumeroAleatorio = EleccionAleatoria.Next(0, 9);

                if (LetraAleatoria < letras.Length)
                {
                    contraseña += letras[LetraAleatoria];
                }
                else
                {
                    contraseña += NumeroAleatorio.ToString();
                }
            }
            return contraseña;
        }
    }
}
