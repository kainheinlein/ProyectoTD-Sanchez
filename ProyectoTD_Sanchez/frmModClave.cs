using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmModClave_883SC : Form, IObservadorIdioma_883SC
    {
        public frmModClave_883SC()
        {
            InitializeComponent();
            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmModClave_FormClosed_883SC;
        }

        UsuarioBLL_883SC usuario_883SC = new UsuarioBLL_883SC();
        BitacoraBLL_883SC bitacora_883SC = new BitacoraBLL_883SC();
        UsuarioBE_883SC us_883SC = new UsuarioBE_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;
        int verif_883SC = 0;
        string patron_883SC = "^[A-Za-z0-9]+$";

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = gestorIdioma_883SC.Traducir_883SC("CLAVE_TITULO");
            lblActual.Text = gestorIdioma_883SC.Traducir_883SC("CLAVE_LBL_ACTUAL");
            lblNuevo.Text = gestorIdioma_883SC.Traducir_883SC("CLAVE_LBL_NUEVA");
            lblRep.Text = gestorIdioma_883SC.Traducir_883SC("CLAVE_LBL_REPETIR");
            btnLogin.Text = gestorIdioma_883SC.Traducir_883SC("CLAVE_BTN_CONFIRMAR");
            btnAceptar.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_ACEPTAR");
            btnCancel.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_CANCELAR");
            if (lblInstrucciones.Text != "")
            {
                lblInstrucciones.Text = gestorIdioma_883SC.Traducir_883SC("CLAVE_MSG_INSTRUCCIONES");
            }
        }

        private void frmModClave_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        #endregion


        #region Modificadores Formulario
        public void CambiarEnabled_883SC()
        {
            if (txtClave.Text != "" & txtClaveRep.Text != "")
            {
                btnAceptar.Enabled = true;
            }
            else { btnAceptar.Enabled = false; }
        }

        public void LimpiaClave_883SC()
        {
            txtClave.Clear();
            txtClaveRep.Clear();
            txtClave.Focus();
        }

        public void VerificarEnabled_883SC()
        {
            if (txtActual.Text != "")
            {
                btnLogin.Enabled = true;
            }
            else { btnLogin.Enabled = false; }
        }

        private void txtActual_KeyPress_883SC(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btnLogin_Click_883SC(sender, e);
            }
        }
        private void txtActual_TextChanged_883SC(object sender, EventArgs e)
        {
            VerificarEnabled_883SC();
            lblError.Text = "";
        }

        private void txtClave_TextChanged_883SC(object sender, EventArgs e)
        {
            CambiarEnabled_883SC();
            lblError.Text = "";
        }

        private void txtClaveRep_TextChanged_883SC(object sender, EventArgs e)
        {
            CambiarEnabled_883SC();
            lblError.Text = "";
        }

        private void txtClaveRep_KeyPress_883SC(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btnAceptar_Click_883SC(sender, e);
            }
        }

        #endregion

        bool OkText_883SC(string text)
        {
            return Regex.IsMatch(text, patron_883SC);
        }

        private void btnLogin_Click_883SC(object sender, EventArgs e)
        {
            if (OkText_883SC(txtActual.Text))
            {
                us_883SC.pass_883SC = txtActual.Text;
                verif_883SC = usuario_883SC.VerifUsuario_883SC(us_883SC, 0);

                switch (verif_883SC)
                {
                    case 0:
                        txtActual.Clear();
                        txtActual.Focus();
                        lblError.Text = string.Format(gestorIdioma_883SC.Traducir_883SC("CLAVE_ERR_INTENTOS"), usuario_883SC.maxIntentos_883SC.ToString());
                        bitacora_883SC.RegistrarBitacora_883SC(SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC, TipoAccion_883SC.LoginFail);
                        //txtActual.Clear();
                        //txtActual.Focus();
                        //lblError.Text = $"Contraseña incorrecta, quedan {usuario.maxIntentos.ToString()} intentos";
                        break;
                    case 1:
                        btnLogin.Visible = false;
                        lblActual.Visible = false;
                        txtActual.Visible = false;
                        lblNuevo.Visible = true;
                        txtClave.Visible = true;
                        lblRep.Visible = true;
                        txtClaveRep.Visible = true;
                        btnAceptar.Visible = true;
                        lblInstrucciones.Text = gestorIdioma_883SC.Traducir_883SC("CLAVE_MSG_INSTRUCCIONES");
                        txtClave.Focus();
                        break;
                    case 2:
                        MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("CLAVE_MSG_BLOQUEADO"), gestorIdioma_883SC.Traducir_883SC("CLAVE_TIT_BLOQUEADO"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        bitacora_883SC.RegistrarBitacora_883SC(SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC, TipoAccion_883SC.BloqueoUsuario);
                        usuario_883SC.Logout_883SC();
                        Application.Exit();
                        break;
                }
            }
            else
            {
                txtActual.Clear();
                lblError.Text = gestorIdioma_883SC.Traducir_883SC("CLAVE_ERR_FORMATO");
            }
        }

        private void btnAceptar_Click_883SC(object sender, EventArgs e)
        {
            if (OkText_883SC(txtClave.Text) && OkText_883SC(txtClaveRep.Text))
            {
                if (txtClave.Text == txtClaveRep.Text)
                {
                    try
                    {
                        us_883SC.pass_883SC = txtClave.Text;
                        verif_883SC = usuario_883SC.VerifUsuario_883SC(us_883SC, 1);

                        if (verif_883SC == 1)
                        {
                            LimpiaClave_883SC();
                            gestorIdioma_883SC.Traducir_883SC("CLAVE_ERR_IGUAL_ANTERIOR");
                        }
                        else
                        {
                            MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("CLAVE_MSG_OK"), gestorIdioma_883SC.Traducir_883SC("CLAVE_TIT_OK"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("COMUN_ERROR_BD") + ex.Message);
                        this.Close();
                    }
                }
                else
                {
                    LimpiaClave_883SC();
                    lblError.Text = gestorIdioma_883SC.Traducir_883SC("CLAVE_ERR_DISTINTAS");
                }
            }
            else
            {
                LimpiaClave_883SC();
                lblError.Text = gestorIdioma_883SC.Traducir_883SC("CLAVE_ERR_NO_FORMATO");
            }
        }

        private void btnCancel_Click_883SC(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
