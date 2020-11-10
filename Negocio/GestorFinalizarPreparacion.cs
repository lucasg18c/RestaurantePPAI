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

        private List<DetalleDePedido> detallePedidoSeleccionadosAServir = new List<DetalleDePedido>(); 
        private List<DetalleDePedido> detallesPedidoEnPreparacion = new List<DetalleDePedido>(); 
        private List<IObservadorDetallePedido> observadores = new List<IObservadorDetallePedido>();
        private PantallaFinalizarPreparacionPedido pantalla;

        public GestorFinalizarPreparacion(PantallaFinalizarPreparacionPedido pantalla)
        {
            this.pantalla = pantalla;
        }

        public void finalizarPedido()
        {
            buscarDetallesPedidoEnPreparacion();
            ordenar();
            mostrarDatosDetalles();
        }

        public void confirmarElaboracion()
        {
            actualizarEstadoDetallePedido();
            obtenerObservadores();
            notificar();
            actualizarEstadoDetallePedidoNotificado();

            finCU();
        }

        private void buscarDetallesPedidoEnPreparacion()
        {
            DetalleDePedido[] detalles = (DetalleDePedido[])FachadaPersistencia.getInstancia().Materializar(typeof(DetalleDePedido));
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

        private void ordenar()
        {
            if (detallesPedidoEnPreparacion.Count < 2) return;

            string ordenamiento = pantalla.metodoOrdenamiento();

            switch (ordenamiento)
            {
                case "Tiempo de espera":
                    ordenarSegunMayorTiempoEspera();
                    break;
                case "Sección":
                    ordenarSegunSeccion();
                    break;
                case "Mesa":
                    ordenarSegunMesa();
                    break;
                case "Mozo":
                    ordenarSegunMozo();
                    break;
            }
        }

        private void ordenarSegunMayorTiempoEspera()
        {
            DateTime hora = getFechaHoraActual();

            for (int i = 0; i < detallesPedidoEnPreparacion.Count - 1; i++)
            {
                for (int j = i + 1; j < detallesPedidoEnPreparacion.Count; j++)
                {
                    int esperai = detallesPedidoEnPreparacion[i].calcularEspera(hora);
                    int esperaj = detallesPedidoEnPreparacion[j].calcularEspera(hora);
                    if (esperai < esperaj)
                    {
                        DetalleDePedido temp = detallesPedidoEnPreparacion[i];
                        detallesPedidoEnPreparacion[i] = detallesPedidoEnPreparacion[j];
                        detallesPedidoEnPreparacion[j] = temp;
                    }
                }
            }
        }

        private void mostrarDatosDetalles()
        {
            for (int i = 0; i < detallesPedidoEnPreparacion.Count; i++)
            {
                string hora = detallesPedidoEnPreparacion[i].getHora().ToString("hh:mm:ss");

                string nombre = buscarInfoDetallePedido(detallesPedidoEnPreparacion[i]);

                string cantidad = detallesPedidoEnPreparacion[i].getCantidad();

                string mesa = buscarMesaDelDetalleEnPreparacion(detallesPedidoEnPreparacion[i]);

                pantalla.mostrarDatosDetallePedidoEnPreparacion(hora, nombre, cantidad, mesa);
            }
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

        private void obtenerObservadores()
        {
            List<IObservadorDetallePedido> interfaces = new List<IObservadorDetallePedido>();
            interfaces.AddRange(Program.getMozosMovil());
            interfaces.AddRange(Program.getMozosMonitor());

            suscribir(interfaces.ToArray());
        }

        public void notificar()
        {
            foreach (IObservadorDetallePedido o in observadores)
            {
                foreach (DetalleDePedido d in detallePedidoSeleccionadosAServir)
                {
                    o.actualizar(d.mostrarMesa(), d.getCantidad());
                }
            }
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

        public void suscribir(IObservadorDetallePedido[] observador)
        {
            foreach (IObservadorDetallePedido o in observador)
            {
                if (!observadores.Contains(o)) observadores.Add(o);
                //observadores.Add(o);
            }
        }

        public void quitar(IObservadorDetallePedido observador)
        {
            observadores.Remove(observador);
        }

        public void filtrarDetalles()
        {
            ordenar();
            mostrarDatosDetalles();
        }

        private void ordenarSegunMozo()
        {
            for (int i = 0; i < detallesPedidoEnPreparacion.Count - 1; i++)
            {
                for (int j = i + 1; j < detallesPedidoEnPreparacion.Count; j++)
                {
                    string mozoi = detallesPedidoEnPreparacion[i].mostrarMozo();
                    string mozoj = detallesPedidoEnPreparacion[j].mostrarMozo();
                    if (mozoi.CompareTo(mozoj) > 0)
                    {
                        DetalleDePedido temp = detallesPedidoEnPreparacion[i];
                        detallesPedidoEnPreparacion[i] = detallesPedidoEnPreparacion[j];
                        detallesPedidoEnPreparacion[j] = temp;
                    }
                }
            }
        }

        private void ordenarSegunMesa()
        {
            for (int i = 0; i < detallesPedidoEnPreparacion.Count - 1; i++)
            {
                for (int j = i + 1; j < detallesPedidoEnPreparacion.Count; j++)
                {
                    string mesai = detallesPedidoEnPreparacion[i].mostrarMesa();
                    string mesaj = detallesPedidoEnPreparacion[j].mostrarMesa();
                    if (mesai.CompareTo(mesaj) > 0)
                    {
                        DetalleDePedido temp = detallesPedidoEnPreparacion[i];
                        detallesPedidoEnPreparacion[i] = detallesPedidoEnPreparacion[j];
                        detallesPedidoEnPreparacion[j] = temp;
                    }
                }
            }
        }

        private void ordenarSegunSeccion()
        {
            for (int i = 0; i < detallesPedidoEnPreparacion.Count - 1; i++)
            {
                for (int j = i + 1; j < detallesPedidoEnPreparacion.Count; j++)
                {
                    string seccioni = detallesPedidoEnPreparacion[i].getSeccion();
                    string seccionj = detallesPedidoEnPreparacion[j].getSeccion();
                    if (seccioni.CompareTo(seccionj) > 0)
                    {
                        DetalleDePedido temp = detallesPedidoEnPreparacion[i];
                        detallesPedidoEnPreparacion[i] = detallesPedidoEnPreparacion[j];
                        detallesPedidoEnPreparacion[j] = temp;
                    }
                }
            }
        }

        private string buscarMesaDelDetalleEnPreparacion(DetalleDePedido detalleDePedido)
        {
            return detalleDePedido.mostrarMesa();
        }

        private string buscarInfoDetallePedido(DetalleDePedido detalle)
        {
            if (detalle.esProductoDeCarta()) return detalle.mostrarNombreProducto();

            return detalle.mostrarNombreMenu();
        }

        private DateTime getFechaHoraActual()
        {
            return DateTime.Now;
        }

        public void detalleDePedidoSeleccionado(int indice)
        {
            detallePedidoSeleccionadosAServir.Add(detallesPedidoEnPreparacion[ indice ]);
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
            //pantalla.Close();
        }

    }
}
