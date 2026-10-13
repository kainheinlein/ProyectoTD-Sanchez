using Entidad_BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Acceso_DAL
{
    public class IdiomaDAL_883SC
    {
        private AccesoDatos_883SC acceso_883SC = new AccesoDatos_883SC();

        public List<IdiomaBE_883SC> ObtenerIdiomas_883SC()
        {
            List<IdiomaBE_883SC> idiomas = new List<IdiomaBE_883SC>();
            DataTable dt = acceso_883SC.LeerTabla_883SC("SP_ExtIdiomas", null);

            foreach (DataRow fila in dt.Rows)
            {
                IdiomaBE_883SC idioma = new IdiomaBE_883SC();
                idioma.Id_883SC = Convert.ToInt32(fila["Id"]);
                idioma.Codigo_883SC = fila["Codigo"].ToString();
                idioma.Nombre_883SC = fila["Nombre"].ToString();
                idiomas.Add(idioma);
            }
            return idiomas;
        }

        public Dictionary<string, string> ObtenerTraducciones_883SC(int idIdioma)
        {
            Dictionary<string, string> traducciones = new Dictionary<string, string>();
            foreach (DataRow fila in ObtenerTablaTraducciones_883SC(idIdioma).Rows)
            {
                traducciones[fila["Clave"].ToString()] = fila["Texto"].ToString();
            }
            return traducciones;
        }

        public DataTable ObtenerTablaTraducciones_883SC(int idIdioma)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdIdioma", idIdioma)
            };
            return acceso_883SC.LeerTabla_883SC("SP_ExtTraducciones", parametros);
        }

        public void CrearIdioma_883SC(string codigo, string nombre, string codigoBase)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Codigo", codigo),
                new SqlParameter("@Nombre", nombre),
                new SqlParameter("@CodigoBase", codigoBase)
            };
            acceso_883SC.Escribir_883SC("SP_CrearIdioma", parametros);
        }

        public void ActualizarTraduccion_883SC(int idIdioma, string clave, string texto)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdIdioma", idIdioma),
                new SqlParameter("@Clave", clave),
                new SqlParameter("@Texto", texto)
            };
            acceso_883SC.Escribir_883SC("SP_ActualizarTraduccion", parametros);
        }
    }
}
