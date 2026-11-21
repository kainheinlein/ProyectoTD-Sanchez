using Entidad_BE;
using Negocio_BLL;
using ProyectoCampo_JuanFer;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    internal static class Program_883SC
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            //Desinstalador: --eliminar-base elimina la base configurada (sin interfaz). Codigo 0 = ok; otro = error (detalle en el log del TEMP).
            if (args != null && Array.Exists(args, a => string.Equals(a, "--eliminar-base", StringComparison.OrdinalIgnoreCase)))
            {
                try
                {
                    new InicializacionBLL_883SC().EliminarBase_883SC();
                    return 0;
                }
                catch (Exception ex)
                {
                    try { System.IO.File.WriteAllText(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "FerreSV_eliminar_base.log"), DateTime.Now.ToString("s") + " " + ex.Message + Environment.NewLine); }
                    catch (Exception) { }
                    return 1;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Antes de crear frmLogin: la cadena se resuelve aca (puede tardar hasta ~12 s con fallback) y se prepara la base.
            //Se hace en un hilo aparte para que el aviso "Conectando..." siga respondiendo.
            ResultadoInicializacionBE_883SC resultado = null;
            Exception error = null;
            using (frmConectando_883SC conectando = new frmConectando_883SC())
            {
                conectando.Shown += (s, e) => Task.Run(() =>
                {
                    try
                    {
                        conectando.MostrarEtapa_883SC("Conectando con SQL Server...");
                        ConexionConfig_883SC.ObtenerCadena_883SC();
                        resultado = new InicializacionBLL_883SC().Inicializar_883SC(conectando.MostrarEtapa_883SC, conectando.ConfirmarBaseNueva_883SC);
                    }
                    catch (Exception ex)
                    {
                        error = ex;
                    }
                    finally
                    {
                        conectando.CerrarAviso_883SC();
                    }
                });
                conectando.ShowDialog();
            }

            if (error != null)
            {
                //El usuario eligio no crear la base en la instancia alternativa: se cierra sin mensaje de error
                InicializacionException_883SC cancelada = error as InicializacionException_883SC;
                if (cancelada != null && cancelada.Motivo_883SC == MotivoInicializacion_883SC.CanceladaPorUsuario) { return 0; }

                MessageBox.Show(MensajeDeError_883SC(error), "FerreSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }

            Application.Run(new frmLogin_883SC());
            return 0;
        }

        private static string MensajeDeError_883SC(Exception ex)
        {
            if (ex is ConexionNoDisponibleException_883SC || ex is InicializacionException_883SC)
            {
                return ex.Message;
            }
            return "No se pudo iniciar la aplicacion: " + ex.Message + "\r\n\r\nRevise la cadena 'FerreDB' en " + AppDomain.CurrentDomain.SetupInformation.ConfigurationFile + ".";
        }
    }
}
