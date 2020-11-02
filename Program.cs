using RestaurantePPAI.Negocio;
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

            foreach (IObservadorDetallePedido m in mozosMovil) ((Form)m).Show();

            Application.Run(new PantallaFinalizarPreparacionPedido());

        }

        static List<IObservadorDetallePedido> mozosMovil = new List<IObservadorDetallePedido>();
        static List<IObservadorDetallePedido> mozosMonitor;

        public static List<IObservadorDetallePedido> getMozosMovil()
        {
            return mozosMovil;
        }
    }
}
