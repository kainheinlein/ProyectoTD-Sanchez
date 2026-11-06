namespace Entidad_BE
{
    /// Fila de un archivo de lista de precios que no pasó la validacion
    public class FilaRechazadaBE_883SC
    {
        private int _numeroFila_883SC;
        public int NumeroFila_883SC
        {
            get { return _numeroFila_883SC; }
            set { _numeroFila_883SC = value; }
        }

        private string _codigoProveedor_883SC;
        public string CodigoProveedor_883SC
        {
            get { return _codigoProveedor_883SC; }
            set { _codigoProveedor_883SC = value; }
        }

        //Motivo ya traducido al idioma activo
        private string _motivo_883SC;
        public string Motivo_883SC
        {
            get { return _motivo_883SC; }
            set { _motivo_883SC = value; }
        }
    }
}
