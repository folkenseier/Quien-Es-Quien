using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QEQ.Controllers
{
    public class JuegoController : Controller
    {
        // GET: Juego
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SelectCat(string jugador)
        {
            Session["jugador"] = jugador;
            return View();
        }
    }
}