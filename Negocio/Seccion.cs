using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePPAI.Negocio
{
    public class Seccion
    {
        private string nombre;
        private Mesa mesa;

        public Seccion(string nombre)
        {
            this.nombre = nombre;
        }

        public string mostrarSeccion()
        {
            return nombre;
        }
    }
}
