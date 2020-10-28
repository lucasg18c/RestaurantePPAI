using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePPAI.Soporte
{
    interface ISujetoDetallePedido
    {
        private void IObservadorDetalleDePedido[] observadores;

        public void notificar() { };

        public void quitar(IObservadorDetalleDePedido observador) { };

        public void suscribir(IObservadorDetalleDePedido observador) { };

        public void tomarConfFinalizar() { };


    }
}
