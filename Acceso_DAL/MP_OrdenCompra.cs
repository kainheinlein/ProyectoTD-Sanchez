using Entidad_BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Acceso_DAL
{
    public class MP_OrdenCompra_883SC
    {
        AccesoDatos_883SC conexDB_883SC = new AccesoDatos_883SC();

        public List<OrdenCompraBE_883SC> GuardarOrdenes_883SC(int idUsuario, List<OrdenCompraBE_883SC> ordenes)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@IdUsuario", idUsuario);
            parametros[1] = new SqlParameter("@Detalle", ArmarTablaDetalle_883SC(ordenes));
            parametros[1].SqlDbType = SqlDbType.Structured;
            parametros[1].TypeName = "dbo.TipoDetalleOrdenCompra";

            //LeerTabla porque el SP devuelve un id por cada proveedor (EscribirRetornar devuelve un solo valor)
            DataTable dt = conexDB_883SC.LeerTabla_883SC("AltaOrdenesCompra_SP", parametros);
            foreach (DataRow dr in dt.Rows)
            {
                int idProveedor = Convert.ToInt32(dr["IdProveedor"]);
                foreach (OrdenCompraBE_883SC orden in ordenes)
                {
                    if (orden.Proveedor_883SC.Id_883SC == idProveedor)
                    {
                        orden.AsignarId_883SC(Convert.ToInt32(dr["IdOrdenCompra"]));
                        orden.IdUsuarioCreacion_883SC = idUsuario;
                    }
                }
            }
            return ordenes;
        }

        public List<OrdenCompraBE_883SC> ListarPorEstado_883SC(EstadoOrdenCompra_883SC estado)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@Estado", estado.ToString());

            DataTable dt = conexDB_883SC.LeerTabla_883SC("ListarOrdenesPorEstado_SP", parametros);
            List<OrdenCompraBE_883SC> ordenes = new List<OrdenCompraBE_883SC>();
            OrdenCompraBE_883SC actual = null;
            foreach (DataRow dr in dt.Rows)
            {
                int id = Convert.ToInt32(dr["IdOrdenCompra"]);
                if (actual == null || actual.IdOrdenCompra_883SC != id)
                {
                    actual = MapearCabecera_883SC(dr, id);
                    ordenes.Add(actual);
                }

                DetalleOrdenCompraBE_883SC detalle = new DetalleOrdenCompraBE_883SC();
                ProductoBE_883SC producto = new ProductoBE_883SC();
                producto.Codigo_883SC = dr["Codigo"].ToString();
                producto.Nombre_883SC = dr["Producto"].ToString();
                detalle.Producto_883SC = producto;
                detalle.Cantidad_883SC = Convert.ToInt32(dr["Cantidad"]);
                detalle.PrecioUnitario_883SC = Convert.ToDecimal(dr["PrecioUnitario"]);
                if (dr["CantidadRecibida"] != DBNull.Value)
                {
                    detalle.CantidadRecibida_883SC = Convert.ToInt32(dr["CantidadRecibida"]);
                }
                actual.Detalle_883SC.Add(detalle);
            }
            return ordenes;
        }

        private OrdenCompraBE_883SC MapearCabecera_883SC(DataRow dr, int id)
        {
            OrdenCompraBE_883SC orden = new OrdenCompraBE_883SC();
            orden.AsignarId_883SC(id);

            ProveedorBE_883SC proveedor = new ProveedorBE_883SC();
            proveedor.AsignarId_883SC(Convert.ToInt32(dr["IdProveedor"]));
            proveedor.Nombre_883SC = dr["Proveedor"].ToString();
            orden.Proveedor_883SC = proveedor;

            orden.Estado_883SC = (EstadoOrdenCompra_883SC)Enum.Parse(typeof(EstadoOrdenCompra_883SC), dr["Estado"].ToString());
            orden.FechaCreacion_883SC = Convert.ToDateTime(dr["FechaCreacion"]);
            orden.IdUsuarioCreacion_883SC = Convert.ToInt32(dr["IdUsuarioCreacion"]);
            if (dr["IdUsuarioDecision"] != DBNull.Value) { orden.IdUsuarioDecision_883SC = Convert.ToInt32(dr["IdUsuarioDecision"]); }
            if (dr["FechaDecision"] != DBNull.Value) { orden.FechaDecision_883SC = Convert.ToDateTime(dr["FechaDecision"]); }
            if (dr["ObservacionesDecision"] != DBNull.Value) { orden.ObservacionesDecision_883SC = dr["ObservacionesDecision"].ToString(); }
            if (dr["FechaEnvio"] != DBNull.Value) { orden.FechaEnvio_883SC = Convert.ToDateTime(dr["FechaEnvio"]); }
            if (dr["FechaRecepcion"] != DBNull.Value) { orden.FechaRecepcion_883SC = Convert.ToDateTime(dr["FechaRecepcion"]); }
            if (dr["ObservacionesRecepcion"] != DBNull.Value) { orden.ObservacionesRecepcion_883SC = dr["ObservacionesRecepcion"].ToString(); }
            return orden;
        }

        /// Pendiente -> Autorizada. Lanza OrdenNoPendienteException_883SC si ya fue resuelta
        public void Autorizar_883SC(int idOrden, int idUsuario, string observaciones)
        {
            Decidir_883SC("AutorizarOrdenCompra_SP", idOrden, idUsuario, observaciones);
        }

        ///  Pendiente -> Rechazada. Lanza OrdenNoPendienteException_883SC si ya fue resuelta.
        public void Rechazar_883SC(int idOrden, int idUsuario, string observaciones)
        {
            Decidir_883SC("RechazarOrdenCompra_SP", idOrden, idUsuario, observaciones);
        }

        private void Decidir_883SC(string sp, int idOrden, int idUsuario, string observaciones)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@IdOrdenCompra", idOrden);
            parametros[1] = new SqlParameter("@IdUsuario", idUsuario);
            parametros[2] = new SqlParameter("@Observaciones", (object)observaciones ?? DBNull.Value);

            try
            {
                //LeerTabla y no Escribir: Escribir abre una transaccion propia y, cuando el SP hace THROW con
                //XACT_ABORT ON, el servidor ya la cancelo y el Rollback posterior ocultaria la excepcion original.
                //El SP ya es transaccional por si mismo (igual que GuardarOrdenes_883SC).
                conexDB_883SC.LeerTabla_883SC(sp, parametros);
            }
            catch (SqlException ex)
            {
                //50001 = el SP encontro la orden en otro estado (resuelta por otro usuario)
                if (ex.Number == 50001) { throw new OrdenNoPendienteException_883SC(ex); }
                throw;
            }
        }

        /// Autorizada -> EnEjecucion. Lanza OrdenEstadoCambiadoException_883SC si la orden ya no esta Autorizada
        public void Enviar_883SC(int idOrden)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@IdOrdenCompra", idOrden);
            EjecutarTransaccional_883SC("EnviarOrdenCompra_SP", parametros);
        }

        /// EnEjecucion -> Recibida: guarda la cantidad recibida de cada linea (codigo de producto -> cantidad),
        /// suma al stock y cierra la orden, todo dentro del SP. Lanza OrdenEstadoCambiadoException_883SC si la
        /// orden ya no esta EnEjecucion.
        public void RegistrarRecepcion_883SC(int idOrden, Dictionary<string, int> recibidas, string observaciones)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@IdOrdenCompra", idOrden);
            parametros[1] = new SqlParameter("@Observaciones", (object)observaciones ?? DBNull.Value);
            parametros[2] = new SqlParameter("@Lineas", ArmarTablaRecepcion_883SC(recibidas));
            parametros[2].SqlDbType = SqlDbType.Structured;
            parametros[2].TypeName = "dbo.TipoRecepcionLinea";
            EjecutarTransaccional_883SC("RegistrarRecepcion_SP", parametros);
        }

        //LeerTabla y no Escribir, por el mismo motivo que Decidir_883SC (el SP ya es transaccional por si mismo)
        private void EjecutarTransaccional_883SC(string sp, SqlParameter[] parametros)
        {
            try
            {
                conexDB_883SC.LeerTabla_883SC(sp, parametros);
            }
            catch (SqlException ex)
            {
                //50001 = el SP encontro la orden en otro estado
                if (ex.Number == 50001) { throw new OrdenEstadoCambiadoException_883SC(ex); }
                throw;
            }
        }

        //Las columnas van en el mismo orden que dbo.TipoRecepcionLinea
        private DataTable ArmarTablaRecepcion_883SC(Dictionary<string, int> recibidas)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Codigo", typeof(string));
            tabla.Columns.Add("CantidadRecibida", typeof(int));
            foreach (KeyValuePair<string, int> linea in recibidas)
            {
                tabla.Rows.Add(linea.Key, linea.Value);
            }
            return tabla;
        }

        //Las columnas van en el mismo orden que dbo.TipoDetalleOrdenCompra
        private DataTable ArmarTablaDetalle_883SC(List<OrdenCompraBE_883SC> ordenes)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("IdProveedor", typeof(int));
            tabla.Columns.Add("Codigo", typeof(string));
            tabla.Columns.Add("Cantidad", typeof(int));
            tabla.Columns.Add("PrecioUnitario", typeof(decimal));

            foreach (OrdenCompraBE_883SC orden in ordenes)
            {
                foreach (DetalleOrdenCompraBE_883SC linea in orden.Detalle_883SC)
                {
                    tabla.Rows.Add(
                        orden.Proveedor_883SC.Id_883SC,
                        linea.Producto_883SC.Codigo_883SC,
                        linea.Cantidad_883SC,
                        linea.PrecioUnitario_883SC);
                }
            }
            return tabla;
        }
    }
}
