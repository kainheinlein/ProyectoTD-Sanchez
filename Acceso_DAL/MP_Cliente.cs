using Entidad_BE;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Acceso_DAL
{
    public class MP_Cliente_883SC
    {
        AccesoDatos_883SC conexDB_883SC = new AccesoDatos_883SC();

        public ClienteBE_883SC BuscarCliente_883SC(int dni)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@DNI", dni);

            DataTable dt = conexDB_883SC.LeerTabla_883SC("BuscarCliente_SP", parametros);
            if (dt.Rows.Count == 0) { return null; }

            return MapearFila_883SC(dt.Rows[0]);
        }

        public void GuardarCliente_883SC(ClienteBE_883SC cliente)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("@DNI", cliente.Dni_883SC);
            parametros[1] = new SqlParameter("@Nombre", cliente.Nombre_883SC);
            parametros[2] = new SqlParameter("@Apellido", cliente.Apellido_883SC);
            parametros[3] = new SqlParameter("@Direccion", cliente.Direccion_883SC);
            parametros[4] = new SqlParameter("@Telefono", cliente.Telefono_883SC);

            conexDB_883SC.Escribir_883SC("CrearCliente_SP", parametros);
        }

        private ClienteBE_883SC MapearFila_883SC(DataRow dr)
        {
            ClienteBE_883SC cliente = new ClienteBE_883SC();
            cliente.Dni_883SC = Convert.ToInt32(dr["DNI"]);
            cliente.Nombre_883SC = dr["Nombre"].ToString();
            cliente.Apellido_883SC = dr["Apellido"].ToString();
            cliente.Direccion_883SC = dr["Direccion"].ToString();
            cliente.Telefono_883SC = dr["Telefono"].ToString();
            return cliente;
        }
    }
}
