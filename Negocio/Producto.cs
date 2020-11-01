using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePPAI.Negocio
{
    public class Producto
    {
        private DateTime fechaCreacion;
        private string foto;
        private string nombre;
        private double precio;
        //private Receta receta;
        private SectorComanda sectorComanda;
        //private TiempoPresentacion tiempoPresentacion;

        public Producto(string nombre, double precio)
        {
            this.nombre = nombre;
            this.precio = precio;
        }

        public double getPrecio()
        {
            return precio;
        }

        public string getNombre()
        {
            return nombre;
        }
    }
}
