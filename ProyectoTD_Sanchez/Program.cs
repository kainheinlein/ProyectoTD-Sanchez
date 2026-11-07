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
        static void Main()
        {
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
                        resultado = new InicializacionBLL_883SC().Inicializar_883SC(conectando.MostrarEtapa_883SC);
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
                MessageBox.Show(MensajeDeError_883SC(error), "FerreSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (resultado.UsoInstanciaAlternativa_883SC)
            {
                MessageBox.Show("La instancia configurada (" + resultado.InstanciaConfigurada_883SC + ") no respondio. La aplicacion usa: " + resultado.InstanciaUsada_883SC +
                    ".\r\n\r\nPara que no vuelva a aparecer este aviso, corrija la cadena 'FerreDB' en " + AppDomain.CurrentDomain.SetupInformation.ConfigurationFile + ".",
                    "FerreSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Application.Run(new frmLogin_883SC());
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
