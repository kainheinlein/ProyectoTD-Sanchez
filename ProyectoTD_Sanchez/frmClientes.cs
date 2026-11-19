using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmClientes_883SC : Form, IObservadorIdioma_883SC
    {
        public frmClientes_883SC()
        {
            InitializeComponent();
            //Carpeta propuesta para el XML: Documentos del usuario (escribible en una PC compartida)
            txtSerCarpeta.Text = RutasUsuario_883SC.CarpetaDocumentos_883SC();
        }

        ClienteBLL_883SC clienteBLL_883SC = new ClienteBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        ClienteBE_883SC clienteSel_883SC;   //Cliente elegido en la grilla
        int varMod_883SC = 0;               //0 = alta, 1 = modificacion
        bool editando_883SC = false;        //true mientras se esta en alta o modificacion
        bool vistaArchivo_883SC = false;    //true mientras la grilla muestra clientes leidos de un XML (no de la base)

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = Traducir_883SC("CLI_ABM_TITULO");
            lblTitulo.Text = Traducir_883SC("CLI_ABM_TITULO");
            lblOpciones.Text = Traducir_883SC("CLI_ABM_LBL_OPCIONES");
            gbDatos.Text = Traducir_883SC("CLI_ABM_GB_DATOS");
            gbMensajes.Text = Traducir_883SC("CLI_ABM_GB_MENSAJES");
            lblDni.Text = Traducir_883SC("MAESTRO_COL_DNI");
            lblNombre.Text = Traducir_883SC("COMUN_NOMBRE");
            lblApellido.Text = Traducir_883SC("COMUN_APELLIDO");
            lblDireccion.Text = Traducir_883SC("MAESTRO_COL_DIRECCION");
            lblTelefono.Text = Traducir_883SC("MAESTRO_COL_TELEFONO");
            chkActivo.Text = Traducir_883SC("MAESTRO_COL_ACTIVO");
            chkInactivos.Text = Traducir_883SC("CLI_ABM_CHK_INACTIVOS");
            btnCrear.Text = Traducir_883SC("CLI_ABM_BTN_CREAR");
            btnModificar.Text = Traducir_883SC("CLI_ABM_BTN_MODIFICAR");
            btnEliminar.Text = Traducir_883SC("CLI_ABM_BTN_ELIMINAR");
            btnReactivar.Text = Traducir_883SC("CLI_ABM_BTN_REACTIVAR");
            btnGuardar.Text = Traducir_883SC("COMUN_GUARDAR");
            btnCancelar.Text = Traducir_883SC("COMUN_CANCELAR");
            btnSalir.Text = Traducir_883SC("COMUN_SALIR");
            lblSerTitulo.Text = Traducir_883SC("CLI_SER_LBL_TITULO");
            lblSerCarpeta.Text = Traducir_883SC("CLI_SER_LBL_CARPETA");
            lblSerNombre.Text = Traducir_883SC("CLI_SER_LBL_NOMBRE");
            lblDesArchivo.Text = Traducir_883SC("CLI_SER_LBL_ARCHIVO");
            btnSerializar.Text = Traducir_883SC("CLI_SER_BTN_SERIALIZAR");
            btnDeserializar.Text = Traducir_883SC("CLI_SER_BTN_DESERIALIZAR");
            btnLimpiar.Text = Traducir_883SC("CLI_SER_BTN_LIMPIAR");
            btnActualizar.Text = Traducir_883SC("CLI_SER_BTN_ACTUALIZAR");
            toolTip.SetToolTip(btnLimpiar, Traducir_883SC("CLI_SER_TIP_LIMPIAR"));
            toolTip.SetToolTip(btnActualizar, Traducir_883SC("CLI_SER_TIP_ACTUALIZAR"));
            toolTip.SetToolTip(btnSerCarpeta, Traducir_883SC("CLI_SER_TIP_CARPETA"));
            toolTip.SetToolTip(btnDesArchivo, Traducir_883SC("CLI_SER_TIP_ARCHIVO"));
            foreach (DataGridViewColumn columna in dgvClientes.Columns)
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
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.Columns.Clear();
            AgregarColumna_883SC("Dni_883SC", "MAESTRO_COL_DNI", false);
            AgregarColumna_883SC("Nombre_883SC", "COMUN_NOMBRE", false);
            AgregarColumna_883SC("Apellido_883SC", "COMUN_APELLIDO", false);
            AgregarColumna_883SC("Direccion_883SC", "MAESTRO_COL_DIRECCION", false);
            AgregarColumna_883SC("Telefono_883SC", "MAESTRO_COL_TELEFONO", false);
            AgregarColumna_883SC("Activo_883SC", "MAESTRO_COL_ACTIVO", true);
        }

        private void AgregarColumna_883SC(string propiedad, string claveEncabezado, bool booleana)
        {
            DataGridViewColumn columna = booleana ? (DataGridViewColumn)new DataGridViewCheckBoxColumn() : new DataGridViewTextBoxColumn();
            columna.DataPropertyName = propiedad;
            columna.Name = "col" + propiedad;
            columna.Tag = claveEncabezado;
            columna.ReadOnly = true;
            dgvClientes.Columns.Add(columna);
        }

        private void CargarGrilla_883SC()
        {
            List<ClienteBE_883SC> clientes = clienteBLL_883SC.ListarClientesAbm_883SC(chkInactivos.Checked);
            vistaArchivo_883SC = false;
            MostrarEnGrilla_883SC(clientes);

            int sinCifrar = clientes.FindAll(c => c.DireccionSinCifrar_883SC).Count;
            if (sinCifrar > 0)
            {
                LlenarMensaje_883SC(string.Format(Traducir_883SC("CLI_ABM_MSG_SIN_CIFRAR"), sinCifrar));
            }
        }

        //Muestra la lista en la grilla; los inactivos se muestran en gris
        private void MostrarEnGrilla_883SC(List<ClienteBE_883SC> clientes)
        {
            dgvClientes.DataSource = clientes;
            dgvClientes.ClearSelection();
            foreach (DataGridViewRow fila in dgvClientes.Rows)
            {
                ClienteBE_883SC cliente = (ClienteBE_883SC)fila.DataBoundItem;
                fila.DefaultCellStyle.ForeColor = cliente.Activo_883SC ? Color.Black : Color.Gray;
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
            clienteSel_883SC = null;
            HabilitarBtn_883SC(btnCrear, !vistaArchivo_883SC);   //Con datos del XML en la grilla no se da de alta
            HabilitarBtn_883SC(btnModificar, false);
            HabilitarBtn_883SC(btnEliminar, false);
            HabilitarBtn_883SC(btnReactivar, false);
            HabilitarBtn_883SC(btnGuardar, false);
            HabilitarBtn_883SC(btnCancelar, false);
            HabilitarBtn_883SC(btnSalir, true);
            HabilitarSerializacion_883SC(true);
            dgvClientes.Enabled = true;
            chkInactivos.Enabled = true;
            LimpiarDatos_883SC();
            HabilitarCampos_883SC(false, false);
        }

        //Serializacion, Limpiar y Actualizar solo disponibles fuera de alta / modificacion
        private void HabilitarSerializacion_883SC(bool habilitar)
        {
            pSerializacion.Enabled = habilitar;
            HabilitarBtn_883SC(btnLimpiar, habilitar);
            HabilitarBtn_883SC(btnActualizar, habilitar);
            HabilitarBtn_883SC(btnSerCarpeta, habilitar);
            HabilitarBtn_883SC(btnSerializar, habilitar);
            HabilitarBtn_883SC(btnDesArchivo, habilitar);
            HabilitarBtn_883SC(btnDeserializar, habilitar);
        }

        //Clientes a serializar: las filas seleccionadas (en el orden de la grilla) o, sin seleccion, todas las visibles
        private List<ClienteBE_883SC> ClientesParaSerializar_883SC(out bool todos)
        {
            List<DataGridViewRow> filas = new List<DataGridViewRow>();
            foreach (DataGridViewRow fila in dgvClientes.SelectedRows) { filas.Add(fila); }
            todos = filas.Count == 0;
            if (todos)
            {
                foreach (DataGridViewRow fila in dgvClientes.Rows) { filas.Add(fila); }
            }
            filas.Sort((a, b) => a.Index.CompareTo(b.Index));

            List<ClienteBE_883SC> clientes = new List<ClienteBE_883SC>();
            foreach (DataGridViewRow fila in filas) { clientes.Add((ClienteBE_883SC)fila.DataBoundItem); }
            return clientes;
        }

        private string ListarDnis_883SC(List<ClienteBE_883SC> clientes)
        {
            List<string> dnis = new List<string>();
            foreach (ClienteBE_883SC cliente in clientes) { dnis.Add(cliente.Dni_883SC.ToString()); }
            return string.Join(", ", dnis);
        }

        private void LimpiarDatos_883SC()
        {
            txtDni.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            chkActivo.Checked = false;
        }

        private void HabilitarCampos_883SC(bool editables, bool dniEditable)
        {
            txtDni.Enabled = editables && dniEditable;
            txtNombre.Enabled = editables;
            txtApellido.Enabled = editables;
            txtDireccion.Enabled = editables;
            txtTelefono.Enabled = editables;
            foreach (TextBox txt in new TextBox[] { txtDni, txtNombre, txtApellido, txtDireccion, txtTelefono })
            {
                txt.BackColor = txt.Enabled ? Color.White : Color.Gainsboro;
            }
        }

        private void EntrarEnEdicion_883SC(bool dniEditable)
        {
            editando_883SC = true;
            dgvClientes.Enabled = false;
            chkInactivos.Enabled = false;
            HabilitarBtn_883SC(btnCrear, false);
            HabilitarBtn_883SC(btnModificar, false);
            HabilitarBtn_883SC(btnEliminar, false);
            HabilitarBtn_883SC(btnReactivar, false);
            HabilitarBtn_883SC(btnCancelar, true);
            HabilitarSerializacion_883SC(false);
            HabilitarCampos_883SC(true, dniEditable);
            GuardarEnabled_883SC();
        }

        //Guardar solo con los obligatorios completos; el detalle de la validacion lo da la BLL
        private void GuardarEnabled_883SC()
        {
            bool completo = txtDni.Text.Trim() != "" && txtNombre.Text.Trim() != "" && txtApellido.Text.Trim() != "";
            HabilitarBtn_883SC(btnGuardar, editando_883SC && completo);
        }

        private void LlenarMensaje_883SC(string linea)
        {
            txtMensaje.Text = linea + Environment.NewLine + Environment.NewLine + txtMensaje.Text;
        }

        //Marca en rojo el campo que indica el ParamName de la excepcion de la BLL
        private void MarcarCampo_883SC(string campo)
        {
            TextBox txt = null;
            switch (campo)
            {
                case "Dni": txt = txtDni; break;
                case "Nombre": txt = txtNombre; break;
                case "Apellido": txt = txtApellido; break;
                case "Direccion": txt = txtDireccion; break;
                case "Telefono": txt = txtTelefono; break;
            }
            if (txt != null && txt.Enabled)
            {
                txt.BackColor = Color.LightCoral;
                txt.Focus();
            }
        }

        #endregion

        #region Eventos

        private void frmClientes_Load_883SC(object sender, EventArgs e)
        {
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
            this.FormClosed += frmClientes_FormClosed_883SC;
        }

        private void frmClientes_FormClosed_883SC(object sender, FormClosedEventArgs e)
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

        private void dgvClientes_CellClick_883SC(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            clienteSel_883SC = (ClienteBE_883SC)dgvClientes.Rows[e.RowIndex].DataBoundItem;
            txtDni.Text = clienteSel_883SC.Dni_883SC.ToString();
            txtNombre.Text = clienteSel_883SC.Nombre_883SC;
            txtApellido.Text = clienteSel_883SC.Apellido_883SC;
            txtDireccion.Text = clienteSel_883SC.Direccion_883SC;
            txtTelefono.Text = clienteSel_883SC.Telefono_883SC;
            chkActivo.Checked = clienteSel_883SC.Activo_883SC;

            //Con varias filas elegidas (para serializar) o con datos del XML no se modifica ni se da de baja
            bool unica = dgvClientes.SelectedRows.Count == 1 && !vistaArchivo_883SC;
            HabilitarBtn_883SC(btnModificar, unica && clienteSel_883SC.Activo_883SC);
            HabilitarBtn_883SC(btnEliminar, unica && clienteSel_883SC.Activo_883SC);
            HabilitarBtn_883SC(btnReactivar, unica && !clienteSel_883SC.Activo_883SC);
            HabilitarBtn_883SC(btnCancelar, true);
            HabilitarBtn_883SC(btnGuardar, false);
        }

        private void btnCrear_Click_883SC(object sender, EventArgs e)
        {
            varMod_883SC = 0;
            clienteSel_883SC = null;
            LimpiarDatos_883SC();
            chkActivo.Checked = true;
            EntrarEnEdicion_883SC(true);
            btnCrear.BackColor = Color.LightCoral;   //Boton activo resaltado como en frmUsuario
            txtDni.Focus();
        }

        private void btnModificar_Click_883SC(object sender, EventArgs e)
        {
            varMod_883SC = 1;
            EntrarEnEdicion_883SC(false);   //El DNI es la clave: no se edita
            btnModificar.BackColor = Color.LightCoral;
            txtNombre.Focus();
        }

        private void btnCancelar_Click_883SC(object sender, EventArgs e)
        {
            ConfigDefaultForm_883SC();
            dgvClientes.ClearSelection();
        }

        private void btnGuardar_Click_883SC(object sender, EventArgs e)
        {
            try
            {
                if (varMod_883SC == 0)
                {
                    int dni;
                    if (!int.TryParse(txtDni.Text.Trim(), out dni))
                    {
                        MarcarCampo_883SC("Dni");
                        LlenarMensaje_883SC(Traducir_883SC("CLI_ABM_ERR_DNI"));
                        return;
                    }
                    clienteBLL_883SC.CrearCliente_883SC(dni, txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtTelefono.Text);
                    ActualizarGrilla_883SC();
                    LlenarMensaje_883SC(string.Format(Traducir_883SC("CLI_ABM_MSG_CREADO"), dni));
                }
                else
                {
                    clienteSel_883SC.Nombre_883SC = txtNombre.Text;
                    clienteSel_883SC.Apellido_883SC = txtApellido.Text;
                    clienteSel_883SC.Direccion_883SC = txtDireccion.Text;
                    clienteSel_883SC.Telefono_883SC = txtTelefono.Text;
                    int dni = clienteSel_883SC.Dni_883SC;
                    clienteBLL_883SC.ModificarCliente_883SC(clienteSel_883SC);
                    ActualizarGrilla_883SC();
                    LlenarMensaje_883SC(string.Format(Traducir_883SC("CLI_ABM_MSG_ACTUALIZADO"), dni));
                }
            }
            catch (ArgumentException ex)
            {
                //Error de validacion: se queda en edicion para corregir
                MarcarCampo_883SC(ex.ParamName);
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
            if (clienteSel_883SC == null) { return; }
            int dni = clienteSel_883SC.Dni_883SC;
            if (MessageBox.Show(string.Format(Traducir_883SC("CLI_ABM_MSG_CONFIRMA_ELIMINAR"), dni), Traducir_883SC("CLI_ABM_BTN_ELIMINAR"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            EjecutarBaja_883SC(dni, false);
        }

        private void btnReactivar_Click_883SC(object sender, EventArgs e)
        {
            if (clienteSel_883SC == null) { return; }
            int dni = clienteSel_883SC.Dni_883SC;
            if (MessageBox.Show(string.Format(Traducir_883SC("CLI_ABM_MSG_CONFIRMA_REACTIVAR"), dni), Traducir_883SC("CLI_ABM_BTN_REACTIVAR"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            EjecutarBaja_883SC(dni, true);
        }

        //Baja o reactivacion segun el segundo parametro
        private void EjecutarBaja_883SC(int dni, bool reactivar)
        {
            try
            {
                if (reactivar)
                {
                    clienteBLL_883SC.ReactivarCliente_883SC(dni);
                }
                else
                {
                    clienteBLL_883SC.BajaCliente_883SC(dni);
                }
                ActualizarGrilla_883SC();
                LlenarMensaje_883SC(string.Format(Traducir_883SC(reactivar ? "CLI_ABM_MSG_REACTIVADO" : "CLI_ABM_MSG_BAJA_OK"), dni));
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

        #region Serializacion XML (M2)

        private void btnSerCarpeta_Click_883SC(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialogo = new FolderBrowserDialog())
            {
                dialogo.Description = Traducir_883SC("CLI_SER_DLG_CARPETA");
                dialogo.SelectedPath = txtSerCarpeta.Text != "" ? txtSerCarpeta.Text : RutasUsuario_883SC.CarpetaDocumentos_883SC();
                if (dialogo.ShowDialog() != DialogResult.OK) { return; }
                txtSerCarpeta.Text = dialogo.SelectedPath;
            }
        }

        private void btnDesArchivo_Click_883SC(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Filter = Traducir_883SC("CLI_SER_FILTRO");
                dialogo.CheckFileExists = true;
                if (dialogo.ShowDialog() != DialogResult.OK) { return; }
                txtDesArchivo.Text = dialogo.FileName;
            }
        }

        private void btnSerializar_Click_883SC(object sender, EventArgs e)
        {
            try
            {
                bool todos;
                List<ClienteBE_883SC> aSerializar = ClientesParaSerializar_883SC(out todos);

                if (clienteBLL_883SC.ExisteArchivoXML_883SC(txtSerCarpeta.Text, txtSerNombre.Text)
                    && MessageBox.Show(Traducir_883SC("CLI_SER_MSG_CONFIRMA_SOBRESCRIBIR"), Traducir_883SC("CLI_SER_BTN_SERIALIZAR"),
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                string ruta = clienteBLL_883SC.SerializarClientes_883SC(aSerializar, txtSerCarpeta.Text, txtSerNombre.Text);
                LlenarMensaje_883SC(string.Format(Traducir_883SC("CLI_SER_MSG_SERIALIZADO"), aSerializar.Count, ListarDnis_883SC(aSerializar)));
                if (todos) { LlenarMensaje_883SC(Traducir_883SC("CLI_SER_MSG_TODOS")); }

                //Verificacion visual: se muestra el contenido del archivo generado
                using (frmVerXML_883SC verXml = new frmVerXML_883SC(clienteBLL_883SC.LeerContenidoXML_883SC(ruta)))
                {
                    verXml.ShowDialog(this);
                }
            }
            catch (ArgumentException ex)
            {
                LlenarMensaje_883SC(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeserializar_Click_883SC(object sender, EventArgs e)
        {
            try
            {
                List<ClienteBE_883SC> clientes = clienteBLL_883SC.DeserializarClientes_883SC(txtDesArchivo.Text);
                MostrarEnGrilla_883SC(clientes);
                vistaArchivo_883SC = true;   //Solo en la grilla: la base de datos no se modifica
                ConfigDefaultForm_883SC();
                LlenarMensaje_883SC(string.Format(Traducir_883SC("CLI_SER_MSG_DESERIALIZADO"), clientes.Count, ListarDnis_883SC(clientes)));
            }
            catch (ArgumentException ex)
            {
                LlenarMensaje_883SC(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Vacia la grilla (no toca la base de datos)
        private void btnLimpiar_Click_883SC(object sender, EventArgs e)
        {
            MostrarEnGrilla_883SC(new List<ClienteBE_883SC>());
            ConfigDefaultForm_883SC();
            LlenarMensaje_883SC(Traducir_883SC("CLI_SER_MSG_LIMPIADO"));
        }

        //Vuelve a leer los clientes desde la base de datos
        private void btnActualizar_Click_883SC(object sender, EventArgs e)
        {
            try
            {
                ActualizarGrilla_883SC();
                LlenarMensaje_883SC(Traducir_883SC("CLI_SER_MSG_ACTUALIZADO"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(Traducir_883SC("COMUN_ERROR_BD") + ex.Message, Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

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
