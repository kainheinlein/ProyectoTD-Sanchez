using Entidad_BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Acceso_DAL
{
    /// Historial de cambios de Productos (tabla Productos_C). Todo por stored procedures.
    public class MP_ProductoC_883SC
    {
        AccesoDatos_883SC conexDB_883SC = new AccesoDatos_883SC();

        public List<ProductoCBE_883SC> ListarCambios_883SC()
        {
            return MapearTabla_883SC(conexDB_883SC.LeerTabla_883SC("ListarProductosC_SP", null));
        }

        /// Filtros opcionales: null = sin filtro. Las fechas son inclusivas (el SP suma un dia al hasta).
        public List<ProductoCBE_883SC> BuscarCambios_883SC(string codigo, string nombre, DateTime? desde, DateTime? hasta)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("@codigo", SqlDbType.NVarChar, 50);
            parametros[0].Value = string.IsNullOrEmpty(codigo) ? (object)DBNull.Value : codigo;
            parametros[1] = new SqlParameter("@nombre", SqlDbType.NVarChar, 50);
            parametros[1].Value = string.IsNullOrEmpty(nombre) ? (object)DBNull.Value : nombre;
            parametros[2] = new SqlParameter("@desde", SqlDbType.Date);
            parametros[2].Value = desde.HasValue ? (object)desde.Value.Date : DBNull.Value;
            parametros[3] = new SqlParameter("@hasta", SqlDbType.Date);
            parametros[3].Value = hasta.HasValue ? (object)hasta.Value.Date : DBNull.Value;

            return MapearTabla_883SC(conexDB_883SC.LeerTabla_883SC("BuscarProductosC_SP", parametros));
        }

        /// Restaura la version en Productos y la deja como vigente (todo dentro del SP, en una transaccion).
        /// Lanza ActivarVersionException_883SC si el SP rechaza la operacion (50001, 50002 o 50003).
        public void ActivarVersion_883SC(int idCambio)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@IdCambio", idCambio);
            try
            {
                //LeerTabla y no Escribir: Escribir abre una transaccion propia y su Rollback taparia la excepcion del SP
                conexDB_883SC.LeerTabla_883SC("ActivarVersionProducto_SP", parametros);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50001 || ex.Number == 50002 || ex.Number == 50003)
                {
                    throw new ActivarVersionException_883SC(ex.Number, ex);
                }
                throw;
            }
        }

        public List<string> ListarCodigos_883SC()
        {
            return LeerLista_883SC("ListarCodigosProductosC_SP", "Codigo");
        }

        public List<string> ListarNombres_883SC()
        {
            return LeerLista_883SC("ListarNombresProductosC_SP", "Nombre");
        }

        private List<string> LeerLista_883SC(string sp, string columna)
        {
            List<string> valores = new List<string>();
            DataTable dt = conexDB_883SC.LeerTabla_883SC(sp, null);
            foreach (DataRow dr in dt.Rows)
            {
                valores.Add(dr[columna].ToString());
            }
            return valores;
        }

        private List<ProductoCBE_883SC> MapearTabla_883SC(DataTable dt)
        {
            List<ProductoCBE_883SC> cambios = new List<ProductoCBE_883SC>();
            foreach (DataRow dr in dt.Rows)
            {
                ProductoCBE_883SC c = new ProductoCBE_883SC();
                c.IdCambio_883SC = Convert.ToInt32(dr["IdCambio"]);
                c.Codigo_883SC = dr["Codigo"].ToString();
                c.Fecha_883SC = Convert.ToDateTime(dr["Fecha"]);
                c.Hora_883SC = (TimeSpan)dr["Hora"];
                c.Proveedor_883SC = Convert.ToInt32(dr["Proveedor"]);
                c.Nombre_883SC = dr["Nombre"].ToString();
                c.Descripcion_883SC = dr["Descripcion"].ToString();
                c.Stock_883SC = Convert.ToInt32(dr["Stock"]);
                c.Precio_883SC = Convert.ToDecimal(dr["Precio"]);
                c.StockMinimo_883SC = Convert.ToInt32(dr["StockMinimo"]);
                c.Baja_883SC = Convert.ToBoolean(dr["Bit_Lo_Bo"]);
                c.Vigente_883SC = Convert.ToBoolean(dr["Act"]);
                cambios.Add(c);
            }
            return cambios;
        }
    }
}
