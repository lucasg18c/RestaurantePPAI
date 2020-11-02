using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePPAI.Soporte
{
    public interface ISujetoDetallePedido
    {
        //IObservadorDetallePedido[] observadores;

        void notificar();

        void quitar(IObservadorDetallePedido observador);

        void suscribir(IObservadorDetallePedido[] observador);

    }
}
