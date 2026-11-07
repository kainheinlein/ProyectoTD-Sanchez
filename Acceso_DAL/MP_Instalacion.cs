using Entidad_BE;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Acceso_DAL
{
    //Instalacion del primer arranque (crear la base, el esquema y el admin).
    //EXCEPCION APROBADA a "solo los Mappers usan AccesoDatos_883SC": este Mapper abre su propia conexion porque
    //(a) tiene que conectar a master, y AccesoDatos siempre usa la cadena de la base de la aplicacion, y
    //(b) necesita UNA transaccion que abarque muchos comandos, y AccesoDatos abre/cierra por llamada.
    //No hay stored procedures para crear la base ni el esquema (todavia no existen); el SQL es fijo, con parametros.
    public class MP_Instalacion_883SC
    {
        private const string RecursoEsquema_883SC = "Acceso_DAL.Instalacion.01_Esquema.sql";
        private const string RecursoDatosBase_883SC = "Acceso_DAL.Instalacion.02_DatosBase.sql";
        private const int TimeoutScriptSegundos_883SC = 300;

        //Errores de CREATE DATABASE: 1801 = la base ya existe (se sigue), 262 = permiso denegado.
        //5123 (CREATE FILE: error del sistema operativo al abrir/crear el archivo), 5133 (no se encontro/accedio a la carpeta de
        //datos) y 5105 (error de activacion de archivo, acompana a los anteriores) son la cuenta del SERVICIO de SQL Server sin acceso
        //a su carpeta de datos: no es el usuario de Windows, pero el remedio es el mismo (que el encargado cree la base).
        private const int BaseYaExiste_883SC = 1801;
        private const int PermisoDenegado_883SC = 262;
        private static readonly int[] ErroresCarpetaDatos_883SC = { 5123, 5133, 5105 };
        //Base que existe pero a la que este usuario no puede entrar: 4060 (no se puede abrir la base), 916 (sin acceso a la base)
        private static readonly int[] ErroresSinAccesoBase_883SC = { 4060, 916, 18456 };

        public string ObtenerInstanciaConfigurada_883SC()
        {
            return ConexionConfig_883SC.ObtenerInstanciaConfigurada_883SC();
        }

        public string ObtenerInstanciaUsada_883SC()
        {
            return ConexionConfig_883SC.ObtenerInstanciaUsada_883SC();
        }

        private static string NombreBase_883SC()
        {
            return new SqlConnectionStringBuilder(ConexionConfig_883SC.ObtenerCadena_883SC()).InitialCatalog;
        }

        public bool ExisteBase_883SC()
        {
            using (SqlConnection cn = new SqlConnection(ConexionConfig_883SC.ObtenerCadenaMaster_883SC()))
            using (SqlCommand cmd = new SqlCommand("SELECT CASE WHEN DB_ID(@nombre) IS NULL THEN 0 ELSE 1 END", cn))
            {
                cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar, 128) { Value = NombreBase_883SC() });
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) == 1;
            }
        }

        //CREATE DATABASE sin rutas de archivo (usa los valores de la base model). No admite transaccion de varias instrucciones.
        //El nombre se arma con QUOTENAME dentro del SQL, con el valor como parametro (no hay concatenacion en C#).
        public void CrearBase_883SC()
        {
            string nombre = NombreBase_883SC();
            string instancia = ConexionConfig_883SC.ObtenerInstanciaUsada_883SC();
            try
            {
                using (SqlConnection cn = new SqlConnection(ConexionConfig_883SC.ObtenerCadenaMaster_883SC()))
                using (SqlCommand cmd = new SqlCommand("DECLARE @sql nvarchar(400) = N'CREATE DATABASE ' + QUOTENAME(@nombre); EXEC (@sql);", cn))
                {
                    cmd.CommandTimeout = TimeoutScriptSegundos_883SC;
                    cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar, 128) { Value = nombre });
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                if (TieneError_883SC(ex, BaseYaExiste_883SC))
                {
                    return; //Otro proceso (u otro arranque) la creo entre la consulta y el CREATE: se sigue
                }
                string texto = TextoSql_883SC(ex);
                if (TieneError_883SC(ex, PermisoDenegado_883SC))
                {
                    throw new InicializacionException_883SC(MotivoInicializacion_883SC.SinPermisosCrearBase,
                        "No se pudo crear la base de datos '" + nombre + "' en la instancia '" + instancia + "': el usuario de Windows no tiene permiso para crear bases de datos.\r\n\r\n" +
                        "Pida al encargado que cree la base '" + nombre + "' vacia y vuelva a abrir la aplicacion.\r\n\r\nDetalle de SQL Server: " + texto, ex);
                }
                if (TieneAlgunError_883SC(ex, ErroresCarpetaDatos_883SC))
                {
                    throw new InicializacionException_883SC(MotivoInicializacion_883SC.CarpetaDeDatos,
                        "No se pudo crear la base de datos '" + nombre + "' en la instancia '" + instancia + "': SQL Server no pudo crear los archivos en su carpeta de datos (falta de permisos o carpeta inexistente).\r\n\r\n" +
                        "Pida al encargado que cree la base '" + nombre + "' vacia (o que revise los permisos de la carpeta de datos del servicio de SQL Server) y vuelva a abrir la aplicacion.\r\n\r\nDetalle de SQL Server: " + texto, ex);
                }
                throw new InicializacionException_883SC(MotivoInicializacion_883SC.ErrorCrearBase,
                    "No se pudo crear la base de datos '" + nombre + "' en la instancia '" + instancia + "'.\r\n\r\nDetalle de SQL Server: " + texto + "\r\n\r\n" +
                    "Ocurrio un error inesperado al preparar la base de datos. Avise al encargado e informe este mensaje.", ex);
            }
        }

        public bool ExisteEsquema_883SC()
        {
            return EjecutarEscalar_883SC("SELECT CASE WHEN OBJECT_ID(N'dbo.Usuarios', N'U') IS NULL THEN 0 ELSE 1 END") == 1;
        }

        public bool ExistenUsuarios_883SC()
        {
            return EjecutarEscalar_883SC("SELECT CASE WHEN EXISTS (SELECT 1 FROM dbo.Usuarios) THEN 1 ELSE 0 END") == 1;
        }

        private static int EjecutarEscalar_883SC(string sql)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConexionConfig_883SC.ObtenerCadena_883SC()))
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex) when (TieneAlgunError_883SC(ex, ErroresSinAccesoBase_883SC))
            {
                string nombre = NombreBase_883SC();
                throw new InicializacionException_883SC(MotivoInicializacion_883SC.SinAccesoBase,
                    "El usuario de Windows no tiene acceso a la base de datos '" + nombre + "' en la instancia '" + ConexionConfig_883SC.ObtenerInstanciaUsada_883SC() + "'.\r\n\r\n" +
                    "Pida al encargado que le otorgue acceso y vuelva a abrir la aplicacion.\r\n\r\nDetalle de SQL Server: " + TextoSql_883SC(ex), ex);
            }
        }

        //Esquema + datos base en UNA transaccion: o queda todo o no queda nada.
        //alComenzarDatos se invoca al terminar el esquema y empezar los datos base (para informar la etapa).
        public void InstalarEsquemaYDatos_883SC(Action alComenzarDatos)
        {
            List<string> esquema = LeerBatches_883SC(RecursoEsquema_883SC);
            List<string> datos = LeerBatches_883SC(RecursoDatosBase_883SC);
            SqlTransaction tr = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(ConexionConfig_883SC.ObtenerCadena_883SC()))
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    foreach (string batch in esquema) { EjecutarBatch_883SC(cn, tr, batch); }
                    if (alComenzarDatos != null) { alComenzarDatos(); }
                    foreach (string batch in datos) { EjecutarBatch_883SC(cn, tr, batch); }
                    tr.Commit();
                }
            }
            catch (Exception ex)
            {
                Revertir_883SC(tr);
                throw new InicializacionException_883SC(MotivoInicializacion_883SC.EsquemaFallido,
                    "No se pudo crear el esquema de la base de datos '" + NombreBase_883SC() + "'. No se guardo ningun cambio parcial: al volver a abrir la aplicacion se reintenta desde cero.\r\n\r\n" +
                    "Detalle: " + TextoDe_883SC(ex), ex);
            }
        }

        //Alta del admin + su DVH + el DVV + el evento de bitacora, todo en UNA transaccion.
        //calcularDvh recibe el Codigo recien generado (IDENTITY) y devuelve el DVH; calcularDvv recibe los DVH de todos los usuarios.
        public void CrearAdmin_883SC(UsuarioBE_883SC admin, Func<int, string> calcularDvh, Func<List<string>, string> calcularDvv, EventoBE_883SC evento)
        {
            SqlTransaction tr = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(ConexionConfig_883SC.ObtenerCadena_883SC()))
                {
                    cn.Open();
                    tr = cn.BeginTransaction();

                    int codigo = Convert.ToInt32(EjecutarSP_883SC(cn, tr, "SP_CrearUsuario", true,
                        new SqlParameter("@DNI", admin.dni_883SC),
                        new SqlParameter("@Nombre", admin.nomb_883SC),
                        new SqlParameter("@Apellido", admin.ape_883SC),
                        new SqlParameter("@Usuario", admin.user_883SC),
                        new SqlParameter("@Rol", admin.rol_883SC),
                        new SqlParameter("@Contraseña", admin.pass_883SC),
                        new SqlParameter("@Direccion", admin.dir_883SC),
                        new SqlParameter("@Telefono", admin.tel_883SC),
                        new SqlParameter("@Email", admin.email_883SC),
                        new SqlParameter("@Activo", admin.estado_883SC),
                        new SqlParameter("@Bloqueado", admin.bloq_883SC),
                        new SqlParameter("@UsuarioResponsable", evento.usuario_883SC),
                        new SqlParameter("@PrimerInicio", admin.primer_883SC)));

                    string dvh = calcularDvh(codigo);
                    EjecutarSP_883SC(cn, tr, "ActualizarDVH_SP", false,
                        new SqlParameter("@Codigo", codigo),
                        new SqlParameter("@DVH", dvh));
                    EjecutarSP_883SC(cn, tr, "SP_ActualizarDVV", false,
                        new SqlParameter("@tabla", "Usuarios"),
                        new SqlParameter("@dvv", calcularDvv(new List<string> { dvh })));
                    EjecutarSP_883SC(cn, tr, "SP_RegistrarEvento", false,
                        new SqlParameter("@usuario", evento.usuario_883SC),
                        new SqlParameter("@accion", (int)evento.accion_883SC),
                        new SqlParameter("@fecha", evento.fecha_883SC),
                        new SqlParameter("@detalle", evento.detalle_883SC == null ? (object)DBNull.Value : evento.detalle_883SC));

                    tr.Commit();
                }
            }
            catch (Exception ex)
            {
                Revertir_883SC(tr);
                throw new InicializacionException_883SC(MotivoInicializacion_883SC.AdminFallido,
                    "No se pudo crear el usuario administrador. No se guardo ningun cambio parcial: al volver a abrir la aplicacion se reintenta.\r\n\r\nDetalle: " + TextoDe_883SC(ex), ex);
            }
        }

        private static object EjecutarSP_883SC(SqlConnection cn, SqlTransaction tr, string sp, bool devuelveValor, params SqlParameter[] parametros)
        {
            using (SqlCommand cmd = new SqlCommand(sp, cn, tr))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parametros);
                return devuelveValor ? cmd.ExecuteScalar() : (object)cmd.ExecuteNonQuery();
            }
        }

        private static void EjecutarBatch_883SC(SqlConnection cn, SqlTransaction tr, string batch)
        {
            using (SqlCommand cmd = new SqlCommand(batch, cn, tr))
            {
                cmd.CommandTimeout = TimeoutScriptSegundos_883SC;
                cmd.ExecuteNonQuery();
            }
        }

        //Si un SP hizo su propio ROLLBACK (SP_CrearUsuario lo hace en el CATCH) la transaccion ya no existe en el servidor y
        //tr.Rollback() lanza InvalidOperationException; el efecto buscado (nada guardado) ya se logro, por eso se ignora.
        private static void Revertir_883SC(SqlTransaction tr)
        {
            if (tr == null) { return; }
            try { tr.Rollback(); }
            catch (Exception) { }
        }

        //Parte el script por las lineas que contienen solo GO (como hace sqlcmd). Los recursos estan embebidos en este ensamblado.
        public static List<string> LeerBatches_883SC(string recurso)
        {
            string texto;
            using (Stream flujo = Assembly.GetExecutingAssembly().GetManifestResourceStream(recurso))
            {
                if (flujo == null) { throw new InvalidOperationException("No se encuentra el recurso embebido '" + recurso + "'."); }
                using (StreamReader lector = new StreamReader(flujo, Encoding.UTF8, true)) { texto = lector.ReadToEnd(); }
            }
            List<string> batches = new List<string>();
            foreach (string parte in Regex.Split(texto, @"^[ \t]*GO[ \t]*\r?$", RegexOptions.Multiline | RegexOptions.IgnoreCase))
            {
                if (parte.Trim().Length > 0) { batches.Add(parte); }
            }
            return batches;
        }

        private static bool TieneError_883SC(SqlException ex, int numero)
        {
            foreach (SqlError e in ex.Errors) { if (e.Number == numero) { return true; } }
            return false;
        }

        private static bool TieneAlgunError_883SC(SqlException ex, int[] numeros)
        {
            foreach (int n in numeros) { if (TieneError_883SC(ex, n)) { return true; } }
            return false;
        }

        //Todos los mensajes que devolvio SQL Server (un CREATE DATABASE fallido trae varios errores encadenados)
        private static string TextoSql_883SC(SqlException ex)
        {
            //Un mismo error se repite una vez por fila afectada: se muestra una sola vez
            StringBuilder sb = new StringBuilder();
            HashSet<string> vistos = new HashSet<string>();
            foreach (SqlError e in ex.Errors)
            {
                string linea = "(" + e.Number + ") " + e.Message;
                if (!vistos.Add(linea)) { continue; }
                if (sb.Length > 0) { sb.Append(" | "); }
                sb.Append(linea);
            }
            return sb.ToString();
        }

        private static string TextoDe_883SC(Exception ex)
        {
            SqlException sql = ex as SqlException;
            return sql != null ? TextoSql_883SC(sql) : ex.Message;
        }
    }
}
