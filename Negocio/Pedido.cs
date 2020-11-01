using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePPAI.Negocio
{
    public class Pedido
    {
        private List<HistorialEstado> historialEstado = new List<HistorialEstado>();
        private int numeroPedido;
        private string fechaHoraPedido;
        private List<DetalleDePedido> detalle = new List<DetalleDePedido>();

        public string mostrarMesa(Mesa[] mesas)
        {
            Mesa mesaActual = new Mesa(0);

            foreach (Mesa m in mesas)
            {
                if (m.tienePedido(this))
                {
                    mesaActual = m;
                    break;
                }
            }
            return mesaActual.mostrarMesa();
        }

        public bool tieneDetalle(DetalleDePedido detalleDePedido)
        {
            foreach (DetalleDePedido d in detalle)
            {
                if (d == detalleDePedido)
                {
                    return true;
                }
            }
            return false;
        }

        public void agregarDetalle(DetalleDePedido dp)
        {
            detalle.Add(dp);
        }
    }
}
