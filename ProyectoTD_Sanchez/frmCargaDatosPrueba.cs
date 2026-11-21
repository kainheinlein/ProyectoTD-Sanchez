using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    /// Dialogo de Admin -> Cargar datos de prueba. Corre DatosPruebaBLL en otro hilo (para que el aviso de cada etapa siga
    /// respondiendo) y al terminar muestra el resultado: nombre del backup y usuarios de prueba con su clave, o el error.
    public partial class frmCargaDatosPrueba_883SC : Form, IObservadorIdioma_883SC
    {
        private readonly DatosPruebaBLL_883SC datosPruebaBLL_883SC = new DatosPruebaBLL_883SC();
        private readonly GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;
        private bool terminado_883SC = false;

        public frmCargaDatosPrueba_883SC()
        {
            InitializeComponent();
        }

        public void ActualizarTextos_883SC()
        {
            this.Text = gestorIdioma_883SC.Traducir_883SC("DAT_TITULO");
            lblTitulo.Text = terminado_883SC ? gestorIdioma_883SC.Traducir_883SC("DAT_TITULO") : gestorIdioma_883SC.Traducir_883SC("DAT_LBL_TRABAJANDO");
            btnCerrar.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_SALIR");
        }

        private void frmCargaDatosPrueba_Load_883SC(object sender, EventArgs e)
        {
            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += (s, ev) => gestorIdioma_883SC.Desuscribir_883SC(this);
            lblEtapa.Text = "";
        }

        private void frmCargaDatosPrueba_Shown_883SC(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                ResultadoDatosPruebaBE_883SC resultado = null;
                Exception error = null;
                try { resultado = datosPruebaBLL_883SC.CargarDatosPrueba_883SC(MostrarEtapa_883SC); }
                catch (Exception ex) { error = ex; }
                if (!IsDisposed && IsHandleCreated) { BeginInvoke(new Action(() => MostrarResultado_883SC(resultado, error))); }
            });
        }

        //Se llama desde el hilo de trabajo
        private void MostrarEtapa_883SC(string texto)
        {
            if (IsDisposed || !IsHandleCreated) { return; }
            BeginInvoke(new Action(() => lblEtapa.Text = texto));
        }

        private void MostrarResultado_883SC(ResultadoDatosPruebaBE_883SC resultado, Exception error)
        {
            terminado_883SC = true;
            barra.Visible = false;
            lblEtapa.Visible = false;
            StringBuilder sb = new StringBuilder();
            if (error != null)
            {
                lblTitulo.ForeColor = System.Drawing.Color.Firebrick;
                sb.Append(error.Message);
            }
            else
            {
                sb.AppendLine(gestorIdioma_883SC.Traducir_883SC("DAT_RES_OK"));
                sb.AppendLine(string.Format(gestorIdioma_883SC.Traducir_883SC("DAT_RES_CONTENIDO"),
                    resultado.Proveedores_883SC, resultado.Productos_883SC, resultado.Clientes_883SC, resultado.Usuarios_883SC.Count));
                sb.AppendLine();
                sb.AppendLine(string.Format(gestorIdioma_883SC.Traducir_883SC("DAT_RES_BACKUP"), resultado.NombreBackup_883SC));
                sb.AppendLine(gestorIdioma_883SC.Traducir_883SC("DAT_RES_RESTORE"));
                sb.AppendLine();
                sb.AppendLine(gestorIdioma_883SC.Traducir_883SC("DAT_RES_USUARIOS"));
                foreach (UsuarioPruebaBE_883SC u in resultado.Usuarios_883SC)
                {
                    sb.AppendLine(string.Format(gestorIdioma_883SC.Traducir_883SC("DAT_RES_USUARIO_FILA"), u.Usuario_883SC, u.Rol_883SC, u.Clave_883SC));
                }
            }
            txtResultado.Text = sb.ToString();
            txtResultado.Visible = true;
            btnCerrar.Enabled = true;
            ActualizarTextos_883SC();
        }

        private void btnCerrar_Click_883SC(object sender, EventArgs e)
        {
            this.Close();
        }

        //Mientras se carga no se puede cerrar (Alt+F4): dejaria el proceso a medias sin avisar
        private void frmCargaDatosPrueba_FormClosing_883SC(object sender, FormClosingEventArgs e)
        {
            if (!terminado_883SC) { e.Cancel = true; }
        }
    }
}
