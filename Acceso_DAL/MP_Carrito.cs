using Entidad_BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Acceso_DAL
{
    public class MP_Carrito_883SC
    {
        AccesoDatos_883SC conexDB_883SC = new AccesoDatos_883SC();

        /// Se persiste encabezado y detalle de carrito en una sola transaccion,se envia
        /// el detalle como tabla (tipo definido en la base). El SP devuelve el IDCarrito
        public int GuardarCarrito_883SC(CarritoBE_883SC carrito)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@Nombre", carrito.Nombre_883SC);
            parametros[1] = new SqlParameter("@FechaCreacion", carrito.FechaCreacion_883SC);
            parametros[2] = new SqlParameter("@Detalle", ArmarTablaDetalle_883SC(carrito.Detalle_883SC));
            parametros[2].SqlDbType = SqlDbType.Structured;
            parametros[2].TypeName = "dbo.TipoDetalleCarrito";

            return Convert.ToInt32(conexDB_883SC.EscribirRetornar_883SC("GuardarCarrito_SP", parametros));
        }

        /// Carritos que todavia no tienen factura asociada (NOT EXISTS en Facturas).
        public List<CarritoBE_883SC> ListarCarritosPendientes_883SC()
        {
            List<CarritoBE_883SC> carritos = new List<CarritoBE_883SC>();

            DataTable dt = conexDB_883SC.LeerTabla_883SC("ListarCarritosPendientes_SP", null);
            foreach (DataRow dr in dt.Rows)
            {
                carritos.Add(MapearEncabezado_883SC(dr));
            }
            return carritos;
        }

        /// Carrito completo con su detalle. Devuelve null si el carrito no existe o no tiene lineas.
        public CarritoBE_883SC ObtenerCarritoCompleto_883SC(int idCarrito)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@IDCarrito", idCarrito);

            DataTable dt = conexDB_883SC.LeerTabla_883SC("ObtenerCarritoDetalle_SP", parametros);
            if (dt.Rows.Count == 0) { return null; }

            CarritoBE_883SC carrito = MapearEncabezado_883SC(dt.Rows[0]);
            foreach (DataRow dr in dt.Rows)
            {
                DetalleCarritoBE_883SC linea = new DetalleCarritoBE_883SC();
                linea.Producto_883SC = MapearProducto_883SC(dr);
                linea.Cantidad_883SC = Convert.ToInt32(dr["cantidad"]);
                //El precio unitario es el guardado al momento de la compra, no el actual del producto. Se guarda en detalle de carrito.
                linea.PrecioUnitario_883SC = Convert.ToDecimal(dr["PrecioUnitario"]);
                carrito.Detalle_883SC.Add(linea);
            }
            return carrito;
        }

        private CarritoBE_883SC MapearEncabezado_883SC(DataRow dr)
        {
            CarritoBE_883SC carrito = new CarritoBE_883SC();
            carrito.AsignarId_883SC(Convert.ToInt32(dr["IDCarrito"]));
            carrito.Nombre_883SC = dr["nombre"].ToString();
            carrito.FechaCreacion_883SC = Convert.ToDateTime(dr["fecha_creacion"]);
            return carrito;
        }

        //Mismas columnas que devuelve BuscarProductos_SP (ver MP_Producto_883SC), salvo el
        //nombre: el SP lo devuelve como NombreProducto porque la fila tambien trae el
        //"nombre" del carrito y el DataTable no distingue mayusculas al buscar columnas
        private ProductoBE_883SC MapearProducto_883SC(DataRow dr)
        {
            ProductoBE_883SC producto = new ProductoBE_883SC();
            producto.Codigo_883SC = dr["Codigo"].ToString();
            producto.Nombre_883SC = dr["NombreProducto"].ToString();
            producto.Stock_883SC = Convert.ToInt32(dr["Stock"]);
            producto.Tipo_883SC = dr["Descripcion"].ToString();
            producto.Precio_883SC = Convert.ToDecimal(dr["Precio"]);
            producto.Proveedor_883SC = Convert.ToInt32(dr["Proveedor"]);
            return producto;
        }

        //Las columnas van en el mismo orden que dbo.TipoDetalleCarrito
        private DataTable ArmarTablaDetalle_883SC(List<DetalleCarritoBE_883SC> detalle)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Codigo", typeof(string));
            tabla.Columns.Add("Cantidad", typeof(int));
            tabla.Columns.Add("PrecioUnitario", typeof(decimal));

            foreach (DetalleCarritoBE_883SC linea in detalle)
            {
                tabla.Rows.Add(
                    linea.Producto_883SC.Codigo_883SC,
                    linea.Cantidad_883SC,
                    linea.PrecioUnitario_883SC);
            }
            return tabla;
        }
    }
}
