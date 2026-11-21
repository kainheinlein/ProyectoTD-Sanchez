using Entidad_BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Acceso_DAL
{
    public class MP_ReporteVentas_883SC
    {
        AccesoDatos_883SC conexDB_883SC = new AccesoDatos_883SC();

        public ReporteVentasBE_883SC ObtenerResumen_883SC(DateTime desde, DateTime hasta)
        {
            DataTable dt = conexDB_883SC.LeerTabla_883SC("ReporteVentasResumen_SP", ArmarPeriodo_883SC(desde, hasta));

            ReporteVentasBE_883SC reporte = new ReporteVentasBE_883SC();
            reporte.Desde_883SC = desde.Date;
            reporte.Hasta_883SC = hasta.Date;
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                reporte.CantidadVentas_883SC = Convert.ToInt32(dr["CantidadVentas"]);
                reporte.UnidadesVendidas_883SC = Convert.ToInt32(dr["UnidadesVendidas"]);
                reporte.MontoTotal_883SC = Convert.ToDecimal(dr["MontoTotal"]);
            }
            return reporte;
        }

        public List<VentaDiariaBE_883SC> ObtenerVentasPorDia_883SC(DateTime desde, DateTime hasta)
        {
            DataTable dt = conexDB_883SC.LeerTabla_883SC("ReporteVentasPorDia_SP", ArmarPeriodo_883SC(desde, hasta));

            List<VentaDiariaBE_883SC> ventas = new List<VentaDiariaBE_883SC>();
            foreach (DataRow dr in dt.Rows)
            {
                VentaDiariaBE_883SC venta = new VentaDiariaBE_883SC();
                venta.Fecha_883SC = Convert.ToDateTime(dr["Fecha"]);
                venta.CantidadVentas_883SC = Convert.ToInt32(dr["CantidadVentas"]);
                venta.Importe_883SC = Convert.ToDecimal(dr["Importe"]);
                ventas.Add(venta);
            }
            return ventas;
        }

        public List<ProductoVendidoBE_883SC> ObtenerTopProductos_883SC(DateTime desde, DateTime hasta, int top)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@desde", SqlDbType.Date) { Value = desde.Date };
            parametros[1] = new SqlParameter("@hasta", SqlDbType.Date) { Value = hasta.Date };
            parametros[2] = new SqlParameter("@top", top);
            DataTable dt = conexDB_883SC.LeerTabla_883SC("ReporteVentasTopProductos_SP", parametros);

            List<ProductoVendidoBE_883SC> productos = new List<ProductoVendidoBE_883SC>();
            foreach (DataRow dr in dt.Rows)
            {
                ProductoVendidoBE_883SC producto = new ProductoVendidoBE_883SC();
                producto.Codigo_883SC = dr["Codigo"].ToString();
                //El nombre puede faltar si el producto ya no existe en el catalogo
                producto.Nombre_883SC = dr["Nombre"] == DBNull.Value ? "" : dr["Nombre"].ToString();
                producto.Unidades_883SC = Convert.ToInt32(dr["Unidades"]);
                producto.Importe_883SC = Convert.ToDecimal(dr["Importe"]);
                productos.Add(producto);
            }
            return productos;
        }

        //SqlDbType.Date: el SP compara por dia, la hora de la fecha elegida no importa
        private SqlParameter[] ArmarPeriodo_883SC(DateTime desde, DateTime hasta)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@desde", SqlDbType.Date) { Value = desde.Date };
            parametros[1] = new SqlParameter("@hasta", SqlDbType.Date) { Value = hasta.Date };
            return parametros;
        }
    }
}
