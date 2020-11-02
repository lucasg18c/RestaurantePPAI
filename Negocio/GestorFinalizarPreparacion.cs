using RestaurantePPAI.Persistencia;
using RestaurantePPAI.Soporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePPAI.Negocio 
{
    public class GestorFinalizarPreparacion : ISujetoDetallePedido{
        //private Estado estado;
        //private Sesion sesion;
        //private InterfazDispositivoMovil dispositivoMovil;
        //private InterfazMonitor monitor;

        private List<DetalleDePedido> detallePedidoSeleccionadosAServir = new List<DetalleDePedido>(); 
        private List<DetalleDePedido> detallesPedidoEnPreparacion = new List<DetalleDePedido>(); 
        private List<DetalleDePedido> detallePedidoNotificados = new List<DetalleDePedido>();

        private List<IObservadorDetallePedido> observadores = new List<IObservadorDetallePedido>();


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

        public void detalleDePedidoSeleccionado(int indice)
        {
            detallePedidoSeleccionadosAServir.Add(detallesPedidoEnPreparacion[ indice ]);
        }

        public void confirmarElaboracion()
        {
            obtenerObservadores();
            actualizarEstadoDetallePedido();
            notificar();
            actualizarEstadoDetallePedidoNotificado();

            finCU();

        }

        private void finCU()
        {
            foreach (DetalleDePedido dselec in detallePedidoSeleccionadosAServir)
            {
                foreach (DetalleDePedido d in detallesPedidoEnPreparacion)
                {
                    if (dselec == d)
                    {
                        detallesPedidoEnPreparacion.Remove(d);
                        break;
                    }
                }

            }

            detallePedidoSeleccionadosAServir = new List<DetalleDePedido>();
            detallesPedidoEnPreparacion = new List<DetalleDePedido>();
            pantalla.limpiar();
            finalizarPedido();

        }

        private void actualizarEstadoDetallePedidoNotificado()
        {
            Estado estadoNotificado = new Estado();
            Estado[] estados = (Estado[])FachadaPersistencia.getInstancia().Materializar(typeof(Estado));
            DateTime horaActual = getFechaHoraActual();

            foreach (Estado e in estados)
            {
                if (e.esAmbitoDetallePedido() && e.esNotificado())
                {
                    estadoNotificado = e;
                    break;
                }
            }

            foreach (DetalleDePedido dp in detallePedidoSeleccionadosAServir)
            {
                dp.notificar(estadoNotificado, horaActual);
            }
        }

        private void obtenerObservadores()
        {
            List<IObservadorDetallePedido> interfacesMovil = Program.getMozosMovil();
            //List<IObservadorDetallePedido> interfacesMonitor = Program.getMozosMonitor();

            suscribir(interfacesMovil.ToArray());
            //suscribir(interfacesMonitor.ToArray());

        }

    private void actualizarEstadoDetallePedido()
        {
            Estado estadoListo = new Estado();
            Estado[] estados = (Estado[])FachadaPersistencia.getInstancia().Materializar(typeof(Estado));
            DateTime horaActual = getFechaHoraActual();

            foreach (Estado e in estados)
            {
                if (e.esAmbitoDetallePedido() && e.esListoParaServir())
                {
                    estadoListo = e;
                    break;
                }
            }

            foreach (DetalleDePedido dp in detallePedidoSeleccionadosAServir)
            {
                dp.finalizar(estadoListo, horaActual);
            }
        }

        public void notificar()
        {
            Mesa[] mesas = (Mesa[])FachadaPersistencia.getInstancia().Materializar(typeof(Mesa));
            Pedido[] pedidos = (Pedido[])FachadaPersistencia.getInstancia().Materializar(typeof(Pedido));

            foreach (IObservadorDetallePedido o in observadores)
            {
                foreach (DetalleDePedido d in detallePedidoSeleccionadosAServir)
                {
                    o.actualizar(
                        d.mostrarMesa(mesas, pedidos), 
                        d.getCantidad());
                }
            }
        }

        public void quitar(IObservadorDetallePedido observador)
        {
            throw new NotImplementedException();
        }

        public void suscribir(IObservadorDetallePedido[] observador)
        {
            foreach (IObservadorDetallePedido o in observador)
            {
                if (!observadores.Contains(o)) observadores.Add(o);
            }
        }
    }
}
