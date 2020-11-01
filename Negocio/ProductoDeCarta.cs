using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePPAI.Negocio
{
    public class ProductoDeCarta
    {
        private bool esFavorito;
        private double precio;
        private Producto producto;

        public ProductoDeCarta(Producto producto)
        {
            this.producto = producto;
            esFavorito = true;
            precio = producto.getPrecio();
        }

        public double getPrecio()
        {
            return precio;
        }

        public string mostrarProducto()
        {
            return producto.getNombre();
        }
    }
}
