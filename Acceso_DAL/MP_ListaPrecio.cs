using Entidad_BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Acceso_DAL
{
    public class MP_ListaPrecio_883SC
    {
        AccesoDatos_883SC conexDB_883SC = new AccesoDatos_883SC();
        public ResumenImportacionBE_883SC GuardarLista_883SC(int idProveedor, List<ItemListaPrecioBE_883SC> items)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@IdProveedor", idProveedor);
            parametros[1] = new SqlParameter("@Items", ArmarTablaItems_883SC(items));
            parametros[1].SqlDbType = SqlDbType.Structured;
            parametros[1].TypeName = "dbo.TipoItemListaPrecio";

            DataTable dt = conexDB_883SC.LeerTabla_883SC("ImportarListaPrecios_SP", parametros);
            DataRow fila = dt.Rows[0];

            ResumenImportacionBE_883SC resumen = new ResumenImportacionBE_883SC();
            resumen.Importados_883SC = Convert.ToInt32(fila["Insertados"]) + Convert.ToInt32(fila["Actualizados"]);
            resumen.PreciosVentaActualizados_883SC = Convert.ToInt32(fila["PreciosVentaActualizados"]);
            resumen.Pendientes_883SC = Convert.ToInt32(fila["Pendientes"]);
            return resumen;
        }

        //Las columnas van en el mismo orden que dbo.TipoItemListaPrecio
        private DataTable ArmarTablaItems_883SC(List<ItemListaPrecioBE_883SC> items)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("CodigoProveedor", typeof(string));
            tabla.Columns.Add("Descripcion", typeof(string));
            tabla.Columns.Add("PrecioLista", typeof(decimal));

            foreach (ItemListaPrecioBE_883SC item in items)
            {
                tabla.Rows.Add(item.CodigoProveedor_883SC, item.Descripcion_883SC, item.PrecioLista_883SC);
            }
            return tabla;
        }
    }
}
