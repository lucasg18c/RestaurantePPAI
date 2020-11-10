using RestaurantePPAI.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePPAI.Persistencia
{
    public class FachadaPersistencia
    {
        // ESTA CLASE ES UNA SIMULACIÓN DE UNA FACHADA DE PERSISTENCIA Y
        // NO SE ESPERA QUE CUMPLA CON UNA IMPLEMENTACIÓN REAL.
        // TIENE EL ÚNICO FIN DE TESTEAR EL CU DESARROLLADO

        private static FachadaPersistencia instancia;

        private List<DetalleDePedido> detalles = new List<DetalleDePedido>();
        private List<Estado> estados = new List<Estado>();
        private List<Mesa> mesas = new List<Mesa>();
        private List<Pedido> pedidos = new List<Pedido>();

        private FachadaPersistencia()
        {
            Estado enPreparacion = new Estado("EnPreparacion", "DetallePedido");
            Estado pendiente = new Estado("PendientePreparacion", "DetallePedido");
            Estado listo = new Estado("ListoParaServir", "DetallePedido");
            Estado notificado = new Estado("Notificado", "DetallePedido");

            estados.Add(enPreparacion);
            estados.Add(pendiente);
            estados.Add(listo);
            estados.Add(notificado);

            pedidos.Add(new Pedido());
            pedidos.Add(new Pedido());
            pedidos.Add(new Pedido());

            detalles.Add(new DetalleDePedido(pedidos[0], 3, DateTime.Now, new ProductoDeCarta(new Producto("Hamburguesa", 300)), enPreparacion));
            detalles.Add(new DetalleDePedido(pedidos[0], 1, new DateTime(2020, 10, 31, 22, 20,0), new ProductoDeCarta(new Producto("Pizza", 400)), enPreparacion));
            detalles.Add(new DetalleDePedido(pedidos[1], 3, new DateTime(2020, 10, 31, 22, 38,0), new ProductoDeCarta(new Producto("Milanesa", 250)), enPreparacion));
            detalles.Add(new DetalleDePedido(pedidos[2], 2, new DateTime(2020, 10, 31, 22, 10,0), new ProductoDeCarta(new Producto("Zapallo", 900)), enPreparacion));
            detalles.Add(new DetalleDePedido(pedidos[2], 5, new DateTime(2020, 10, 31, 22, 13,0), new ProductoDeCarta(new Producto("Fideos", 120)), enPreparacion));


            pedidos[0].agregarDetalle(detalles[0]);
            pedidos[0].agregarDetalle(detalles[1]);
            pedidos[1].agregarDetalle(detalles[2]);
            pedidos[2].agregarDetalle(detalles[3]);
            pedidos[2].agregarDetalle(detalles[4]);


            for (int i = 0; i < 3; i++)
            {
                Mesa m = new Mesa(23 + i * 2);
                m.agregarPedido(pedidos[i]);
                m.setSeccion(new Seccion($"sección {23 + i * 2}"));
                mesas.Add(m);
                pedidos[i].setMesa(m);
            }
        }

        public static FachadaPersistencia getInstancia()
        {
            if (instancia == null) instancia = new FachadaPersistencia();
            return instancia;
        }

        public object[] Materializar(Type clase)
        {
            switch (clase.Name)
            {
                case "DetalleDePedido":
                    return detalles.ToArray();
                case "Estado":
                    return estados.ToArray();                
                case "Mesa":
                    return mesas.ToArray();
                case "Pedido":
                    return pedidos.ToArray();
            }
            return null;
        }
    }
}
