using Entidad_BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Acceso_DAL
{
    public class MP_Backup_883SC
    {
        AccesoDatos_883SC conexDB_883SC = new AccesoDatos_883SC();

        //Misma cadena que usa AccesoDatos_883SC, del unico punto de lectura (ConexionConfig_883SC)
        public string ObtenerCadenaConexion_883SC()
        {
            return Servicios.ConexionConfig_883SC.ObtenerCadena_883SC();
        }

        public void Registrar_883SC(BackupBE_883SC backup)
        {
            SqlParameter[] parametros = new SqlParameter[6];
            parametros[0] = new SqlParameter("@NombreArchivo", backup.NombreArchivo_883SC);
            parametros[1] = new SqlParameter("@Ruta", backup.Ruta_883SC);
            parametros[2] = new SqlParameter("@Fecha", backup.Fecha_883SC);
            parametros[3] = new SqlParameter("@Usuario", backup.Usuario_883SC);
            if (backup.TamanioBytes_883SC == null) { parametros[4] = new SqlParameter("@TamanioBytes", DBNull.Value); }
            else { parametros[4] = new SqlParameter("@TamanioBytes", backup.TamanioBytes_883SC.Value); }
            parametros[5] = new SqlParameter("@Verificado", backup.Verificado_883SC);

            object id = conexDB_883SC.EscribirRetornar_883SC("RegistrarBackup_SP", parametros);
            backup.AsignarId_883SC(Convert.ToInt32(id));
        }

        //Deja la tabla Backups igual a "catalogo" (mismos IdBackup). Un SP con TVP, transaccional.
        //Se llama con LeerTabla_883SC por el mismo motivo que los SP con THROW: Escribir abre una transaccion propia
        //y el Rollback posterior taparia la excepcion original.
        public void Sincronizar_883SC(List<BackupBE_883SC> catalogo)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("IdBackup", typeof(int));
            tabla.Columns.Add("NombreArchivo", typeof(string));
            tabla.Columns.Add("Ruta", typeof(string));
            tabla.Columns.Add("Fecha", typeof(DateTime));
            tabla.Columns.Add("Usuario", typeof(string));
            tabla.Columns.Add("TamanioBytes", typeof(long));
            tabla.Columns.Add("Verificado", typeof(bool));
            foreach (BackupBE_883SC b in catalogo)
            {
                DataRow fila = tabla.NewRow();
                fila["IdBackup"] = b.Id_883SC;
                fila["NombreArchivo"] = b.NombreArchivo_883SC;
                fila["Ruta"] = b.Ruta_883SC;
                fila["Fecha"] = b.Fecha_883SC;
                fila["Usuario"] = b.Usuario_883SC;
                if (b.TamanioBytes_883SC == null) { fila["TamanioBytes"] = DBNull.Value; }
                else { fila["TamanioBytes"] = b.TamanioBytes_883SC.Value; }
                fila["Verificado"] = b.Verificado_883SC;
                tabla.Rows.Add(fila);
            }

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@Catalogo", tabla);
            parametros[0].SqlDbType = SqlDbType.Structured;
            parametros[0].TypeName = "dbo.TipoCatalogoBackup";
            conexDB_883SC.LeerTabla_883SC("SincronizarCatalogoBackups_SP", parametros);
        }

        public List<BackupBE_883SC> Listar_883SC()
        {
            List<BackupBE_883SC> backups = new List<BackupBE_883SC>();
            DataTable dt = conexDB_883SC.LeerTabla_883SC("ListarBackups_SP", null);
            foreach (DataRow dr in dt.Rows)
            {
                backups.Add(MapearFila_883SC(dr));
            }
            return backups;
        }

        public BackupBE_883SC Obtener_883SC(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@IdBackup", id);
            DataTable dt = conexDB_883SC.LeerTabla_883SC("ObtenerBackup_SP", parametros);
            if (dt.Rows.Count == 0)
            {
                throw new KeyNotFoundException("No existe el backup " + id + " en el catalogo.");
            }
            return MapearFila_883SC(dt.Rows[0]);
        }

        public void Eliminar_883SC(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@IdBackup", id);
            conexDB_883SC.Escribir_883SC("EliminarBackup_SP", parametros);
        }

        private BackupBE_883SC MapearFila_883SC(DataRow dr)
        {
            BackupBE_883SC backup = new BackupBE_883SC();
            backup.AsignarId_883SC(Convert.ToInt32(dr["IdBackup"]));
            backup.NombreArchivo_883SC = dr["NombreArchivo"].ToString();
            backup.Ruta_883SC = dr["Ruta"].ToString();
            backup.Fecha_883SC = Convert.ToDateTime(dr["Fecha"]);
            backup.Usuario_883SC = dr["Usuario"].ToString();
            if (dr.IsNull("TamanioBytes")) { backup.TamanioBytes_883SC = null; }
            else { backup.TamanioBytes_883SC = Convert.ToInt64(dr["TamanioBytes"]); }
            backup.Verificado_883SC = Convert.ToBoolean(dr["Verificado"]);
            return backup;
        }
    }
}
