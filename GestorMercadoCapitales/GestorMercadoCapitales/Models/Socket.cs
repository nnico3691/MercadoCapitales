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
            
            if (hora_actual >= hora.Horario_Mercado)
            {

                Console.WriteLine("Connecting to ReMarkets...");

                var api = new Api(Api.DemoEndpoint);
                await api.Login(Api.DemoUsername, Api.DemoPassword);

                // Get a all dollar futures
                Console.WriteLine("Getting available instruments...");

                var allIInstruments = await api.GetAllInstruments();

                //consumimos la devolucion de todos los instrumentos de la api
                /*
                var datasymbols = new List<PanelFuturoFinancieros>();
                datasymbols = GetPanelFuturoFinancieros();
                string[] symbols = new string[datasymbols.Count];
                int indice = 0;

                foreach (var insymbols in datasymbols)
                {
                    symbols[indice] = insymbols.symbol.ToString();
                    indice = indice + 1;
                }

                var symbols = new[]
                {
                    "DLR/DIC24",
                    "DLR/ENE25A",

                };
                
                var dollarFuture = allIInstruments.Where(c => symbols.Contains(c.Symbol));

                */

                //PanelInferiorInstrumentos.Instrumentos = symbols;

                // Subscribe to bids and offers
                var entries = new[] { Entry.Offers, Entry.Close, Entry.EffectiveVolume, Entry.NominalVolume, Entry.Bids };

                Console.WriteLine("Connecting to market data...");

                // Crear una lista para almacenar los instrumentos
                var instrumentIds = new List<Primary.Data.InstrumentId>
                {
                    new Primary.Data.InstrumentId
                    {
                        Market = "ROFX",
                        Symbol = "DLR/DIC24"
                    },
                    new Primary.Data.InstrumentId
                    {
                        Market = "ROFX",
                        Symbol = "DLR/ENE25A"
                    },
                    new Primary.Data.InstrumentId
                    {
                        Market = "ROFX",
                        Symbol = "DLR/ABR25"
                    },
                    new Primary.Data.InstrumentId
                    {
                        Market = "ROFX",
                        Symbol = "DLR/AGO25"
                    },
                    new Primary.Data.InstrumentId
                    {
                        Market = "ROFX",
                        Symbol = "GGAL/DIC24"
                    },
                    new Primary.Data.InstrumentId
                    {
                        Market = "ROFX",
                        Symbol = "PAMP/DIC24"
                    },
                    new Primary.Data.InstrumentId
                    {
                        Market = "ROFX",
                        Symbol = "PAMP/FEB25"
                    }

                };

                // Pasar la lista directamente al método CreateMarketDataSocket
                var socket = api.CreateMarketDataSocket(instrumentIds, entries, 1, 2);

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

                // Obtener el último Bid y Offer, asegurándose de que no sean nulos
                var lastBid = marketData.Data.Bids.LastOrDefault();
                var lastOffer = marketData.Data.Offers.LastOrDefault();

                // Construir el mensaje con verificaciones de nulos
                string bidPrice = lastBid != null ? lastBid.Price.ToString() : "N/A";
                string offerPrice = lastOffer != null ? lastOffer.Price.ToString() : "N/A";

                Console.WriteLine($"MarketData Novedades ==> El Símbolo es: {marketData.InstrumentId.Symbol}, Bids: {bidPrice}, Offers: {offerPrice}");

                var bid = default(decimal);
                var offer = default(decimal);

                var bidSize = default(decimal);
                var offerSize = default(decimal);

                var nominalVolume = default(decimal?);

                if (marketData.Data.Bids != null)
                {
                    // Obtener el último registro de Bids
                    if (lastBid != null)
                    {
                        bid = lastBid.Price;
                        bidSize = lastBid.Size;
                    }

                    // Obtener el último registro de Offers
                    if (lastOffer != null)
                    {
                        offer = lastOffer.Price;
                        offerSize = lastOffer.Size;
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
                            rfx.Compra = bid;
                            rfx.Venta = offer;
                            rfx.VolV = offerSize;
                            rfx.VolOpe = nominalVolume;
                            //rfx.ColorCompra = ColorCompra;
                            //rfx.ColorVenta = ColorVenta;
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
                                    //break;
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


            }
            catch { }

        }
    }
}
