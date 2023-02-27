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
    public class StartRecovery
    {
        public class Ejecuta : IRequest<Unit>
        {

            [EmailAddress]
            [Required]
            public string Email { get; set; }

        }

        public class Manejador : IRequestHandler<Ejecuta, Unit>
        {
            private readonly ContextCliente _contexto;
            private readonly IEmailSenderService _emailSenderService;

            public Manejador(ContextCliente contexto, IEmailSenderService emailSenderService)
            {
                _contexto = contexto;
                _emailSenderService = emailSenderService;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                try
                {
                    /*HAY QUE HACER EL AUTOMAPPER VER EJEMPLO*/

                    string token = GetSha256(Guid.NewGuid().ToString());

                    var oUser = _contexto.Cliente.Where(x => x.Email == request.Email).ToList().FirstOrDefault();
                    if (oUser != null) 
                    {
                        oUser.TokenRecovery = token;
                        _contexto.Update(oUser);
                        _contexto.SaveChanges();

                        string urlDomain = "http://localhost:51736/api/Cliente/Recovery?token=" + token + "&email=" + request.Email;

                        /*ENVIAR EMAIL*/
                        MailRequest mail = new MailRequest 
                        {
                            Email = request.Email,
                            Subject = "Mercado Capitales - Recupero Contraseña",
                            Body = "<p> Correo para recuperación de Contraseña</p><br>" + "<a href='" + urlDomain + "'>Click para recuperar</a>"
                        };
                        
                        await _emailSenderService.SenderEmailAsync(mail);


                    }

                    return Unit.Value;

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
}
