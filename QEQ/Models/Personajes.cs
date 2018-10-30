using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public int fkCategoria { get => _fkCategoria; set => _fkCategoria = value; }
    }
}