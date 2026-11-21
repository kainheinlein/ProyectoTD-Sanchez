using System;

namespace Negocio_BLL
{
    //El restore se completo, pero no se pudo restituir el catalogo de backups. Se lanza al final de Restaurar_883SC,
    //cuando la bitacora y el cierre de sesion ya se hicieron: la GUI avisa y sigue con el logout.
    public class CatalogoBackupsDesactualizadoException_883SC : Exception
    {
        public CatalogoBackupsDesactualizadoException_883SC(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
