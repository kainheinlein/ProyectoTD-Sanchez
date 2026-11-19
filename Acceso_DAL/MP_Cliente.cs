using Entidad_BE;
using System;
using System.Collections.Generic;
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

        public List<ClienteBE_883SC> ListarClientes_883SC()
        {
            List<ClienteBE_883SC> clientes = new List<ClienteBE_883SC>();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@tabla", "Clientes");

            DataTable dt = conexDB_883SC.LeerTabla_883SC("SP_ExtTabla", param);
            foreach (DataRow dr in dt.Rows)
            {
                clientes.Add(MapearFila_883SC(dr));
            }
            return clientes;
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

        //LeerTabla en vez de Escribir: los SP lanzan THROW 50001 y Escribir taparia la excepcion con su Rollback
        public void ModificarCliente_883SC(ClienteBE_883SC cliente)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("@DNI", cliente.Dni_883SC);
            parametros[1] = new SqlParameter("@Nombre", cliente.Nombre_883SC);
            parametros[2] = new SqlParameter("@Apellido", cliente.Apellido_883SC);
            parametros[3] = new SqlParameter("@Direccion", (object)cliente.Direccion_883SC ?? DBNull.Value);
            parametros[4] = new SqlParameter("@Telefono", (object)cliente.Telefono_883SC ?? DBNull.Value);

            conexDB_883SC.LeerTabla_883SC("ModificarCliente_SP", parametros);
        }

        public void BajaCliente_883SC(int dni)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@DNI", dni);

            conexDB_883SC.LeerTabla_883SC("BajaCliente_SP", parametros);
        }

        public void ReactivarCliente_883SC(int dni)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@DNI", dni);

            conexDB_883SC.LeerTabla_883SC("ReactivarCliente_SP", parametros);
        }

        private ClienteBE_883SC MapearFila_883SC(DataRow dr)
        {
            ClienteBE_883SC cliente = new ClienteBE_883SC();
            cliente.Dni_883SC = Convert.ToInt32(dr["DNI"]);
            cliente.Nombre_883SC = dr["Nombre"].ToString();
            cliente.Apellido_883SC = dr["Apellido"].ToString();
            cliente.Direccion_883SC = dr["Direccion"].ToString();
            cliente.Telefono_883SC = dr["Telefono"].ToString();
            //Si el resultado no trae la columna se asume activo
            cliente.Activo_883SC = dr.Table.Columns.Contains("Activo") ? Convert.ToBoolean(dr["Activo"]) : true;
            return cliente;
        }
    }
}
