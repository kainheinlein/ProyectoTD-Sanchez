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
                proveedor.Id_883SC = Convert.ToInt32(dr["IDProveedor"]);
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
    }
}
