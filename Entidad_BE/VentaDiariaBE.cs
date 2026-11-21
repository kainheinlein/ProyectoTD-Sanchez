using System;

namespace Entidad_BE
{
    public class VentaDiariaBE_883SC
    {
        private DateTime _fecha_883SC;
        public DateTime Fecha_883SC
        {
            get { return _fecha_883SC; }
            set { _fecha_883SC = value; }
        }

        private int _cantidadVentas_883SC;
        public int CantidadVentas_883SC
        {
            get { return _cantidadVentas_883SC; }
            set { _cantidadVentas_883SC = value; }
        }

        private decimal _importe_883SC;
        public decimal Importe_883SC
        {
            get { return _importe_883SC; }
            set { _importe_883SC = value; }
        }
    }
}
