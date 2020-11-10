using RestaurantePPAI.Negocio;
using RestaurantePPAI.Presentacion;
using RestaurantePPAI.Soporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantePPAI
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mozosMovil.Add(new InterfazDispositivoMovil());
            mozosMovil.Add(new InterfazDispositivoMovil());

            mozosMonitor.Add(new InterfazMonitor());

            foreach (IObservadorDetallePedido m in mozosMovil) ((Form)m).Show();
            foreach (IObservadorDetallePedido m in mozosMonitor) ((Form)m).Show();

            Application.Run(new PantallaFinalizarPreparacionPedido());

        }

        static List<IObservadorDetallePedido> mozosMovil = new List<IObservadorDetallePedido>();
        static List<IObservadorDetallePedido> mozosMonitor = new List<IObservadorDetallePedido>();

        public static List<IObservadorDetallePedido> getMozosMovil()
        {
            return mozosMovil;
        }

        public static List<IObservadorDetallePedido> getMozosMonitor()
        {
            return mozosMonitor;
        }
    }
}
