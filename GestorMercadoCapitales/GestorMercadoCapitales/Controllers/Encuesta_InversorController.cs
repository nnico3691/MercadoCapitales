using GestorMercadoCapitales.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace GestorMercadoCapitales.Controllers
{
    public class Encuesta_InversorController : Controller
    {

        private IConfiguration _configuration;

        public Encuesta_InversorController(IConfiguration iconfig)
        {
            _configuration = iconfig;
        }


        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("Login") == "Logueado")
            {
                List<EncuestaPreguntas> encuestaPreguntas = new List<EncuestaPreguntas>();
                encuestaPreguntas = ConsultaEncuestaApi();
                EncuestaPreguntas mensajeEncuesta = new EncuestaPreguntas();

                if (HttpContext.Session.GetString("ErrorEncuesta") == "Error")
                {
                    var mens = TipoMensaje.ObtenerTipoMensaje("ErrEncuesta");

                    mensajeEncuesta.MensajeRetorno.cod_mensaje = mens.cod_mensaje;
                    mensajeEncuesta.MensajeRetorno.mensaje = mens.mensaje;
                    encuestaPreguntas.Add(mensajeEncuesta);
                }

                return View(encuestaPreguntas);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public ActionResult Resultado(RequetsParamEncuesta req)
        {
            req.ClienteId = Guid.Parse(HttpContext.Session.GetString("ClienteId"));

            string url = "http://localhost:51736/api/Cliente/CrearClientePerfilInversor";

            var json = JsonConvert.SerializeObject(req);

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

                    return View();
                }
                else
                {
                    HttpContext.Session.SetString("ErrorEncuesta", "Error");
                    return RedirectToAction("Index", "Encuesta_Inversor");
                }

            }

        }


        private List<EncuestaPreguntas> ConsultaEncuestaApi()
        {
         
            string url = "http://localhost:51736/api/Cliente/GetEncuestaPreguntasRespuestas";
            var parames = new Dictionary<string, string>();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var data = new List<EncuestaPreguntas>();

            using (HttpClient client = new HttpClient(clientHandler))
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                var responseText = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<List<EncuestaPreguntas>>(responseText);
            }


            return data;

        }

    }
}
