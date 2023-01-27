using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GestorMercadoCapitales.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace GestorMercadoCapitales.Controllers
{
    public class LoginController : Controller
    {

        private IConfiguration _configuration;

        public LoginController(IConfiguration iconfig)
        {
            _configuration = iconfig;
        }


        // GET: Index
        public ActionResult Index(string usuario, string clave)
        {

            DatosLogin datoslogin = new DatosLogin();

            datoslogin.Usuario = usuario.Trim();
            datoslogin.Clave = clave;

            string url = _configuration.GetSection("API:Login").Value;

            var json = JsonConvert.SerializeObject(datoslogin);

            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var data = new List<CotizacionAccion>();
            var responseDataLogin = new LoginResponse();

            using (HttpClient client = new HttpClient(clientHandler))
            {
                HttpResponseMessage response = client.PostAsync(url, stringContent).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    HttpContext.Session.SetString("Login", "Logueado");
                    var responseText = response.Content.ReadAsStringAsync().Result;
                    responseDataLogin = JsonConvert.DeserializeObject<LoginResponse>(responseText);

                    HttpContext.Session.SetString("ClienteId", responseDataLogin.cliente.ToString());
                    HttpContext.Session.SetString("Usuario", responseDataLogin.usuario.ToString().ToUpper().Trim());

                    return RedirectToAction("Dashboard","Home");
                }
                else
                {

                    HttpContext.Session.SetString("Login", "ErrLogin");
                    
                    
                    return RedirectToAction("Login", "Login");

                }
                
            }

        }

        // GET: Login
        public ActionResult Login()
        {
            MensajeRetorno mensaje = new MensajeRetorno();

            if (HttpContext.Session.GetString("Login") == "ErrLogin")
            {
                mensaje = TipoMensaje.ObtenerTipoMensaje("ErrLogin");
            }


            return View(mensaje);
        }

        public ActionResult Registrarme()
        {
            return View();
        }

        public ActionResult Confirmacion(string DNI, string Nombre, string Apellido, string Telefono, string clave)
        {
            DatosCliente datoCliente = new DatosCliente();

            datoCliente.TipoDNI = "DNI";
            datoCliente.DNI = DNI.Trim();
            datoCliente.Nombre = Nombre.Trim();
            datoCliente.Apellido = Apellido.Trim();
            datoCliente.Usuario = DNI.Trim();
            datoCliente.Telefono = Telefono.Trim();
            datoCliente.Clave = clave.Trim();

            string url = _configuration.GetSection("API:Registrarme").Value;

            var json = JsonConvert.SerializeObject(datoCliente);

            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var data = new List<CotizacionAccion>();

            using (HttpClient client = new HttpClient(clientHandler))
            {
               HttpResponseMessage response = client.PostAsync(url, stringContent).Result;
               var responseText = response.Content.ReadAsStringAsync().Result;
            }



            return View(datoCliente);
           
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }

        public ActionResult OlvideClave()
        {
            return View();
        }



        public ActionResult ConfirmaClave(string clave_anterior, string clave_nueva)
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }

    }
}