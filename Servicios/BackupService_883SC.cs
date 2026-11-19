using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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

        //3201: no se pudo abrir el dispositivo de backup (generico: la causa esta en el codigo de SO del texto).
        //18204: mismo caso, informado por el motor de backup.
        private static readonly int[] ErroresDispositivo_883SC = { 3201, 18204 };
        //Ultimo "<numero>(" del mensaje: el texto de SQL Server es "... Operating system error 5(Access is denied.)" y su
        //version localizada ("Error de sistema operativo 5(Acceso denegado.)"). La ruta va antes, por eso se toma el ultimo.
        private static readonly Regex CodigoSO_883SC = new Regex(@"(\d+)\(", RegexOptions.RightToLeft);
        private const int SOAccesoDenegado_883SC = 5;
        private const int SORutaInexistente_883SC = 3;
        private const int SODiscoLleno_883SC = 112;

        private static void Ejecutar_883SC(SqlConnection conexion, string sql, string ruta)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conexion))
            {
                cmd.CommandTimeout = 0;
                if (ruta != null)
                {
                    cmd.Parameters.AddWithValue("@ruta", ruta);
                }
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex) when (ruta != null)
                {
                    BackupException_883SC conocida = Clasificar_883SC(ex, ruta);
                    if (conocida == null) { throw; }
                    throw conocida;
                }
            }
        }

        //Devuelve null si el SqlException no es de "no se pudo abrir el dispositivo": ese error sube sin cambios.
        private static BackupException_883SC Clasificar_883SC(SqlException ex, string ruta)
        {
            SqlError error = null;
            foreach (SqlError e in ex.Errors)
            {
                if (Array.IndexOf(ErroresDispositivo_883SC, e.Number) >= 0) { error = e; break; }
            }
            if (error == null) { return null; }

            string detalle = string.Join(Environment.NewLine, ex.Errors.Cast<SqlError>().Select(e => e.Message));
            Match m = CodigoSO_883SC.Match(error.Message);
            int codigo = m.Success ? int.Parse(m.Groups[1].Value) : -1;

            MotivoBackup_883SC motivo = MotivoBackup_883SC.SqlOtro;
            if (codigo == SOAccesoDenegado_883SC) { motivo = MotivoBackup_883SC.SqlSinAcceso; }
            else if (codigo == SORutaInexistente_883SC) { motivo = MotivoBackup_883SC.SqlRutaInexistente; }
            else if (codigo == SODiscoLleno_883SC) { motivo = MotivoBackup_883SC.SqlDiscoLleno; }
            return new BackupException_883SC(motivo, ruta, detalle, ex);
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

        //File.Exists devuelve false tambien cuando el usuario no tiene permiso: eso se leeria como "el archivo no existe".
        //File.GetAttributes distingue: archivo/carpeta inexistente -> false; sin permiso -> BackupException (no se pudo comprobar).
        public bool Existe_883SC(string ruta)
        {
            try
            {
                File.GetAttributes(ruta);
                return true;
            }
            catch (FileNotFoundException) { return false; }
            catch (DirectoryNotFoundException) { return false; }
            catch (UnauthorizedAccessException ex)
            {
                throw new BackupException_883SC(MotivoBackup_883SC.ClienteSinPermiso, ruta, "", ex);
            }
        }

        public void Borrar_883SC(string ruta)
        {
            try
            {
                File.Delete(ruta);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new BackupException_883SC(MotivoBackup_883SC.ClienteSinPermiso, ruta, "", ex);
            }
        }

        public IEnumerable<string> ListarBak_883SC(string carpeta)
        {
            try
            {
                return Directory.GetFiles(carpeta, "*.bak")
                    .Where(f => f.EndsWith(".bak", StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new BackupException_883SC(MotivoBackup_883SC.ClienteSinPermiso, carpeta, "", ex);
            }
        }
    }
}
