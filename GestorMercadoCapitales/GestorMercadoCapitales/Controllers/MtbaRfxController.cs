using GestorMercadoCapitales.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GestorMercadoCapitales.Controllers
{
    public class MtbaRfxController : Controller
    {
        private IConfiguration _configuration;
        public MtbaRfxController(IConfiguration iconfig)
        {
            _configuration = iconfig;
        }

        public ActionResult Futuros_Financieros()
        {
            if (HttpContext.Session.GetString("Login") != "Logueado")
            {
                return RedirectToAction("Login", "Login");
            }



            int hora_actual = DateTime.Now.Hour;

            HorarioMercado hora = new HorarioMercado();

            try
            {
                hora.Horario_Mercado = int.Parse(_configuration.GetSection("HorarioMercado:hora").Value);

            }
            catch
            { hora.Horario_Mercado = 0; }

            if (hora_actual >= hora.Horario_Mercado)
            {
                //validamos primero que ya se ejecuto el socket
                //Luego, validamos que inicie solo cuando este logueado
                if (HttpContext.Session.GetString("Socket") != "Iniciado"
                    && HttpContext.Session.GetString("Login") == "Logueado")
                {
                    try
                    {
                        Socket socket = new Socket(_configuration);

                        ThreadPool.QueueUserWorkItem(socket.RunSocket, new object[] { });
                        HttpContext.Session.SetString("Socket", "Iniciado");
                    }
                    catch { }
                }
            }

            return View(RofexList.rfxlist);
        }


        public ActionResult opciones_financieras()
        {
            return View();
        }



        public ActionResult CompraInstrumento(string symbol, string precio, int cantidad)
        {
            Orden ordenParam = new Orden();
            ordenParam.Symbol = symbol;
            ordenParam.Quantity = cantidad;
            ordenParam.Price = decimal.Parse(precio.Replace(".", ","));
            ordenParam.Side = "Buy";

            string url = _configuration.GetSection("API:CrearOrden").Value;
            var json = JsonConvert.SerializeObject(ordenParam);

            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (HttpClient client = new HttpClient(clientHandler))
            {
                HttpResponseMessage response = client.PostAsync(url, stringContent).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {

                    var responseText = response.Content.ReadAsStringAsync().Result;
                    //responseDataLogin = JsonConvert.DeserializeObject<LoginResponse>(responseText);

                    // return RedirectToAction("Dashboard", "Home");
                }
                else
                {

                }

            }

            return View();
        }

        public ActionResult HistoricoOperaciones()
        {
            string url = _configuration.GetSection("API:GetOrderAll").Value;
            var parames = new Dictionary<string, string>();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var data = new List<OrderAll>();

            using (HttpClient client = new HttpClient(clientHandler))
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                var responseText = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<List<OrderAll>>(responseText);
            }


            return View(data);

        }
    }
}
