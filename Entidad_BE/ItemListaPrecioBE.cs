using System;

namespace Entidad_BE
{
    public class ItemListaPrecioBE_883SC
    {
        private int _idProveedor_883SC;
        public int IdProveedor_883SC
        {
            get { return _idProveedor_883SC; }
            set { _idProveedor_883SC = value; }
        }

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

        //Codigo del producto vinculado; null mientras el item esta pendiente de vincular
        private string _codigo_883SC;
        public string Codigo_883SC
        {
            get { return _codigo_883SC; }
            set { _codigo_883SC = value; }
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
    }
}
