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
        private Seccion seccion;

        public Mesa(int numero)
        {
            this.numero = numero;
        }

        public bool tienePedido(Pedido pedido)
        {
            foreach (Pedido p in pedidos)
            {
                if (p == pedido) return true;
            }
            return false;
        }

        public string mostrarNumero()
        {
            return numero.ToString();
        }

        public void agregarPedido(Pedido p)
        {
            pedidos.Add(p);
        }

        public void setSeccion(Seccion seccion)
        {
            this.seccion = seccion;
        }

        public string getSeccion()
        {
            return seccion.mostrarSeccion();
        }
    }
}
