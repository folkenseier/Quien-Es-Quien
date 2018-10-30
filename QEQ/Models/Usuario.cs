using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace QEQ.Models
{
    public class Usuario
    {
        private int _id;
        private string _Nombre;
        private string _Mail;
        private string _Contraseña;
        private bool _EsAdmin;
        private int _Puntaje;
        private int _Record;

        public Usuario(int id, string Nombre, string Mail, string Contraseña, bool EsAdmin, int Puntaje, int Record)
        {
            _id = id;
            _Nombre = Nombre;
            _Mail = Mail;
            _Contraseña = Contraseña;
            _EsAdmin = EsAdmin;
            _Puntaje = Puntaje;
            _Record = Record;
        }
        public Usuario()
        {
            
        }

        public int Id { get => _id; set => _id = value; }

        //[Required(ErrorMessage = "El campo no puede estar vacío")]
        //[StringLength(100, MinimumLength = 0, ErrorMessage = "El nombre no puede sobrepasar los 100 caracteres")]

        public string Nombre { get => _Nombre; set => _Nombre = value; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [StringLength(200, MinimumLength = 0, ErrorMessage = "El Mail no puede sobrepasar los 200 caracteres")]

        public string Mail { get => _Mail; set => _Mail = value; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        public string Contraseña { get => _Contraseña; set => _Contraseña = value; }

        public bool EsAdmin { get => _EsAdmin; set => _EsAdmin = value; }
        public int Puntaje { get => _Puntaje; set => _Puntaje = value; }
        public int Record { get => _Record; set => _Record = value; }
    }
}