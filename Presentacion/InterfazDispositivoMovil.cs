using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantePPAI.Soporte;

namespace RestaurantePPAI.Negocio
{
    public partial class InterfazDispositivoMovil : Form, IObservadorDetallePedido
    {
        public InterfazDispositivoMovil()
        {
            InitializeComponent();
        }

        public void actualizar(string numeroMesa, string estado, DateTime hora, string cantidadProducto, string mozo)
        {

        }
    }
}
