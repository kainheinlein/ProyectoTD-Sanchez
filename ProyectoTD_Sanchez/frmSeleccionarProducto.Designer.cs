namespace TP_SanchezVillaverde
{
    partial class frmSeleccionarProducto_883SC
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
            this.lblCriterio = new System.Windows.Forms.Label();
            this.cmbCriterio = new System.Windows.Forms.ComboBox();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAgregarCarrito = new System.Windows.Forms.Button();
            this.lblCarrito = new System.Windows.Forms.Label();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.colCarrCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCarrNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCarrCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCarrPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCarrSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCantEditar = new System.Windows.Forms.Label();
            this.numCantidadEditar = new System.Windows.Forms.NumericUpDown();
            this.btnEditarCarrito = new System.Windows.Forms.Button();
            this.btnEliminarCarrito = new System.Windows.Forms.Button();
            this.lblTotalCarrito = new System.Windows.Forms.Label();
            this.btnFinalizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidadEditar)).BeginInit();
            this.SuspendLayout();
            //
            // lblCriterio
            //
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCriterio.Location = new System.Drawing.Point(15, 18);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(53, 15);
            this.lblCriterio.TabIndex = 0;
            this.lblCriterio.Text = "Criterio:";
            //
            // cmbCriterio
            //
            this.cmbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCriterio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCriterio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbCriterio.Items.AddRange(new object[] {
            "Nombre",
            "Tipo",
            "Codigo"});
            this.cmbCriterio.Location = new System.Drawing.Point(100, 15);
            this.cmbCriterio.Name = "cmbCriterio";
            this.cmbCriterio.Size = new System.Drawing.Size(140, 23);
            this.cmbCriterio.TabIndex = 1;
            //
            // lblBusqueda
            //
            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblBusqueda.Location = new System.Drawing.Point(260, 18);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(53, 15);
            this.lblBusqueda.TabIndex = 2;
            this.lblBusqueda.Text = "Buscar:";
            //
            // txtBusqueda
            //
            this.txtBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtBusqueda.Location = new System.Drawing.Point(330, 15);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(220, 23);
            this.txtBusqueda.TabIndex = 3;
            //
            // btnBuscar
            //
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnBuscar.Location = new System.Drawing.Point(570, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 29);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_883SC);
            //
            // dgvProductos
            //
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductos.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProductos.EnableHeadersVisualStyles = false;
            this.dgvProductos.Location = new System.Drawing.Point(15, 55);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9F);
            this.dgvProductos.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProductos.RowTemplate.Height = 24;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(860, 230);
            this.dgvProductos.TabIndex = 5;
            this.dgvProductos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvProductos_DataBindingComplete_883SC);
            //
            // lblCantidad
            //
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCantidad.Location = new System.Drawing.Point(15, 303);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(66, 15);
            this.lblCantidad.TabIndex = 6;
            this.lblCantidad.Text = "Cantidad:";
            //
            // numCantidad
            //
            this.numCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.numCantidad.Location = new System.Drawing.Point(100, 300);
            this.numCantidad.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(80, 23);
            this.numCantidad.TabIndex = 7;
            this.numCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // btnAgregarCarrito
            //
            this.btnAgregarCarrito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAgregarCarrito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCarrito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCarrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnAgregarCarrito.Location = new System.Drawing.Point(200, 298);
            this.btnAgregarCarrito.Name = "btnAgregarCarrito";
            this.btnAgregarCarrito.Size = new System.Drawing.Size(160, 29);
            this.btnAgregarCarrito.TabIndex = 8;
            this.btnAgregarCarrito.Text = "Agregar al Carrito";
            this.btnAgregarCarrito.UseVisualStyleBackColor = false;
            this.btnAgregarCarrito.Click += new System.EventHandler(this.btnAgregarCarrito_Click_883SC);
            //
            // lblCarrito
            //
            this.lblCarrito.AutoSize = true;
            this.lblCarrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCarrito.Location = new System.Drawing.Point(15, 340);
            this.lblCarrito.Name = "lblCarrito";
            this.lblCarrito.Size = new System.Drawing.Size(122, 15);
            this.lblCarrito.TabIndex = 9;
            this.lblCarrito.Text = "Carrito en progreso:";
            //
            // dgvCarrito
            //
            this.dgvCarrito.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCarrito.AllowUserToAddRows = false;
            this.dgvCarrito.AllowUserToDeleteRows = false;
            this.dgvCarrito.AllowUserToResizeColumns = false;
            this.dgvCarrito.AutoGenerateColumns = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvCarrito.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCarrito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarrito.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCarrito.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCarrito.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCarrito.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCarrito.ColumnHeadersHeight = 40;
            this.dgvCarrito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCarrCodigo,
            this.colCarrNombre,
            this.colCarrCantidad,
            this.colCarrPrecioUnitario,
            this.colCarrSubtotal});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCarrito.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCarrito.EnableHeadersVisualStyles = false;
            this.dgvCarrito.Location = new System.Drawing.Point(15, 365);
            this.dgvCarrito.MultiSelect = false;
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.ReadOnly = true;
            this.dgvCarrito.RowHeadersVisible = false;
            this.dgvCarrito.RowHeadersWidth = 51;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 9F);
            this.dgvCarrito.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCarrito.RowTemplate.Height = 24;
            this.dgvCarrito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarrito.Size = new System.Drawing.Size(860, 180);
            this.dgvCarrito.TabIndex = 10;
            this.dgvCarrito.SelectionChanged += new System.EventHandler(this.dgvCarrito_SelectionChanged_883SC);
            //
            // colCarrCodigo
            //
            this.colCarrCodigo.HeaderText = "Codigo";
            this.colCarrCodigo.Name = "colCarrCodigo";
            this.colCarrCodigo.ReadOnly = true;
            //
            // colCarrNombre
            //
            this.colCarrNombre.HeaderText = "Nombre";
            this.colCarrNombre.Name = "colCarrNombre";
            this.colCarrNombre.ReadOnly = true;
            //
            // colCarrCantidad
            //
            this.colCarrCantidad.HeaderText = "Cantidad";
            this.colCarrCantidad.Name = "colCarrCantidad";
            this.colCarrCantidad.ReadOnly = true;
            //
            // colCarrPrecioUnitario
            //
            this.colCarrPrecioUnitario.HeaderText = "Precio Unitario";
            this.colCarrPrecioUnitario.Name = "colCarrPrecioUnitario";
            this.colCarrPrecioUnitario.ReadOnly = true;
            //
            // colCarrSubtotal
            //
            this.colCarrSubtotal.HeaderText = "Subtotal";
            this.colCarrSubtotal.Name = "colCarrSubtotal";
            this.colCarrSubtotal.ReadOnly = true;
            //
            // lblCantEditar
            //
            this.lblCantEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCantEditar.AutoSize = true;
            this.lblCantEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCantEditar.Location = new System.Drawing.Point(15, 553);
            this.lblCantEditar.Name = "lblCantEditar";
            this.lblCantEditar.Size = new System.Drawing.Size(48, 15);
            this.lblCantEditar.TabIndex = 12;
            this.lblCantEditar.Text = "Cant.:";
            //
            // numCantidadEditar
            //
            this.numCantidadEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numCantidadEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.numCantidadEditar.Location = new System.Drawing.Point(70, 550);
            this.numCantidadEditar.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numCantidadEditar.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCantidadEditar.Name = "numCantidadEditar";
            this.numCantidadEditar.Size = new System.Drawing.Size(70, 23);
            this.numCantidadEditar.TabIndex = 13;
            this.numCantidadEditar.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // btnEditarCarrito
            //
            this.btnEditarCarrito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditarCarrito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEditarCarrito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarCarrito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarCarrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnEditarCarrito.Location = new System.Drawing.Point(150, 548);
            this.btnEditarCarrito.Name = "btnEditarCarrito";
            this.btnEditarCarrito.Size = new System.Drawing.Size(90, 29);
            this.btnEditarCarrito.TabIndex = 14;
            this.btnEditarCarrito.Text = "Editar";
            this.btnEditarCarrito.UseVisualStyleBackColor = false;
            this.btnEditarCarrito.Click += new System.EventHandler(this.btnEditarCarrito_Click_883SC);
            //
            // btnEliminarCarrito
            //
            this.btnEliminarCarrito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminarCarrito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEliminarCarrito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarCarrito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarCarrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnEliminarCarrito.Location = new System.Drawing.Point(250, 548);
            this.btnEliminarCarrito.Name = "btnEliminarCarrito";
            this.btnEliminarCarrito.Size = new System.Drawing.Size(90, 29);
            this.btnEliminarCarrito.TabIndex = 15;
            this.btnEliminarCarrito.Text = "Eliminar";
            this.btnEliminarCarrito.UseVisualStyleBackColor = false;
            this.btnEliminarCarrito.Click += new System.EventHandler(this.btnEliminarCarrito_Click_883SC);
            //
            // lblTotalCarrito
            //
            this.lblTotalCarrito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCarrito.AutoSize = true;
            this.lblTotalCarrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalCarrito.Location = new System.Drawing.Point(600, 551);
            this.lblTotalCarrito.Name = "lblTotalCarrito";
            this.lblTotalCarrito.Size = new System.Drawing.Size(90, 20);
            this.lblTotalCarrito.TabIndex = 16;
            this.lblTotalCarrito.Text = "Total: $ 0.00";
            this.lblTotalCarrito.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // btnFinalizar
            //
            this.btnFinalizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnFinalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnFinalizar.Location = new System.Drawing.Point(762, 592);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(113, 29);
            this.btnFinalizar.TabIndex = 11;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click_883SC);
            //
            // frmSeleccionarProducto_883SC
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(892, 645);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.lblTotalCarrito);
            this.Controls.Add(this.btnEliminarCarrito);
            this.Controls.Add(this.btnEditarCarrito);
            this.Controls.Add(this.numCantidadEditar);
            this.Controls.Add(this.lblCantEditar);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.lblCarrito);
            this.Controls.Add(this.btnAgregarCarrito);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.lblBusqueda);
            this.Controls.Add(this.cmbCriterio);
            this.Controls.Add(this.lblCriterio);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 550);
            this.Name = "frmSeleccionarProducto_883SC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmSeleccionarProducto_Load_883SC);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidadEditar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.ComboBox cmbCriterio;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Button btnAgregarCarrito;
        private System.Windows.Forms.Label lblCarrito;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCarrCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCarrNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCarrCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCarrPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCarrSubtotal;
        private System.Windows.Forms.Label lblCantEditar;
        private System.Windows.Forms.NumericUpDown numCantidadEditar;
        private System.Windows.Forms.Button btnEditarCarrito;
        private System.Windows.Forms.Button btnEliminarCarrito;
        private System.Windows.Forms.Label lblTotalCarrito;
        private System.Windows.Forms.Button btnFinalizar;
    }
}
