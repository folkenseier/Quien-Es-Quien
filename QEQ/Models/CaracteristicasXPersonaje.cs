using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QEQ.Models
{
    public class CaracteristicasXPersonaje
    {
        private int _idCaracteristica;
        private string _Nombre;

        public CaracteristicasXPersonaje(int idCaracteristica, string Nombre)
        {
            _idCaracteristica = idCaracteristica;
            _Nombre = Nombre;
        }

        public CaracteristicasXPersonaje()
        {
        }

        public int idCaracteristica { get => _idCaracteristica; set => _idCaracteristica = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
    }
}