using RestaurantePPAI.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantePPAI
{
    public partial class PantallaFinalizarPreparacionPedido : Form
    {
        private DetalleDePedido[] listaDetallesAServir;
        private DetalleDePedido[] listaDetallesEnPreparacion;

        public PantallaFinalizarPreparacionPedido()
        {
            InitializeComponent();
        }

        public void mostrarDatosDetallePedidoEnPreparacion()
        {

        }

        public void solicitarConfirmacionElaboracionProducto()
        {

        }

        public void solicitarSeleccionDeUnoOVariosDetalles()
        {

        }

        public void tomarConfirmarElaboracion()
        {

        }

        public void tomarOpcionFinalizarPedido()
        {

        }

        public void tomarSeleccionDeDetalle()
        {

        }

        private void abrirVentana(object sender, EventArgs e)
        {
            cargarCombo();
        }

        private void cargarCombo()
        {
            cmbOrdenar.Items.Add("Tiempo de espera");
            cmbOrdenar.Items.Add("Sección");
            cmbOrdenar.Items.Add("Mesa");
            cmbOrdenar.Items.Add("Mozo");
            cmbOrdenar.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {

        }

        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
