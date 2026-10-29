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

        //Cadena que usa AccesoDatos_883SC, sin duplicarla ni modificar esa clase
        public string ObtenerCadenaConexion_883SC()
        {
            try
            {
                conexDB_883SC.AbrirConexion_883SC();
                return conexDB_883SC.conexion_883SC.ConnectionString;
            }
            finally
            {
                if (conexDB_883SC.conexion_883SC != null) { conexDB_883SC.CerrarConexion_883SC(); }
            }
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
