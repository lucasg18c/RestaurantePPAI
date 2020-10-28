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
        private List<DetalleDePedido> datosPedidoEnPreparacion; 
        private List<DetalleDePedido> detallePedidoNotificados;

        private PantallaFinalizarPreparacionPedido pantalla;

        public GestorFinalizarPreparacion(PantallaFinalizarPreparacionPedido pantalla)
        {
            this.pantalla = pantalla;
        }


        public void finalizarPedido()
        {
            buscarDetallesPedidoEnPreparacion();
            ordenarSegunTiempoEspera();
        }

        private void ordenarSegunTiempoEspera()
        {
            //TODO
            //temporal
            pantalla.mostrarDatosDetallePedidoEnPreparacion("hamburguesa", "-", 3, 21, DateTime.Now);
            pantalla.mostrarDatosDetallePedidoEnPreparacion("pizza", "-", 1, 14, DateTime.Now);
            pantalla.mostrarDatosDetallePedidoEnPreparacion("milanesa", "re piola", 5, 3, DateTime.Now);
            pantalla.mostrarDatosDetallePedidoEnPreparacion("zapallo", "#vegan4lifeXD", 9, 7, DateTime.Now);
        }

        private void buscarDetallesPedidoEnPreparacion()
        {

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
