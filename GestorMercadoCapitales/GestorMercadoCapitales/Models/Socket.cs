using Primary.Data;
using Primary;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading;

namespace GestorMercadoCapitales.Models
{
    public class Socket
    {

        private IConfiguration _configuration;
        public Socket(IConfiguration iconfig)
        {
            _configuration = iconfig;
        }

        public async void RunSocket(object state)
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

                Console.WriteLine("Connecting to ReMarkets...");

                var api = new Api(Api.DemoEndpoint);
                await api.Login(Api.DemoUsername, Api.DemoPassword);

                // Get a all dollar futures
                Console.WriteLine("Getting available instruments...");

                var allIInstruments = await api.GetAllInstruments();

                //var symbols = new[]
                //{
                //    "DLR/ENE23",
                //    "ORO/ENE23",
                //    "ORO/MAR23",
                //    "ORO/MAY23",
                //    "YPFD/FEB23",
                //    "RFX20/FEB23",
                //    "GGAL/FEB23",
                //    "WTI/ENE23",
                //    "WTI/MAR23",
                //    "WTI/MAY23"


                //};

                //consumimos la devolucion de todos los instrumentos de la api
                var datasymbols = new List<PanelFuturoFinancieros>();
                datasymbols = GetPanelFuturoFinancieros();
                string[] symbols = new string[datasymbols.Count];
                int indice = 0;

                foreach (var insymbols in datasymbols)
                {
                    symbols[indice] = insymbols.symbol.ToString();
                    indice = indice + 1;
                }


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
            
        }

        private List<PanelFuturoFinancieros> GetPanelFuturoFinancieros()
        {

            string url = _configuration.GetSection("API:Instrumentos").Value;
            var parames = new Dictionary<string, string>();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var data = new List<PanelFuturoFinancieros>();

            using (HttpClient client = new HttpClient(clientHandler))
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                var responseText = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<List<PanelFuturoFinancieros>>(responseText);
            }


            return data;

        }



        private void OnMarketData(Api api, MarketData marketData)
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


                MtbaRfx rfx = new MtbaRfx();

                //RofexList.rfxlist = new List<MtbaRfx>();

               
                if (bid > 0 || offer > 0)
                {
                    bool existe = RofexList.rfxlist.Any(item => item.Instrumento == marketData.InstrumentId.Symbol);

                    if (!existe)
                    {
                        rfx.Instrumento = marketData.InstrumentId.Symbol;
                        rfx.VolC = bidSize;
                        rfx.Venta = offer;
                        rfx.VolV = offerSize;
                        rfx.VolOpe = nominalVolume;
                        RofexList.rfxlist.Add(rfx);

                    }
                    else
                    {
                        var list = RofexList.rfxlist.FirstOrDefault(item => item.Instrumento == marketData.InstrumentId.Symbol);
                        string ColorVenta = "";
                        string ColorCompra = "";

                        if (list.Compra >= bid)
                        {
                            ColorCompra = "#1ABC9C";
                        }
                        else
                        {
                            ColorCompra = "#C70039";
                        }

                        if (list.Venta >= offer)
                        {
                            ColorVenta = "#1ABC9C";
                        }
                        else
                        {
                            ColorVenta = "#C70039";
                        }

                        //RofexList.rfxlist.Remove(list);
                        foreach (var item in RofexList.rfxlist)
                        {
                            if (item.Instrumento == marketData.InstrumentId.Symbol)
                            {
                                item.Instrumento = marketData.InstrumentId.Symbol;
                                item.VolC = bidSize;
                                item.Compra = bid;
                                item.Venta = offer;
                                item.VolV = offerSize;
                                item.VolOpe = nominalVolume;
                                item.ColorCompra = ColorCompra;
                                item.ColorVenta = ColorVenta;
                                break;
                            }

                        }
                      
                       // RofexList.rfxlist.Add(rfx);

                    }

                    
                }
                //Console.WriteLine($"({marketData.Timestamp}) " +
                //                  $"{marketData.InstrumentId.Symbol} -> " +
                //                  $"Vol.C: {bidSize} ; Compra: {bid} ; Venta: {offer} ; Vol.V: {offerSize}; Vol. Operado: nominalVolume;"
                //);

            }
            catch { }

        }
    }
}
