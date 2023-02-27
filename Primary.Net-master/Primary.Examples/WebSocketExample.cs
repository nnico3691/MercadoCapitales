using System;
using System.Linq;
using System.Threading.Tasks;
using Primary.Data;

namespace Primary.Examples
{
    internal static class WebSocketExample
    {
        public static async Task Run()
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

            using var socket = api.CreateMarketDataSocket(dollarFuture, entries, 1, 2);
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

            } catch { }

        }
    }
}
