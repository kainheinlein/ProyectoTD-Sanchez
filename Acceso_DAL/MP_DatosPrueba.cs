using Entidad_BE;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Acceso_DAL
{
    /// Carga de datos de prueba (Admin -> Cargar datos de prueba).
    /// La consulta del contenido usa AccesoDatos_883SC y un stored procedure (ContarDatosNegocio_SP).
    /// EXCEPCION (la misma que MP_Instalacion_883SC): el script embebido 03_DatosPrueba.sql tiene varias sentencias y llama a
    /// otros SP dentro de UNA transaccion, y AccesoDatos abre/cierra la conexion por llamada; por eso se abre una conexion propia.
    /// El script es texto fijo embebido (sin parametros ni concatenacion).
    public class MP_DatosPrueba_883SC
    {
        private const string RecursoDatosPrueba_883SC = "Acceso_DAL.DatosPrueba.03_DatosPrueba.sql";
        private const int TimeoutScriptSegundos_883SC = 300;

        AccesoDatos_883SC conexDB_883SC = new AccesoDatos_883SC();

        public ContenidoBaseBE_883SC ObtenerContenido_883SC()
        {
            DataRow fila = conexDB_883SC.LeerTabla_883SC("ContarDatosNegocio_SP", null).Rows[0];
            ContenidoBaseBE_883SC contenido = new ContenidoBaseBE_883SC();
            contenido.Proveedores_883SC = Convert.ToInt32(fila["Proveedores"]);
            contenido.Productos_883SC = Convert.ToInt32(fila["Productos"]);
            contenido.Clientes_883SC = Convert.ToInt32(fila["Clientes"]);
            contenido.Facturas_883SC = Convert.ToInt32(fila["Facturas"]);
            contenido.ListasPrecio_883SC = Convert.ToInt32(fila["ListasPrecio"]);
            contenido.OrdenesCompra_883SC = Convert.ToInt32(fila["OrdenesCompra"]);
            contenido.Carritos_883SC = Convert.ToInt32(fila["Carritos"]);
            contenido.Usuarios_883SC = Convert.ToInt32(fila["Usuarios"]);
            return contenido;
        }

        /// Ejecuta proveedores + listas de precios + productos + stock en UNA transaccion: o queda todo o no queda nada.
        public void CargarProveedoresYProductos_883SC()
        {
            List<string> lotes = MP_Instalacion_883SC.LeerBatches_883SC(RecursoDatosPrueba_883SC);
            SqlTransaction tr = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(ConexionConfig_883SC.ObtenerCadena_883SC()))
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    foreach (string lote in lotes)
                    {
                        using (SqlCommand cmd = new SqlCommand(lote, cn, tr))
                        {
                            cmd.CommandTimeout = TimeoutScriptSegundos_883SC;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tr.Commit();
                }
            }
            catch (Exception)
            {
                //Si un SP ya revirtio la transaccion, Rollback() falla porque ya no existe: el efecto buscado (nada guardado) esta logrado
                if (tr != null)
                {
                    try { tr.Rollback(); }
                    catch (Exception) { }
                }
                throw;
            }
        }
    }
}
