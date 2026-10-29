using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace Servicios
{
    public class BackupService_883SC
    {
        private readonly string _cadenaConexion_883SC;

        public BackupService_883SC(string cadenaConexion)
        {
            if (string.IsNullOrWhiteSpace(cadenaConexion))
            {
                throw new ArgumentException("La cadena de conexion es obligatoria.", "cadenaConexion");
            }
            _cadenaConexion_883SC = cadenaConexion;
        }

        private string NombreBaseEscapado_883SC()
        {
            string nombre = new SqlConnectionStringBuilder(_cadenaConexion_883SC).InitialCatalog;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new InvalidOperationException("La cadena de conexion no indica la base de datos (Initial Catalog).");
            }
            return "[" + nombre.Replace("]", "]]") + "]";
        }

        private static void Ejecutar_883SC(SqlConnection conexion, string sql, string ruta)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conexion))
            {
                cmd.CommandTimeout = 0;
                if (ruta != null)
                {
                    cmd.Parameters.AddWithValue("@ruta", ruta);
                }
                cmd.ExecuteNonQuery();
            }
        }

        //Devuelve el tamano del archivo generado (FileInfo.Length).
        public long? EjecutarBackup_883SC(string ruta)
        {
            using (SqlConnection cn = new SqlConnection(_cadenaConexion_883SC))
            {
                cn.Open();
                Ejecutar_883SC(cn, "BACKUP DATABASE " + NombreBaseEscapado_883SC() + " TO DISK = @ruta WITH CHECKSUM, INIT", ruta);
            }
            FileInfo archivo = new FileInfo(ruta);
            if (archivo.Exists) { return archivo.Length; }
            return null;
        }

        public void VerificarArchivo_883SC(string ruta)
        {
            using (SqlConnection cn = new SqlConnection(_cadenaConexion_883SC))
            {
                cn.Open();
                Ejecutar_883SC(cn, "RESTORE VERIFYONLY FROM DISK = @ruta WITH CHECKSUM", ruta);
            }
        }

        public void Restaurar_883SC(string ruta)
        {
            string db = NombreBaseEscapado_883SC();
            SqlConnectionStringBuilder master = new SqlConnectionStringBuilder(_cadenaConexion_883SC);
            master.InitialCatalog = "master";

            try
            {
                using (SqlConnection cn = new SqlConnection(master.ConnectionString))
                {
                    cn.Open();
                    Exception falla = null;
                    try
                    {
                        Ejecutar_883SC(cn, "ALTER DATABASE " + db + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE", null);
                        Ejecutar_883SC(cn, "RESTORE DATABASE " + db + " FROM DISK = @ruta WITH REPLACE", ruta);
                    }
                    catch (Exception ex)
                    {
                        falla = ex;
                        throw;
                    }
                    finally
                    {
                        try
                        {
                            Ejecutar_883SC(cn, "ALTER DATABASE " + db + " SET MULTI_USER", null);
                        }
                        catch
                        {
                            if (falla == null) { throw; }
                        }
                    }
                }
            }
            finally
            {
                //Las conexiones del pool quedaron apuntando a la base reemplazada
                SqlConnection.ClearAllPools();
            }
        }

        public string ObtenerCarpetaBackup_883SC()
        {
            using (SqlConnection cn = new SqlConnection(_cadenaConexion_883SC))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT CONVERT(nvarchar(260), SERVERPROPERTY('InstanceDefaultBackupPath'))", cn))
                {
                    object valor = cmd.ExecuteScalar();
                    if (valor == null || valor == DBNull.Value || string.IsNullOrWhiteSpace(valor.ToString()))
                    {
                        throw new InvalidOperationException("El servidor no informa una carpeta de backups por defecto (InstanceDefaultBackupPath es NULL).");
                    }
                    return valor.ToString();
                }
            }
        }

        public bool Existe_883SC(string ruta)
        {
            return File.Exists(ruta);
        }

        public void Borrar_883SC(string ruta)
        {
            File.Delete(ruta);
        }

        public IEnumerable<string> ListarBak_883SC(string carpeta)
        {
            return Directory.GetFiles(carpeta, "*.bak")
                .Where(f => f.EndsWith(".bak", StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
