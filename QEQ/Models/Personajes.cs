using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QEQ.Models
{
    public class Personajes
    {
        private int _id;
        private string _Nombre;
        private int _fkCategoria;

        public Personajes(int id, string Nombre, int fkCategoria)
        {
            _id = id;
            _Nombre = Nombre;
            _fkCategoria = fkCategoria;
        }

        public Personajes()
        {
        }

        public int id { get => _id; set => _id = value; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "El nombre no puede sobrepasar los 100 caracteres")]
        public string Nombre { get => _Nombre; set => _Nombre = value; }

        public int fkCategoria { get => _fkCategoria; set => _fkCategoria = value; }
    }
}