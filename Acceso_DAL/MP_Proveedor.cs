using Entidad_BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Acceso_DAL
{
    public class MP_Proveedor_883SC
    {
        AccesoDatos_883SC conexDB_883SC = new AccesoDatos_883SC();

        public List<ProveedorBE_883SC> ListarProveedores_883SC()
        {
            List<ProveedorBE_883SC> proveedores = new List<ProveedorBE_883SC>();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@tabla", "Proveedores");

            DataTable dt = conexDB_883SC.LeerTabla_883SC("SP_ExtTabla", param);
            foreach (DataRow dr in dt.Rows)
            {
                ProveedorBE_883SC proveedor = new ProveedorBE_883SC();
                proveedor.AsignarId_883SC(Convert.ToInt32(dr["IDProveedor"]));
                proveedor.Nombre_883SC = dr["Nombre"].ToString();
                proveedor.Direccion_883SC = dr["Direccion"].ToString();
                proveedor.Observaciones_883SC = dr["Observaciones"].ToString();
                proveedor.Especialidad_883SC = dr["Especialidad"].ToString();
                proveedor.Telefono_883SC = dr["Telefono"].ToString();
                proveedor.Margen_883SC = Convert.ToDecimal(dr["Margen"]);
                proveedor.Activo_883SC = Convert.ToBoolean(dr["Activo"]);
                proveedores.Add(proveedor);
            }
            return proveedores;
        }

        public bool ExisteProveedor_883SC(string nombre)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@Nombre", nombre);

            DataTable dt = conexDB_883SC.LeerTabla_883SC("ExisteProveedor_SP", parametros);
            return dt.Rows.Count > 0;
        }

        /// Inserta el proveedor (siempre activo) y devuelve el IDProveedor generado por el SP.
        /// Los datos opcionales vacios se envian como NULL.
        public int GuardarProveedor_883SC(ProveedorBE_883SC proveedor)
        {
            SqlParameter[] parametros = new SqlParameter[6];
            parametros[0] = new SqlParameter("@Nombre", proveedor.Nombre_883SC);
            parametros[1] = new SqlParameter("@Especialidad", (object)proveedor.Especialidad_883SC ?? DBNull.Value);
            parametros[2] = new SqlParameter("@Telefono", proveedor.Telefono_883SC);
            parametros[3] = new SqlParameter("@Direccion", (object)proveedor.Direccion_883SC ?? DBNull.Value);
            parametros[4] = new SqlParameter("@Margen", proveedor.Margen_883SC);
            parametros[5] = new SqlParameter("@Observaciones", (object)proveedor.Observaciones_883SC ?? DBNull.Value);

            return Convert.ToInt32(conexDB_883SC.EscribirRetornar_883SC("AltaProveedor_SP", parametros));
        }
    }
}
