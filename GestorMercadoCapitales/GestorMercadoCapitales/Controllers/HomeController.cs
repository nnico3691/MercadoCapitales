using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GestorMercadoCapitales.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Primary.Data;
using Primary;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace GestorMercadoCapitales.Controllers
{
    public class HomeController : Controller
    {

        private IConfiguration _configuration;

        public HomeController(IConfiguration iconfig)
        {
            _configuration = iconfig;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("Login", "Inicio");
            return RedirectToAction("Login", "Login");
        }

        public IActionResult Inicio()
        {
            if (HttpContext.Session.GetString("Login") == "Logueado")
            {

                ViewData["Message"] = "Menu Principal";
                List<CotizacionAccion> cotizacionAccion = new List<CotizacionAccion>();

                cotizacionAccion = GetCotizaciones();


                return View(cotizacionAccion);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }

        public IActionResult Dashboard()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private List<CotizacionAccion> GetCotizaciones()
        {
            Socket Socket = new Socket(_configuration);
            try
            {
                ThreadPool.QueueUserWorkItem(Socket.RunSocket, new object[] { });
            }
            catch { }

            string url = "http://localhost:22684/api/Precio/GetPreciosAccion";
            var parames = new Dictionary<string, string>();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var data = new List<CotizacionAccion>();

            using (HttpClient client = new HttpClient(clientHandler))
            {
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("none"));

                //HttpResponseMessage response = client.PostAsync(url, new FormUrlEncodedContent(parames)).Result;
                HttpResponseMessage response = client.GetAsync(url).Result;
                var responseText = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<List<CotizacionAccion>>(responseText);
            }


            return data;

        }

      


    }
}
