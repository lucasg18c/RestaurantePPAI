using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePPAI.Negocio
{
    class HistorialEstado
    {
        private Estado estado;
        private DateTime fechaHoraFin;
        private DateTime fechaHoraInicio;

        public HistorialEstado(Estado estado, DateTime fechaHoraInicio)
        {
            this.estado = estado;
            this.fechaHoraInicio = fechaHoraInicio;
        }

        public bool esEnPreparacion()
        {
            return estado.esEnPreparacion();
        }

        public bool esUltimoHistorial()
        {
            return fechaHoraFin == new DateTime();
        }

        public bool esEstado(Estado enPreparacion)
        {
            return estado == enPreparacion;
        }
    }

}
