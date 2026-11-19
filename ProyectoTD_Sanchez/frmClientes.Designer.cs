namespace TP_SanchezVillaverde
{
    partial class frmClientes_883SC
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblSerTitulo;
        private System.Windows.Forms.Label lblSerCarpeta;
        private System.Windows.Forms.TextBox txtSerCarpeta;
        private System.Windows.Forms.Button btnSerCarpeta;
        private System.Windows.Forms.Label lblSerNombre;
        private System.Windows.Forms.TextBox txtSerNombre;
        private System.Windows.Forms.Button btnSerializar;
        private System.Windows.Forms.Label lblDesArchivo;
        private System.Windows.Forms.TextBox txtDesArchivo;
        private System.Windows.Forms.Button btnDesArchivo;
        private System.Windows.Forms.Button btnDeserializar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ToolTip toolTip;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle estiloAlterna = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle estiloEncabezado = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle estiloCelda = new System.Windows.Forms.DataGridViewCellStyle();
            this.pLista = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblOpciones = new System.Windows.Forms.Label();
            this.chkInactivos = new System.Windows.Forms.CheckBox();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnReactivar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pDatos = new System.Windows.Forms.Panel();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.gbMensajes = new System.Windows.Forms.GroupBox();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.pSerializacion = new System.Windows.Forms.Panel();
            this.lblSerTitulo = new System.Windows.Forms.Label();
            this.lblSerCarpeta = new System.Windows.Forms.Label();
            this.txtSerCarpeta = new System.Windows.Forms.TextBox();
            this.btnSerCarpeta = new System.Windows.Forms.Button();
            this.lblSerNombre = new System.Windows.Forms.Label();
            this.txtSerNombre = new System.Windows.Forms.TextBox();
            this.btnSerializar = new System.Windows.Forms.Button();
            this.lblDesArchivo = new System.Windows.Forms.Label();
            this.txtDesArchivo = new System.Windows.Forms.TextBox();
            this.btnDesArchivo = new System.Windows.Forms.Button();
            this.btnDeserializar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            estiloAlterna.BackColor = System.Drawing.Color.Gainsboro;
            estiloAlterna.Font = new System.Drawing.Font("Verdana", 9F);
            estiloAlterna.ForeColor = System.Drawing.Color.Black;
            estiloAlterna.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            estiloAlterna.SelectionForeColor = System.Drawing.Color.Black;
            estiloEncabezado.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            estiloEncabezado.BackColor = System.Drawing.Color.Firebrick;
            estiloEncabezado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            estiloEncabezado.ForeColor = System.Drawing.SystemColors.Window;
            estiloEncabezado.SelectionBackColor = System.Drawing.Color.Firebrick;
            estiloEncabezado.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            estiloEncabezado.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            estiloCelda.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            estiloCelda.BackColor = System.Drawing.Color.White;
            estiloCelda.Font = new System.Drawing.Font("Verdana", 9F);
            estiloCelda.ForeColor = System.Drawing.Color.Black;
            estiloCelda.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            estiloCelda.SelectionForeColor = System.Drawing.Color.Black;
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.pLista.SuspendLayout();
            this.pDatos.SuspendLayout();
            this.gbDatos.SuspendLayout();
            this.gbMensajes.SuspendLayout();
            this.SuspendLayout();
            //
            // pLista
            //
            this.pLista.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pLista.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLista.Controls.Add(this.btnActualizar);
            this.pLista.Controls.Add(this.btnLimpiar);
            this.pLista.Controls.Add(this.btnSalir);
            this.pLista.Controls.Add(this.btnCancelar);
            this.pLista.Controls.Add(this.btnGuardar);
            this.pLista.Controls.Add(this.btnReactivar);
            this.pLista.Controls.Add(this.btnEliminar);
            this.pLista.Controls.Add(this.btnModificar);
            this.pLista.Controls.Add(this.btnCrear);
            this.pLista.Controls.Add(this.lblOpciones);
            this.pLista.Controls.Add(this.chkInactivos);
            this.pLista.Controls.Add(this.lblTitulo);
            this.pLista.Controls.Add(this.dgvClientes);
            this.pLista.Location = new System.Drawing.Point(12, 11);
            this.pLista.Name = "pLista";
            this.pLista.Size = new System.Drawing.Size(1004, 426);
            this.pLista.TabIndex = 0;
            //
            // lblTitulo
            //
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Verdana", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblTitulo.Location = new System.Drawing.Point(0, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1002, 26);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "GESTION DE CLIENTES";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // chkInactivos
            //
            this.chkInactivos.AutoSize = true;
            this.chkInactivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chkInactivos.Location = new System.Drawing.Point(15, 52);
            this.chkInactivos.Name = "chkInactivos";
            this.chkInactivos.Size = new System.Drawing.Size(110, 17);
            this.chkInactivos.TabIndex = 1;
            this.chkInactivos.Text = "Mostrar inactivos";
            this.chkInactivos.UseVisualStyleBackColor = true;
            this.chkInactivos.CheckedChanged += new System.EventHandler(this.chkInactivos_CheckedChanged_883SC);
            //
            // dgvClientes
            //
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.AllowUserToResizeRows = false;
            this.dgvClientes.AllowUserToResizeColumns = false;
            this.dgvClientes.AlternatingRowsDefaultCellStyle = estiloAlterna;
            this.dgvClientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientes.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvClientes.ColumnHeadersDefaultCellStyle = estiloEncabezado;
            this.dgvClientes.ColumnHeadersHeight = 40;
            this.dgvClientes.DefaultCellStyle = estiloCelda;
            this.dgvClientes.EnableHeadersVisualStyles = false;
            this.dgvClientes.Location = new System.Drawing.Point(15, 83);
            this.dgvClientes.MultiSelect = true;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.RowHeadersVisible = false;
            this.dgvClientes.RowHeadersWidth = 51;
            this.dgvClientes.RowTemplate.Height = 24;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(832, 327);
            this.dgvClientes.TabIndex = 2;
            this.dgvClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellClick_883SC);
            //
            // lblOpciones
            //
            this.lblOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOpciones.AutoSize = true;
            this.lblOpciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblOpciones.Location = new System.Drawing.Point(888, 97);
            this.lblOpciones.Name = "lblOpciones";
            this.lblOpciones.Size = new System.Drawing.Size(76, 17);
            this.lblOpciones.TabIndex = 3;
            this.lblOpciones.Text = "Opciones";
            //
            // btnCrear
            //
            this.btnCrear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCrear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnCrear.Location = new System.Drawing.Point(867, 127);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(118, 29);
            this.btnCrear.TabIndex = 4;
            this.btnCrear.Text = "Crear Cliente";
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click_883SC);
            //
            // btnModificar
            //
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnModificar.Location = new System.Drawing.Point(867, 162);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(118, 29);
            this.btnModificar.TabIndex = 5;
            this.btnModificar.Text = "Modificar Cliente";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click_883SC);
            //
            // btnEliminar
            //
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnEliminar.Location = new System.Drawing.Point(867, 197);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(118, 29);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar Cliente";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_883SC);
            //
            // btnReactivar
            //
            this.btnReactivar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReactivar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnReactivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReactivar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnReactivar.Location = new System.Drawing.Point(867, 232);
            this.btnReactivar.Name = "btnReactivar";
            this.btnReactivar.Size = new System.Drawing.Size(118, 29);
            this.btnReactivar.TabIndex = 7;
            this.btnReactivar.Text = "Reactivar Cliente";
            this.btnReactivar.UseVisualStyleBackColor = false;
            this.btnReactivar.Click += new System.EventHandler(this.btnReactivar_Click_883SC);
            //
            // btnGuardar
            //
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnGuardar.Location = new System.Drawing.Point(867, 267);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(118, 29);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_883SC);
            //
            // btnCancelar
            //
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnCancelar.Location = new System.Drawing.Point(867, 302);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(118, 29);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_883SC);
            //
            // btnSalir
            //
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSalir.Location = new System.Drawing.Point(867, 338);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(118, 29);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_883SC);
            //
            // btnActualizar
            //
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnActualizar.Location = new System.Drawing.Point(626, 46);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(100, 28);
            this.btnActualizar.TabIndex = 11;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click_883SC);
            //
            // btnLimpiar
            //
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnLimpiar.Location = new System.Drawing.Point(735, 46);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 28);
            this.btnLimpiar.TabIndex = 12;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click_883SC);
            //
            // pDatos
            //
            this.pDatos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pDatos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDatos.Controls.Add(this.pSerializacion);
            this.pDatos.Controls.Add(this.gbMensajes);
            this.pDatos.Controls.Add(this.gbDatos);
            this.pDatos.Location = new System.Drawing.Point(12, 444);
            this.pDatos.Name = "pDatos";
            this.pDatos.Size = new System.Drawing.Size(1004, 206);
            this.pDatos.TabIndex = 1;
            //
            // gbDatos
            //
            this.gbDatos.Controls.Add(this.chkActivo);
            this.gbDatos.Controls.Add(this.txtTelefono);
            this.gbDatos.Controls.Add(this.lblTelefono);
            this.gbDatos.Controls.Add(this.txtDireccion);
            this.gbDatos.Controls.Add(this.lblDireccion);
            this.gbDatos.Controls.Add(this.txtApellido);
            this.gbDatos.Controls.Add(this.lblApellido);
            this.gbDatos.Controls.Add(this.txtNombre);
            this.gbDatos.Controls.Add(this.lblNombre);
            this.gbDatos.Controls.Add(this.txtDni);
            this.gbDatos.Controls.Add(this.lblDni);
            this.gbDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.gbDatos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbDatos.Location = new System.Drawing.Point(20, 8);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(410, 190);
            this.gbDatos.TabIndex = 0;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos del cliente";
            //
            // lblDni
            //
            this.lblDni.AutoSize = true;
            this.lblDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblDni.Location = new System.Drawing.Point(15, 29);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(26, 13);
            this.lblDni.TabIndex = 0;
            this.lblDni.Text = "DNI";
            //
            // txtDni
            //
            this.txtDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtDni.Location = new System.Drawing.Point(130, 26);
            this.txtDni.MaxLength = 9;
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(250, 20);
            this.txtDni.TabIndex = 1;
            this.txtDni.TextChanged += new System.EventHandler(this.campo_TextChanged_883SC);
            //
            // lblNombre
            //
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblNombre.Location = new System.Drawing.Point(15, 59);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre";
            //
            // txtNombre
            //
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtNombre.Location = new System.Drawing.Point(130, 56);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(250, 20);
            this.txtNombre.TabIndex = 3;
            this.txtNombre.TextChanged += new System.EventHandler(this.campo_TextChanged_883SC);
            //
            // lblApellido
            //
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblApellido.Location = new System.Drawing.Point(15, 89);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(49, 13);
            this.lblApellido.TabIndex = 4;
            this.lblApellido.Text = "Apellido";
            //
            // txtApellido
            //
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtApellido.Location = new System.Drawing.Point(130, 86);
            this.txtApellido.MaxLength = 50;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(250, 20);
            this.txtApellido.TabIndex = 5;
            this.txtApellido.TextChanged += new System.EventHandler(this.campo_TextChanged_883SC);
            //
            // lblDireccion
            //
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblDireccion.Location = new System.Drawing.Point(15, 119);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 6;
            this.lblDireccion.Text = "Direccion";
            //
            // txtDireccion
            //
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtDireccion.Location = new System.Drawing.Point(130, 116);
            this.txtDireccion.MaxLength = 100;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(250, 20);
            this.txtDireccion.TabIndex = 7;
            this.txtDireccion.TextChanged += new System.EventHandler(this.campo_TextChanged_883SC);
            //
            // lblTelefono
            //
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTelefono.Location = new System.Drawing.Point(15, 149);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(49, 13);
            this.lblTelefono.TabIndex = 8;
            this.lblTelefono.Text = "Telefono";
            //
            // txtTelefono
            //
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtTelefono.Location = new System.Drawing.Point(130, 146);
            this.txtTelefono.MaxLength = 15;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(250, 20);
            this.txtTelefono.TabIndex = 9;
            this.txtTelefono.TextChanged += new System.EventHandler(this.campo_TextChanged_883SC);
            //
            // chkActivo
            //
            this.chkActivo.AutoSize = true;
            this.chkActivo.Enabled = false;
            this.chkActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chkActivo.Location = new System.Drawing.Point(300, 4);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(56, 17);
            this.chkActivo.TabIndex = 10;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            //
            // gbMensajes
            //
            this.gbMensajes.Controls.Add(this.txtMensaje);
            this.gbMensajes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.gbMensajes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbMensajes.Location = new System.Drawing.Point(445, 8);
            this.gbMensajes.Name = "gbMensajes";
            this.gbMensajes.Size = new System.Drawing.Size(256, 190);
            this.gbMensajes.TabIndex = 1;
            this.gbMensajes.TabStop = false;
            this.gbMensajes.Text = "Mensajes";
            //
            // txtMensaje
            //
            this.txtMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtMensaje.ForeColor = System.Drawing.Color.Black;
            this.txtMensaje.Location = new System.Drawing.Point(6, 22);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.ReadOnly = true;
            this.txtMensaje.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensaje.Size = new System.Drawing.Size(244, 162);
            this.txtMensaje.TabIndex = 0;
            //
            // pSerializacion
            //
            // Serializacion / deserializacion XML de clientes (M2)
            this.pSerializacion.Controls.Add(this.btnDeserializar);
            this.pSerializacion.Controls.Add(this.btnDesArchivo);
            this.pSerializacion.Controls.Add(this.txtDesArchivo);
            this.pSerializacion.Controls.Add(this.lblDesArchivo);
            this.pSerializacion.Controls.Add(this.btnSerializar);
            this.pSerializacion.Controls.Add(this.txtSerNombre);
            this.pSerializacion.Controls.Add(this.lblSerNombre);
            this.pSerializacion.Controls.Add(this.btnSerCarpeta);
            this.pSerializacion.Controls.Add(this.txtSerCarpeta);
            this.pSerializacion.Controls.Add(this.lblSerCarpeta);
            this.pSerializacion.Controls.Add(this.lblSerTitulo);
            this.pSerializacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pSerializacion.Location = new System.Drawing.Point(716, 8);
            this.pSerializacion.Name = "pSerializacion";
            this.pSerializacion.Size = new System.Drawing.Size(270, 190);
            this.pSerializacion.TabIndex = 2;
            //
            // lblSerTitulo
            //
            this.lblSerTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblSerTitulo.Location = new System.Drawing.Point(6, 0);
            this.lblSerTitulo.Name = "lblSerTitulo";
            this.lblSerTitulo.Size = new System.Drawing.Size(258, 15);
            this.lblSerTitulo.TabIndex = 20;
            this.lblSerTitulo.Text = "Serializacion XML";
            //
            // lblSerCarpeta
            //
            this.lblSerCarpeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblSerCarpeta.Location = new System.Drawing.Point(6, 17);
            this.lblSerCarpeta.Name = "lblSerCarpeta";
            this.lblSerCarpeta.Size = new System.Drawing.Size(258, 15);
            this.lblSerCarpeta.TabIndex = 21;
            this.lblSerCarpeta.Text = "Carpeta de destino";
            //
            // txtSerCarpeta
            //
            this.txtSerCarpeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtSerCarpeta.Location = new System.Drawing.Point(6, 32);
            this.txtSerCarpeta.Name = "txtSerCarpeta";
            this.txtSerCarpeta.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSerCarpeta.ReadOnly = true;
            this.txtSerCarpeta.Size = new System.Drawing.Size(206, 21);
            this.txtSerCarpeta.TabIndex = 22;
            //
            // btnSerCarpeta
            //
            this.btnSerCarpeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSerCarpeta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSerCarpeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerCarpeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSerCarpeta.Location = new System.Drawing.Point(216, 31);
            this.btnSerCarpeta.Name = "btnSerCarpeta";
            this.btnSerCarpeta.Size = new System.Drawing.Size(30, 23);
            this.btnSerCarpeta.TabIndex = 23;
            this.btnSerCarpeta.Text = "...";
            this.btnSerCarpeta.UseVisualStyleBackColor = false;
            this.btnSerCarpeta.Click += new System.EventHandler(this.btnSerCarpeta_Click_883SC);
            //
            // lblSerNombre
            //
            this.lblSerNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblSerNombre.Location = new System.Drawing.Point(6, 56);
            this.lblSerNombre.Name = "lblSerNombre";
            this.lblSerNombre.Size = new System.Drawing.Size(258, 15);
            this.lblSerNombre.TabIndex = 24;
            this.lblSerNombre.Text = "Nombre del archivo";
            //
            // txtSerNombre
            //
            this.txtSerNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtSerNombre.Location = new System.Drawing.Point(6, 71);
            this.txtSerNombre.Name = "txtSerNombre";
            this.txtSerNombre.MaxLength = 100;
            this.txtSerNombre.Size = new System.Drawing.Size(240, 21);
            this.txtSerNombre.TabIndex = 25;
            //
            // btnSerializar
            //
            this.btnSerializar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSerializar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSerializar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerializar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSerializar.Location = new System.Drawing.Point(6, 96);
            this.btnSerializar.Name = "btnSerializar";
            this.btnSerializar.Size = new System.Drawing.Size(240, 24);
            this.btnSerializar.TabIndex = 26;
            this.btnSerializar.Text = "Serializar";
            this.btnSerializar.UseVisualStyleBackColor = false;
            this.btnSerializar.Click += new System.EventHandler(this.btnSerializar_Click_883SC);
            //
            // lblDesArchivo
            //
            this.lblDesArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblDesArchivo.Location = new System.Drawing.Point(6, 124);
            this.lblDesArchivo.Name = "lblDesArchivo";
            this.lblDesArchivo.Size = new System.Drawing.Size(258, 15);
            this.lblDesArchivo.TabIndex = 27;
            this.lblDesArchivo.Text = "Archivo XML a cargar";
            //
            // txtDesArchivo
            //
            this.txtDesArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtDesArchivo.Location = new System.Drawing.Point(6, 139);
            this.txtDesArchivo.Name = "txtDesArchivo";
            this.txtDesArchivo.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDesArchivo.ReadOnly = true;
            this.txtDesArchivo.Size = new System.Drawing.Size(206, 21);
            this.txtDesArchivo.TabIndex = 28;
            //
            // btnDesArchivo
            //
            this.btnDesArchivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDesArchivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnDesArchivo.Location = new System.Drawing.Point(216, 138);
            this.btnDesArchivo.Name = "btnDesArchivo";
            this.btnDesArchivo.Size = new System.Drawing.Size(30, 23);
            this.btnDesArchivo.TabIndex = 29;
            this.btnDesArchivo.Text = "...";
            this.btnDesArchivo.UseVisualStyleBackColor = false;
            this.btnDesArchivo.Click += new System.EventHandler(this.btnDesArchivo_Click_883SC);
            //
            // btnDeserializar
            //
            this.btnDeserializar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDeserializar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeserializar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeserializar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnDeserializar.Location = new System.Drawing.Point(6, 164);
            this.btnDeserializar.Name = "btnDeserializar";
            this.btnDeserializar.Size = new System.Drawing.Size(240, 24);
            this.btnDeserializar.TabIndex = 30;
            this.btnDeserializar.Text = "Deserializar";
            this.btnDeserializar.UseVisualStyleBackColor = false;
            this.btnDeserializar.Click += new System.EventHandler(this.btnDeserializar_Click_883SC);
            //
            // frmClientes_883SC
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1028, 661);
            this.Controls.Add(this.pDatos);
            this.Controls.Add(this.pLista);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "frmClientes";
            this.Text = "Gestion de Clientes";
            this.Load += new System.EventHandler(this.frmClientes_Load_883SC);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.pLista.ResumeLayout(false);
            this.pLista.PerformLayout();
            this.pDatos.ResumeLayout(false);
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.gbMensajes.ResumeLayout(false);
            this.gbMensajes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pLista;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblOpciones;
        private System.Windows.Forms.CheckBox chkInactivos;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnReactivar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pDatos;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.GroupBox gbMensajes;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Panel pSerializacion;
    }
}
