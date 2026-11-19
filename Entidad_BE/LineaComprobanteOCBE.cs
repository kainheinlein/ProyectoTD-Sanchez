namespace Entidad_BE
{
    //Linea del comprobante de orden de compra (solo datos, ya persistidos)
    public class LineaComprobanteOCBE_883SC
    {
        private string _codigoProveedor_883SC;
        public string CodigoProveedor_883SC
        {
            get { return _codigoProveedor_883SC; }
            set { _codigoProveedor_883SC = value; }
        }

        private string _descripcion_883SC;
        public string Descripcion_883SC
        {
            get { return _descripcion_883SC; }
            set { _descripcion_883SC = value; }
        }

        private int _cantidad_883SC;
        public int Cantidad_883SC
        {
            get { return _cantidad_883SC; }
            set { _cantidad_883SC = value; }
        }

        //Precio congelado de DetalleOrdenCompra
        private decimal _precioUnitario_883SC;
        public decimal PrecioUnitario_883SC
        {
            get { return _precioUnitario_883SC; }
            set { _precioUnitario_883SC = value; }
        }

        public decimal Subtotal_883SC
        {
            get { return _cantidad_883SC * _precioUnitario_883SC; }
        }
    }
}
