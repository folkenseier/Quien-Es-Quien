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

        //-----------------------ABM-CATEGORIAS-------------------------------------------------------------------------------

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

        //---------------------------------------------------------------------------------------------------------------------------------

        //-----------------------ABM-Caracteristicas-------------------------------------------------------------------------------

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

        //---------------------------------------------------------------------------------------------------------------------------------

        //-----------------------ABM-Personajes-------------------------------------------------------------------------------

        public ActionResult ABMPer()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Home");
            List<Personajes> ListPer = BD.ListarPersonajes();
            ViewBag.ListPer = ListPer;
            return View();
        }

        public ActionResult GestionPersonajes(string Accion, int id = 0)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Home");
            ViewBag.Enable = new { };

            ViewBag.Accion = Accion;
            List<Personajes> ListaPersonajes = new List<Personajes>();
            Personajes P = new Personajes();
            switch (Accion)
            {
                case "Modificar":


                    P = BD.ObtenerPersonaje(id);
                    ViewBag.ListCate = BD.ListarCategorias();
                    return View("FormularioPersonajes", P);



                case "Insertar":

                    ViewBag.ListCate = BD.ListarCategorias();
                    return View("FormularioPersonajes", P);



                case "Eliminar":
                    Categorias Cat = new Categorias();
                    ViewBag.Enable = new { disabled = "disabled" };
                    P = BD.ObtenerPersonaje(id);
                    List<Categorias> ListCat = new List<Categorias>();
                    Cat = BD.ObtenerCategoria(P.fkCategoria);
                    ListCat.Add(Cat);
                    Cat = new Categorias(0, "");
                    ListCat.Add(Cat);
                    ViewBag.ListCate = ListCat;

                    return View("FormularioPersonajes", P);
                    
                    
                case "Ver":
                    List<CaracteristicasXPersonaje> ListaDeCar = new List<CaracteristicasXPersonaje>();
                    Personajes Per = new Personajes();
                    Per = BD.ObtenerPersonaje(id);
                    ListaDeCar = BD.ListarCarDePer(Per.id);
                    Categorias Cate = new Categorias();
                    Cate = BD.ObtenerCategoria(Per.fkCategoria);
                    ViewBag.ListaDeCar = ListaDeCar;
                    ViewBag.Categoria = Cate.Nombre;
                    ViewBag.Nombre = Per.Nombre;
                    return View("Ver");


            }
            return View("FormularioPersonajes");
        }

        [HttpPost]
        public ActionResult ABMPersonajes(string Accion, Personajes P)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Home");

            ViewBag.Accion = Accion;


            switch (Accion)
            {

                case "Insertar":
                    if (ModelState.IsValid)
                    {
                        List<CaracteristicasXPersonaje> ListaDeCaracteristicas = new List<CaracteristicasXPersonaje>();


                        BD.InsertarPersonajes(P.Nombre, P.fkCategoria);
                        ListaDeCaracteristicas = BD.ListarCarID();

                        ViewBag.ListaCar = ListaDeCaracteristicas;
                        ViewBag.ListaCarXPer = new List<int>();
                        ViewBag.idPersonaje = BD.ObtenerUltimoIdPersonaje();

                        return View("RelacionCarXPer", P);


                    }
                    else
                    {
                        return View("FormularioPersonajes", P);
                    }

                case "Modificar":
                    if (ModelState.IsValid)
                    {
                        List<CaracteristicasXPersonaje> ListaDeCaracteristicas = new List<CaracteristicasXPersonaje>();
                        List<int> ListaDeCarXPer = new List<int>();


                        BD.ModificarPersonajes(P);
                        ListaDeCaracteristicas = BD.ListarCarID();
                        ListaDeCarXPer = BD.ListarCarXPer(P.id);

                        ViewBag.ListaCar = ListaDeCaracteristicas;
                        ViewBag.ListaCarXPer = ListaDeCarXPer;
                        ViewBag.idPersonaje = P.id;

                        return View("RelacionCarXPer");
                    }
                    else
                    {
                        return View("FormularioPersonajes", P);
                    }

                case "Eliminar":
                    Personajes Per = new Personajes();
                    Per = BD.ObtenerPersonaje(P.id);
                    BD.EliminarPersonajes(P.id);
                    ViewBag.Mensaje = "eliminado";
                    ViewBag.Atributo = "personaje";
                    ViewBag.Nombre = Per.Nombre;
                    ViewBag.ActionResult = "ABMPer";
                    return View("Confirmacion");


            }
            return View("RelacionCarXPer", P);
        }

        [HttpPost]
        public ActionResult CarXPer(int idPer, string[] idCar, string Accion)
        {

            if (!IsAdmin()) return RedirectToAction("Login", "Home");

            Personajes Per = new Personajes();
            Per = BD.ObtenerPersonaje(idPer);
            ViewBag.Nombre = Per.Nombre;
            ViewBag.Atributo = "personaje";
            ViewBag.ActionResult = "ABMPer";

            BD.InsertarCarPer(idCar, idPer);
            switch (Accion)
            {
                case "Insertar":
                    ViewBag.Mensaje = "agregado";
                    break;

                case "Modificar":
                    ViewBag.Mensaje = "modificado";
                    break;
            }
            return View("Confirmacion");
        }
    }
}