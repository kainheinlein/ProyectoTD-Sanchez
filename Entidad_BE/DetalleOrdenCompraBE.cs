namespace Entidad_BE
{
    public class DetalleOrdenCompraBE_883SC
    {
        private ProductoBE_883SC _producto_883SC;
        public ProductoBE_883SC Producto_883SC
        {
            get { return _producto_883SC; }
            set { _producto_883SC = value; }
        }

        private int _cantidad_883SC;
        public int Cantidad_883SC
        {
            get { return _cantidad_883SC; }
            set { _cantidad_883SC = value; }
        }

        //Snapshot del precio de lista al generar la orden
        private decimal _precioUnitario_883SC;
        public decimal PrecioUnitario_883SC
        {
            get { return _precioUnitario_883SC; }
            set { _precioUnitario_883SC = value; }
        }

        //null hasta registrar la recepcion
        private int? _cantidadRecibida_883SC;
        public int? CantidadRecibida_883SC
        {
            get { return _cantidadRecibida_883SC; }
            set { _cantidadRecibida_883SC = value; }
        }

        public decimal Subtotal_883SC
        {
            get { return _cantidad_883SC * _precioUnitario_883SC; }
        }
    }
}
