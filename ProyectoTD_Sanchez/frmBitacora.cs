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
    public partial class frmBitacora_883SC : Form, IObservadorIdioma_883SC
    {
        public frmBitacora_883SC()
        {
            InitializeComponent();
        }

        BitacoraBLL_883SC bitacora_883SC = new BitacoraBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        private void frmBitacora_Load_883SC(object sender, EventArgs e)
        {
            dgvBitacora.DataSource = bitacora_883SC.ListarBitacora_883SC();
            TraducirColumnas_883SC();
            dgvBitacora.EnableHeadersVisualStyles = false;
            dgvBitacora.ColumnHeadersDefaultCellStyle.Font = new Font(dgvBitacora.Font, FontStyle.Bold);
            dgvBitacora.ReadOnly = true;
            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmBitacora_FormClosed_883SC;
           cmbEvento.DataSource = Enum.GetValues(typeof(TipoAccion_883SC));
            LoadDefaultForm_883SC();
        }

        private void frmBitacora_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = gestorIdioma_883SC.Traducir_883SC("BIT_TITULO");
            label1.Text = gestorIdioma_883SC.Traducir_883SC("BIT_LBL_TITULO");
            btnSalir.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_SALIR");
            TraducirColumnas_883SC();
        }

        private void TraducirColumnas_883SC()
        {
            if (dgvBitacora.Columns.Count == 0) { return; }
            dgvBitacora.Columns[0].HeaderText = gestorIdioma_883SC.Traducir_883SC("BIT_COL_REGISTRO");
            dgvBitacora.Columns[1].HeaderText = gestorIdioma_883SC.Traducir_883SC("COMUN_USUARIO");
            dgvBitacora.Columns[2].HeaderText = gestorIdioma_883SC.Traducir_883SC("COMUN_ACCION");
            dgvBitacora.Columns[3].HeaderText = gestorIdioma_883SC.Traducir_883SC("COMUN_FECHA");
        }

        #endregion


        private void CargarDGV_883SC(List<EventoBE_883SC> ev)
        {
            dgvBitacora.DataSource = ev;
            dgvBitacora.Columns[0].HeaderText = "ID Registro";
            dgvBitacora.Columns[1].HeaderText = "Usuario";
            dgvBitacora.Columns[2].HeaderText = "Accion";
            dgvBitacora.Columns[3].HeaderText = "Fecha";
            dgvBitacora.EnableHeadersVisualStyles = false;
            dgvBitacora.ColumnHeadersDefaultCellStyle.Font = new Font(dgvBitacora.Font, FontStyle.Bold);
            dgvBitacora.ReadOnly = true;
        }

        private void LoadDefaultForm_883SC()
        {
            try
            {
                CargarDGV_883SC(bitacora_883SC.ListarBitacora_883SC());
                dgvBitacora.Columns[0].HeaderText = "ID Registro";
                dgvBitacora.Columns[1].HeaderText = "Usuario";
                dgvBitacora.Columns[2].HeaderText = "Accion";
                dgvBitacora.Columns[3].HeaderText = "Fecha";
                dgvBitacora.EnableHeadersVisualStyles = false;
                dgvBitacora.ColumnHeadersDefaultCellStyle.Font = new Font(dgvBitacora.Font, FontStyle.Bold);
                dgvBitacora.ReadOnly = true;

                dtpDesde.Value = DateTime.Today.AddDays(-30);
                dtpHasta.Value = DateTime.Today;

                cmbEvento.SelectedIndex = -1;
                txtUsuario.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalir_Click_883SC(object sender, EventArgs e)
        {
            Control control = btnSalir.Parent;
            frmMenu_883SC.opcActivo_883SC.BackColor = Color.WhiteSmoke;
            this.Close();
        }

        private void btnLimpiar_Click_883SC(object sender, EventArgs e)
        {
            LoadDefaultForm_883SC();
        }

        private void btnBuscar_Click_883SC(object sender, EventArgs e)
        {
            try
            {
                string us;
                TipoAccion_883SC? acc;
                DateTime fIni = dtpDesde.Value;
                DateTime fFin = dtpHasta.Value.Date.AddDays(1).AddTicks(-1);

                if (string.IsNullOrEmpty(txtUsuario.Text)) { us = null; }
                else { us = txtUsuario.Text; }

                if (cmbEvento.SelectedIndex == -1) { acc = null; }
                else { acc = (TipoAccion_883SC)cmbEvento.SelectedValue; }


                CargarDGV_883SC(bitacora_883SC.BuscarEventos_883SC(us, acc, fIni, fFin));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
