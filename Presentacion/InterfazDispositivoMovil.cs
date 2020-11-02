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
using RestaurantePPAI.Soporte;

namespace RestaurantePPAI.Negocio
{
    public partial class InterfazDispositivoMovil : Form, IObservadorDetallePedido
    {
        SoundPlayer sp;
        public InterfazDispositivoMovil()
        {
            InitializeComponent();
            sp = new SoundPlayer(@"C:\Users\lucas\Desktop\RestaurantePPAI\Resources\bit-sonoro.wav");
        }

        public void actualizar(string numeroMesa, string cantidadProducto)
        {
            dgvPedidos.Rows.Add(new string[] { numeroMesa, cantidadProducto });

            mostrarNotificacion();

        }

        private void mostrarNotificacion()
        {
            timer1.Start();
            imgCampana.Visible = true;
            sp.Play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            imgCampana.Visible = false;
        }
    }
}
