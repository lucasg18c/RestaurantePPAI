using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePPAI.Soporte
{
    interface IObservadorDetalleDePedido
    {
        void actualizar(String numeroMesa, String estado,
            String hora, String cantidadProductos, String mozo);
    }
}
