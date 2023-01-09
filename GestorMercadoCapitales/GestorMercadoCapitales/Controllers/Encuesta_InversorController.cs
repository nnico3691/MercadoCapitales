using GestorMercadoCapitales.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
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
            List<EncuestaPreguntas> encuestaPreguntas = new List<EncuestaPreguntas>();
            encuestaPreguntas = ConsultaEncuestaApi();
            return View(encuestaPreguntas);
        }

        public ActionResult Resultado(RequetsParamEncuesta req)
        {
            //req.ClienteId = "81306C64-74FD-46D9-4F82-08DAF23F840F";
            var data = JsonConvert.SerializeObject(req);
            return View();
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
