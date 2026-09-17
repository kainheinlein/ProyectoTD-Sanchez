namespace TP_SanchezVillaverde
{
    partial class frmRealizarVenta_883SC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlVenta = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblPendientes = new System.Windows.Forms.Label();
            this.dgvPendientes = new System.Windows.Forms.DataGridView();
            this.colPenId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPenNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPenFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.colDetCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.grpCliente = new System.Windows.Forms.GroupBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblNombreValor = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblApellidoValor = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblDireccionValor = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblTelefonoValor = new System.Windows.Forms.Label();
            this.grpPago = new System.Windows.Forms.GroupBox();
            this.lblMetodo = new System.Windows.Forms.Label();
            this.lblMetodoValor = new System.Windows.Forms.Label();
            this.lblAutorizacion = new System.Windows.Forms.Label();
            this.lblAutorizacionValor = new System.Windows.Forms.Label();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.pnlVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.grpCliente.SuspendLayout();
            this.grpPago.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlVenta
            //
            // Anchor None: el panel queda centrado y con tamaño fijo aunque el form
            // llene toda el area MDI (mismo patron que pUsuario en frmUsuario)
            this.pnlVenta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlVenta.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVenta.Controls.Add(this.lblTitulo);
            this.pnlVenta.Controls.Add(this.lblPendientes);
            this.pnlVenta.Controls.Add(this.dgvPendientes);
            this.pnlVenta.Controls.Add(this.lblDetalle);
            this.pnlVenta.Controls.Add(this.dgvDetalle);
            this.pnlVenta.Controls.Add(this.lblTotal);
            this.pnlVenta.Controls.Add(this.grpCliente);
            this.pnlVenta.Controls.Add(this.grpPago);
            this.pnlVenta.Controls.Add(this.btnSalir);
            this.pnlVenta.Controls.Add(this.btnGenerar);
            this.pnlVenta.Location = new System.Drawing.Point(12, 11);
            this.pnlVenta.Name = "pnlVenta";
            this.pnlVenta.Size = new System.Drawing.Size(1004, 639);
            this.pnlVenta.TabIndex = 0;
            //
            // lblTitulo
            //
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Verdana", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblTitulo.Location = new System.Drawing.Point(392, 6);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(220, 25);
            this.lblTitulo.TabIndex = 9;
            this.lblTitulo.Text = "REALIZAR VENTA";
            //
            // lblPendientes
            //
            this.lblPendientes.AutoSize = true;
            this.lblPendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblPendientes.Location = new System.Drawing.Point(15, 50);
            this.lblPendientes.Name = "lblPendientes";
            this.lblPendientes.Size = new System.Drawing.Size(200, 15);
            this.lblPendientes.TabIndex = 0;
            this.lblPendientes.Text = "Carritos pendientes de facturar:";
            //
            // dgvPendientes
            //
            this.dgvPendientes.AllowUserToAddRows = false;
            this.dgvPendientes.AllowUserToDeleteRows = false;
            this.dgvPendientes.AllowUserToResizeColumns = false;
            this.dgvPendientes.AutoGenerateColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPendientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPendientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPendientes.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPendientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPendientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPendientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPendientes.ColumnHeadersHeight = 40;
            this.dgvPendientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPenId,
            this.colPenNombre,
            this.colPenFecha});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPendientes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPendientes.EnableHeadersVisualStyles = false;
            this.dgvPendientes.Location = new System.Drawing.Point(15, 75);
            this.dgvPendientes.MultiSelect = false;
            this.dgvPendientes.Name = "dgvPendientes";
            this.dgvPendientes.ReadOnly = true;
            this.dgvPendientes.RowHeadersVisible = false;
            this.dgvPendientes.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9F);
            this.dgvPendientes.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPendientes.RowTemplate.Height = 24;
            this.dgvPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPendientes.Size = new System.Drawing.Size(340, 250);
            this.dgvPendientes.TabIndex = 1;
            this.dgvPendientes.SelectionChanged += new System.EventHandler(this.dgvPendientes_SelectionChanged_883SC);
            //
            // colPenId
            //
            this.colPenId.FillWeight = 20F;
            this.colPenId.HeaderText = "Nro.";
            this.colPenId.Name = "colPenId";
            this.colPenId.ReadOnly = true;
            //
            // colPenNombre
            //
            this.colPenNombre.FillWeight = 45F;
            this.colPenNombre.HeaderText = "Nombre";
            this.colPenNombre.Name = "colPenNombre";
            this.colPenNombre.ReadOnly = true;
            //
            // colPenFecha
            //
            this.colPenFecha.FillWeight = 35F;
            this.colPenFecha.HeaderText = "Fecha";
            this.colPenFecha.Name = "colPenFecha";
            this.colPenFecha.ReadOnly = true;
            //
            // lblDetalle
            //
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblDetalle.Location = new System.Drawing.Point(370, 50);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(130, 15);
            this.lblDetalle.TabIndex = 2;
            this.lblDetalle.Text = "Detalle del carrito:";
            //
            // dgvDetalle
            //
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AllowUserToResizeColumns = false;
            this.dgvDetalle.AutoGenerateColumns = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDetalle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetalle.ColumnHeadersHeight = 40;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDetCodigo,
            this.colDetNombre,
            this.colDetCantidad,
            this.colDetPrecioUnitario,
            this.colDetSubtotal});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalle.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.Location = new System.Drawing.Point(370, 75);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.RowHeadersWidth = 51;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 9F);
            this.dgvDetalle.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDetalle.RowTemplate.Height = 24;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(617, 250);
            this.dgvDetalle.TabIndex = 3;
            //
            // colDetCodigo
            //
            this.colDetCodigo.HeaderText = "Codigo";
            this.colDetCodigo.Name = "colDetCodigo";
            this.colDetCodigo.ReadOnly = true;
            //
            // colDetNombre
            //
            this.colDetNombre.HeaderText = "Producto";
            this.colDetNombre.Name = "colDetNombre";
            this.colDetNombre.ReadOnly = true;
            //
            // colDetCantidad
            //
            this.colDetCantidad.HeaderText = "Cantidad";
            this.colDetCantidad.Name = "colDetCantidad";
            this.colDetCantidad.ReadOnly = true;
            //
            // colDetPrecioUnitario
            //
            this.colDetPrecioUnitario.HeaderText = "Precio Unitario";
            this.colDetPrecioUnitario.Name = "colDetPrecioUnitario";
            this.colDetPrecioUnitario.ReadOnly = true;
            //
            // colDetSubtotal
            //
            this.colDetSubtotal.HeaderText = "Subtotal";
            this.colDetSubtotal.Name = "colDetSubtotal";
            this.colDetSubtotal.ReadOnly = true;
            //
            // lblTotal
            //
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(800, 333);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(90, 20);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "Total: $ 0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // grpCliente
            //
            this.grpCliente.Controls.Add(this.lblDni);
            this.grpCliente.Controls.Add(this.txtDni);
            this.grpCliente.Controls.Add(this.btnBuscarCliente);
            this.grpCliente.Controls.Add(this.lblNombre);
            this.grpCliente.Controls.Add(this.lblNombreValor);
            this.grpCliente.Controls.Add(this.lblApellido);
            this.grpCliente.Controls.Add(this.lblApellidoValor);
            this.grpCliente.Controls.Add(this.lblDireccion);
            this.grpCliente.Controls.Add(this.lblDireccionValor);
            this.grpCliente.Controls.Add(this.lblTelefono);
            this.grpCliente.Controls.Add(this.lblTelefonoValor);
            this.grpCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grpCliente.Location = new System.Drawing.Point(15, 365);
            this.grpCliente.Name = "grpCliente";
            this.grpCliente.Size = new System.Drawing.Size(520, 215);
            this.grpCliente.TabIndex = 5;
            this.grpCliente.TabStop = false;
            this.grpCliente.Text = "Cliente";
            //
            // lblDni
            //
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(15, 33);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(34, 15);
            this.lblDni.TabIndex = 0;
            this.lblDni.Text = "DNI:";
            //
            // txtDni
            //
            this.txtDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtDni.Location = new System.Drawing.Point(110, 30);
            this.txtDni.MaxLength = 9;
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(170, 21);
            this.txtDni.TabIndex = 1;
            //
            // btnBuscarCliente
            //
            this.btnBuscarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBuscarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnBuscarCliente.Location = new System.Drawing.Point(300, 26);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(150, 29);
            this.btnBuscarCliente.TabIndex = 2;
            this.btnBuscarCliente.Text = "Buscar Cliente";
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click_883SC);
            //
            // lblNombre
            //
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(15, 75);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 15);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre:";
            //
            // lblNombreValor
            //
            this.lblNombreValor.AutoSize = true;
            this.lblNombreValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNombreValor.Location = new System.Drawing.Point(110, 75);
            this.lblNombreValor.Name = "lblNombreValor";
            this.lblNombreValor.Size = new System.Drawing.Size(0, 15);
            this.lblNombreValor.TabIndex = 4;
            //
            // lblApellido
            //
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(15, 108);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(63, 15);
            this.lblApellido.TabIndex = 5;
            this.lblApellido.Text = "Apellido:";
            //
            // lblApellidoValor
            //
            this.lblApellidoValor.AutoSize = true;
            this.lblApellidoValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblApellidoValor.Location = new System.Drawing.Point(110, 108);
            this.lblApellidoValor.Name = "lblApellidoValor";
            this.lblApellidoValor.Size = new System.Drawing.Size(0, 15);
            this.lblApellidoValor.TabIndex = 6;
            //
            // lblDireccion
            //
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(15, 141);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(71, 15);
            this.lblDireccion.TabIndex = 7;
            this.lblDireccion.Text = "Direccion:";
            //
            // lblDireccionValor
            //
            this.lblDireccionValor.AutoSize = true;
            this.lblDireccionValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblDireccionValor.Location = new System.Drawing.Point(110, 141);
            this.lblDireccionValor.Name = "lblDireccionValor";
            this.lblDireccionValor.Size = new System.Drawing.Size(0, 15);
            this.lblDireccionValor.TabIndex = 8;
            //
            // lblTelefono
            //
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(15, 174);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(66, 15);
            this.lblTelefono.TabIndex = 9;
            this.lblTelefono.Text = "Telefono:";
            //
            // lblTelefonoValor
            //
            this.lblTelefonoValor.AutoSize = true;
            this.lblTelefonoValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblTelefonoValor.Location = new System.Drawing.Point(110, 174);
            this.lblTelefonoValor.Name = "lblTelefonoValor";
            this.lblTelefonoValor.Size = new System.Drawing.Size(0, 15);
            this.lblTelefonoValor.TabIndex = 10;
            //
            // grpPago
            //
            this.grpPago.Controls.Add(this.lblMetodo);
            this.grpPago.Controls.Add(this.lblMetodoValor);
            this.grpPago.Controls.Add(this.lblAutorizacion);
            this.grpPago.Controls.Add(this.lblAutorizacionValor);
            this.grpPago.Controls.Add(this.btnCobrar);
            this.grpPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grpPago.Location = new System.Drawing.Point(550, 365);
            this.grpPago.Name = "grpPago";
            this.grpPago.Size = new System.Drawing.Size(437, 215);
            this.grpPago.TabIndex = 6;
            this.grpPago.TabStop = false;
            this.grpPago.Text = "Pago";
            //
            // lblMetodo
            //
            this.lblMetodo.AutoSize = true;
            this.lblMetodo.Location = new System.Drawing.Point(15, 33);
            this.lblMetodo.Name = "lblMetodo";
            this.lblMetodo.Size = new System.Drawing.Size(56, 15);
            this.lblMetodo.TabIndex = 0;
            this.lblMetodo.Text = "Metodo:";
            //
            // lblMetodoValor
            //
            this.lblMetodoValor.AutoSize = true;
            this.lblMetodoValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblMetodoValor.Location = new System.Drawing.Point(120, 33);
            this.lblMetodoValor.Name = "lblMetodoValor";
            this.lblMetodoValor.Size = new System.Drawing.Size(0, 15);
            this.lblMetodoValor.TabIndex = 1;
            //
            // lblAutorizacion
            //
            this.lblAutorizacion.AutoSize = true;
            this.lblAutorizacion.Location = new System.Drawing.Point(15, 68);
            this.lblAutorizacion.Name = "lblAutorizacion";
            this.lblAutorizacion.Size = new System.Drawing.Size(85, 15);
            this.lblAutorizacion.TabIndex = 2;
            this.lblAutorizacion.Text = "Autorizacion:";
            //
            // lblAutorizacionValor
            //
            this.lblAutorizacionValor.AutoSize = true;
            this.lblAutorizacionValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblAutorizacionValor.Location = new System.Drawing.Point(120, 68);
            this.lblAutorizacionValor.Name = "lblAutorizacionValor";
            this.lblAutorizacionValor.Size = new System.Drawing.Size(0, 15);
            this.lblAutorizacionValor.TabIndex = 3;
            //
            // btnCobrar
            //
            this.btnCobrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCobrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCobrar.Enabled = false;
            this.btnCobrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCobrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnCobrar.Location = new System.Drawing.Point(15, 120);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(150, 29);
            this.btnCobrar.TabIndex = 4;
            this.btnCobrar.Text = "Cobrar";
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click_883SC);
            //
            // btnSalir
            //
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSalir.Location = new System.Drawing.Point(750, 595);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(113, 29);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_883SC);
            //
            // btnGenerar
            //
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnGenerar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerar.Enabled = false;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnGenerar.Location = new System.Drawing.Point(875, 595);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(112, 29);
            this.btnGenerar.TabIndex = 8;
            this.btnGenerar.Text = "Generar Factura";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click_883SC);
            //
            // frmRealizarVenta_883SC
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1028, 661);
            this.Controls.Add(this.pnlVenta);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "frmRealizarVenta_883SC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Realizar Venta";
            this.Load += new System.EventHandler(this.frmRealizarVenta_Load_883SC);
            this.pnlVenta.ResumeLayout(false);
            this.pnlVenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.grpCliente.ResumeLayout(false);
            this.grpCliente.PerformLayout();
            this.grpPago.ResumeLayout(false);
            this.grpPago.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlVenta;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblPendientes;
        private System.Windows.Forms.DataGridView dgvPendientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPenId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPenNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPenFecha;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetSubtotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox grpCliente;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblNombreValor;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblApellidoValor;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblDireccionValor;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblTelefonoValor;
        private System.Windows.Forms.GroupBox grpPago;
        private System.Windows.Forms.Label lblMetodo;
        private System.Windows.Forms.Label lblMetodoValor;
        private System.Windows.Forms.Label lblAutorizacion;
        private System.Windows.Forms.Label lblAutorizacionValor;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGenerar;
    }
}
