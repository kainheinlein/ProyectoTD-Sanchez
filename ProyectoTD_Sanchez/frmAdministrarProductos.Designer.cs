namespace TP_SanchezVillaverde
{
    partial class frmAdministrarProductos_883SC
    {
        private System.ComponentModel.IContainer components = null;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pAdmin = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.btnVincular = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnDesvincular = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.chkInactivos = new System.Windows.Forms.CheckBox();
            this.dgvPendientes = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.lblPendientes = new System.Windows.Forms.Label();
            this.dgvVinculados = new System.Windows.Forms.DataGridView();
            this.lblVinculados = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.lblProductos = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVinculados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // pAdmin
            // 
            this.pAdmin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pAdmin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pAdmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pAdmin.Controls.Add(this.btnSalir);
            this.pAdmin.Controls.Add(this.lblError);
            this.pAdmin.Controls.Add(this.btnVincular);
            this.pAdmin.Controls.Add(this.btnCrear);
            this.pAdmin.Controls.Add(this.btnDesvincular);
            this.pAdmin.Controls.Add(this.btnModificar);
            this.pAdmin.Controls.Add(this.btnBaja);
            this.pAdmin.Controls.Add(this.chkInactivos);
            this.pAdmin.Controls.Add(this.dgvPendientes);
            this.pAdmin.Controls.Add(this.btnBuscar);
            this.pAdmin.Controls.Add(this.txtBuscar);
            this.pAdmin.Controls.Add(this.lblBuscar);
            this.pAdmin.Controls.Add(this.cmbFiltro);
            this.pAdmin.Controls.Add(this.lblFiltro);
            this.pAdmin.Controls.Add(this.lblPendientes);
            this.pAdmin.Controls.Add(this.dgvVinculados);
            this.pAdmin.Controls.Add(this.lblVinculados);
            this.pAdmin.Controls.Add(this.dgvProductos);
            this.pAdmin.Controls.Add(this.lblProductos);
            this.pAdmin.Controls.Add(this.lblTitulo);
            this.pAdmin.Location = new System.Drawing.Point(12, 11);
            this.pAdmin.Name = "pAdmin";
            this.pAdmin.Size = new System.Drawing.Size(1000, 628);
            this.pAdmin.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSalir.Location = new System.Drawing.Point(880, 586);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 29);
            this.btnSalir.TabIndex = 14;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_883SC);
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(20, 583);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(860, 32);
            this.lblError.TabIndex = 13;
            // 
            // btnVincular
            // 
            this.btnVincular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnVincular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVincular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVincular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnVincular.Location = new System.Drawing.Point(730, 545);
            this.btnVincular.Name = "btnVincular";
            this.btnVincular.Size = new System.Drawing.Size(100, 29);
            this.btnVincular.TabIndex = 12;
            this.btnVincular.Text = "Vincular";
            this.btnVincular.UseVisualStyleBackColor = false;
            this.btnVincular.Click += new System.EventHandler(this.btnVincular_Click_883SC);
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCrear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCrear.Location = new System.Drawing.Point(600, 545);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(120, 29);
            this.btnCrear.TabIndex = 11;
            this.btnCrear.Text = "Crear producto";
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click_883SC);
            // 
            // btnDesvincular
            // 
            this.btnDesvincular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDesvincular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesvincular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesvincular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnDesvincular.Location = new System.Drawing.Point(130, 545);
            this.btnDesvincular.Name = "btnDesvincular";
            this.btnDesvincular.Size = new System.Drawing.Size(100, 29);
            this.btnDesvincular.TabIndex = 10;
            this.btnDesvincular.Text = "Desvincular";
            this.btnDesvincular.UseVisualStyleBackColor = false;
            this.btnDesvincular.Click += new System.EventHandler(this.btnDesvincular_Click_883SC);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnModificar.Location = new System.Drawing.Point(20, 545);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(100, 29);
            this.btnModificar.TabIndex = 9;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click_883SC);
            // 
            // btnBaja
            // 
            this.btnBaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnBaja.Location = new System.Drawing.Point(240, 545);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(110, 29);
            this.btnBaja.TabIndex = 18;
            this.btnBaja.Text = "Dar de baja";
            this.btnBaja.UseVisualStyleBackColor = false;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click_883SC);
            // 
            // chkInactivos
            // 
            this.chkInactivos.AutoSize = true;
            this.chkInactivos.Location = new System.Drawing.Point(440, 87);
            this.chkInactivos.Name = "chkInactivos";
            this.chkInactivos.Size = new System.Drawing.Size(105, 17);
            this.chkInactivos.TabIndex = 19;
            this.chkInactivos.Text = "Mostrar inactivos";
            this.chkInactivos.UseVisualStyleBackColor = true;
            this.chkInactivos.CheckedChanged += new System.EventHandler(this.chkInactivos_CheckedChanged_883SC);
            // 
            // dgvPendientes
            // 
            this.dgvPendientes.AllowUserToAddRows = false;
            this.dgvPendientes.AllowUserToDeleteRows = false;
            this.dgvPendientes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
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
            this.dgvPendientes.ColumnHeadersHeight = 32;
            this.dgvPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPendientes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPendientes.EnableHeadersVisualStyles = false;
            this.dgvPendientes.Location = new System.Drawing.Point(600, 170);
            this.dgvPendientes.MultiSelect = false;
            this.dgvPendientes.Name = "dgvPendientes";
            this.dgvPendientes.ReadOnly = true;
            this.dgvPendientes.RowHeadersVisible = false;
            this.dgvPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPendientes.Size = new System.Drawing.Size(380, 366);
            this.dgvPendientes.TabIndex = 8;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.Location = new System.Drawing.Point(898, 138);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(82, 24);
            this.btnBuscar.TabIndex = 17;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_883SC);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(670, 140);
            this.txtBuscar.MaxLength = 200;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(220, 20);
            this.txtBuscar.TabIndex = 16;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown_883SC);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(600, 144);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(66, 13);
            this.lblBuscar.TabIndex = 15;
            this.lblBuscar.Text = "Descripcion:";
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.Location = new System.Drawing.Point(670, 110);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(310, 21);
            this.cmbFiltro.TabIndex = 7;
            this.cmbFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged_883SC);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(600, 114);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(59, 13);
            this.lblFiltro.TabIndex = 6;
            this.lblFiltro.Text = "Proveedor:";
            // 
            // lblPendientes
            // 
            this.lblPendientes.AutoSize = true;
            this.lblPendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblPendientes.Location = new System.Drawing.Point(600, 88);
            this.lblPendientes.Name = "lblPendientes";
            this.lblPendientes.Size = new System.Drawing.Size(213, 15);
            this.lblPendientes.TabIndex = 5;
            this.lblPendientes.Text = "Items pendientes de vinculacion";
            // 
            // dgvVinculados
            // 
            this.dgvVinculados.AllowUserToAddRows = false;
            this.dgvVinculados.AllowUserToDeleteRows = false;
            this.dgvVinculados.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvVinculados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvVinculados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVinculados.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvVinculados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvVinculados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVinculados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvVinculados.ColumnHeadersHeight = 32;
            this.dgvVinculados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVinculados.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvVinculados.EnableHeadersVisualStyles = false;
            this.dgvVinculados.Location = new System.Drawing.Point(20, 386);
            this.dgvVinculados.MultiSelect = false;
            this.dgvVinculados.Name = "dgvVinculados";
            this.dgvVinculados.ReadOnly = true;
            this.dgvVinculados.RowHeadersVisible = false;
            this.dgvVinculados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVinculados.Size = new System.Drawing.Size(560, 150);
            this.dgvVinculados.TabIndex = 4;
            // 
            // lblVinculados
            // 
            this.lblVinculados.AutoSize = true;
            this.lblVinculados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblVinculados.Location = new System.Drawing.Point(20, 366);
            this.lblVinculados.Name = "lblVinculados";
            this.lblVinculados.Size = new System.Drawing.Size(219, 15);
            this.lblVinculados.TabIndex = 3;
            this.lblVinculados.Text = "Codigos de proveedor vinculados";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvProductos.ColumnHeadersHeight = 32;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductos.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvProductos.EnableHeadersVisualStyles = false;
            this.dgvProductos.Location = new System.Drawing.Point(20, 108);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(560, 250);
            this.dgvProductos.TabIndex = 2;
            this.dgvProductos.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged_883SC);
            // 
            // lblProductos
            // 
            this.lblProductos.AutoSize = true;
            this.lblProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblProductos.Location = new System.Drawing.Point(20, 88);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(71, 15);
            this.lblProductos.TabIndex = 1;
            this.lblProductos.Text = "Productos";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Verdana", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblTitulo.Location = new System.Drawing.Point(330, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(326, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "ADMINISTRAR PRODUCTOS";
            // 
            // frmAdministrarProductos_883SC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1024, 650);
            this.Controls.Add(this.pAdmin);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.MinimumSize = new System.Drawing.Size(1024, 650);
            this.Name = "frmAdministrarProductos_883SC";
            this.Text = "Administrar Productos";
            this.Load += new System.EventHandler(this.frmAdministrarProductos_Load_883SC);
            this.pAdmin.ResumeLayout(false);
            this.pAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVinculados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pAdmin;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label lblVinculados;
        private System.Windows.Forms.DataGridView dgvVinculados;
        private System.Windows.Forms.Label lblPendientes;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvPendientes;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.CheckBox chkInactivos;
        private System.Windows.Forms.Button btnDesvincular;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnVincular;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnSalir;
    }
}
