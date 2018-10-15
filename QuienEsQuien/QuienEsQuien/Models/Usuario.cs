using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections.ObjectModel;
using System.



namespace QuienEsQuien.Models
{
    public class Usuario
    {
        
        public int id { get; set; }

        [Required()]
        public string Nombre { get; set; }

        [Required()]
        public string Mail { get; set; }

        [Required()]
        public string Contraseña { get; set; }

        [Required()]
        public string CheckContraseña { get; set; }

        [Required()]
        public bool Admin { get; set; }

        public Usuario(int _id, string _Nombre, string _Mail, string _Contraseña, string _CheckContraseña, bool _Admin)
        {
            id = _id;
            Nombre = _Nombre;
            Mail = _Mail;
            Contraseña = _Contraseña;
            CheckContraseña = _CheckContraseña;
            Admin = _Admin;
        }

    }
}