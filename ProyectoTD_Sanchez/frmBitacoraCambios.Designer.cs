namespace TP_SanchezVillaverde
{
    partial class frmBitacoraCambios_883SC
    {
        private System.ComponentModel.IContainer components = null;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pBitacora = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnActivar = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.dgvCambios = new System.Windows.Forms.DataGridView();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.cboNombre = new System.Windows.Forms.ComboBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.cboCodigo = new System.Windows.Forms.ComboBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pBitacora.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCambios)).BeginInit();
            this.SuspendLayout();
            //
            // pBitacora
            //
            this.pBitacora.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pBitacora.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pBitacora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBitacora.Controls.Add(this.btnSalir);
            this.pBitacora.Controls.Add(this.btnActivar);
            this.pBitacora.Controls.Add(this.lblError);
            this.pBitacora.Controls.Add(this.dgvCambios);
            this.pBitacora.Controls.Add(this.btnLimpiar);
            this.pBitacora.Controls.Add(this.btnAplicar);
            this.pBitacora.Controls.Add(this.dtpHasta);
            this.pBitacora.Controls.Add(this.lblHasta);
            this.pBitacora.Controls.Add(this.dtpDesde);
            this.pBitacora.Controls.Add(this.lblDesde);
            this.pBitacora.Controls.Add(this.cboNombre);
            this.pBitacora.Controls.Add(this.lblNombre);
            this.pBitacora.Controls.Add(this.cboCodigo);
            this.pBitacora.Controls.Add(this.lblCodigo);
            this.pBitacora.Controls.Add(this.lblTitulo);
            this.pBitacora.Location = new System.Drawing.Point(12, 11);
            this.pBitacora.Name = "pBitacora";
            this.pBitacora.Size = new System.Drawing.Size(1000, 540);
            this.pBitacora.TabIndex = 0;
            //
            // btnSalir
            //
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSalir.Location = new System.Drawing.Point(885, 495);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(95, 29);
            this.btnSalir.TabIndex = 14;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_883SC);
            //
            // btnActivar
            //
            this.btnActivar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnActivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnActivar.Location = new System.Drawing.Point(780, 495);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(95, 29);
            this.btnActivar.TabIndex = 13;
            this.btnActivar.Text = "Activar";
            this.btnActivar.UseVisualStyleBackColor = false;
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click_883SC);
            //
            // lblError
            //
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(20, 490);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(740, 38);
            this.lblError.TabIndex = 12;
            //
            // dgvCambios
            //
            this.dgvCambios.AllowUserToAddRows = false;
            this.dgvCambios.AllowUserToDeleteRows = false;
            this.dgvCambios.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvCambios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCambios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCambios.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCambios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCambios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCambios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCambios.ColumnHeadersHeight = 32;
            this.dgvCambios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCambios.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCambios.EnableHeadersVisualStyles = false;
            this.dgvCambios.Location = new System.Drawing.Point(20, 110);
            this.dgvCambios.MultiSelect = false;
            this.dgvCambios.Name = "dgvCambios";
            this.dgvCambios.ReadOnly = true;
            this.dgvCambios.RowHeadersVisible = false;
            this.dgvCambios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCambios.Size = new System.Drawing.Size(960, 365);
            this.dgvCambios.TabIndex = 11;
            this.dgvCambios.SelectionChanged += new System.EventHandler(this.dgvCambios_SelectionChanged_883SC);
            //
            // btnLimpiar
            //
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.Location = new System.Drawing.Point(885, 66);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(95, 29);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click_883SC);
            //
            // btnAplicar
            //
            this.btnAplicar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAplicar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAplicar.Location = new System.Drawing.Point(780, 66);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(95, 29);
            this.btnAplicar.TabIndex = 9;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = false;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click_883SC);
            //
            // dtpHasta
            //
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(620, 70);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.ShowCheckBox = true;
            this.dtpHasta.Size = new System.Drawing.Size(140, 20);
            this.dtpHasta.TabIndex = 8;
            //
            // lblHasta
            //
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(620, 52);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(61, 13);
            this.lblHasta.TabIndex = 7;
            this.lblHasta.Text = "Fecha final";
            //
            // dtpDesde
            //
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(460, 70);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.ShowCheckBox = true;
            this.dtpDesde.Size = new System.Drawing.Size(140, 20);
            this.dtpDesde.TabIndex = 6;
            //
            // lblDesde
            //
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(460, 52);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(67, 13);
            this.lblDesde.TabIndex = 5;
            this.lblDesde.Text = "Fecha inicial";
            //
            // cboNombre
            //
            this.cboNombre.FormattingEnabled = true;
            this.cboNombre.Location = new System.Drawing.Point(200, 70);
            this.cboNombre.MaxLength = 50;
            this.cboNombre.Name = "cboNombre";
            this.cboNombre.Size = new System.Drawing.Size(240, 21);
            this.cboNombre.TabIndex = 4;
            //
            // lblNombre
            //
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(200, 52);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre";
            //
            // cboCodigo
            //
            this.cboCodigo.FormattingEnabled = true;
            this.cboCodigo.Location = new System.Drawing.Point(20, 70);
            this.cboCodigo.MaxLength = 50;
            this.cboCodigo.Name = "cboCodigo";
            this.cboCodigo.Size = new System.Drawing.Size(160, 21);
            this.cboCodigo.TabIndex = 2;
            //
            // lblCodigo
            //
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(20, 52);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 1;
            this.lblCodigo.Text = "Codigo";
            //
            // lblTitulo
            //
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Verdana", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblTitulo.Location = new System.Drawing.Point(262, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(477, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "BITACORA DE CAMBIOS DE PRODUCTOS";
            //
            // frmBitacoraCambios_883SC
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1024, 562);
            this.Controls.Add(this.pBitacora);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.MinimumSize = new System.Drawing.Size(1024, 562);
            this.Name = "frmBitacoraCambios_883SC";
            this.Text = "Bitacora de Cambios de Productos";
            this.Load += new System.EventHandler(this.frmBitacoraCambios_Load_883SC);
            this.pBitacora.ResumeLayout(false);
            this.pBitacora.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCambios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBitacora;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.ComboBox cboCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ComboBox cboNombre;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvCambios;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.Button btnSalir;
    }
}
