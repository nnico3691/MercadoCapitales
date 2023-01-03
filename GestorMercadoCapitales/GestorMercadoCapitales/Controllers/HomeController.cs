﻿using System;
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

namespace GestorMercadoCapitales.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            HttpContext.Session.SetString("Login", "Inicio");
            return RedirectToAction("Login", "Login");
        }

        public IActionResult Inicio()
        {
            if (HttpContext.Session.GetString("Login") != "Inicio")
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
