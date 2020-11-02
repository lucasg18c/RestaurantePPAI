using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePPAI.Negocio
{
    public class DetalleDePedido
    {
        private int cantidad; 
        private List<HistorialEstado> historialEstado = new List<HistorialEstado>();
        private DateTime hora;
        private double precio;
        private ProductoDeCarta producto;
        //private TiempoPresentacion tiempo;
        //private DetalleFactura detalleFactura;
        private Menu menu;

        public DetalleDePedido(int cantidad, DateTime hora, ProductoDeCarta producto, Estado estado)
        {
            this.cantidad = cantidad;
            this.hora = hora;
            this.producto = producto;
            precio = producto.getPrecio();
            historialEstado.Add(new HistorialEstado(estado, hora));
        }

        public string mostrarNombreProducto()
        {
            if (producto == null) return "-";
            return producto.mostrarProducto();
        }

        public string mostrarNombreMenu()
        {
            if (menu == null) return "-";
            return menu.getNombre();
        }

        public bool estaEnPreparacion(Estado enPreparacion)
        {
            HistorialEstado ultimo = obtenerUltimoEstado();
            return ultimo.esEstado(enPreparacion);
        }

        private HistorialEstado obtenerUltimoEstado()
        {
            foreach (HistorialEstado he in historialEstado)
            {
                if (he.esUltimoHistorial()) return he;
            }
            return null;
        }

        public int calcularEspera(DateTime hora)
        {
            return (int) (hora - this.hora).TotalMinutes;
        }

        public string mostrarMesa(Mesa[] mesas, Pedido[] pedidos)
        {
            Pedido pedido = new Pedido();

            foreach (Pedido p in pedidos)
            {
                if (p.tieneDetalle(this))
                {
                    pedido = p;
                    break;
                }
            }

            return pedido.mostrarMesa(mesas);
        }

        public string getCantidad()
        {
            return cantidad.ToString();
        }

        public DateTime getHora()
        {
            return hora;
        }

        public void finalizar(Estado estadoListo, DateTime horaActual)
        {
            setearFinUltimoHistorial(horaActual);
            crearHistorial(estadoListo, horaActual);
        }

        private void crearHistorial(Estado estado, DateTime horaInicio)
        {
            HistorialEstado nuevo = new HistorialEstado(estado, horaInicio);
            historialEstado.Add(nuevo);
        }

        private void setearFinUltimoHistorial(DateTime horaActual)
        {
            HistorialEstado ultimo = obtenerUltimoEstado();
            ultimo.setFechaHoraFin(horaActual);
        }

        public void notificar(Estado estadoNotificado, DateTime horaActual)
        {
            setearFinUltimoHistorial(horaActual);
            crearHistorial(estadoNotificado, horaActual);
        }
    }
}
