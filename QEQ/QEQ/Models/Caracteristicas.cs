using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QEQ.Models
{
    public class Caracteristicas
    {
        private int _id;
        private string _Nombre;
        private string _TextoPregunta;
        private int _ValorPregunta;

        public Caracteristicas(int id, string Nombre, string TextoPregunta, int ValorPregunta)
        {
            _id = id;
            _Nombre = Nombre;
            _TextoPregunta = TextoPregunta;
            _ValorPregunta = ValorPregunta;
        }

        public Caracteristicas()
        {

        }

        public int id { get => _id; set => _id = value; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [StringLength(200, MinimumLength = 0, ErrorMessage = "El nombre no puede sobrepasar los 200 caracteres")]
        public string Nombre { get => _Nombre; set => _Nombre = value; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "El texto de la pregunta no puede sobrepasar los 500 caracteres")]
        public string TextoPregunta { get => _TextoPregunta; set => _TextoPregunta = value; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [Range(1000, 10000, ErrorMessage = "La pregunta solo puede valer entre 1000 y 10000 infocoins")]
        public int ValorPregunta { get => _ValorPregunta; set => _ValorPregunta = value; }
    }
}