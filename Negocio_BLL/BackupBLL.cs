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

        public BackupBE_883SC RealizarBackup_883SC()
        {
            string usuario = UsuarioActual_883SC();
            string carpeta = Servicio_883SC.ObtenerCarpetaBackup_883SC();
            DateTime ahora = DateTime.Now;
            string nombre = "FerreDB_" + ahora.ToString("yyyyMMdd_HHmmss") + ".bak";
            string ruta = Path.Combine(carpeta, nombre);

            long? tamanio;
            try
            {
                tamanio = Servicio_883SC.EjecutarBackup_883SC(ruta);
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
                throw new InvalidOperationException(gestorIdioma_883SC.Traducir_883SC("BKP_ERR_VERIFICACION") + ex.Message, ex);
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
                throw new InvalidOperationException(gestorIdioma_883SC.Traducir_883SC("BKP_ERR_VERIFICACION") + ex.Message, ex);
            }

            Servicio_883SC.Restaurar_883SC(ruta);

            //Las traducciones de la base restaurada pueden ser otras. Es de mejor esfuerzo:
            //si falla se conservan los textos cargados y el restore igual se informa.
            try { gestorIdioma_883SC.Recargar_883SC(); }
            catch { }

            try
            {
                bitacora_883SC.RegistrarBitacora_883SC(usuario, TipoAccion_883SC.RestoreRealizado, "archivo=" + backup.NombreArchivo_883SC);
            }
            finally
            {
                SessionManager_883SC.GetInstance_883SC.Logout_883SC();
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

            Servicio_883SC.Borrar_883SC(backup.RutaCompleta_883SC);
            mpBackup_883SC.Eliminar_883SC(id);

            bitacora_883SC.RegistrarBitacora_883SC(usuario, TipoAccion_883SC.BackupEliminado, "archivo=" + backup.NombreArchivo_883SC);
        }

        //Solo informa. Faltantes: filas del catalogo cuyo archivo no esta en disco.
        //Huerfanos: .bak de la carpeta del servidor que no figuran en el catalogo.
        public void VerificarArchivos_883SC(out List<string> faltantes, out List<string> huerfanos)
        {
            List<BackupBE_883SC> catalogo = mpBackup_883SC.Listar_883SC();
            string carpeta = Servicio_883SC.ObtenerCarpetaBackup_883SC();

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
