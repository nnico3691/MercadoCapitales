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
using Newtonsoft.Json;

namespace GestorMercadoCapitales.Controllers
{
    public class LoginController : Controller
    {
        // GET: Index
        public ActionResult Index(string usuario, string clave)
        {

            DatosLogin datoslogin = new DatosLogin();

            datoslogin.Usuario = usuario.Trim();
            datoslogin.Clave = clave;

            string url = "http://localhost:51736/api/Cliente/Login";

            var json = JsonConvert.SerializeObject(datoslogin);

            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var data = new List<CotizacionAccion>();

            using (HttpClient client = new HttpClient(clientHandler))
            {
                HttpResponseMessage response = client.PostAsync(url, stringContent).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    HttpContext.Session.SetString("Login", "");
                    return View();
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
            datoCliente.Nombre = Nombre.Trim();
            datoCliente.Apellido = Apellido.Trim();
            datoCliente.Usuario = DNI.Trim();
            datoCliente.Telefono = Telefono.Trim();
            datoCliente.Clave = clave.Trim();

            string url = "http://localhost:51736/api/Cliente/CrearRegistro";

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

    }
}