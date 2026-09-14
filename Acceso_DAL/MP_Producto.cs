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

        private ProductoBE_883SC MapearFila_883SC(DataRow dr)
        {
            ProductoBE_883SC producto = new ProductoBE_883SC();
            producto.Codigo_883SC = dr["Codigo"].ToString();
            producto.Nombre_883SC = dr["Nombre"].ToString();
            producto.Stock_883SC = Convert.ToInt32(dr["Stock"]);
            producto.Tipo_883SC = dr["Descripcion"].ToString();
            producto.Precio_883SC = Convert.ToDecimal(dr["Precio"]);
            producto.Proveedor_883SC = Convert.ToInt32(dr["Proveedor"]);
            return producto;
        }
    }
}
