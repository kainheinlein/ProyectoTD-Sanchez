using Acceso_DAL;
using Entidad_BE;
using System.Collections.Generic;

namespace Negocio_BLL
{
    /// Ayuda en linea. No requiere sesion ni permisos y no se registra en la bitacora.
    public class AyudaBLL_883SC
    {
        MP_Ayuda_883SC mpAyuda_883SC = new MP_Ayuda_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        /// Tema que se abre cuando la pantalla activa no tiene tema propio
        public const string TemaInicio_883SC = "AYUDA_INICIO";

        /// Temas del idioma activo (o de Espanol si ese idioma no tiene ayuda), ordenados como el arbol.
        /// Los errores de base de datos suben sin cambios: la GUI los muestra.
        public List<AyudaTemaBE_883SC> ListarTemas_883SC()
        {
            //Sin idioma cargado se pide el id 0: el SP no encuentra temas y devuelve los de Espanol
            int idIdioma = gestorIdioma_883SC.IdiomaActual_883SC != null ? gestorIdioma_883SC.IdiomaActual_883SC.Id_883SC : 0;

            List<AyudaTemaBE_883SC> temas = mpAyuda_883SC.ListarTemas_883SC(idIdioma);
            foreach (AyudaTemaBE_883SC tema in temas)
            {
                //Los scripts pueden venir con CRLF o LF segun el archivo: la pantalla trabaja siempre con LF
                tema.Contenido_883SC = tema.Contenido_883SC.Replace("\r\n", "\n");
            }
            return temas;
        }
    }
}
