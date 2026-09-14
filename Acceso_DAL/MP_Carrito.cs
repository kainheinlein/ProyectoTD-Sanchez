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

        /// <summary>
        /// Persiste el encabezado y el detalle del carrito en una sola llamada.
        /// El detalle viaja como Table Valued Parameter (dbo.TipoDetalleCarrito)
        /// para que el SP inserte todas las lineas dentro de la misma transaccion.
        /// Devuelve el IDCarrito generado por la base.
        /// </summary>
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
