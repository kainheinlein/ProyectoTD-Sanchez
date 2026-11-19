namespace Entidad_BE
{
    /// Que columnas del archivo del proveedor son el codigo, la descripcion y el precio, y desde que
    /// fila empiezan los datos. Las columnas se cuentan desde 0; -1 significa "sin elegir".
    public class MapeoListaBE_883SC
    {
        private int _colCodigo_883SC = -1;
        public int ColCodigo_883SC
        {
            get { return _colCodigo_883SC; }
            set { _colCodigo_883SC = value; }
        }

        private int _colDescripcion_883SC = -1;
        public int ColDescripcion_883SC
        {
            get { return _colDescripcion_883SC; }
            set { _colDescripcion_883SC = value; }
        }

        private int _colPrecio_883SC = -1;
        public int ColPrecio_883SC
        {
            get { return _colPrecio_883SC; }
            set { _colPrecio_883SC = value; }
        }

        //Numero de fila del archivo (el mismo que muestra la vista previa) donde empiezan los datos
        private int _primeraFila_883SC = 1;
        public int PrimeraFila_883SC
        {
            get { return _primeraFila_883SC; }
            set { _primeraFila_883SC = value; }
        }
    }
}
