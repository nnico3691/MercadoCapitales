using System;
using System.Threading.Tasks;

namespace Primary.Examples
{
    internal static class RunExamples
    {
        private static async Task Main()
        {
            Console.WriteLine("Conectando Sistema Mercado Capitales...");
            await GetInstrumentsAndDataExample.Run();
            //await OrderExample.Run();
            //await WebSocketExample.Run();
        }
    }
}
