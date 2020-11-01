using RestaurantePPAI.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePPAI.Negocio 
{
    public class GestorFinalizarPreparacion {
        //private Estado estado;
        //private Sesion sesion;
        //private InterfazDispositivoMovil dispositivoMovil;
        //private InterfazMonitor monitor;

        private List<DetalleDePedido> detallePedidoSeleccionadosAServir; 
        private List<DetalleDePedido> detallesPedidoEnPreparacion = new List<DetalleDePedido>(); 
        private List<DetalleDePedido> detallePedidoNotificados;

        private PantallaFinalizarPreparacionPedido pantalla;

        public GestorFinalizarPreparacion(PantallaFinalizarPreparacionPedido pantalla)
        {
            this.pantalla = pantalla;
        }


        public void finalizarPedido()
        {
            buscarDetallesPedidoEnPreparacion();
            ordenarSegunMayorTiempoEspera();

            string[] datosDetallesEnPreparacion;

            for (int i = 0; i < detallesPedidoEnPreparacion.Count; i++)
            {
                datosDetallesEnPreparacion = buscarInfoDetallePedido(detallesPedidoEnPreparacion[i]);
                pantalla.mostrarDatosDetallePedidoEnPreparacion(
                    datosDetallesEnPreparacion[0],
                    datosDetallesEnPreparacion[1],
                    datosDetallesEnPreparacion[2],
                    datosDetallesEnPreparacion[3],
                    datosDetallesEnPreparacion[4]);
            }
        }

        private string[] buscarInfoDetallePedido(DetalleDePedido detalle)
        {
            string[] datos = new string[5];
            Mesa[] mesas = (Mesa[]) FachadaPersistencia.getInstancia().Materializar(typeof(Mesa));
            Pedido[] pedidos = (Pedido[]) FachadaPersistencia.getInstancia().Materializar(typeof(Pedido));

            datos[0] = detalle.getHora().ToString("hh:mm:ss");
            datos[1] = detalle.mostrarNombreProducto();
            datos[2] = detalle.mostrarNombreMenu();
            datos[3] = detalle.getCantidad();
            datos[4] = detalle.mostrarMesa(mesas, pedidos);

            return datos;
        }

        private void ordenarSegunMayorTiempoEspera()
        {
            DateTime hora = getFechaHoraActual();

            if (detallesPedidoEnPreparacion.Count <= 1) return;

            for (int i = 0; i < detallesPedidoEnPreparacion.Count - 1; i++)
            {
                for (int j = i + 1; j < detallesPedidoEnPreparacion.Count; j++)
                {
                    int esperai = detallesPedidoEnPreparacion[i].calcularEspera(hora);
                    int esperaj = detallesPedidoEnPreparacion[j].calcularEspera(hora);
                    if ( esperai < esperaj)
                    {
                        DetalleDePedido temp = detallesPedidoEnPreparacion[i];
                        detallesPedidoEnPreparacion[i] = detallesPedidoEnPreparacion[j];
                        detallesPedidoEnPreparacion[j] = temp;
                    }
                }
            }            
        }

        private DateTime getFechaHoraActual()
        {
            return DateTime.Now;
        }

        private void buscarDetallesPedidoEnPreparacion()
        {
            DetalleDePedido[] detalles = (DetalleDePedido[]) FachadaPersistencia.getInstancia().Materializar(typeof(DetalleDePedido));
            Estado[] estados = (Estado[])FachadaPersistencia.getInstancia().Materializar(typeof(Estado));
            
            Estado enPreparacion = new Estado();

            foreach (Estado e in estados)
            {
                if (e.esAmbitoDetallePedido() && e.esEnPreparacion())
                {
                    enPreparacion = e;
                    break;
                }
            }

            foreach (DetalleDePedido dp in detalles)
            {
                if (dp.estaEnPreparacion(enPreparacion))
                {
                    detallesPedidoEnPreparacion.Add(dp);
                }
            }


        }

        public void detalleDePedidoSeleccionado(DetalleDePedido detalle)
        {
            detallePedidoSeleccionadosAServir.Add(detalle);
        }

        private void notificar() { }

        public void notificarEstadoDetalleDePedido() { }

        public void confirmarElaboracion()
        {
        }

        public void quitar() { }
        public void suscribir() { }
            
    }
}
