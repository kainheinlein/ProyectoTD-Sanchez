using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmLogin_883SC : Form, IObservadorIdioma_883SC
    {
        public frmLogin_883SC()
        {
            InitializeComponent();
        }

        UsuarioBLL_883SC usuario_883SC = new UsuarioBLL_883SC();
        BitacoraBLL_883SC bitacora_883SC = new BitacoraBLL_883SC();
        VerificadorIntegridadBLL_883SC IntegridadBLL_883SC = new VerificadorIntegridadBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        private void frmLogin_Load_883SC(object sender, EventArgs e)
        {
            try
            {
                if (IntegridadBLL_883SC.VerificarIntegridad_883SC())
                {
                    txtContra.boton_883SC = this.btnIniciar;
                    lblError.Text = "";
                    CargarMenuIdiomas_883SC();
                    gestorIdioma_883SC.Suscribir_883SC(this);
                    this.FormClosed += frmLogin_FormClosed_883SC;
                }
                else
                {
                    using (var formRecalcular = new frmRecalcular_883SC())
                    {
                        if (formRecalcular.ShowDialog() == DialogResult.OK)
                        {
                            IntegridadBLL_883SC.RecalcularDV_883SC();
                            if (!IntegridadBLL_883SC.VerificarIntegridad_883SC())
                            {
                                MessageBox.Show("No fue posible restaurar la integridad.");
                                Application.Exit();
                            }
                        } else Application.Exit();
                        MessageBox.Show("Integridad de la base de datos restaurada", "Integridad Restaurada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblError.Text = "";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmLogin_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = gestorIdioma_883SC.Traducir_883SC("LOGIN_TITULO");
            lblUsuario.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_USUARIO");
            lblContra.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_CONTRASENA");
            btnIniciar.Text = gestorIdioma_883SC.Traducir_883SC("LOGIN_BTN_INICIAR");
            btnCancelar.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_CANCELAR");
            lblSinConexion.Text = gestorIdioma_883SC.Traducir_883SC("LOGIN_LNK_SIN_CONEXION");
            cambiarIdiomaToolStripMenuItem.Text = gestorIdioma_883SC.Traducir_883SC("MENU_CAMBIAR_IDIOMA");
            MarcarIdiomaActivo_883SC();
        }

        private void CargarMenuIdiomas_883SC()
        {
            try
            {
                cambiarIdiomaToolStripMenuItem.DropDownItems.Clear();
                foreach (IdiomaBE_883SC idioma in gestorIdioma_883SC.ObtenerIdiomas_883SC())
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(idioma.Nombre_883SC);
                    item.Tag = idioma.Codigo_883SC;
                    item.Click += itemIdioma_Click_883SC;
                    cambiarIdiomaToolStripMenuItem.DropDownItems.Add(item);
                }
            }
            catch { }//Sin conexion a la BD no se ofrece el cambio de idioma
        }

        private void MarcarIdiomaActivo_883SC()
        {
            foreach (ToolStripMenuItem item in cambiarIdiomaToolStripMenuItem.DropDownItems)
            {
                item.Checked = gestorIdioma_883SC.IdiomaActual_883SC != null
                    && item.Tag.ToString() == gestorIdioma_883SC.IdiomaActual_883SC.Codigo_883SC;
            }
        }

        private void itemIdioma_Click_883SC(object sender, EventArgs e)
        {
            try
            {
                gestorIdioma_883SC.CambiarIdioma_883SC((sender as ToolStripMenuItem).Tag.ToString());
                bitacora_883SC.RegistrarBitacora_883SC("null", TipoAccion_883SC.CambioIdioma);
            }
            catch (Exception ex)
            {
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("COMUN_ERROR_BD") + ex.Message);
            }
        }

        #endregion


        private void txtContra_Load_883SC(object sender, EventArgs e)
        {
            txtContra.Hide_883SC(true);
        }

        private void btnCancelar_Click_883SC(object sender, EventArgs e)
        {
            if (MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("COMUN_CONFIRMA_SALIR_APP"), gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"),
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (SessionManager_883SC.Logged_883SC()) { usuario_883SC.Logout_883SC(); }
                    else { bitacora_883SC.RegistrarBitacora_883SC("null", TipoAccion_883SC.AppClose); }
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else txtUsuario.Enfocar_883SC();
        }

        private void btnIniciar_Click_883SC(object sender, EventArgs e)
        {
            UsuarioBE_883SC user;

            if (!txtUsuario.ok_883SC || !txtContra.ok_883SC)
            {
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("LOGIN_MSG_DATOS_INVALIDOS"), gestorIdioma_883SC.Traducir_883SC("LOGIN_TIT_DATOS_INVALIDOS"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    user = new UsuarioBE_883SC();
                    user.user_883SC = txtUsuario.texto_883SC;
                    user.pass_883SC = txtContra.texto_883SC;

                    LoginResult_883SC authOK = usuario_883SC.Login_883SC(user);
                    if (authOK == LoginResult_883SC.LoginOK_883SC)
                    {
                        bitacora_883SC.RegistrarBitacora_883SC(user.user_883SC, TipoAccion_883SC.Login);
                        frmMenu_883SC frm = new frmMenu_883SC();
                        frm.Show();
                        this.Hide();

                        frm.FormClosing += frm_closing_883SC;
                    }
                    else
                    {
                        //Mensaje de label de Error
                        switch (authOK)
                        {
                            case LoginResult_883SC.UserInexistente_883SC:
                                bitacora_883SC.RegistrarBitacora_883SC(user.user_883SC, TipoAccion_883SC.LoginFail);
                                lblError.Text = gestorIdioma_883SC.Traducir_883SC("LOGIN_ERR_USER_INEXISTENTE");
                                break;
                            case LoginResult_883SC.UserBloqueado_883SC:
                                bitacora_883SC.RegistrarBitacora_883SC(user.user_883SC, TipoAccion_883SC.LoginFail);
                                lblError.Text = gestorIdioma_883SC.Traducir_883SC("LOGIN_ERR_USER_BLOQUEADO");
                                break;
                            case LoginResult_883SC.PassIncorrecta_883SC:
                                bitacora_883SC.RegistrarBitacora_883SC(user.user_883SC, TipoAccion_883SC.LoginFail);
                                lblError.Text = gestorIdioma_883SC.Traducir_883SC("LOGIN_ERR_PASS_INCORRECTA");
                                break;
                            case LoginResult_883SC.UserInactivo_883SC:
                                bitacora_883SC.RegistrarBitacora_883SC(user.user_883SC, TipoAccion_883SC.LoginFail);
                                MessageBox.Show(string.Format(gestorIdioma_883SC.Traducir_883SC("LOGIN_MSG_USER_INACTIVO"), user.user_883SC), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                break;
                            case LoginResult_883SC.FinIntentos_883SC:
                                bitacora_883SC.RegistrarBitacora_883SC(user.user_883SC, TipoAccion_883SC.BloqueoUsuario);
                                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("LOGIN_MSG_FIN_INTENTOS"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Application.Exit();
                                break;
                            case LoginResult_883SC.SesionIniciada_883SC:
                                bitacora_883SC.RegistrarBitacora_883SC(user.user_883SC, TipoAccion_883SC.Login);
                                MessageBox.Show(string.Format(gestorIdioma_883SC.Traducir_883SC("LOGIN_MSG_SESION_INICIADA"), user.user_883SC), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                frmMenu_883SC frm = new frmMenu_883SC();
                                frm.Show();
                                this.Hide();

                                frm.FormClosing += frm_closing_883SC;
                                break;
                            case LoginResult_883SC.ExisteSesion_883SC:
                                if (MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("LOGIN_MSG_EXISTE_SESION"), " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    bitacora_883SC.RegistrarBitacora_883SC(user.user_883SC, TipoAccion_883SC.Logout);
                                    usuario_883SC.Logout_883SC();
                                    MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("LOGIN_MSG_SESION_CERRADA"), " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else { MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("LOGIN_MSG_USUARIO_EN_USO"), " ", MessageBoxButtons.OK, MessageBoxIcon.Hand); }
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("COMUN_ERROR_BD") + ex.Message);
                }
            }
            txtUsuario.Limpiar_883SC();
            txtContra.Limpiar_883SC();
            txtUsuario.Enfocar_883SC();
        }

        private void lblSinConexion_Click_883SC(object sender, EventArgs e)
        {
            bitacora_883SC.RegistrarBitacora_883SC("null", TipoAccion_883SC.NoSesion);
            usuario_883SC.Logout_883SC();
            frmMenu_883SC frm = new frmMenu_883SC();
            frm.Show();
            this.Hide();
        }

        private void lblSinConexion_MouseHover_883SC(object sender, EventArgs e)
        {
            var font = ((Label)sender).Font;

            ((Label)sender).Font = new Font(font, FontStyle.Bold);

            font.Dispose();
        }

        private void lblSinConexion_MouseLeave_883SC(object sender, EventArgs e)
        {
            var font = ((Label)sender).Font;

            ((Label)sender).Font = new Font(font, FontStyle.Regular);

            font.Dispose();
        }

        private void frm_closing_883SC(object sender, FormClosingEventArgs e)
        {
            txtContra.Limpiar_883SC();
            txtUsuario.Limpiar_883SC();
            this.Show();
            txtUsuario.Enfocar_883SC();
        }

        private void txtUsuario_Leave_883SC(object sender, EventArgs e)
        {
            lblError.Text = "";
        }
    }
}
