using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QEQ.Models;

namespace QEQ.Controllers
{
    public class BackOfficeController : Controller
    {
        // GET: BackOffice
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ABMCat()
        {
            List<Categorias> ListCate = BD.ListarCategorias();
            ViewBag.ListCate = ListCate;
            return View();
        }

        public ActionResult GestionCategorias(string Accion, int id = 0)
        {
            ViewBag.Enable = new { };

            ViewBag.Accion = Accion;
            List<Categorias> ListaCategorias = new List<Categorias>();
            Categorias C = new Categorias();
            switch (Accion)
            {
                case "Modificar":

                    
                    C = BD.ObtenerCategoria(id);
                    return View("FormularioCategorias", C);



                case "Insertar":
                   
                    return View("FormularioCategorias", C);



                case "Eliminar":
                    ViewBag.Enable = new { disabled = "disabled" };
                    C = ListaCategorias[0];
                    ListaCategorias = BD.ListarCategorias();
                    return View("FormularioCategorias", C);


                

            }
            return View("FormularioCategorias");
        }

        [HttpPost]
        public ActionResult ABMCategorias(string Accion, Categorias C)
        {
            ViewBag.Accion = Accion;
            switch (Accion)
            {

                case "Insertar":
                    if (ModelState.IsValid)
                    {
                        BD.InsertarCategoria(C.Nombre);
                        return View("Confirmacion");
                    }
                    else
                    {
                        return View("FormularioCategorias", C);
                    }

                case "Modificar":
                    if (ModelState.IsValid)
                    {
                        BD.ModificarCategoria(C);
                        return View("Confirmacion");
                    }
                    else
                    {
                        return View("FormularioCategorias", C);
                    }

                case "Eliminar":
                    BD.EliminarCategoria(C.id);
                    return View("FormularioCategorias", C);

                
            }
            return View("Confirmacion");
        }
    }
}