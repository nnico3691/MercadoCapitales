using GestorMercadoCapitales.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;

namespace GestorMercadoCapitales.Controllers
{
    public class BymaController : Controller
    {
        
        public ActionResult lider()
        {
            return View();
        }

    }
}
