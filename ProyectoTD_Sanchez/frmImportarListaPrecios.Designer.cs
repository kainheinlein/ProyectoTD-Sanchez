namespace TP_SanchezVillaverde
{
    partial class frmImportarListaPrecios_883SC
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.btnNuevoProveedor = new System.Windows.Forms.Button();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.lblColCodigo = new System.Windows.Forms.Label();
            this.cmbColCodigo = new System.Windows.Forms.ComboBox();
            this.lblColDescripcion = new System.Windows.Forms.Label();
            this.cmbColDescripcion = new System.Windows.Forms.ComboBox();
            this.lblColPrecio = new System.Windows.Forms.Label();
            this.cmbColPrecio = new System.Windows.Forms.ComboBox();
            this.lblPrimeraFila = new System.Windows.Forms.Label();
            this.nudPrimeraFila = new System.Windows.Forms.NumericUpDown();
            this.lblVistaPrevia = new System.Windows.Forms.Label();
            this.dgvVista = new System.Windows.Forms.DataGridView();
            this.lblError = new System.Windows.Forms.Label();
            this.lblRechazadas = new System.Windows.Forms.Label();
            this.dgvRechazadas = new System.Windows.Forms.DataGridView();
            this.colFila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrimeraFila)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRechazadas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(25, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(210, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Importar Lista de Precios";
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblProveedor.Location = new System.Drawing.Point(25, 69);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(76, 15);
            this.lblProveedor.TabIndex = 1;
            this.lblProveedor.Text = "Proveedor:";
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(125, 66);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(250, 23);
            this.cmbProveedor.TabIndex = 2;
            // 
            // btnNuevoProveedor
            // 
            this.btnNuevoProveedor.BackColor = System.Drawing.Color.Gray;
            this.btnNuevoProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnNuevoProveedor.Location = new System.Drawing.Point(390, 63);
            this.btnNuevoProveedor.Name = "btnNuevoProveedor";
            this.btnNuevoProveedor.Size = new System.Drawing.Size(130, 29);
            this.btnNuevoProveedor.TabIndex = 3;
            this.btnNuevoProveedor.Text = "Nuevo proveedor";
            this.btnNuevoProveedor.UseVisualStyleBackColor = false;
            this.btnNuevoProveedor.Click += new System.EventHandler(this.btnNuevoProveedor_Click_883SC);
            // 
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblArchivo.Location = new System.Drawing.Point(25, 109);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(85, 15);
            this.lblArchivo.TabIndex = 4;
            this.lblArchivo.Text = "Archivo .csv:";
            // 
            // txtArchivo
            // 
            this.txtArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtArchivo.Location = new System.Drawing.Point(125, 106);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.Size = new System.Drawing.Size(250, 21);
            this.txtArchivo.TabIndex = 5;
            // 
            // btnExaminar
            // 
            this.btnExaminar.BackColor = System.Drawing.Color.Gray;
            this.btnExaminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExaminar.Location = new System.Drawing.Point(390, 103);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(130, 29);
            this.btnExaminar.TabIndex = 6;
            this.btnExaminar.Text = "Examinar...";
            this.btnExaminar.UseVisualStyleBackColor = false;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click_883SC);
            // 
            // btnImportar
            // 
            this.btnImportar.BackColor = System.Drawing.Color.Gray;
            this.btnImportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnImportar.Location = new System.Drawing.Point(558, 103);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(120, 29);
            this.btnImportar.TabIndex = 7;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click_883SC);
            // 
            // lblColCodigo
            // 
            this.lblColCodigo.AutoSize = true;
            this.lblColCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblColCodigo.Location = new System.Drawing.Point(25, 149);
            this.lblColCodigo.Name = "lblColCodigo";
            this.lblColCodigo.Size = new System.Drawing.Size(56, 15);
            this.lblColCodigo.TabIndex = 20;
            this.lblColCodigo.Text = "Codigo:";
            // 
            // cmbColCodigo
            // 
            this.cmbColCodigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbColCodigo.FormattingEnabled = true;
            this.cmbColCodigo.Location = new System.Drawing.Point(85, 146);
            this.cmbColCodigo.Name = "cmbColCodigo";
            this.cmbColCodigo.Size = new System.Drawing.Size(55, 23);
            this.cmbColCodigo.TabIndex = 21;
            // 
            // lblColDescripcion
            // 
            this.lblColDescripcion.AutoSize = true;
            this.lblColDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblColDescripcion.Location = new System.Drawing.Point(160, 149);
            this.lblColDescripcion.Name = "lblColDescripcion";
            this.lblColDescripcion.Size = new System.Drawing.Size(87, 15);
            this.lblColDescripcion.TabIndex = 22;
            this.lblColDescripcion.Text = "Descripcion:";
            // 
            // cmbColDescripcion
            // 
            this.cmbColDescripcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbColDescripcion.FormattingEnabled = true;
            this.cmbColDescripcion.Location = new System.Drawing.Point(250, 146);
            this.cmbColDescripcion.Name = "cmbColDescripcion";
            this.cmbColDescripcion.Size = new System.Drawing.Size(55, 23);
            this.cmbColDescripcion.TabIndex = 23;
            // 
            // lblColPrecio
            // 
            this.lblColPrecio.AutoSize = true;
            this.lblColPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblColPrecio.Location = new System.Drawing.Point(325, 149);
            this.lblColPrecio.Name = "lblColPrecio";
            this.lblColPrecio.Size = new System.Drawing.Size(52, 15);
            this.lblColPrecio.TabIndex = 24;
            this.lblColPrecio.Text = "Precio:";
            // 
            // cmbColPrecio
            // 
            this.cmbColPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbColPrecio.FormattingEnabled = true;
            this.cmbColPrecio.Location = new System.Drawing.Point(385, 146);
            this.cmbColPrecio.Name = "cmbColPrecio";
            this.cmbColPrecio.Size = new System.Drawing.Size(55, 23);
            this.cmbColPrecio.TabIndex = 25;
            // 
            // lblPrimeraFila
            // 
            this.lblPrimeraFila.AutoSize = true;
            this.lblPrimeraFila.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrimeraFila.Location = new System.Drawing.Point(460, 149);
            this.lblPrimeraFila.Name = "lblPrimeraFila";
            this.lblPrimeraFila.Size = new System.Drawing.Size(145, 15);
            this.lblPrimeraFila.TabIndex = 26;
            this.lblPrimeraFila.Text = "Primera fila de datos:";
            // 
            // nudPrimeraFila
            // 
            this.nudPrimeraFila.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.nudPrimeraFila.Location = new System.Drawing.Point(620, 146);
            this.nudPrimeraFila.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudPrimeraFila.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPrimeraFila.Name = "nudPrimeraFila";
            this.nudPrimeraFila.Size = new System.Drawing.Size(70, 21);
            this.nudPrimeraFila.TabIndex = 27;
            this.nudPrimeraFila.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblVistaPrevia
            // 
            this.lblVistaPrevia.AutoSize = true;
            this.lblVistaPrevia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblVistaPrevia.Location = new System.Drawing.Point(25, 262);
            this.lblVistaPrevia.Name = "lblVistaPrevia";
            this.lblVistaPrevia.Size = new System.Drawing.Size(155, 15);
            this.lblVistaPrevia.TabIndex = 28;
            this.lblVistaPrevia.Text = "Vista previa del archivo";
            // 
            // dgvVista
            // 
            this.dgvVista.AllowUserToAddRows = false;
            this.dgvVista.AllowUserToDeleteRows = false;
            this.dgvVista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVista.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvVista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVista.Location = new System.Drawing.Point(25, 282);
            this.dgvVista.Name = "dgvVista";
            this.dgvVista.ReadOnly = true;
            this.dgvVista.RowHeadersVisible = false;
            this.dgvVista.Size = new System.Drawing.Size(760, 150);
            this.dgvVista.TabIndex = 29;
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(82, 216);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(660, 32);
            this.lblError.TabIndex = 8;
            // 
            // lblRechazadas
            // 
            this.lblRechazadas.AutoSize = true;
            this.lblRechazadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblRechazadas.Location = new System.Drawing.Point(25, 445);
            this.lblRechazadas.Name = "lblRechazadas";
            this.lblRechazadas.Size = new System.Drawing.Size(120, 15);
            this.lblRechazadas.TabIndex = 9;
            this.lblRechazadas.Text = "Filas rechazadas:";
            // 
            // dgvRechazadas
            // 
            this.dgvRechazadas.AllowUserToAddRows = false;
            this.dgvRechazadas.AllowUserToDeleteRows = false;
            this.dgvRechazadas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRechazadas.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvRechazadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRechazadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFila,
            this.colCodigo,
            this.colMotivo});
            this.dgvRechazadas.Location = new System.Drawing.Point(25, 465);
            this.dgvRechazadas.Name = "dgvRechazadas";
            this.dgvRechazadas.ReadOnly = true;
            this.dgvRechazadas.RowHeadersVisible = false;
            this.dgvRechazadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRechazadas.Size = new System.Drawing.Size(760, 170);
            this.dgvRechazadas.TabIndex = 10;
            // 
            // colFila
            // 
            this.colFila.FillWeight = 10F;
            this.colFila.HeaderText = "Fila";
            this.colFila.Name = "colFila";
            this.colFila.ReadOnly = true;
            // 
            // colCodigo
            // 
            this.colCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCodigo.FillWeight = 25F;
            this.colCodigo.HeaderText = "Codigo del proveedor";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            // 
            // colMotivo
            // 
            this.colMotivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMotivo.FillWeight = 65F;
            this.colMotivo.HeaderText = "Motivo";
            this.colMotivo.Name = "colMotivo";
            this.colMotivo.ReadOnly = true;
            // 
            // frmImportarListaPrecios_883SC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(810, 650);
            this.Controls.Add(this.dgvVista);
            this.Controls.Add(this.lblVistaPrevia);
            this.Controls.Add(this.nudPrimeraFila);
            this.Controls.Add(this.lblPrimeraFila);
            this.Controls.Add(this.cmbColPrecio);
            this.Controls.Add(this.lblColPrecio);
            this.Controls.Add(this.cmbColDescripcion);
            this.Controls.Add(this.lblColDescripcion);
            this.Controls.Add(this.cmbColCodigo);
            this.Controls.Add(this.lblColCodigo);
            this.Controls.Add(this.dgvRechazadas);
            this.Controls.Add(this.lblRechazadas);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.txtArchivo);
            this.Controls.Add(this.lblArchivo);
            this.Controls.Add(this.btnNuevoProveedor);
            this.Controls.Add(this.cmbProveedor);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmImportarListaPrecios_883SC";
            this.Text = "Importar Lista de Precios";
            this.Load += new System.EventHandler(this.frmImportarListaPrecios_Load_883SC);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrimeraFila)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRechazadas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Button btnNuevoProveedor;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Label lblColCodigo;
        private System.Windows.Forms.ComboBox cmbColCodigo;
        private System.Windows.Forms.Label lblColDescripcion;
        private System.Windows.Forms.ComboBox cmbColDescripcion;
        private System.Windows.Forms.Label lblColPrecio;
        private System.Windows.Forms.ComboBox cmbColPrecio;
        private System.Windows.Forms.Label lblPrimeraFila;
        private System.Windows.Forms.NumericUpDown nudPrimeraFila;
        private System.Windows.Forms.Label lblVistaPrevia;
        private System.Windows.Forms.DataGridView dgvVista;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblRechazadas;
        private System.Windows.Forms.DataGridView dgvRechazadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFila;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMotivo;
    }
}
