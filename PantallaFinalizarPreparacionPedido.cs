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
        private GestorFinalizarPreparacion gestor;
        private List<DetalleDePedido> detalles;

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
            DialogResult r = MessageBox.Show(
                "Desea confirmar la finalización de la preparación de los productos seleccionados?",
                "Confirmar finalización",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (tomarConfirmarElaboracion(r))
            {
                gestor.confirmarElaboracion();
            }
        }


        public bool tomarConfirmarElaboracion(DialogResult r)
        {
            return r == DialogResult.Yes;
        }


        public void tomarSeleccionDeDetalle(int fila)
        {
            //gestor.detalleDePedidoSeleccionado(detalles[fila]);
        }

        private void abrirVentana(object sender, EventArgs e)
        {
            cargarCombo();

            gestor = new GestorFinalizarPreparacion(this);
            gestor.finalizarPedido();


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
            Close();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            bool haySeleccionados = false;

            for (int i = 0; i < grillaPedidos.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell celda = (DataGridViewCheckBoxCell) grillaPedidos.Rows[i].Cells[5];
                if (celda.Value != null)
                {
                    tomarSeleccionDeDetalle(i);
                    haySeleccionados = true;
                }
            }
            if (haySeleccionados) solicitarConfirmacionElaboracionProducto();
            else mostrarErrorSinSeleccionados();
        }

        private void mostrarErrorSinSeleccionados()
        {
            MessageBox.Show(
                "No hay detalles seleccionados",
                "Ocurrió un error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
