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
        private Mesa mesa;
        private List<DetalleDePedido> detalle = new List<DetalleDePedido>();

        public string mostrarMesa()
        {
            return mesa.mostrarNumero();
        }

        public void agregarDetalle(DetalleDePedido dp)
        {
            detalle.Add(dp);
        }

        public void setMesa(Mesa mesa)
        {
            this.mesa = mesa;
        }

        public string getSeccion()
        {
            return mesa.getSeccion();
        }

        public string mostrarMozo()
        {
            Random r = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, 5)
              .Select(s => s[r.Next(s.Length)]).ToArray());
        }
    }
}
