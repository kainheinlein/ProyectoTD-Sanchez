using Negocio_BLL;
using Entidad_BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicios;

namespace TP_SanchezVillaverde
{
    public partial class frmHistorialUsuario_883SC : Form, IObservadorIdioma_883SC
    {
        private readonly HistorialUsuarioBLL_883SC historialBLL_883SC = new HistorialUsuarioBLL_883SC();
        private readonly GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;
        public frmHistorialUsuario_883SC()
        {
            InitializeComponent();
        }

        private void frmHistorialUsuario_Load_883SC(object sender, EventArgs e)
        {
            cmbAccion.DataSource = Enum.GetValues(typeof(TipoAccion_883SC));
            gestorIdioma_883SC.Suscribir_883SC(this);
            ActualizarTextos_883SC();
            ConfigDGV_883SC(historialBLL_883SC.ListarHistorial_883SC());
        }

        private void frmHistorialUsuario_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        void ConfigDGV_883SC(List<HistorialUsuarioBE_883SC> lista)
        {
            dgvHistorial.DataSource = lista;

            if (dgvHistorial.Columns.Count > 0)
            {
                dgvHistorial.Columns["idHistorial_883SC"].Visible = false;
                dgvHistorial.Columns["usuarioId_883SC"].Visible = false;
                dgvHistorial.Columns["fecha_883SC"].HeaderText = "Fecha";
                dgvHistorial.Columns["accion_883SC"].HeaderText = "Acción";
                dgvHistorial.Columns["usuarioResponsable_883SC"].HeaderText = "Responsable";
                dgvHistorial.EnableHeadersVisualStyles = false;
            }
        }

        private void CargarHistorial_883SC()
        {
            var lista = historialBLL_883SC.BuscarHistorial_883SC((TipoAccion_883SC?)cmbAccion.SelectedItem, dtpDesde.Value, dtpHasta.Value);
            dgvHistorial.DataSource = lista;

            if (dgvHistorial.Columns.Count > 0)
            {
                dgvHistorial.Columns["idHistorial_883SC"].Visible = false;
                dgvHistorial.Columns["usuarioId_883SC"].Visible = false;
                dgvHistorial.Columns["fecha_883SC"].HeaderText = "Fecha";
                dgvHistorial.Columns["accion_883SC"].HeaderText = "Acción";
                dgvHistorial.Columns["usuarioResponsable_883SC"].HeaderText = "Responsable";
                dgvHistorial.EnableHeadersVisualStyles = false;
            }
        }

        private void btnBuscar_Click_883SC(object sender, EventArgs e) => CargarHistorial_883SC();

        private void btnRestaurar_Click_883SC(object sender, EventArgs e)
        {
            var version = (HistorialUsuarioBE_883SC)dgvHistorial.CurrentRow.DataBoundItem;

            var confirmacion = MessageBox.Show(
                $"¿Confirma restaurar al usuario '{version.usuario_883SC}' al estado del {version.fecha_883SC}?",
                "Confirmar restauración",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                historialBLL_883SC.RestaurarVersion_883SC(version.idHistorial_883SC, SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC);
                MessageBox.Show("Usuario restaurado correctamente.");
                CargarHistorial_883SC();
            }
        }

        #region Patrón Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = gestorIdioma_883SC.Traducir_883SC("HIST_TITULO");
            btnBuscar.Text = gestorIdioma_883SC.Traducir_883SC("HIST_BTN_BUSCAR");
            btnRestaurar.Text = gestorIdioma_883SC.Traducir_883SC("HIST_BTN_RESTAURAR");
            btnSalir.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_SALIR");
            gbDetalle.Text = gestorIdioma_883SC.Traducir_883SC("HIST_GB_DETALLE");
        }

        #endregion

        private void btnSalir_Click_883SC(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvHistorial_CellClick_883SC(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHistorial.CurrentRow == null) { return; }

            var version = (HistorialUsuarioBE_883SC)dgvHistorial.CurrentRow.DataBoundItem;
            txtDni.Text = version.dni_883SC.ToString();
            txtNombre.Text = version.nombre_883SC;
            txtApellido.Text = version.apellido_883SC;
            txtUsuario.Text = version.usuario_883SC;
            txtRol.Text = version.rol_883SC;
            lblDireccion.Text = version.direccion_883SC;
            lblTelefono.Text = version.telefono_883SC;
            lblEmail.Text = version.email_883SC;
            chkActivo.Checked = version.activo_883SC;
            chkBloqueado.Checked = version.bloqueado_883SC;

            btnRestaurar.Enabled = true;
        }
    }
}
