using GestorMercadoCapitales.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
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


            if (1 == 0)
            {
                int hora_actual = DateTime.Now.Hour;

                HorarioMercado hora = new HorarioMercado();

                try
                {
                    hora.Horario_Mercado = int.Parse(_configuration.GetSection("HorarioMercado:hora").Value);

                }
                catch
                { hora.Horario_Mercado = 0; }

                if (hora.Horario_Mercado >= hora_actual)
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
            }

            var data = GetFuturoFinanciero();



            return View(data);
        }

        private List<MtbaRfx> GetFuturoFinanciero()
        {
           
            string url = _configuration.GetSection("API:Instrumentos").Value;
            var parames = new Dictionary<string, string>();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var data = new List<MtbaRfx>();

            using (HttpClient client = new HttpClient(clientHandler))
            {
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("none"));

                //HttpResponseMessage response = client.PostAsync(url, new FormUrlEncodedContent(parames)).Result;
                HttpResponseMessage response = client.GetAsync(url).Result;
                var responseText = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<List<MtbaRfx>>(responseText);
            }


            return data;

        }



        public ActionResult opciones_financieras()
        {
            return View();
        }


    }
}
