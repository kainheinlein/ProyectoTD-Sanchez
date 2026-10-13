namespace Entidad_BE
{
    public class MetodoPagoBE_883SC
    {
        //Id de catalogo generado por la base: sin setter publico
        private int _idMetodoPago_883SC;
        public int IdMetodoPago_883SC
        {
            get { return _idMetodoPago_883SC; }
        }

        public void AsignarId_883SC(int id)
        {
            _idMetodoPago_883SC = id;
        }

        private string _nombre_883SC;
        public string Nombre_883SC
        {
            get { return _nombre_883SC; }
            set { _nombre_883SC = value; }
        }

        //true = requiere validacion bancaria; false = Efectivo/Transferencia
        private bool _validacion_883SC;
        public bool Validacion_883SC
        {
            get { return _validacion_883SC; }
            set { _validacion_883SC = value; }
        }

        private bool _requiereDatosTarjeta_883SC;
        public bool RequiereDatosTarjeta_883SC
        {
            get { return _requiereDatosTarjeta_883SC; }
            set { _requiereDatosTarjeta_883SC = value; }
        }
    }
}
