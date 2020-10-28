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

        public PantallaFinalizarPreparacionPedido()
        {
            InitializeComponent();
        }

        public void mostrarDatosDetallePedidoEnPreparacion(string nombreProducto, string nombreMenu, int cantidad, int numeroMesa, DateTime hora)
        {
            string[] fila = new string[]
            {
                nombreProducto,
                nombreMenu,
                cantidad.ToString(),
                numeroMesa.ToString(),
                hora.ToString("hh:mm:ss")
            };
            grillaPedidos.Rows.Add(fila);
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

            mostrarDatosDetallePedidoEnPreparacion("hamburguesa", "-", 3, 21, DateTime.Now);
            mostrarDatosDetallePedidoEnPreparacion("pizza", "-", 1, 14, DateTime.Now);
            mostrarDatosDetallePedidoEnPreparacion("milanesa", "re piola", 5, 3, DateTime.Now);
            mostrarDatosDetallePedidoEnPreparacion("zapallo", "#vegan4lifeXD", 9, 7, DateTime.Now);

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
