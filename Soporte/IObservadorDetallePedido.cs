using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePPAI.Soporte
{
    public interface IObservadorDetallePedido
    {
        void actualizar(string numeroMesa, string cantidadProducto);
    }
}
