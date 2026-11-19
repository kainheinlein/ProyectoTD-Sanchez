using System.Xml.Serialization;

namespace Entidad_BE
{
    /// Transporte para el archivo XML de clientes (serializacion). Solo datos, sin logica.
    /// No es ClienteBE_883SC para no sacar al archivo datos internos del ABM (DireccionSinCifrar) y para poder
    /// cifrar la direccion sin modificar los objetos que muestra la grilla. XmlSerializer necesita
    /// constructor sin parametros y propiedades publicas con get y set.
    /// La Direccion_883SC viaja CIFRADA (AES, Encriptador_883SC); el cifrado y descifrado lo hace la BLL.
    [XmlType("Cliente")]
    public class ClienteXMLBE_883SC
    {
        private int _dni_883SC;
        public int Dni_883SC
        {
            get { return _dni_883SC; }
            set { _dni_883SC = value; }
        }

        private string _nombre_883SC;
        public string Nombre_883SC
        {
            get { return _nombre_883SC; }
            set { _nombre_883SC = value; }
        }

        private string _apellido_883SC;
        public string Apellido_883SC
        {
            get { return _apellido_883SC; }
            set { _apellido_883SC = value; }
        }

        private string _direccion_883SC;
        public string Direccion_883SC
        {
            get { return _direccion_883SC; }
            set { _direccion_883SC = value; }
        }

        private string _telefono_883SC;
        public string Telefono_883SC
        {
            get { return _telefono_883SC; }
            set { _telefono_883SC = value; }
        }

        private bool _activo_883SC;
        public bool Activo_883SC
        {
            get { return _activo_883SC; }
            set { _activo_883SC = value; }
        }
    }
}
