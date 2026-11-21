using Acceso_DAL;
using Entidad_BE;
using Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Negocio_BLL
{
    public class BackupBLL_883SC
    {
        private MP_Backup_883SC mpBackup_883SC = new MP_Backup_883SC();
        private BitacoraBLL_883SC bitacora_883SC = new BitacoraBLL_883SC();
        private VerificadorIntegridadBLL_883SC integridad_883SC = new VerificadorIntegridadBLL_883SC();
        private GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;
        private BackupService_883SC _servicio_883SC;

        //Se crea al primer uso: pedir la cadena abre una conexion y el formulario
        //no debe fallar al construirse si la base no responde
        private BackupService_883SC Servicio_883SC
        {
            get
            {
                if (_servicio_883SC == null)
                {
                    _servicio_883SC = new BackupService_883SC(mpBackup_883SC.ObtenerCadenaConexion_883SC());
                }
                return _servicio_883SC;
            }
        }

        private string UsuarioActual_883SC()
        {
            if (!SessionManager_883SC.Logged_883SC())
            {
                throw new InvalidOperationException(gestorIdioma_883SC.Traducir_883SC("BKP_ERR_SIN_SESION"));
            }
            return SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC;
        }

        //Mensaje comprensible para un fallo de backup con causa conocida (permisos, ruta, disco). No es un booleano de error:
        //la excepcion original viaja como InnerException.
        private InvalidOperationException Traducir_883SC(BackupException_883SC ex)
        {
            //La ruta puede ser de un archivo .bak o ya de la carpeta (ListarBak): se muestra siempre la carpeta
            string carpeta = string.Equals(Path.GetExtension(ex.Ruta_883SC), ".bak", StringComparison.OrdinalIgnoreCase)
                ? Path.GetDirectoryName(ex.Ruta_883SC)
                : ex.Ruta_883SC;
            string mensaje;
            switch (ex.Motivo_883SC)
            {
                case MotivoBackup_883SC.SqlSinAcceso:
                    mensaje = string.Format(gestorIdioma_883SC.Traducir_883SC("BKP_ERR_SQL_ACCESO"), carpeta);
                    break;
                case MotivoBackup_883SC.SqlRutaInexistente:
                    mensaje = string.Format(gestorIdioma_883SC.Traducir_883SC("BKP_ERR_SQL_RUTA"), carpeta);
                    break;
                case MotivoBackup_883SC.SqlDiscoLleno:
                    mensaje = string.Format(gestorIdioma_883SC.Traducir_883SC("BKP_ERR_SQL_DISCO"), carpeta);
                    break;
                case MotivoBackup_883SC.ClienteSinPermiso:
                    mensaje = string.Format(gestorIdioma_883SC.Traducir_883SC("BKP_ERR_SIN_LECTURA"), carpeta);
                    break;
                default:
                    mensaje = gestorIdioma_883SC.Traducir_883SC("BKP_ERR_SQL_OTRO") + Environment.NewLine + ex.Detalle_883SC;
                    break;
            }
            return new InvalidOperationException(mensaje, ex);
        }

        //Para anteponer a BKP_ERR_VERIFICACION: el texto traducido si la causa es conocida, el de la excepcion si no
        private string MensajeDe_883SC(Exception ex)
        {
            BackupException_883SC conocida = ex as BackupException_883SC;
            return conocida == null ? ex.Message : Traducir_883SC(conocida).Message;
        }

        //prefijo: primera parte del nombre del archivo (por defecto "FerreDB"; la carga de datos de prueba usa "PreDatosPrueba").
        public BackupBE_883SC RealizarBackup_883SC(string prefijo = "FerreDB")
        {
            string usuario = UsuarioActual_883SC();
            //El DVV solo se refresca en el logout: tras un cambio de clave (primer inicio) o un alta de usuarios en esta misma sesion el
            //DVV de la base esta desfasado, y un backup tomado asi lo restauraria inconsistente. Solo actua si la integridad fue verificada.
            integridad_883SC.ActualizarDVVSiVerificado_883SC();
            string carpeta = Servicio_883SC.ObtenerCarpetaBackup_883SC();
            DateTime ahora = DateTime.Now;
            string nombre = prefijo + "_" + ahora.ToString("yyyyMMdd_HHmmss") + ".bak";
            string ruta = Path.Combine(carpeta, nombre);

            long? tamanio;
            try
            {
                tamanio = Servicio_883SC.EjecutarBackup_883SC(ruta);
            }
            catch (BackupException_883SC ex)
            {
                BorrarSiExiste_883SC(ruta);
                throw Traducir_883SC(ex);
            }
            catch
            {
                BorrarSiExiste_883SC(ruta);//Por si quedo un archivo a medio escribir
                throw;
            }
            try
            {
                Servicio_883SC.VerificarArchivo_883SC(ruta);
            }
            catch (Exception ex)
            {
                BorrarSiExiste_883SC(ruta);
                throw new InvalidOperationException(gestorIdioma_883SC.Traducir_883SC("BKP_ERR_VERIFICACION") + MensajeDe_883SC(ex), ex);
            }

            BackupBE_883SC backup = new BackupBE_883SC();
            backup.NombreArchivo_883SC = nombre;
            backup.Ruta_883SC = carpeta;
            backup.Fecha_883SC = ahora;
            backup.Usuario_883SC = usuario;
            backup.TamanioBytes_883SC = tamanio;
            backup.Verificado_883SC = true;
            mpBackup_883SC.Registrar_883SC(backup);

            bitacora_883SC.RegistrarBitacora_883SC(usuario, TipoAccion_883SC.BackupRealizado, "archivo=" + nombre);
            return backup;
        }

        public void Restaurar_883SC(int id)
        {
            string usuario = UsuarioActual_883SC();
            BackupBE_883SC backup = mpBackup_883SC.Obtener_883SC(id);
            string ruta = backup.RutaCompleta_883SC;

            //El catalogo vive en la misma base que se restaura: la base restaurada trae el catalogo de cuando se tomo ese
            //backup (sin el y sin los posteriores). Se guarda ahora para restituirlo despues. El aviso se traduce ahora
            //porque un backup viejo puede no tener la clave.
            List<BackupBE_883SC> catalogoPrevio = mpBackup_883SC.Listar_883SC();
            string avisoCatalogo = gestorIdioma_883SC.Traducir_883SC("BKP_RESTORE_AVISO_CATALOGO");

            try
            {
                if (!Servicio_883SC.Existe_883SC(ruta))
                {
                    throw new FileNotFoundException(gestorIdioma_883SC.Traducir_883SC("BKP_ERR_ARCHIVO_NO_EXISTE") + backup.NombreArchivo_883SC);
                }
                try
                {
                    Servicio_883SC.VerificarArchivo_883SC(ruta);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(gestorIdioma_883SC.Traducir_883SC("BKP_ERR_VERIFICACION") + MensajeDe_883SC(ex), ex);
                }

                Servicio_883SC.Restaurar_883SC(ruta);
            }
            catch (BackupException_883SC ex)
            {
                throw Traducir_883SC(ex);
            }

            //Las traducciones de la base restaurada pueden ser otras. Es de mejor esfuerzo:
            //si falla se conservan los textos cargados y el restore igual se informa.
            try { gestorIdioma_883SC.Recargar_883SC(); }
            catch { }

            //Si falla, el restore igual se completo: se informa al final (bitacora y logout van igual)
            Exception falloCatalogo = null;
            try { mpBackup_883SC.Sincronizar_883SC(catalogoPrevio); }
            catch (Exception ex) { falloCatalogo = ex; }

            try
            {
                string detalle = "archivo=" + backup.NombreArchivo_883SC;
                if (falloCatalogo != null) { detalle += ";catalogo=sin_sincronizar"; }
                bitacora_883SC.RegistrarBitacora_883SC(usuario, TipoAccion_883SC.RestoreRealizado, detalle);
            }
            finally
            {
                SessionManager_883SC.GetInstance_883SC.Logout_883SC();
            }

            if (falloCatalogo != null)
            {
                throw new CatalogoBackupsDesactualizadoException_883SC(avisoCatalogo, falloCatalogo);
            }
        }

        public List<BackupBE_883SC> Listar_883SC()
        {
            return mpBackup_883SC.Listar_883SC();
        }

        public void Eliminar_883SC(int id)
        {
            string usuario = UsuarioActual_883SC();
            BackupBE_883SC backup = mpBackup_883SC.Obtener_883SC(id);

            try
            {
                Servicio_883SC.Borrar_883SC(backup.RutaCompleta_883SC);
            }
            catch (BackupException_883SC ex)
            {
                throw Traducir_883SC(ex);//El registro del catalogo se conserva: el archivo no se pudo borrar
            }
            mpBackup_883SC.Eliminar_883SC(id);

            bitacora_883SC.RegistrarBitacora_883SC(usuario, TipoAccion_883SC.BackupEliminado, "archivo=" + backup.NombreArchivo_883SC);
        }

        //Solo informa. Faltantes: filas del catalogo cuyo archivo no esta en disco.
        //Huerfanos: .bak de la carpeta del servidor que no figuran en el catalogo.
        public void VerificarArchivos_883SC(out List<string> faltantes, out List<string> huerfanos)
        {
            List<BackupBE_883SC> catalogo = mpBackup_883SC.Listar_883SC();
            string carpeta = Servicio_883SC.ObtenerCarpetaBackup_883SC();

            //Si el usuario de Windows no puede acceder a la carpeta, no se informa "faltante" (no se sabe): se lanza la excepcion
            try
            {
                faltantes = catalogo
                    .Where(b => !Servicio_883SC.Existe_883SC(b.RutaCompleta_883SC))
                    .Select(b => b.NombreArchivo_883SC)
                    .ToList();

                HashSet<string> registrados = new HashSet<string>(
                    catalogo.Select(b => b.NombreArchivo_883SC), StringComparer.OrdinalIgnoreCase);
                huerfanos = Servicio_883SC.ListarBak_883SC(carpeta)
                    .Select(f => Path.GetFileName(f))
                    .Where(n => !registrados.Contains(n))
                    .ToList();
            }
            catch (BackupException_883SC ex)
            {
                throw Traducir_883SC(ex);
            }
        }

        private void BorrarSiExiste_883SC(string ruta)
        {
            try
            {
                if (Servicio_883SC.Existe_883SC(ruta)) { Servicio_883SC.Borrar_883SC(ruta); }
            }
            catch { }
        }
    }
}
