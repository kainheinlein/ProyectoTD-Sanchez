using System;
using System.Collections.Generic;

namespace Entidad_BE
{
    public class ReporteVentasBE_883SC
    {
        private DateTime _desde_883SC;
        public DateTime Desde_883SC
        {
            get { return _desde_883SC; }
            set { _desde_883SC = value; }
        }

        private DateTime _hasta_883SC;
        public DateTime Hasta_883SC
        {
            get { return _hasta_883SC; }
            set { _hasta_883SC = value; }
        }

        private int _cantidadVentas_883SC;
        public int CantidadVentas_883SC
        {
            get { return _cantidadVentas_883SC; }
            set { _cantidadVentas_883SC = value; }
        }

        private int _unidadesVendidas_883SC;
        public int UnidadesVendidas_883SC
        {
            get { return _unidadesVendidas_883SC; }
            set { _unidadesVendidas_883SC = value; }
        }

        private decimal _montoTotal_883SC;
        public decimal MontoTotal_883SC
        {
            get { return _montoTotal_883SC; }
            set { _montoTotal_883SC = value; }
        }

        //Calculado: monto total / cantidad de ventas, redondeado a 2 decimales (0 si no hay ventas)
        public decimal TicketPromedio_883SC
        {
            get
            {
                if (_cantidadVentas_883SC == 0) { return 0m; }
                return Math.Round(_montoTotal_883SC / _cantidadVentas_883SC, 2, MidpointRounding.AwayFromZero);
            }
        }

        private List<VentaDiariaBE_883SC> _ventasPorDia_883SC = new List<VentaDiariaBE_883SC>();
        public List<VentaDiariaBE_883SC> VentasPorDia_883SC
        {
            get { return _ventasPorDia_883SC; }
            set { _ventasPorDia_883SC = value; }
        }

        private List<ProductoVendidoBE_883SC> _topProductos_883SC = new List<ProductoVendidoBE_883SC>();
        public List<ProductoVendidoBE_883SC> TopProductos_883SC
        {
            get { return _topProductos_883SC; }
            set { _topProductos_883SC = value; }
        }
    }
}
