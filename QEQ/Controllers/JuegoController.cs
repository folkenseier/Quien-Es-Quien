﻿using System;
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
        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult SelectCat()
        {
            Categorias C = new Categorias(0, "Todas");
            List<Categorias> ListCate = new List<Categorias>();
            List<Categorias> ListCategorias = new List<Categorias>();
            ListCate = BD.ListarCategorias();
            ListCate.Add(C);

            ViewBag.ListCate = ListCate;

            return View();
        }
        [HttpPost]
        public ActionResult SelectPerXCate(int id)
        {
            List<Personajes> Pers = new List<Personajes>();
            if (id != 0)
            {
                Pers = BD.ListarPersonajesXCategoria(id);
            }
            else
            {
                Pers = BD.ListarPersonajes();
            }
            ViewBag.ListaDePersonajes = Pers;
            return View();
        }
    }
}