using System;

namespace Entidad_BE
{
    public class LineaCompraBE_883SC
    {
        private ProductoBE_883SC _producto_883SC;
        public ProductoBE_883SC Producto_883SC
        {
            get { return _producto_883SC; }
            set { _producto_883SC = value; }
        }

        private ProveedorBE_883SC _proveedor_883SC;
        public ProveedorBE_883SC Proveedor_883SC
        {
            get { return _proveedor_883SC; }
            set { _proveedor_883SC = value; }
        }

        private int _cantidad_883SC;
        public int Cantidad_883SC
        {
            get { return _cantidad_883SC; }
            set { _cantidad_883SC = value; }
        }

        private decimal _precioLista_883SC;
        public decimal PrecioLista_883SC
        {
            get { return _precioLista_883SC; }
            set { _precioLista_883SC = value; }
        }

        private DateTime _fechaActualizacion_883SC;
        public DateTime FechaActualizacion_883SC
        {
            get { return _fechaActualizacion_883SC; }
            set { _fechaActualizacion_883SC = value; }
        }

        public decimal Subtotal_883SC
        {
            get { return _cantidad_883SC * _precioLista_883SC; }
        }
    }
}
