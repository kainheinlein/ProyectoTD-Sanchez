using System;

namespace Servicios
{
    //Carpetas por defecto con permiso de escritura para el usuario de Windows. Nunca rutas fijas.
    //No sirve para el backup: el .bak lo escribe el servicio de SQL Server, que no puede escribir en el perfil del usuario.
    public static class RutasUsuario_883SC
    {
        public static string CarpetaDocumentos_883SC()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }
}
