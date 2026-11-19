namespace Entidad_BE
{
    /// Que hizo la inicializacion del primer arranque (solo datos)
    public class ResultadoInicializacionBE_883SC
    {
        private bool _baseCreada_883SC;
        public bool BaseCreada_883SC
        {
            get { return _baseCreada_883SC; }
            set { _baseCreada_883SC = value; }
        }

        private bool _esquemaCreado_883SC;
        public bool EsquemaCreado_883SC
        {
            get { return _esquemaCreado_883SC; }
            set { _esquemaCreado_883SC = value; }
        }

        private bool _adminCreado_883SC;
        public bool AdminCreado_883SC
        {
            get { return _adminCreado_883SC; }
            set { _adminCreado_883SC = value; }
        }

        //Servidor que figura en el config
        private string _instanciaConfigurada_883SC;
        public string InstanciaConfigurada_883SC
        {
            get { return _instanciaConfigurada_883SC; }
            set { _instanciaConfigurada_883SC = value; }
        }

        //Servidor que resolvio ConexionConfig (puede ser una alternativa)
        private string _instanciaUsada_883SC;
        public string InstanciaUsada_883SC
        {
            get { return _instanciaUsada_883SC; }
            set { _instanciaUsada_883SC = value; }
        }

        //Calculada: no se almacena
        public bool UsoInstanciaAlternativa_883SC
        {
            get { return !string.Equals(_instanciaConfigurada_883SC, _instanciaUsada_883SC, System.StringComparison.OrdinalIgnoreCase); }
        }
    }
}
