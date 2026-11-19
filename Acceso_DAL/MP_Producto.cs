using Entidad_BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Acceso_DAL
{
    public class MP_Producto_883SC
    {
        AccesoDatos_883SC conexDB_883SC = new AccesoDatos_883SC();

        public List<ProductoBE_883SC> BuscarProductos_883SC(string criterio, string dato)
        {
            List<ProductoBE_883SC> productos = new List<ProductoBE_883SC>();
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@criterio", criterio);
            parametros[1] = new SqlParameter("@dato", dato);

            DataTable dt = conexDB_883SC.LeerTabla_883SC("BuscarProductos_SP", parametros);
            foreach (DataRow dr in dt.Rows)
            {
                productos.Add(MapearFila_883SC(dr));
            }
            return productos;
        }

        public List<ProductoBE_883SC> ListarProductos_883SC()
        {
            List<ProductoBE_883SC> productos = new List<ProductoBE_883SC>();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@tabla", "Productos");

            DataTable dt = conexDB_883SC.LeerTabla_883SC("SP_ExtTabla", param);
            foreach (DataRow dr in dt.Rows)
            {
                productos.Add(MapearFila_883SC(dr));
            }
            return productos;
        }

        public List<ProductoBE_883SC> ListarBajoStock_883SC()
        {
            List<ProductoBE_883SC> productos = new List<ProductoBE_883SC>();
            DataTable dt = conexDB_883SC.LeerTabla_883SC("ListarBajoStock_SP", null);
            foreach (DataRow dr in dt.Rows)
            {
                ProductoBE_883SC producto = MapearFila_883SC(dr);
                producto.CantidadProveedores_883SC = Convert.ToInt32(dr["CantProveedores"]);
                productos.Add(producto);
            }
            return productos;
        }

        public bool ExisteProducto_883SC(string codigo)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@Codigo", codigo);

            DataTable dt = conexDB_883SC.LeerTabla_883SC("ExisteProducto_SP", parametros);
            return dt.Rows.Count > 0;
        }

        /// CUN-006. Inserta el producto (stock 0) y vincula el item de la lista en una sola operacion:
        /// el SP hace ambas cosas dentro de su transaccion (no hay detalle, por eso no usa TVP).
        /// El proveedor de referencia es el del item; la descripcion viaja en Tipo_883SC.
        public void GuardarProducto_883SC(ProductoBE_883SC producto, ItemListaPrecioBE_883SC item)
        {
            SqlParameter[] parametros = new SqlParameter[7];
            parametros[0] = new SqlParameter("@Codigo", producto.Codigo_883SC);
            parametros[1] = new SqlParameter("@Nombre", producto.Nombre_883SC);
            parametros[2] = new SqlParameter("@Descripcion", producto.Tipo_883SC);
            parametros[3] = new SqlParameter("@StockMinimo", producto.StockMinimo_883SC);
            parametros[4] = new SqlParameter("@Precio", producto.Precio_883SC);
            parametros[5] = new SqlParameter("@IdProveedor", item.IdProveedor_883SC);
            parametros[6] = new SqlParameter("@CodigoProveedor", item.CodigoProveedor_883SC);

            conexDB_883SC.Escribir_883SC("AltaProductoVinculado_SP", parametros);
        }

        public void ModificarProducto_883SC(ProductoBE_883SC producto)
        {
            SqlParameter[] parametros = new SqlParameter[6];
            parametros[0] = new SqlParameter("@Codigo", producto.Codigo_883SC);
            parametros[1] = new SqlParameter("@Nombre", producto.Nombre_883SC);
            parametros[2] = new SqlParameter("@Descripcion", producto.Tipo_883SC);
            parametros[3] = new SqlParameter("@StockMinimo", producto.StockMinimo_883SC);
            parametros[4] = new SqlParameter("@IdProveedor", producto.Proveedor_883SC);
            parametros[5] = new SqlParameter("@Precio", producto.Precio_883SC);

            conexDB_883SC.Escribir_883SC("ModificarProducto_SP", parametros);
        }

        private ProductoBE_883SC MapearFila_883SC(DataRow dr)
        {
            ProductoBE_883SC producto = new ProductoBE_883SC();
            producto.Codigo_883SC = dr["Codigo"].ToString();
            producto.Nombre_883SC = dr["Nombre"].ToString();
            producto.Stock_883SC = Convert.ToInt32(dr["Stock"]);
            producto.Tipo_883SC = dr["Descripcion"].ToString();
            producto.Precio_883SC = Convert.ToDecimal(dr["Precio"]);
            producto.Proveedor_883SC = Convert.ToInt32(dr["Proveedor"]);
            //BuscarProductos_SP y ObtenerCarritoDetalle_SP (Ventas) no devuelven StockMinimo; SP_ExtTabla si
            if (dr.Table.Columns.Contains("StockMinimo"))
            {
                producto.StockMinimo_883SC = Convert.ToInt32(dr["StockMinimo"]);
            }
            return producto;
        }
    }
}
