using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QEQ.Models;

namespace QEQ.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
            return View("index");
        }
    }
}