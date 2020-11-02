using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePPAI.Negocio
{
    public class Estado
    {
        private string nombre;
        private string ambito;

        public Estado()
        {

        }

        public Estado(string nombre, string ambito)
        {
            this.nombre = nombre;
            this.ambito = ambito;
        }

        public bool esAmbitoDetallePedido()
        {
            return ambito == "DetallePedido";
        }

        public bool esEnPreparacion()
        {
            return nombre == "EnPreparacion";
        }

        public bool esListoParaServir()
        {
            return nombre == "ListoParaServir";
        }

        public bool esNotificado()
        {
            return nombre == "Notificado";
        }
    }
}
