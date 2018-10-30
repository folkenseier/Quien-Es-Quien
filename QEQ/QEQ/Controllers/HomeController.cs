﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QEQ.Models;
using System.Text;
using System.Xml;


namespace QEQ.Controllers
{
    public class HomeController : Controller
    {
        [NonAction]
        private bool Validate()
        {
            Usuario user = Session["Usuario"] as Usuario;
            if (user == null) return false;
            return user.EsAdmin;
        }
        [NonAction]
        private bool PinCheck(int pin)
        {
            return pin == 623;
        }

        public ActionResult Index()
        {

            if (!Validate()) return View();
            else return RedirectToAction("Index", "BackOffice" );

        }
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidarLogIn(Usuario unUsuario)
        {
            Usuario User = new Usuario();
            if (ModelState.IsValid)
            {
                if (BD.ValidarUser(unUsuario.Mail, unUsuario.Contraseña) == true)
                {
                    
                    User = BD.TraerUsuario(unUsuario.Mail, unUsuario.Contraseña);

                    Session["Usuario"] = User;

                    if (User.EsAdmin == true)
                    {
                        return RedirectToAction("Index", "BackOffice");
                    }
                    else
                    {
                        return View("Index");
                    }
                }
                else
                {
                    ViewBag.Mensaje = "Usuario o contraseña erróneo";
                    return View("Login");
                }
                
            }
            else
            {
                return View("Login");
            }
            
        }

        public ActionResult Logout()
        {
            Session["Usuario"] = null;
            return View("Index");
        }

        public ActionResult FormRegistro()
        {
            return View();
        }




        [HttpPost]
        public ActionResult Registrar(Usuario usuario, int pin)
        {
            if (!ModelState.IsValid)
            {
                if (BD.BuscarPorMail(usuario.Mail))
                {
                    ViewBag.Mensaje = "El mail ingresado ya existe";
                }
                return View("FormRegistro", usuario);
            }

            else
            {
                if (BD.RegistrarUsuario(usuario))
                {
                    if(PinCheck())
                    return View("Index");
                }
                else
                {
                    ViewBag.Mensaje = "Error al cargar la base de datos, intente de nuevo mas tarde.";
                    return View("FormRegistro");
                }
            }
        }

        public string GetUsersAjax()
        {
            
            List<Usuario> Users = BD.ListarUsuarios();
            Users.OrderBy(x => x.Puntaje).Reverse().Where(x => !x.EsAdmin);
            string table = "";
            foreach(var i in Users)
            {
                table += "<tr>";
                table += "<td>"+ i.Nombre +"</td>";
                table += "<td>"+ i.Puntaje +"</td>";
                table += "<tr>";

            }


          /*  foreach(Usuario user in Users)
            {
                xml += "<User>";
                xml += "<Nombre>"+ user.Id.ToString() +"</Nombre>";
                xml += "<Puntaje>"+ user.Puntaje.ToString() +"</Puntaje>";
                xml += "<Record>"+ user.Record.ToString() +"</Record>";
                xml += "</User>";
               
            }
            xml += "</xml>";*/
            return table;
        }

    }

    

}