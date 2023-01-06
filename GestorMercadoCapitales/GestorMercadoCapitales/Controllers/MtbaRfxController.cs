using GestorMercadoCapitales.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GestorMercadoCapitales.Controllers
{
    public class MtbaRfxController : Controller
    {
        private IConfiguration _configuration;
        public ActionResult Futuros_Financieros()
        {
            if (HttpContext.Session.GetString("Socket") != "Iniciado")
            {
                try
                {
                    Socket socket = new Socket(_configuration);

                    ThreadPool.QueueUserWorkItem(socket.RunSocket, new object[] { });
                    HttpContext.Session.SetString("Socket", "Iniciado");
                }
                catch { }
            }

            return View(RofexList.rfxlist);
        }


    }
}
