using Entidad_BE;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Acceso_DAL
{
    /// Temas de la ayuda en linea (tabla AyudaTema). Todo por stored procedures.
    public class MP_Ayuda_883SC
    {
        AccesoDatos_883SC conexDB_883SC = new AccesoDatos_883SC();

        /// Temas del idioma pedido, en el orden del arbol. Si ese idioma no tiene temas, el SP devuelve los de Espanol.
        public List<AyudaTemaBE_883SC> ListarTemas_883SC(int idIdioma)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@IdIdioma", idIdioma);

            List<AyudaTemaBE_883SC> temas = new List<AyudaTemaBE_883SC>();
            foreach (DataRow fila in conexDB_883SC.LeerTabla_883SC("ListarAyudaTemas_SP", parametros).Rows)
            {
                AyudaTemaBE_883SC tema = new AyudaTemaBE_883SC();
                tema.IdIdioma_883SC = (int)fila["IdIdioma"];
                tema.Clave_883SC = fila["Clave"].ToString();
                tema.Orden_883SC = (int)fila["Orden"];
                tema.Titulo_883SC = fila["Titulo"].ToString();
                tema.Contenido_883SC = fila["Contenido"].ToString();
                temas.Add(tema);
            }
            return temas;
        }
    }
}
