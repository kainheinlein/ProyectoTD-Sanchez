using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmRestore_883SC : Form, IObservadorIdioma_883SC
    {
        public frmRestore_883SC()
        {
            InitializeComponent();
        }

        BackupBLL_883SC backupBLL_883SC = new BackupBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        private void frmRestore_Load_883SC(object sender, EventArgs e)
        {
            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmRestore_FormClosed_883SC;
            CargarGrilla_883SC();
        }

        private void frmRestore_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = gestorIdioma_883SC.Traducir_883SC("BKP_RESTORE_TITULO");
            lblTitulo.Text = gestorIdioma_883SC.Traducir_883SC("BKP_RESTORE_LBL_TITULO");
            lblAviso.Text = gestorIdioma_883SC.Traducir_883SC("BKP_RESTORE_AVISO");
            btnRestaurar.Text = gestorIdioma_883SC.Traducir_883SC("BKP_BTN_RESTAURAR");
            btnCancelar.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_CANCELAR");
            TraducirColumnas_883SC();
        }

        private void TraducirColumnas_883SC()
        {
            if (dgvBackups.Columns.Count == 0) { return; }
            dgvBackups.Columns["NombreArchivo_883SC"].HeaderText = gestorIdioma_883SC.Traducir_883SC("BKP_COL_ARCHIVO");
            dgvBackups.Columns["Fecha_883SC"].HeaderText = gestorIdioma_883SC.Traducir_883SC("COMUN_FECHA");
            dgvBackups.Columns["Usuario_883SC"].HeaderText = gestorIdioma_883SC.Traducir_883SC("COMUN_USUARIO");
            dgvBackups.Columns["TamanioBytes_883SC"].HeaderText = gestorIdioma_883SC.Traducir_883SC("BKP_COL_TAMANIO");
            dgvBackups.Columns["Verificado_883SC"].HeaderText = gestorIdioma_883SC.Traducir_883SC("BKP_COL_VERIFICADO");
        }

        #endregion

        private void CargarGrilla_883SC()
        {
            try
            {
                dgvBackups.DataSource = backupBLL_883SC.Listar_883SC();
                dgvBackups.Columns["Id_883SC"].Visible = false;
                dgvBackups.Columns["Ruta_883SC"].Visible = false;
                dgvBackups.Columns["RutaCompleta_883SC"].Visible = false;
                dgvBackups.Columns["Fecha_883SC"].DefaultCellStyle.Format = "g";
                dgvBackups.Columns["TamanioBytes_883SC"].DefaultCellStyle.Format = "N0";
                dgvBackups.Columns["TamanioBytes_883SC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvBackups.Columns["NombreArchivo_883SC"].FillWeight = 200;
                dgvBackups.EnableHeadersVisualStyles = false;
                dgvBackups.ColumnHeadersDefaultCellStyle.Font = new Font(dgvBackups.Font, FontStyle.Bold);
                dgvBackups.ReadOnly = true;
                TraducirColumnas_883SC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("COMUN_ERROR_BD") + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestaurar_Click_883SC(object sender, EventArgs e)
        {
            if (dgvBackups.CurrentRow == null)
            {
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("BKP_MSG_SELECCIONE"), gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            BackupBE_883SC backup = (BackupBE_883SC)dgvBackups.CurrentRow.DataBoundItem;

            //Confirmacion fuerte: archivo y fecha, perdida de datos posteriores y cierre de sesion. Cancelar por defecto.
            string mensaje = gestorIdioma_883SC.Traducir_883SC("BKP_RESTORE_CONFIRMA") + Environment.NewLine + Environment.NewLine
                + gestorIdioma_883SC.Traducir_883SC("BKP_LBL_ARCHIVO") + backup.NombreArchivo_883SC + Environment.NewLine
                + gestorIdioma_883SC.Traducir_883SC("COMUN_FECHA") + ": " + backup.Fecha_883SC.ToString("g");
            if (MessageBox.Show(mensaje, gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                this.UseWaitCursor = true;
                this.Enabled = false;
                backupBLL_883SC.Restaurar_883SC(backup.Id_883SC);
                this.Enabled = true;
                this.UseWaitCursor = false;
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("BKP_RESTORE_OK"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //frmMenu cierra la sesion y vuelve al login
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                this.UseWaitCursor = false;
                MessageBox.Show(ex.Message, gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click_883SC(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
