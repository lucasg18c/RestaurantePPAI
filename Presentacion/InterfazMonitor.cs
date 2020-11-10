using RestaurantePPAI.Soporte;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantePPAI.Presentacion
{
    public partial class InterfazMonitor : Form, IObservadorDetallePedido
    {
        SoundPlayer sp;

        public InterfazMonitor()
        {
            InitializeComponent();
            sp = new SoundPlayer(@"C:\Users\lucas\Desktop\RestaurantePPAI\Resources\bit-sonoro.wav");
        }

        public void actualizar(string numeroMesa, string cantidadProducto)
        {
            visualizar(numeroMesa, cantidadProducto);

            mostrarNotificacion();
        }

        private void mostrarNotificacion()
        {
            imgCampana.Visible = true;
            timer1.Start();
            sp.Play();

        }

        private void visualizar(string numeroMesa, string cantidadProducto)
        {
            grillaPedidos.Rows.Add(new string[] { numeroMesa, cantidadProducto });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            imgCampana.Visible = false;
            timer1.Stop();
        }
    }
}
