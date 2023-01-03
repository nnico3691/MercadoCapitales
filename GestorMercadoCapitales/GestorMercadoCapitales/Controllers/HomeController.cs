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

            try
            {
                ThreadPool.QueueUserWorkItem(RunSocket, new object[] { });
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

        private static async void RunSocket(object state)
        {
            Console.WriteLine("Connecting to ReMarkets...");

            var api = new Api(Api.DemoEndpoint);
            await api.Login(Api.DemoUsername, Api.DemoPassword);

            // Get a all dollar futures
            Console.WriteLine("Getting available instruments...");

            var allIInstruments = await api.GetAllInstruments();

            var symbols = new[]
            {
                "DLR/ENE23",
                "ORO/ENE23",
                "ORO/MAR23",
                "ORO/MAY23",
                "YPFD/FEB23",
                "RFX20/FEB23",
                "GGAL/FEB23",
                "WTI/ENE23",
                "WTI/MAR23",
                "WTI/MAY23"


            };
            var dollarFuture = allIInstruments.Where(c => symbols.Contains(c.Symbol));

            // Subscribe to bids and offers
            var entries = new[] { Entry.Offers, Entry.Close, Entry.EffectiveVolume, Entry.NominalVolume, Entry.Bids };

            Console.WriteLine("Connecting to market data...");

            var socket = api.CreateMarketDataSocket(dollarFuture, entries, 1, 2);
            socket.OnData = OnMarketData;

            Console.WriteLine("Start Socket...");

            var socketTask = await socket.Start();

            socketTask.Wait();
            await socketTask;


        }
        private static void OnMarketData(Api api, MarketData marketData)
        {
            try
            {
                var bid = default(decimal);
                var offer = default(decimal);

                var bidSize = default(decimal);
                var offerSize = default(decimal);

                var nominalVolume = default(decimal?);

                foreach (var trade in marketData.Data.Bids)
                {
                    bid = trade.Price;
                    bidSize = trade.Size;
                }

                foreach (var trade in marketData.Data.Offers)
                {
                    offer = trade.Price;
                    offerSize = trade.Size;
                }

                nominalVolume = marketData.Data.NominalVolume;

                if (bid > 0 || offer > 0)
                    Console.WriteLine($"({marketData.Timestamp}) " +
                                      $"{marketData.InstrumentId.Symbol} -> " +
                                      $"Vol.C: {bidSize} ; Compra: {bid} ; Venta: {offer} ; Vol.V: {offerSize}; Vol. Operado: nominalVolume;"
                    );

            }
            catch { }

        }


    }
}
