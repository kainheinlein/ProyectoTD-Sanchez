using Acceso_DAL;
using Entidad_BE;
using Servicios;
using System.Collections.Generic;

namespace Negocio_BLL
{
    /// <summary>
    /// Sujeto observable del patron Observer de idiomas (Singleton).
    /// Mantiene el idioma activo, el diccionario de traducciones cargado
    /// desde la base de datos y la lista de observadores suscriptos.
    /// Al cambiar el idioma notifica a todos los observadores para que
    /// refresquen sus textos sin reiniciar la aplicacion.
    /// </summary>
    public class GestorDeIdioma_883SC
    {
        private static GestorDeIdioma_883SC _gestor_883SC = null;
        private static object _lock_883SC = new object();//Bloquear acceso multihilo

        public const string IdiomaPorDefecto_883SC = "ES";

        private readonly List<IObservadorIdioma_883SC> _observadores_883SC = new List<IObservadorIdioma_883SC>();
        private Dictionary<string, string> _traducciones_883SC = new Dictionary<string, string>();
        private IdiomaBE_883SC _idiomaActual_883SC = null;
        private IdiomaDAL_883SC idiomaDAL_883SC = new IdiomaDAL_883SC();

        private GestorDeIdioma_883SC() { }

        public static GestorDeIdioma_883SC GetInstance_883SC
        {
            get
            {
                if (_gestor_883SC == null)
                {
                    lock (_lock_883SC)
                    {
                        if (_gestor_883SC == null)
                        {
                            _gestor_883SC = new GestorDeIdioma_883SC();
                        }
                    }
                }
                return _gestor_883SC;
            }
        }

        public IdiomaBE_883SC IdiomaActual_883SC
        {
            get
            {
                AsegurarIdiomaCargado_883SC();
                return _idiomaActual_883SC;
            }
        }

        public List<IdiomaBE_883SC> ObtenerIdiomas_883SC()
        {
            return idiomaDAL_883SC.ObtenerIdiomas_883SC();
        }

        public System.Data.DataTable ObtenerTablaTraducciones_883SC(int idIdioma)
        {
            return idiomaDAL_883SC.ObtenerTablaTraducciones_883SC(idIdioma);
        }

        /// <summary>
        /// Da de alta un idioma. Si se indica un archivo de traducciones
        /// (formato CLAVE;Texto) se aplican sus textos sobre el idioma nuevo.
        /// Devuelve la cantidad de traducciones importadas desde el archivo.
        /// </summary>
        public int AgregarIdioma_883SC(string codigo, string nombre, string rutaArchivo = null)
        {
            codigo = (codigo ?? "").Trim().ToUpper();
            nombre = (nombre ?? "").Trim();

            if (codigo == "" || nombre == "")
            {
                throw new System.ArgumentException(Traducir_883SC("IDI_ERR_DATOS"));
            }
            if (codigo.Length > 5 || nombre.Length > 50)
            {
                throw new System.ArgumentException(Traducir_883SC("IDI_ERR_LONGITUD"));
            }
            if (ObtenerIdiomas_883SC().Exists(i => i.Codigo_883SC == codigo))
            {
                throw new System.ArgumentException(Traducir_883SC("IDI_ERR_CODIGO_EXISTE"));
            }

            //El archivo se lee ANTES de crear el idioma: si esta mal formado
            //no queda un idioma a medias en la base
            Dictionary<string, string> archivo = null;
            if (!string.IsNullOrEmpty(rutaArchivo))
            {
                archivo = LectorTraducciones_883SC.LeerArchivo_883SC(rutaArchivo);
            }

            //El idioma nuevo nace con las traducciones del idioma base copiadas
            //como punto de partida, para que la interfaz nunca quede sin textos
            idiomaDAL_883SC.CrearIdioma_883SC(codigo, nombre, IdiomaPorDefecto_883SC);

            if (archivo == null) { return 0; }

            //Se aplican solo las claves que existen en el catalogo del idioma
            IdiomaBE_883SC nuevo = ObtenerIdiomas_883SC().Find(i => i.Codigo_883SC == codigo);
            Dictionary<string, string> catalogo = idiomaDAL_883SC.ObtenerTraducciones_883SC(nuevo.Id_883SC);
            Dictionary<string, string> aplicables = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> par in archivo)
            {
                if (catalogo.ContainsKey(par.Key))
                {
                    aplicables[par.Key] = par.Value;
                }
            }
            GuardarTraducciones_883SC(nuevo.Id_883SC, aplicables);
            return aplicables.Count;
        }

        public void GuardarTraducciones_883SC(int idIdioma, Dictionary<string, string> cambios)
        {
            foreach (KeyValuePair<string, string> cambio in cambios)
            {
                idiomaDAL_883SC.ActualizarTraduccion_883SC(idIdioma, cambio.Key, cambio.Value);
            }

            //Si se edito el idioma activo se recarga el diccionario y se
            //notifica a los observadores: las pantallas abiertas se actualizan
            if (_idiomaActual_883SC != null && _idiomaActual_883SC.Id_883SC == idIdioma)
            {
                CambiarIdioma_883SC(_idiomaActual_883SC.Codigo_883SC);
            }
        }

        public void Suscribir_883SC(IObservadorIdioma_883SC observador)
        {
            if (!_observadores_883SC.Contains(observador))
            {
                _observadores_883SC.Add(observador);
            }
            //El nuevo observador arranca alineado con el idioma vigente
            AsegurarIdiomaCargado_883SC();
            if (_idiomaActual_883SC != null)
            {
                observador.ActualizarTextos_883SC();
            }
        }

        public void Desuscribir_883SC(IObservadorIdioma_883SC observador)
        {
            _observadores_883SC.Remove(observador);
        }

        public void CambiarIdioma_883SC(string codigo)
        {
            foreach (IdiomaBE_883SC idioma in idiomaDAL_883SC.ObtenerIdiomas_883SC())
            {
                if (idioma.Codigo_883SC == codigo)
                {
                    _traducciones_883SC = idiomaDAL_883SC.ObtenerTraducciones_883SC(idioma.Id_883SC);
                    _idiomaActual_883SC = idioma;
                    Notificar_883SC();
                    return;
                }
            }
            throw new KeyNotFoundException($"El idioma '{codigo}' no se encuentra registrado en el sistema");
        }

        public string Traducir_883SC(string clave)
        {
            AsegurarIdiomaCargado_883SC();
            string texto;
            if (_traducciones_883SC.TryGetValue(clave, out texto))
            {
                return texto;
            }
            return clave;//Si falta la traduccion se muestra la clave para detectarla facil
        }

        private void Notificar_883SC()
        {
            //Copia defensiva: un observador puede desuscribirse durante la notificacion
            foreach (IObservadorIdioma_883SC observador in _observadores_883SC.ToArray())
            {
                observador.ActualizarTextos_883SC();
            }
        }

        private void AsegurarIdiomaCargado_883SC()
        {
            if (_idiomaActual_883SC == null)
            {
                try
                {
                    CambiarIdioma_883SC(IdiomaPorDefecto_883SC);
                }
                catch
                {
                    //Sin conexion o sin migracion de idiomas: la UI conserva
                    //los textos del disenio y Traducir devuelve las claves
                }
            }
        }
    }
}
