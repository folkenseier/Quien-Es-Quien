using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QEQ.Models
{
    public class Categorias
    {
        private int _id;
        private string _Nombre;

        public Categorias()
        {

        }

        public Categorias(int id, string Nombre)
        {
            _id = id;
            _Nombre = Nombre;
        }

        public int id { get => _id; set => _id = value; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [Range(0, 200, ErrorMessage = "El nombre no puede sobrepasar los 200 caracteres")]
        public string Nombre { get => _Nombre; set => _Nombre = value; }
    }
}