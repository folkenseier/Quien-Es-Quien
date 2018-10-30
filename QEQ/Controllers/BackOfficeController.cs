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
        [NonAction]
        private bool IsAdmin()
        {
            Usuario user = Session["Usuario"] as Usuario;
            if (user == null) return false;
            return user.EsAdmin;
        }
        // GET: BackOffice
        public ActionResult Index()
        {
            if (IsAdmin()) return View();
            else return RedirectToAction("Login", "Home");
        }

        public ActionResult ABMCat()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Home");
            List<Categorias> ListCate = BD.ListarCategorias();
            ViewBag.ListCate = ListCate;
            return View();
        }

        public ActionResult GestionCategorias(string Accion, int id = 0)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Home");
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
                    C = BD.ObtenerCategoria(id);
                    return View("FormularioCategorias", C);


                

            }
            return View("FormularioCategorias");
        }

        [HttpPost]
        public ActionResult ABMCategorias(string Accion, Categorias C)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Home");

            ViewBag.Atributo = "categoría";
            ViewBag.ActionResult = "ABMCat";
            ViewBag.Accion = Accion;
            switch (Accion)
            {

                case "Insertar":
                    if (ModelState.IsValid)
                    {
                        BD.InsertarCategoria(C.Nombre);
                        ViewBag.Mensaje = "agregado";
                        ViewBag.Nombre = C.Nombre;
                        return View("Confirmacion", C);
                        
                    }
                    else
                    {
                        return View("FormularioCategorias", C);
                    }

                case "Modificar":
                    if (ModelState.IsValid)
                    {
                        BD.ModificarCategoria(C);
                        ViewBag.Mensaje = "modificado";
                        ViewBag.Nombre = C.Nombre;
                        return View("Confirmacion");
                    }
                    else
                    {
                        return View("FormularioCategorias", C);
                    }

                case "Eliminar":
                    BD.EliminarCategoria(C.id);
                    ViewBag.Mensaje = "eliminado";
                    ViewBag.Nombre = C.Nombre;
                    return View("Confirmacion", C);


            }
            return View("Confirmacion", C);
        }

        public ActionResult ABMCar()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Home");
            List<Caracteristicas> ListCara = BD.ListarCaracteristicas();
            ViewBag.ListCara = ListCara;
            return View();
        }

        public ActionResult GestionCaracteristicas(string Accion, int id = 0)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Home");
            ViewBag.Enable = new { };

            ViewBag.Accion = Accion;
            List<Caracteristicas> ListaCaracteristicas = new List<Caracteristicas>();
            Caracteristicas C = new Caracteristicas();
            switch (Accion)
            {
                case "Modificar":


                    C = BD.ObtenerCaracteristica(id);
                    return View("FormularioCaracteristicas", C);



                case "Insertar":

                    return View("FormularioCaracteristicas", C);



                case "Eliminar":
                    ViewBag.Enable = new { disabled = "disabled" };
                    C = BD.ObtenerCaracteristica(id);
                    return View("FormularioCaracteristicas", C);

                case "Ver":
                    ViewBag.Enable = new { disabled = "disabled" };
                    C = BD.ObtenerCaracteristica(id);
                    return View("FormularioCaracteristicas", C);


            }
            return View("FormularioCaracteristicas");
        }

        [HttpPost]
        public ActionResult ABMCaracteristicas(string Accion, Caracteristicas C)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Home");

            ViewBag.Atributo = "característica";
            ViewBag.ActionResult = "ABMCar";
            ViewBag.Accion = Accion;
            switch (Accion)
            {

                case "Insertar":
                    if (ModelState.IsValid)
                    {
                        BD.InsertarCaracteristicas(C.Nombre, C.TextoPregunta, C.ValorPregunta);
                        ViewBag.Mensaje = "agregado";
                        ViewBag.Nombre = C.Nombre;
                        return View("Confirmacion", C);

                    }
                    else
                    {
                        return View("FormularioCaracteristicas", C);
                    }

                case "Modificar":
                    if (ModelState.IsValid)
                    {
                        BD.ModificarCaracteristicas(C);                       
                        ViewBag.Mensaje = "modificado";
                        ViewBag.Nombre = C.Nombre;
                        return View("Confirmacion");
                    }
                    else
                    {
                        return View("FormularioCaracteristicas", C);
                    }

                case "Eliminar":
                    BD.EliminarCaracteristicas(C.id);
                    ViewBag.Mensaje = "eliminado";
                    ViewBag.Nombre = C.Nombre;
                    return View("Confirmacion", C);

                case "Ver":
                    return RedirectToAction("ABMCar", "BackOffice");

            }
            return View("Confirmacion", C);
        }

        //https://www.w3schools.com/jquery/jquery_filters.asp

    }
}