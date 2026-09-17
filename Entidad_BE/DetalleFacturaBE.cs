namespace Entidad_BE
{
    public class DetalleFacturaBE_883SC
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

        //Precio congelado al momento de armar el carrito (CUN-002)
        private decimal _precioUnitario_883SC;
        public decimal PrecioUnitario_883SC
        {
            get { return _precioUnitario_883SC; }
            set { _precioUnitario_883SC = value; }
        }
    }
}
