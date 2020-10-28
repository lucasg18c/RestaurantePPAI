using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePPAI.Negocio
{
    public class DetalleDePedido
    {
        private String cantidad;
        private HistorialEstado historialEstado;
        private String hora;
        private int precio;
       

        public DetalleDePedido(string cantidad,
             string hora, int precio)
        {
            this.cantidad = cantidad;
            
            this.hora = hora;
            this.precio = precio;
        }
    }
}
