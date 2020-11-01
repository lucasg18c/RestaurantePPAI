﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePPAI.Soporte
{
    interface ISujetoDetallePedido
    {
        //private IObservadorDetalleDePedido[] observadores;

        void notificar();

        void quitar(IObservadorDetallePedido observador);

        void suscribir(IObservadorDetallePedido observador);

        void tomarConfFinalizar();


    }
}
