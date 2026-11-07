namespace TP_SanchezVillaverde
{
    partial class frmRegistrarRecepcion_883SC
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
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblOrdenes = new System.Windows.Forms.Label();
            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnRecibir = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(180, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registrar Recepcion";
            //
            // lblEstado
            //
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(640, 17);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 1;
            this.lblEstado.Text = "Estado:";
            //
            // cboEstado
            //
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(700, 14);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(180, 21);
            this.cboEstado.TabIndex = 2;
            this.cboEstado.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cboEstado_Format_883SC);
            this.cboEstado.SelectedIndexChanged += new System.EventHandler(this.cboEstado_SelectedIndexChanged_883SC);
            //
            // lblOrdenes
            //
            this.lblOrdenes.AutoSize = true;
            this.lblOrdenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblOrdenes.Location = new System.Drawing.Point(20, 48);
            this.lblOrdenes.Name = "lblOrdenes";
            this.lblOrdenes.Size = new System.Drawing.Size(120, 15);
            this.lblOrdenes.TabIndex = 3;
            this.lblOrdenes.Text = "Ordenes de compra";
            //
            // dgvOrdenes
            //
            this.dgvOrdenes.AllowUserToAddRows = false;
            this.dgvOrdenes.AllowUserToDeleteRows = false;
            this.dgvOrdenes.AllowUserToResizeRows = false;
            this.dgvOrdenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrdenes.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenes.Location = new System.Drawing.Point(20, 68);
            this.dgvOrdenes.MultiSelect = false;
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.ReadOnly = true;
            this.dgvOrdenes.RowHeadersVisible = false;
            this.dgvOrdenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenes.Size = new System.Drawing.Size(860, 160);
            this.dgvOrdenes.TabIndex = 4;
            this.dgvOrdenes.SelectionChanged += new System.EventHandler(this.dgvOrdenes_SelectionChanged_883SC);
            //
            // lblDetalle
            //
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblDetalle.Location = new System.Drawing.Point(20, 242);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(120, 15);
            this.lblDetalle.TabIndex = 5;
            this.lblDetalle.Text = "Detalle de la orden";
            //
            // dgvDetalle
            //
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AllowUserToResizeRows = false;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(20, 262);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(860, 160);
            this.dgvDetalle.TabIndex = 6;
            //
            // btnEnviar
            //
            this.btnEnviar.BackColor = System.Drawing.Color.Gray;
            this.btnEnviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnEnviar.Location = new System.Drawing.Point(640, 436);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(130, 29);
            this.btnEnviar.TabIndex = 7;
            this.btnEnviar.Text = "Registrar envio";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click_883SC);
            //
            // btnRecibir
            //
            this.btnRecibir.BackColor = System.Drawing.Color.Gray;
            this.btnRecibir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecibir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecibir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnRecibir.Location = new System.Drawing.Point(780, 436);
            this.btnRecibir.Name = "btnRecibir";
            this.btnRecibir.Size = new System.Drawing.Size(100, 29);
            this.btnRecibir.TabIndex = 8;
            this.btnRecibir.Text = "Recibir";
            this.btnRecibir.UseVisualStyleBackColor = false;
            this.btnRecibir.Click += new System.EventHandler(this.btnRecibir_Click_883SC);
            //
            // lblError
            //
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(20, 436);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(600, 32);
            this.lblError.TabIndex = 9;
            //
            // btnSalir
            //
            this.btnSalir.BackColor = System.Drawing.Color.Gray;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSalir.Location = new System.Drawing.Point(785, 480);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(95, 29);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_883SC);
            //
            // frmRegistrarRecepcion_883SC
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(900, 525);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnRecibir);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.dgvOrdenes);
            this.Controls.Add(this.lblOrdenes);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "frmRegistrarRecepcion_883SC";
            this.Text = "Registrar Recepcion";
            this.Load += new System.EventHandler(this.frmRegistrarRecepcion_Load_883SC);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label lblOrdenes;
        private System.Windows.Forms.DataGridView dgvOrdenes;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnRecibir;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnSalir;
    }
}
