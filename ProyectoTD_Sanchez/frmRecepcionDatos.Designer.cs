namespace TP_SanchezVillaverde
{
    partial class frmRecepcionDatos_883SC
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
            this.lblOrden = new System.Windows.Forms.Label();
            this.dgvLineas = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecibida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineas)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(150, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Recibir mercaderia";
            //
            // lblOrden
            //
            this.lblOrden.Location = new System.Drawing.Point(20, 42);
            this.lblOrden.Name = "lblOrden";
            this.lblOrden.Size = new System.Drawing.Size(600, 15);
            this.lblOrden.TabIndex = 1;
            //
            // dgvLineas
            //
            this.dgvLineas.AllowUserToAddRows = false;
            this.dgvLineas.AllowUserToDeleteRows = false;
            this.dgvLineas.AllowUserToResizeRows = false;
            this.dgvLineas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLineas.BackgroundColor = System.Drawing.Color.White;
            this.dgvLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colNombre,
            this.colPedida,
            this.colRecibida});
            this.dgvLineas.Location = new System.Drawing.Point(20, 64);
            this.dgvLineas.MultiSelect = false;
            this.dgvLineas.Name = "dgvLineas";
            this.dgvLineas.RowHeadersVisible = false;
            this.dgvLineas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvLineas.Size = new System.Drawing.Size(600, 230);
            this.dgvLineas.TabIndex = 2;
            //
            // colCodigo
            //
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.HeaderText = "Codigo";
            //
            // colNombre
            //
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            this.colNombre.HeaderText = "Nombre";
            //
            // colPedida
            //
            this.colPedida.Name = "colPedida";
            this.colPedida.ReadOnly = true;
            this.colPedida.HeaderText = "Cantidad pedida";
            //
            // colRecibida
            //
            this.colRecibida.Name = "colRecibida";
            this.colRecibida.HeaderText = "Cantidad recibida";
            //
            // lblObservaciones
            //
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(20, 304);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(120, 13);
            this.lblObservaciones.TabIndex = 3;
            this.lblObservaciones.Text = "Observaciones (opcional):";
            //
            // txtObservaciones
            //
            this.txtObservaciones.Location = new System.Drawing.Point(20, 322);
            this.txtObservaciones.MaxLength = 500;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(600, 55);
            this.txtObservaciones.TabIndex = 4;
            //
            // lblError
            //
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(20, 388);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(600, 30);
            this.lblError.TabIndex = 5;
            //
            // btnConfirmar
            //
            this.btnConfirmar.BackColor = System.Drawing.Color.Gray;
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnConfirmar.Location = new System.Drawing.Point(420, 425);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(95, 29);
            this.btnConfirmar.TabIndex = 6;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click_883SC);
            //
            // btnCancelar
            //
            this.btnCancelar.BackColor = System.Drawing.Color.Gray;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.Location = new System.Drawing.Point(525, 425);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(95, 29);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_883SC);
            //
            // frmRecepcionDatos_883SC
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(640, 470);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.lblObservaciones);
            this.Controls.Add(this.dgvLineas);
            this.Controls.Add(this.lblOrden);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRecepcionDatos_883SC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recibir mercaderia";
            this.Load += new System.EventHandler(this.frmRecepcionDatos_Load_883SC);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblOrden;
        private System.Windows.Forms.DataGridView dgvLineas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecibida;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
