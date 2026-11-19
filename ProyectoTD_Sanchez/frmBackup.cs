using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmBackup_883SC : Form, IObservadorIdioma_883SC
    {
        public frmBackup_883SC()
        {
            InitializeComponent();
        }

        BackupBLL_883SC backupBLL_883SC = new BackupBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        //Resultado de la ultima verificacion de archivos (null = todavia no se verifico)
        private List<string> faltantes_883SC = null;
        private List<string> huerfanos_883SC = null;

        private void frmBackup_Load_883SC(object sender, EventArgs e)
        {
            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmBackup_FormClosed_883SC;
            CargarGrilla_883SC();
        }

        private void frmBackup_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = gestorIdioma_883SC.Traducir_883SC("BKP_TITULO");
            lblTitulo.Text = gestorIdioma_883SC.Traducir_883SC("BKP_LBL_TITULO");
            btnRealizar.Text = gestorIdioma_883SC.Traducir_883SC("BKP_BTN_REALIZAR");
            btnEliminar.Text = gestorIdioma_883SC.Traducir_883SC("BKP_BTN_ELIMINAR");
            btnVerificar.Text = gestorIdioma_883SC.Traducir_883SC("BKP_BTN_VERIFICAR");
            btnSalir.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_SALIR");
            TraducirColumnas_883SC();
            ActualizarIndicadores_883SC();
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
                MarcarFaltantes_883SC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("COMUN_ERROR_BD") + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Las filas cuyo archivo falta en disco se pintan en rojo
        private void MarcarFaltantes_883SC()
        {
            foreach (DataGridViewRow fila in dgvBackups.Rows)
            {
                BackupBE_883SC backup = (BackupBE_883SC)fila.DataBoundItem;
                bool falta = faltantes_883SC != null && faltantes_883SC.Contains(backup.NombreArchivo_883SC);
                fila.DefaultCellStyle.ForeColor = falta ? Color.Red : SystemColors.ControlText;
            }
        }

        private void ActualizarIndicadores_883SC()
        {
            if (faltantes_883SC == null)
            {
                lblFaltantes.Text = "";
                lblHuerfanos.Text = "";
                return;
            }
            lblFaltantes.Text = gestorIdioma_883SC.Traducir_883SC("BKP_LBL_FALTANTES") + faltantes_883SC.Count;
            lblHuerfanos.Text = gestorIdioma_883SC.Traducir_883SC("BKP_LBL_HUERFANOS") + huerfanos_883SC.Count;
            lblFaltantes.ForeColor = faltantes_883SC.Count > 0 ? Color.Red : Color.Black;
            lblHuerfanos.ForeColor = huerfanos_883SC.Count > 0 ? Color.Red : Color.Black;
        }

        private BackupBE_883SC BackupSeleccionado_883SC()
        {
            if (dgvBackups.CurrentRow == null) { return null; }
            return (BackupBE_883SC)dgvBackups.CurrentRow.DataBoundItem;
        }

        private void btnRealizar_Click_883SC(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                this.Enabled = false;
                BackupBE_883SC backup = backupBLL_883SC.RealizarBackup_883SC();
                this.Enabled = true;
                this.UseWaitCursor = false;
                faltantes_883SC = null;
                huerfanos_883SC = null;
                ActualizarIndicadores_883SC();
                CargarGrilla_883SC();
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("BKP_MSG_BACKUP_OK") + backup.NombreArchivo_883SC, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                this.UseWaitCursor = false;
                MessageBox.Show(ex.Message, gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click_883SC(object sender, EventArgs e)
        {
            BackupBE_883SC backup = BackupSeleccionado_883SC();
            if (backup == null)
            {
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("BKP_MSG_SELECCIONE"), gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("BKP_CONFIRMA_ELIMINAR") + Environment.NewLine + backup.NombreArchivo_883SC,
                gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                backupBLL_883SC.Eliminar_883SC(backup.Id_883SC);
                faltantes_883SC = null;
                huerfanos_883SC = null;
                ActualizarIndicadores_883SC();
                CargarGrilla_883SC();
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("BKP_MSG_ELIMINADO"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerificar_Click_883SC(object sender, EventArgs e)
        {
            try
            {
                List<string> faltantes;
                List<string> huerfanos;
                backupBLL_883SC.VerificarArchivos_883SC(out faltantes, out huerfanos);
                faltantes_883SC = faltantes;
                huerfanos_883SC = huerfanos;
                ActualizarIndicadores_883SC();
                MarcarFaltantes_883SC();

                if (faltantes.Count == 0 && huerfanos.Count == 0)
                {
                    MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("BKP_MSG_VERIF_OK"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string detalle = "";
                if (faltantes.Count > 0)
                {
                    detalle += gestorIdioma_883SC.Traducir_883SC("BKP_MSG_FALTANTES") + Environment.NewLine + string.Join(Environment.NewLine, faltantes) + Environment.NewLine + Environment.NewLine;
                }
                if (huerfanos.Count > 0)
                {
                    detalle += gestorIdioma_883SC.Traducir_883SC("BKP_MSG_HUERFANOS") + Environment.NewLine + string.Join(Environment.NewLine, huerfanos);
                }
                MessageBox.Show(detalle, gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click_883SC(object sender, EventArgs e)
        {
            frmMenu_883SC.opcActivo_883SC.BackColor = Color.WhiteSmoke;
            this.Close();
        }
    }
}
