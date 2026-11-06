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

        /// Items pendientes de vinculacion (sin producto). idProveedor null = de todos los proveedores.
        public List<ItemListaPrecioBE_883SC> ListarPendientes_883SC(int? idProveedor)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@IdProveedor", (object)idProveedor ?? DBNull.Value);

            return MapearItems_883SC(conexDB_883SC.LeerTabla_883SC("ListarPendientes_SP", parametros));
        }

        /// Items de lista vinculados a un producto (uno por proveedor como maximo).
        public List<ItemListaPrecioBE_883SC> ListarVinculados_883SC(string codigoProducto)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@Codigo", codigoProducto);

            return MapearItems_883SC(conexDB_883SC.LeerTabla_883SC("ListarVinculados_SP", parametros));
        }

        /// Precio de lista del producto en cada proveedor activo que lo tiene vinculado,
        /// de menor a mayor. Cada linea llega con cantidad 0 (la cantidad la elige el usuario).
        public List<LineaCompraBE_883SC> ListarPreciosProducto_883SC(ProductoBE_883SC producto)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@Codigo", producto.Codigo_883SC);

            List<LineaCompraBE_883SC> lineas = new List<LineaCompraBE_883SC>();
            foreach (DataRow dr in conexDB_883SC.LeerTabla_883SC("ListarPreciosProducto_SP", parametros).Rows)
            {
                ProveedorBE_883SC proveedor = new ProveedorBE_883SC();
                proveedor.AsignarId_883SC(Convert.ToInt32(dr["IdProveedor"]));
                proveedor.Nombre_883SC = dr["NombreProveedor"].ToString();

                LineaCompraBE_883SC linea = new LineaCompraBE_883SC();
                linea.Producto_883SC = producto;
                linea.Proveedor_883SC = proveedor;
                linea.CodigoProveedor_883SC = dr["CodigoProveedor"].ToString();
                linea.PrecioLista_883SC = Convert.ToDecimal(dr["PrecioLista"]);
                linea.FechaActualizacion_883SC = Convert.ToDateTime(dr["FechaActualizacion"]);
                lineas.Add(linea);
            }
            return lineas;
        }

        /// Vincula el item pendiente con un producto existente. El SP revalida dentro de su transaccion.
        public void VincularItem_883SC(ItemListaPrecioBE_883SC item, string codigoProducto)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@IdProveedor", item.IdProveedor_883SC);
            parametros[1] = new SqlParameter("@CodigoProveedor", item.CodigoProveedor_883SC);
            parametros[2] = new SqlParameter("@Codigo", codigoProducto);

            conexDB_883SC.Escribir_883SC("VincularItem_SP", parametros);
        }

        /// Desvincula el item (vuelve a quedar pendiente).
        public void DesvincularItem_883SC(ItemListaPrecioBE_883SC item)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@IdProveedor", item.IdProveedor_883SC);
            parametros[1] = new SqlParameter("@CodigoProveedor", item.CodigoProveedor_883SC);

            conexDB_883SC.Escribir_883SC("DesvincularItem_SP", parametros);
        }

        private List<ItemListaPrecioBE_883SC> MapearItems_883SC(DataTable dt)
        {
            List<ItemListaPrecioBE_883SC> items = new List<ItemListaPrecioBE_883SC>();
            foreach (DataRow dr in dt.Rows)
            {
                ItemListaPrecioBE_883SC item = new ItemListaPrecioBE_883SC();
                item.IdProveedor_883SC = Convert.ToInt32(dr["IdProveedor"]);
                item.CodigoProveedor_883SC = dr["CodigoProveedor"].ToString();
                item.Descripcion_883SC = dr["Descripcion"].ToString();
                item.Codigo_883SC = dr["Codigo"] == DBNull.Value ? null : dr["Codigo"].ToString();
                item.PrecioLista_883SC = Convert.ToDecimal(dr["PrecioLista"]);
                item.FechaActualizacion_883SC = Convert.ToDateTime(dr["FechaActualizacion"]);
                items.Add(item);
            }
            return items;
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
