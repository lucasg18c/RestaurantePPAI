using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePPAI.Negocio
{
    public class Mesa
    {
        private int numero;
        private List<Pedido> pedidos = new List<Pedido>();

        public Mesa(int numero)
        {
            this.numero = numero;
        }

        public string mostrarMesa()
        {
            return numero.ToString();
        }

        public bool tienePedido(Pedido pedido)
        {
            foreach (Pedido p in pedidos)
            {
                if (p == pedido) return true;
            }
            return false;
        }

        public void agregarPedido(Pedido p)
        {
            pedidos.Add(p);
        }
    }
}
