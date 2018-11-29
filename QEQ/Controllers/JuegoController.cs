using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QEQ.Models;

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
            Session["modo"] = jugador;

            Session["Puntaje"] = 1000000;

            Categorias C = new Categorias(0, "Todas");
            List<Categorias> ListCate = new List<Categorias>();
            List<Categorias> ListCategorias = new List<Categorias>();
            ListCate = BD.ListarCategorias();
            ListCate.Add(C);
            ListCate = ListCate.OrderBy(x => x.id).ToList();

            ViewBag.ListCate = ListCate;

            return View();
        }
        public ActionResult VerPersonajes()
        {
            Session["Puntaje"] = (Convert.ToInt32(Session["Puntaje"]) / 2);
            ViewBag.ListaDePersonajes = Session["ListaPersonajes"];
            return View("SelectPerXCate");
        }

        [HttpPost]
        public ActionResult SelectPerXCate(int idCategorias)
        {
            List<Personajes> Pers = new List<Personajes>();
            if (idCategorias != 0)
            {
                Pers = BD.ListarPersonajesXCategoria(idCategorias);
            }
            else
            {
                Pers = BD.ListarPersonajes();
            }
            Session["ListaPersonajes"] = Pers;

            List<int> ListaIDPersonajes = new List<int>();
            ListaIDPersonajes = BD.ListarIDPersonajes();

            Random rnd = new Random();
            int PosiciónElegida = rnd.Next(0, ListaIDPersonajes.Count-1);
            int PersonajeElegido = ListaIDPersonajes[PosiciónElegida];

            Session["PersonajeElegido"] = PersonajeElegido;

            ViewBag.ListaDePersonajes = Pers;
            return View();
        }
		
        [HttpPost]
        public ActionResult Preguntas()
        {
            ViewBag.Preguntas = BD.ListarPreguntas();



            return View();
        }
        [HttpPost]
        public ActionResult Respuesta(int id) {
            int valor = BD.ObtenerCaracteristica(id).ValorPregunta;
            if (valor > Convert.ToInt32(Session["Puntaje"]))
            {
                ViewBag.Mensaje = "No tienes los infocoins necesarios para hacer la pregunta";
                return RedirectToAction("Preguntas", "Juego");
            }
            else
            {


                Session["Puntaje"] = Convert.ToInt32(Session["Puntaje"]) - valor;
                var ListPersonajes = BD.ListarPersonajesXCaracteristica(id);
                if (ListPersonajes.Contains(Session["PersonajeElegido"]))
                {
                    List<Personajes> PersonajesQueSeQuedan = new List<Personajes>();
                    List<Personajes> personajesActuales = Session["ListaPersonajes"] as List<Personajes>;
                    foreach (Personajes P in ListPersonajes)
                    {
                        if (personajesActuales.Contains(P))
                        {
                            PersonajesQueSeQuedan.Add(P);
                        }
                    }
                    Session["ListaPersonajes"] = PersonajesQueSeQuedan;
                    ViewBag.Mensaje = "Si";
                }
                else
                {
                    List<Personajes> personajesActuales = Session["ListaPersonajes"] as List<Personajes>;
                    foreach (var P in ListPersonajes)
                    {
                        personajesActuales.Remove(P);
                    }
                    ViewBag.Mensaje = "No";
                    Session["ListaPersonajes"] = personajesActuales;

                }

                return View();
            }
        }
        /*
    [HttpGet]
    public ActionResult SelectCat(string jugador)
    {
        Session["jugador"] = jugador;

        return View();
    }
    */

    }
}
