namespace Entidad_BE
{
    public class ProductoBE_883SC
    {
        private string _codigo_883SC;
        public string Codigo_883SC
        {
            get { return _codigo_883SC; }
            set { _codigo_883SC = value; }
        }

        private string _nombre_883SC;
        public string Nombre_883SC
        {
            get { return _nombre_883SC; }
            set { _nombre_883SC = value; }
        }

        private int _stock_883SC;
        public int Stock_883SC
        {
            get { return _stock_883SC; }
            set { _stock_883SC = value; }
        }

        private string _tipo_883SC;
        public string Tipo_883SC
        {
            get { return _tipo_883SC; }
            set { _tipo_883SC = value; }
        }

        private decimal _precio_883SC;
        public decimal Precio_883SC
        {
            get { return _precio_883SC; }
            set { _precio_883SC = value; }
        }

        private int _stockMinimo_883SC;
        public int StockMinimo_883SC
        {
            get { return _stockMinimo_883SC; }
            set { _stockMinimo_883SC = value; }
        }

        private int _proveedor_883SC;
        public int Proveedor_883SC
        {
            get { return _proveedor_883SC; }
            set { _proveedor_883SC = value; }
        }

        //Solo lo completa ListarBajoStock_SP: proveedores activos con el producto vinculado
        private int _cantidadProveedores_883SC;
        public int CantidadProveedores_883SC
        {
            get { return _cantidadProveedores_883SC; }
            set { _cantidadProveedores_883SC = value; }
        }

        //Calculada: lo que falta para llegar al stock minimo (0 si ya lo alcanzo)
        public int CantidadFaltante_883SC
        {
            get { return _stock_883SC < _stockMinimo_883SC ? _stockMinimo_883SC - _stock_883SC : 0; }
        }
    }
}
