using Entidad_BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Acceso_DAL
{
    public class MP_OrdenCompra_883SC
    {
        AccesoDatos_883SC conexDB_883SC = new AccesoDatos_883SC();

        public List<OrdenCompraBE_883SC> GuardarOrdenes_883SC(int idUsuario, List<OrdenCompraBE_883SC> ordenes)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@IdUsuario", idUsuario);
            parametros[1] = new SqlParameter("@Detalle", ArmarTablaDetalle_883SC(ordenes));
            parametros[1].SqlDbType = SqlDbType.Structured;
            parametros[1].TypeName = "dbo.TipoDetalleOrdenCompra";

            //LeerTabla porque el SP devuelve un id por cada proveedor (EscribirRetornar devuelve un solo valor)
            DataTable dt = conexDB_883SC.LeerTabla_883SC("AltaOrdenesCompra_SP", parametros);
            foreach (DataRow dr in dt.Rows)
            {
                int idProveedor = Convert.ToInt32(dr["IdProveedor"]);
                foreach (OrdenCompraBE_883SC orden in ordenes)
                {
                    if (orden.Proveedor_883SC.Id_883SC == idProveedor)
                    {
                        orden.AsignarId_883SC(Convert.ToInt32(dr["IdOrdenCompra"]));
                        orden.IdUsuarioCreacion_883SC = idUsuario;
                    }
                }
            }
            return ordenes;
        }

        //Las columnas van en el mismo orden que dbo.TipoDetalleOrdenCompra
        private DataTable ArmarTablaDetalle_883SC(List<OrdenCompraBE_883SC> ordenes)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("IdProveedor", typeof(int));
            tabla.Columns.Add("Codigo", typeof(string));
            tabla.Columns.Add("Cantidad", typeof(int));
            tabla.Columns.Add("PrecioUnitario", typeof(decimal));

            foreach (OrdenCompraBE_883SC orden in ordenes)
            {
                foreach (DetalleOrdenCompraBE_883SC linea in orden.Detalle_883SC)
                {
                    tabla.Rows.Add(
                        orden.Proveedor_883SC.Id_883SC,
                        linea.Producto_883SC.Codigo_883SC,
                        linea.Cantidad_883SC,
                        linea.PrecioUnitario_883SC);
                }
            }
            return tabla;
        }
    }
}
