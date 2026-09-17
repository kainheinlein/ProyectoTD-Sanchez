using Entidad_BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Acceso_DAL
{
    public class MP_Factura_883SC
    {
        AccesoDatos_883SC conexDB_883SC = new AccesoDatos_883SC();

        /// <summary>
        /// Persiste el encabezado y el detalle de la factura en una sola llamada.
        /// El detalle viaja como Table Valued Parameter (dbo.TipoDetalleFactura)
        /// para que el SP inserte todas las lineas dentro de la misma transaccion.
        /// Devuelve el IDFactura generado por la base.
        /// </summary>
        public int GuardarFactura_883SC(FacturaBE_883SC factura)
        {
            SqlParameter[] parametros = new SqlParameter[7];
            parametros[0] = new SqlParameter("@IDUsuario", factura.IdUsuario_883SC);
            parametros[1] = new SqlParameter("@DNI", factura.Cliente_883SC.Dni_883SC);
            parametros[2] = new SqlParameter("@IDCarrito", factura.IdCarrito_883SC);
            parametros[3] = new SqlParameter("@IDMetodoPago", factura.MetodoPago_883SC.IdMetodoPago_883SC);
            //Un SqlParameter con Value = null no se envia: el NULL de Efectivo/Transferencia va como DBNull
            parametros[4] = new SqlParameter("@CodigoAutorizacion", (object)factura.CodigoAutorizacion_883SC ?? DBNull.Value);
            parametros[5] = new SqlParameter("@FechaVenta", factura.FechaVenta_883SC);
            parametros[6] = new SqlParameter("@Detalle", ArmarTablaDetalle_883SC(factura.Detalle_883SC));
            parametros[6].SqlDbType = SqlDbType.Structured;
            parametros[6].TypeName = "dbo.TipoDetalleFactura";

            return Convert.ToInt32(conexDB_883SC.EscribirRetornar_883SC("GuardarFactura_SP", parametros));
        }

        //Las columnas van en el mismo orden que dbo.TipoDetalleFactura
        private DataTable ArmarTablaDetalle_883SC(List<DetalleFacturaBE_883SC> detalle)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Codigo", typeof(string));
            tabla.Columns.Add("Cantidad", typeof(int));
            tabla.Columns.Add("PrecioUnitario", typeof(decimal));

            foreach (DetalleFacturaBE_883SC linea in detalle)
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
