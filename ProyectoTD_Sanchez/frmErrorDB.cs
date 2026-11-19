using Negocio_BLL;
using Servicios;
using System;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    //Se abre despues de autenticar, solo para un usuario con permiso GestionBackup, cuando la
    //verificacion de integridad falla. El llamador decide que hacer segun el estado de la sesion.
    public partial class frmErrorDB_883SC : Form, IObservadorIdioma_883SC
    {
        public frmErrorDB_883SC()
        {
            InitializeComponent();
        }

        VerificadorIntegridadBLL_883SC integridadBLL_883SC = new VerificadorIntegridadBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        private void frmErrorDB_Load_883SC(object sender, EventArgs e)
        {
            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmErrorDB_FormClosed_883SC;
        }

        private void frmErrorDB_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = gestorIdioma_883SC.Traducir_883SC("ERRORDB_TITULO");
            lblMensaje.Text = gestorIdioma_883SC.Traducir_883SC("ERRORDB_MSG");
            btnRecalcular.Text = gestorIdioma_883SC.Traducir_883SC("ERRORDB_BTN_RECALCULAR");
            btnRestaurar.Text = gestorIdioma_883SC.Traducir_883SC("ERRORDB_BTN_RESTAURAR");
            btnCancelar.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_CANCELAR");
        }

        #endregion

        private void btnRecalcular_Click_883SC(object sender, EventArgs e)
        {
            if (MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("ERRORDB_CONFIRMA_RECALCULAR"), gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                //Recalcula, verifica y registra el evento; lanza excepcion si no quedo consistente
                integridadBLL_883SC.RecalcularDV_883SC();
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("ERRORDB_MSG_RECALCULADO"), gestorIdioma_883SC.Traducir_883SC("ERRORDB_TIT_RECALCULADO"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestaurar_Click_883SC(object sender, EventArgs e)
        {
            using (frmRestore_883SC frmRestore = new frmRestore_883SC())
            {
                //Si restaura, BackupBLL ya cerro la sesion: el llamador lo detecta
                if (frmRestore.ShowDialog(this) == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.Abort;
                }
            }
        }

        private void btnCancelar_Click_883SC(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
