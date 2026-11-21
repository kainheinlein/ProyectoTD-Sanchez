using System.Collections.Generic;

namespace Servicios
{
    //Clase que representa una sección de un PDF con tabla de datos
    public class SeccionPdf_883SC
    {
        private string _titulo_883SC;
        public string Titulo_883SC
        {
            get { return _titulo_883SC; }
            set { _titulo_883SC = value; }
        }

        //Encabezados de columna; si esta vacia la seccion se dibuja como tabla sin encabezado
        private List<string> _columnas_883SC = new List<string>();
        public List<string> Columnas_883SC
        {
            get { return _columnas_883SC; }
            set { _columnas_883SC = value; }
        }

        //Anchos relativos de cada columna (mismo orden que las columnas). Vacia = todas iguales
        private List<double> _anchos_883SC = new List<double>();
        public List<double> Anchos_883SC
        {
            get { return _anchos_883SC; }
            set { _anchos_883SC = value; }
        }

        //true = el contenido de esa columna se alinea a la derecha (importes y cantidades)
        private List<bool> _alinearDerecha_883SC = new List<bool>();
        public List<bool> AlinearDerecha_883SC
        {
            get { return _alinearDerecha_883SC; }
            set { _alinearDerecha_883SC = value; }
        }

        private List<string[]> _filas_883SC = new List<string[]>();
        public List<string[]> Filas_883SC
        {
            get { return _filas_883SC; }
            set { _filas_883SC = value; }
        }

        //Fila final opcional (por ejemplo "Total") que se dibuja en negrita
        private string[] _filaTotal_883SC;
        public string[] FilaTotal_883SC
        {
            get { return _filaTotal_883SC; }
            set { _filaTotal_883SC = value; }
        }
    }
}
