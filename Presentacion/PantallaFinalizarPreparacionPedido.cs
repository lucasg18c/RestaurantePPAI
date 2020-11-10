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
        private bool ventanaAbierta = false;

        public PantallaFinalizarPreparacionPedido()
        {
            InitializeComponent();
        }

        private void abrirVentana(object sender, EventArgs e)
        {
            cargarCombo();

            gestor = new GestorFinalizarPreparacion(this);
            gestor.finalizarPedido();
            ventanaAbierta = true;

        }

        public void mostrarDatosDetallePedidoEnPreparacion(string hora, string nombreDeProductoOMenu, string cantidad, string numeroMesa)
        {
            string[] fila = new string[]
            {
                hora,
                nombreDeProductoOMenu,
                cantidad,
                numeroMesa,

            };
            grillaPedidos.Rows.Add(fila);
        }

        private void finalizarPedidosSeleccionados(object sender, EventArgs e)
        {
            bool haySeleccionados = false;

            for (int i = 0; i < grillaPedidos.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell celda = (DataGridViewCheckBoxCell)grillaPedidos.Rows[i].Cells[4];
                if (celda.Value != null)
                {
                    tomarSeleccionDeDetalle(i);
                    haySeleccionados = true;
                }
            }
            if (haySeleccionados) solicitarConfirmacionElaboracionProducto();
            else mostrarErrorSinSeleccionados();
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
            gestor.detalleDePedidoSeleccionado(fila);
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string metodoOrdenamiento()
        {
            return cmbOrdenar.Text;
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
            if (ventanaAbierta)
            {
                limpiar();
                gestor.filtrarDetalles();
            }
        }

        public void limpiar()
        {
            grillaPedidos.Rows.Clear();
        }

        private void cargarCombo()
        {
            cmbOrdenar.Items.Add("Tiempo de espera");
            cmbOrdenar.Items.Add("Sección");
            cmbOrdenar.Items.Add("Mesa");
            cmbOrdenar.Items.Add("Mozo");
            cmbOrdenar.SelectedIndex = 0;
        }
    }
}
