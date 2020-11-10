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
        private Pedido pedido;
        //private TiempoPresentacion tiempo;
        //private DetalleFactura detalleFactura;
        private Menu menu;

        public DetalleDePedido(Pedido pedido, int cantidad, DateTime hora, ProductoDeCarta producto, Estado estado)
        {
            this.cantidad = cantidad;
            this.hora = hora;
            this.producto = producto;
            this.pedido = pedido;
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

        public bool esProductoDeCarta()
        {
            return producto != null;
        }
        
        public bool esMenuDeCarta()
        {
            return menu != null;
        }

        public string mostrarMesa()
        {
            return pedido.mostrarMesa();
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

        public string mostrarMozo()
        {
            return pedido.mostrarMozo();
        }

        public string getSeccion()
        {
            return pedido.getSeccion();
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
