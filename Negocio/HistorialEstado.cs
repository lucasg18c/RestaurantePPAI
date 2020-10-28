using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePPAI.Negocio
{
    class HistorialEstado
    {
        private String estado;
        private String fechaHoraFin;
        private String fechaHoraInicio;

        public HistorialEstado(string estado, string fechaHoraFin, string fechaHoraInicio)
        {
            this.estado = estado;
            this.fechaHoraFin = fechaHoraFin;
            this.fechaHoraInicio = fechaHoraInicio;
        }


    }

}
