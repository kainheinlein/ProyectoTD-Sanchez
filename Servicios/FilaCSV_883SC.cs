namespace Servicios
{
    /// Una fila de datos leida de un archivo CSV, sin ninguna validacion de negocio.
    public class FilaCSV_883SC
    {
        //Numero de linea del archivo donde empieza la fila (el encabezado es la linea 1)
        private int _numeroFila_883SC;
        public int NumeroFila_883SC
        {
            get { return _numeroFila_883SC; }
            set { _numeroFila_883SC = value; }
        }

        private string[] _valores_883SC;
        public string[] Valores_883SC
        {
            get { return _valores_883SC; }
            set { _valores_883SC = value; }
        }
    }
}
