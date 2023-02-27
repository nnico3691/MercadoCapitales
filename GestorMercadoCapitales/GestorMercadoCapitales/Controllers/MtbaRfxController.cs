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

            List<MtbaRfx> ListmtbaRfx = new List<MtbaRfx>();
            MtbaRfx mtbaRfx = new MtbaRfx();

            if (HttpContext.Session.GetString("Socket") != "Iniciado"
                   && HttpContext.Session.GetString("Login") == "Logueado")
            {
                var datasymbols = new List<PanelFuturoFinancieros>();
                datasymbols = GetPanelFuturoFinancieros();

                if (datasymbols.Count == 0)
                {
                    return View(RofexList.rfxlist);
                }

                string[] symbols = new string[datasymbols.Count];
                int indice = 0;
                RofexList.rfxlist = new List<MtbaRfx>();

                PanelInferiorInstrumentos.Instrumentos = symbols;

                foreach (var insymbols in datasymbols)
                {
                    mtbaRfx = new MtbaRfx();    
                    symbols[indice] = insymbols.symbol.ToString();
                    mtbaRfx.Instrumento = symbols[indice];
                    indice = indice + 1;

                    RofexList.rfxlist.Add(mtbaRfx);
                }

                //carga de precios consultando al mercado directamente
                ActualizaPrecios();

            }

            return View(RofexList.rfxlist);
        }

        public void ActualizaPrecios()
        {

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

                RofexList.LimpiarMensaje();
            }
            else
            {
                var mens = TipoMensaje.ObtenerTipoMensaje("ErrHorarioMercado");
                RofexList.rfxlist[0].cod_mensaje = mens.cod_mensaje;
                RofexList.rfxlist[0].mensaje = mens.mensaje + " " + hora.Horario_Mercado + " am";
            }

        }


        public ActionResult opciones_financieras()
        {
            return View();
        }


        public ActionResult CompraInstrumento(string symbol, string precio, int cantidad,string TipoOp)
        {

            try
            {

                if (decimal.Parse(precio) <= 0 || cantidad <= 0)
                {
                    var mens = TipoMensaje.ObtenerTipoMensaje("ErrCompraVentamayorcero");
                    RofexList.rfxlist[0].cod_mensaje = mens.cod_mensaje;
                    RofexList.rfxlist[0].mensaje = mens.mensaje;
                    return RedirectToAction("Futuros_Financieros", "Mtba");
                }


                Orden ordenParam = new Orden();
                ordenParam.Symbol = symbol;
                ordenParam.Quantity = cantidad;
                ordenParam.Price = decimal.Parse(precio.Replace(".", ","));

                if (TipoOp == "Compra")
                {
                    ordenParam.Side = "Buy";
                }
                else
                {
                    ordenParam.Side = "Sell";
                }

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
                    }

                }

                RofexList.LimpiarMensaje();

                return View();

            }
            catch {

                var mens = TipoMensaje.ObtenerTipoMensaje("ErrValidaCompra");

                RofexList.rfxlist[0].cod_mensaje = mens.cod_mensaje;
                RofexList.rfxlist[0].mensaje = mens.mensaje;
                

               return RedirectToAction("Futuros_Financieros", "Mtba");

            }

        }

        public ActionResult HistoricoOperaciones()
        {

            var data = new List<OrderAll>();

            try
            {
                string url = _configuration.GetSection("API:GetOrderAll").Value;
                var parames = new Dictionary<string, string>();
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };


                using (HttpClient client = new HttpClient(clientHandler))
                {
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    var responseText = response.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<List<OrderAll>>(responseText);
                }
            }
            catch { }
           
            return View(data);

        }

        private List<PanelFuturoFinancieros> GetPanelFuturoFinancieros()
        {
            var data = new List<PanelFuturoFinancieros>();

            try
            {
                string url = _configuration.GetSection("API:Instrumentos").Value;
                var parames = new Dictionary<string, string>();
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };


                using (HttpClient client = new HttpClient(clientHandler))
                {
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    var responseText = response.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<List<PanelFuturoFinancieros>>(responseText);

                    if (data.Count == 0)
                    {
                        var mens = TipoMensaje.ObtenerTipoMensaje("ErrCargaPrecio");

                        RofexList.rfxlist[0].cod_mensaje = mens.cod_mensaje;
                        RofexList.rfxlist[0].mensaje = mens.mensaje;
                    }

                }
            }
            catch {
                var mens = TipoMensaje.ObtenerTipoMensaje("ErrCargaPrecio");

                RofexList.rfxlist[0].cod_mensaje = mens.cod_mensaje;
                RofexList.rfxlist[0].mensaje = mens.mensaje;
            }
            
            return data;

        }

    }
}
