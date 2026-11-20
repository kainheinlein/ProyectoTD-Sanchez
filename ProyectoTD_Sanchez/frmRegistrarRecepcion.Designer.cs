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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pRecepcion = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblOrdenes = new System.Windows.Forms.Label();
            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnRecibir = new System.Windows.Forms.Button();
            this.btnReimprimir = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.pRecepcion.SuspendLayout();
            this.SuspendLayout();
            //
            // pRecepcion
            //
            this.pRecepcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pRecepcion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pRecepcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRecepcion.Controls.Add(this.btnSalir);
            this.pRecepcion.Controls.Add(this.lblError);
            this.pRecepcion.Controls.Add(this.btnReimprimir);
            this.pRecepcion.Controls.Add(this.btnRecibir);
            this.pRecepcion.Controls.Add(this.btnEnviar);
            this.pRecepcion.Controls.Add(this.dgvDetalle);
            this.pRecepcion.Controls.Add(this.lblDetalle);
            this.pRecepcion.Controls.Add(this.dgvOrdenes);
            this.pRecepcion.Controls.Add(this.lblOrdenes);
            this.pRecepcion.Controls.Add(this.cboEstado);
            this.pRecepcion.Controls.Add(this.lblEstado);
            this.pRecepcion.Controls.Add(this.lblTitulo);
            this.pRecepcion.Location = new System.Drawing.Point(12, 11);
            this.pRecepcion.Name = "pRecepcion";
            this.pRecepcion.Size = new System.Drawing.Size(900, 525);
            this.pRecepcion.TabIndex = 0;
            //
            // lblTitulo
            //
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Verdana", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblTitulo.Location = new System.Drawing.Point(307, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(285, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "REGISTRAR RECEPCION";
            //
            // lblEstado
            //
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(640, 49);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 1;
            this.lblEstado.Text = "Estado:";
            //
            // cboEstado
            //
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(700, 45);
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvOrdenes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrdenes.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvOrdenes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvOrdenes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdenes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrdenes.ColumnHeadersHeight = 32;
            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvOrdenes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOrdenes.EnableHeadersVisualStyles = false;
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
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDetalle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetalle.ColumnHeadersHeight = 32;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDetalle.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
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
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
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
            this.btnRecibir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
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
            // btnReimprimir
            //
            this.btnReimprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnReimprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReimprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReimprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnReimprimir.Location = new System.Drawing.Point(430, 436);
            this.btnReimprimir.Name = "btnReimprimir";
            this.btnReimprimir.Size = new System.Drawing.Size(200, 29);
            this.btnReimprimir.TabIndex = 11;
            this.btnReimprimir.Text = "Reimprimir comprobante";
            this.btnReimprimir.UseVisualStyleBackColor = false;
            this.btnReimprimir.Click += new System.EventHandler(this.btnReimprimir_Click_883SC);
            //
            // lblError
            //
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(20, 436);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(400, 32);
            this.lblError.TabIndex = 9;
            //
            // btnSalir
            //
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
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
            this.ClientSize = new System.Drawing.Size(924, 547);
            this.Controls.Add(this.pRecepcion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.MinimumSize = new System.Drawing.Size(924, 547);
            this.Name = "frmRegistrarRecepcion_883SC";
            this.Text = "Registrar Recepcion";
            this.Load += new System.EventHandler(this.frmRegistrarRecepcion_Load_883SC);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.pRecepcion.ResumeLayout(false);
            this.pRecepcion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pRecepcion;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label lblOrdenes;
        private System.Windows.Forms.DataGridView dgvOrdenes;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnRecibir;
        private System.Windows.Forms.Button btnReimprimir;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnSalir;
    }
}
