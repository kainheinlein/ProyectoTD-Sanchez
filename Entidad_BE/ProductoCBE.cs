using System;

namespace Entidad_BE
{
    /// Una version historica de un producto (fila de Productos_C). Solo datos: la arma el Mapper.
    public class ProductoCBE_883SC
    {
        private int _idCambio_883SC;
        public int IdCambio_883SC
        {
            get { return _idCambio_883SC; }
            set { _idCambio_883SC = value; }
        }

        private string _codigo_883SC;
        public string Codigo_883SC
        {
            get { return _codigo_883SC; }
            set { _codigo_883SC = value; }
        }

        private DateTime _fecha_883SC;
        public DateTime Fecha_883SC
        {
            get { return _fecha_883SC; }
            set { _fecha_883SC = value; }
        }

        private TimeSpan _hora_883SC;
        public TimeSpan Hora_883SC
        {
            get { return _hora_883SC; }
            set { _hora_883SC = value; }
        }

        private int _proveedor_883SC;
        public int Proveedor_883SC
        {
            get { return _proveedor_883SC; }
            set { _proveedor_883SC = value; }
        }

        private string _nombre_883SC;
        public string Nombre_883SC
        {
            get { return _nombre_883SC; }
            set { _nombre_883SC = value; }
        }

        private string _descripcion_883SC;
        public string Descripcion_883SC
        {
            get { return _descripcion_883SC; }
            set { _descripcion_883SC = value; }
        }

        private int _stock_883SC;
        public int Stock_883SC
        {
            get { return _stock_883SC; }
            set { _stock_883SC = value; }
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

        //true = el producto estaba dado de baja logica en esa version
        private bool _baja_883SC;
        public bool Baja_883SC
        {
            get { return _baja_883SC; }
            set { _baja_883SC = value; }
        }

        //true = es la version vigente (la que tiene hoy Productos)
        private bool _vigente_883SC;
        public bool Vigente_883SC
        {
            get { return _vigente_883SC; }
            set { _vigente_883SC = value; }
        }
    }
}
