using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    /// ABM de proveedores (Maestros -> Proveedores). Misma estructura que frmClientes.
    /// frmAltaProveedor sigue siendo el alta rapida (desde Gestion y desde la importacion de listas).
    public partial class frmProveedores_883SC : Form, IObservadorIdioma_883SC
    {
        public frmProveedores_883SC()
        {
            InitializeComponent();
        }

        ProveedorBLL_883SC proveedorBLL_883SC = new ProveedorBLL_883SC();
        PerfilBLL_883SC perfilBLL_883SC = new PerfilBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        ProveedorBE_883SC proveedorSel_883SC;   //Proveedor elegido en la grilla
        int varMod_883SC = 0;                   //0 = alta, 1 = modificacion
        bool editando_883SC = false;            //true mientras se esta en alta o modificacion
        bool puedeEscribir_883SC = false;       //RegistrarProveedor; sin el permiso la pantalla es de solo lectura

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = Traducir_883SC("PROV_ABM_TITULO");
            lblTitulo.Text = Traducir_883SC("PROV_ABM_TITULO");
            lblOpciones.Text = Traducir_883SC("PROV_ABM_LBL_OPCIONES");
            gbDatos.Text = Traducir_883SC("PROV_ABM_GB_DATOS");
            gbMensajes.Text = Traducir_883SC("PROV_ABM_GB_MENSAJES");
            lblNombre.Text = Traducir_883SC("PROV_LBL_NOMBRE");
            lblEspecialidad.Text = Traducir_883SC("PROV_LBL_ESPECIALIDAD");
            lblTelefono.Text = Traducir_883SC("PROV_LBL_TELEFONO");
            lblDireccion.Text = Traducir_883SC("PROV_LBL_DIRECCION");
            lblMargen.Text = Traducir_883SC("PROV_LBL_MARGEN");
            lblObservaciones.Text = Traducir_883SC("PROV_LBL_OBSERVACIONES");
            chkActivo.Text = Traducir_883SC("MAESTRO_COL_ACTIVO");
            chkInactivos.Text = Traducir_883SC("PROV_ABM_CHK_INACTIVOS");
            btnCrear.Text = Traducir_883SC("PROV_ABM_BTN_CREAR");
            btnModificar.Text = Traducir_883SC("PROV_ABM_BTN_MODIFICAR");
            btnEliminar.Text = Traducir_883SC("PROV_ABM_BTN_ELIMINAR");
            btnReactivar.Text = Traducir_883SC("PROV_ABM_BTN_REACTIVAR");
            btnGuardar.Text = Traducir_883SC("COMUN_GUARDAR");
            btnCancelar.Text = Traducir_883SC("COMUN_CANCELAR");
            btnSalir.Text = Traducir_883SC("COMUN_SALIR");
            foreach (DataGridViewColumn columna in dgvProveedores.Columns)
            {
                columna.HeaderText = Traducir_883SC(columna.Tag.ToString());
            }
        }

        private string Traducir_883SC(string clave)
        {
            return gestorIdioma_883SC.Traducir_883SC(clave);
        }

        #endregion

        #region Funciones

        private void ConfigurarColumnas_883SC()
        {
            dgvProveedores.AutoGenerateColumns = false;
            dgvProveedores.Columns.Clear();
            AgregarColumna_883SC("Id_883SC", "MAESTRO_COL_ID", false);
            AgregarColumna_883SC("Nombre_883SC", "COMUN_NOMBRE", false);
            AgregarColumna_883SC("Especialidad_883SC", "MAESTRO_COL_ESPECIALIDAD", false);
            AgregarColumna_883SC("Telefono_883SC", "MAESTRO_COL_TELEFONO", false);
            AgregarColumna_883SC("Direccion_883SC", "MAESTRO_COL_DIRECCION", false);
            AgregarColumna_883SC("Margen_883SC", "MAESTRO_COL_MARGEN", false);
            AgregarColumna_883SC("Observaciones_883SC", "MAESTRO_COL_OBSERVACIONES", false);
            AgregarColumna_883SC("Activo_883SC", "MAESTRO_COL_ACTIVO", true);
            dgvProveedores.Columns["colMargen_883SC"].DefaultCellStyle.Format = "N2";
        }

        private void AgregarColumna_883SC(string propiedad, string claveEncabezado, bool booleana)
        {
            DataGridViewColumn columna = booleana ? (DataGridViewColumn)new DataGridViewCheckBoxColumn() : new DataGridViewTextBoxColumn();
            columna.DataPropertyName = propiedad;
            columna.Name = "col" + propiedad;
            columna.Tag = claveEncabezado;
            columna.ReadOnly = true;
            dgvProveedores.Columns.Add(columna);
        }

        //Muestra los proveedores; los inactivos (solo si se pidieron) se muestran en gris
        private void CargarGrilla_883SC()
        {
            List<ProveedorBE_883SC> proveedores = proveedorBLL_883SC.ListarProveedores_883SC();
            if (!chkInactivos.Checked)
            {
                proveedores = proveedores.FindAll(p => p.Activo_883SC);
            }
            dgvProveedores.DataSource = proveedores;
            dgvProveedores.ClearSelection();
            foreach (DataGridViewRow fila in dgvProveedores.Rows)
            {
                ProveedorBE_883SC proveedor = (ProveedorBE_883SC)fila.DataBoundItem;
                fila.DefaultCellStyle.ForeColor = proveedor.Activo_883SC ? Color.Black : Color.Gray;
            }
        }

        private void ActualizarGrilla_883SC()
        {
            CargarGrilla_883SC();
            ConfigDefaultForm_883SC();
        }

        private void HabilitarBtn_883SC(Button btn, bool habilitar)
        {
            btn.Enabled = habilitar;
            btn.Font = new Font(btn.Font.Name, btn.Font.Size, habilitar ? FontStyle.Bold : FontStyle.Regular);
            btn.BackColor = Color.FromArgb(255, 192, 192);   //Rosado como frmUsuario
            btn.ForeColor = Color.Black;
        }

        private void ConfigDefaultForm_883SC()
        {
            editando_883SC = false;
            varMod_883SC = 0;
            proveedorSel_883SC = null;
            HabilitarBtn_883SC(btnCrear, puedeEscribir_883SC);
            HabilitarBtn_883SC(btnModificar, false);
            HabilitarBtn_883SC(btnEliminar, false);
            HabilitarBtn_883SC(btnReactivar, false);
            HabilitarBtn_883SC(btnGuardar, false);
            HabilitarBtn_883SC(btnCancelar, false);
            HabilitarBtn_883SC(btnSalir, true);
            dgvProveedores.Enabled = true;
            chkInactivos.Enabled = true;
            LimpiarDatos_883SC();
            HabilitarCampos_883SC(false);
        }

        private TextBox[] Campos_883SC()
        {
            return new TextBox[] { txtNombre, txtEspecialidad, txtTelefono, txtDireccion, txtMargen, txtObservaciones };
        }

        private void LimpiarDatos_883SC()
        {
            foreach (TextBox txt in Campos_883SC()) { txt.Text = ""; }
            chkActivo.Checked = false;
        }

        private void HabilitarCampos_883SC(bool editables)
        {
            foreach (TextBox txt in Campos_883SC())
            {
                txt.Enabled = editables;
                txt.BackColor = txt.Enabled ? Color.White : Color.Gainsboro;
            }
        }

        private void EntrarEnEdicion_883SC()
        {
            editando_883SC = true;
            dgvProveedores.Enabled = false;
            chkInactivos.Enabled = false;
            HabilitarBtn_883SC(btnCrear, false);
            HabilitarBtn_883SC(btnModificar, false);
            HabilitarBtn_883SC(btnEliminar, false);
            HabilitarBtn_883SC(btnReactivar, false);
            HabilitarBtn_883SC(btnCancelar, true);
            HabilitarCampos_883SC(true);
            GuardarEnabled_883SC();
        }

        //Guardar solo con los obligatorios completos; el detalle de la validacion lo da la BLL
        private void GuardarEnabled_883SC()
        {
            bool completo = txtNombre.Text.Trim() != "" && txtTelefono.Text.Trim() != "" && txtMargen.Text.Trim() != "";
            HabilitarBtn_883SC(btnGuardar, editando_883SC && completo);
        }

        private void LlenarMensaje_883SC(string linea)
        {
            txtMensaje.Text = linea + Environment.NewLine + Environment.NewLine + txtMensaje.Text;
        }

        //Marca en rojo el campo que indica ex.Data["Campo"] (lo carga la BLL)
        private void MarcarCampo_883SC(string campo)
        {
            TextBox txt = null;
            switch (campo)
            {
                case "Nombre": txt = txtNombre; break;
                case "Especialidad": txt = txtEspecialidad; break;
                case "Telefono": txt = txtTelefono; break;
                case "Direccion": txt = txtDireccion; break;
                case "Margen": txt = txtMargen; break;
            }
            if (txt != null && txt.Enabled)
            {
                txt.BackColor = Color.LightCoral;
                txt.Focus();
            }
        }

        //Acepta punto o coma como separador decimal, sin separador de miles (igual que frmAltaProveedor)
        private bool TryLeerMargen_883SC(out decimal margen)
        {
            string separador = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            string texto = txtMargen.Text.Trim().Replace(".", separador).Replace(",", separador);
            return decimal.TryParse(texto, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out margen);
        }

        #endregion

        #region Eventos

        private void frmProveedores_Load_883SC(object sender, EventArgs e)
        {
            puedeEscribir_883SC = perfilBLL_883SC.TienePermiso_883SC(
                SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().rol_883SC,
                TipoPermiso_883SC.RegistrarProveedor.ToString());

            ConfigurarColumnas_883SC();
            try
            {
                CargarGrilla_883SC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConfigDefaultForm_883SC();

            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmProveedores_FormClosed_883SC;
        }

        private void frmProveedores_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        private void campo_TextChanged_883SC(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Enabled) { txt.BackColor = Color.White; }
            GuardarEnabled_883SC();
        }

        private void chkInactivos_CheckedChanged_883SC(object sender, EventArgs e)
        {
            if (editando_883SC || !this.IsHandleCreated) { return; }
            try
            {
                ActualizarGrilla_883SC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProveedores_CellClick_883SC(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            proveedorSel_883SC = (ProveedorBE_883SC)dgvProveedores.Rows[e.RowIndex].DataBoundItem;
            txtNombre.Text = proveedorSel_883SC.Nombre_883SC;
            txtEspecialidad.Text = proveedorSel_883SC.Especialidad_883SC;
            txtTelefono.Text = proveedorSel_883SC.Telefono_883SC;
            txtDireccion.Text = proveedorSel_883SC.Direccion_883SC;
            txtMargen.Text = proveedorSel_883SC.Margen_883SC.ToString("0.00", CultureInfo.CurrentCulture);
            txtObservaciones.Text = proveedorSel_883SC.Observaciones_883SC;
            chkActivo.Checked = proveedorSel_883SC.Activo_883SC;

            HabilitarBtn_883SC(btnModificar, puedeEscribir_883SC && proveedorSel_883SC.Activo_883SC);
            HabilitarBtn_883SC(btnEliminar, puedeEscribir_883SC && proveedorSel_883SC.Activo_883SC);
            HabilitarBtn_883SC(btnReactivar, puedeEscribir_883SC && !proveedorSel_883SC.Activo_883SC);
            HabilitarBtn_883SC(btnCancelar, true);
            HabilitarBtn_883SC(btnGuardar, false);
        }

        private void btnCrear_Click_883SC(object sender, EventArgs e)
        {
            varMod_883SC = 0;
            proveedorSel_883SC = null;
            LimpiarDatos_883SC();
            chkActivo.Checked = true;
            EntrarEnEdicion_883SC();
            btnCrear.BackColor = Color.LightCoral;   //Boton activo resaltado como en frmUsuario
            txtNombre.Focus();
        }

        private void btnModificar_Click_883SC(object sender, EventArgs e)
        {
            varMod_883SC = 1;
            EntrarEnEdicion_883SC();
            btnModificar.BackColor = Color.LightCoral;
            txtNombre.Focus();
        }

        private void btnCancelar_Click_883SC(object sender, EventArgs e)
        {
            ConfigDefaultForm_883SC();
            dgvProveedores.ClearSelection();
        }

        private void btnGuardar_Click_883SC(object sender, EventArgs e)
        {
            decimal margen;
            if (!TryLeerMargen_883SC(out margen))
            {
                MarcarCampo_883SC("Margen");
                LlenarMensaje_883SC(Traducir_883SC("PROV_ERR_MARGEN"));
                return;
            }

            try
            {
                if (varMod_883SC == 0)
                {
                    ProveedorBE_883SC nuevo = proveedorBLL_883SC.RegistrarProveedor_883SC(
                        txtNombre.Text, txtEspecialidad.Text, txtTelefono.Text, txtDireccion.Text, margen, txtObservaciones.Text);
                    ActualizarGrilla_883SC();
                    LlenarMensaje_883SC(string.Format(Traducir_883SC("PROV_MSG_OK"), nuevo.Id_883SC, nuevo.Nombre_883SC));
                }
                else
                {
                    int id = proveedorSel_883SC.Id_883SC;
                    int precios = proveedorBLL_883SC.ModificarProveedor_883SC(
                        id, txtNombre.Text, txtEspecialidad.Text, txtTelefono.Text, txtDireccion.Text, margen, txtObservaciones.Text);
                    ActualizarGrilla_883SC();
                    LlenarMensaje_883SC(string.Format(Traducir_883SC("PROV_ABM_MSG_ACTUALIZADO"), id, precios));
                }
            }
            catch (ArgumentException ex)
            {
                //Error de validacion: se queda en edicion para corregir
                if (ex.Data.Contains("Campo")) { MarcarCampo_883SC((string)ex.Data["Campo"]); }
                LlenarMensaje_883SC(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Traducir_883SC("COMUN_ERROR_BD") + ex.Message, Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConfigDefaultForm_883SC();
            }
        }

        private void btnEliminar_Click_883SC(object sender, EventArgs e)
        {
            if (proveedorSel_883SC == null) { return; }
            int id = proveedorSel_883SC.Id_883SC;
            if (MessageBox.Show(string.Format(Traducir_883SC("PROV_ABM_MSG_CONFIRMA_ELIMINAR"), id), Traducir_883SC("PROV_ABM_BTN_ELIMINAR"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            EjecutarBaja_883SC(id, false);
        }

        private void btnReactivar_Click_883SC(object sender, EventArgs e)
        {
            if (proveedorSel_883SC == null) { return; }
            int id = proveedorSel_883SC.Id_883SC;
            if (MessageBox.Show(string.Format(Traducir_883SC("PROV_ABM_MSG_CONFIRMA_REACTIVAR"), id), Traducir_883SC("PROV_ABM_BTN_REACTIVAR"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            EjecutarBaja_883SC(id, true);
        }

        //Baja o reactivacion segun el segundo parametro
        private void EjecutarBaja_883SC(int id, bool reactivar)
        {
            try
            {
                if (reactivar)
                {
                    proveedorBLL_883SC.ReactivarProveedor_883SC(id);
                }
                else
                {
                    proveedorBLL_883SC.BajaProveedor_883SC(id);
                }
                ActualizarGrilla_883SC();
                LlenarMensaje_883SC(string.Format(Traducir_883SC(reactivar ? "PROV_ABM_MSG_REACTIVADO" : "PROV_ABM_MSG_BAJA_OK"), id));
            }
            catch (ArgumentException ex)
            {
                LlenarMensaje_883SC(ex.Message);
                ActualizarGrilla_883SC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Traducir_883SC("COMUN_ERROR_BD") + ex.Message, Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConfigDefaultForm_883SC();
            }
        }

        private void btnSalir_Click_883SC(object sender, EventArgs e)
        {
            if (frmMenu_883SC.opcActivo_883SC != null)
            {
                frmMenu_883SC.opcActivo_883SC.BackColor = Color.WhiteSmoke;
            }
            this.Close();
        }

        #endregion
    }
}
