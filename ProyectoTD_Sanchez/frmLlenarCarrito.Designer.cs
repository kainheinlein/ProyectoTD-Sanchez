namespace TP_SanchezVillaverde
{
    partial class frmLlenarCarrito_883SC
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
            this.pnlCarrito = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblResumen = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.colDetCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.pnlCarrito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            //
            // pnlCarrito
            //
            // Anchor None: el panel queda centrado y con tamaño fijo aunque el form
            // llene toda el area MDI (mismo patron que pUsuario en frmUsuario)
            this.pnlCarrito.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCarrito.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlCarrito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCarrito.Controls.Add(this.lblTitulo);
            this.pnlCarrito.Controls.Add(this.lblResumen);
            this.pnlCarrito.Controls.Add(this.dgvDetalle);
            this.pnlCarrito.Controls.Add(this.btnQuitar);
            this.pnlCarrito.Controls.Add(this.lblTotal);
            this.pnlCarrito.Controls.Add(this.lblCliente);
            this.pnlCarrito.Controls.Add(this.txtCliente);
            this.pnlCarrito.Controls.Add(this.btnSalir);
            this.pnlCarrito.Controls.Add(this.btnConfirmar);
            this.pnlCarrito.Location = new System.Drawing.Point(12, 11);
            this.pnlCarrito.Name = "pnlCarrito";
            this.pnlCarrito.Size = new System.Drawing.Size(1004, 639);
            this.pnlCarrito.TabIndex = 0;
            //
            // lblTitulo
            //
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Verdana", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblTitulo.Location = new System.Drawing.Point(442, 6);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(120, 25);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "CARRITO";
            //
            // lblResumen
            //
            this.lblResumen.AutoSize = true;
            this.lblResumen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblResumen.Location = new System.Drawing.Point(15, 50);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(130, 15);
            this.lblResumen.TabIndex = 0;
            this.lblResumen.Text = "Resumen del carrito:";
            //
            // dgvDetalle
            //
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AllowUserToResizeColumns = false;
            this.dgvDetalle.AutoGenerateColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDetalle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetalle.ColumnHeadersHeight = 40;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDetCodigo,
            this.colDetNombre,
            this.colDetCantidad,
            this.colDetPrecioUnitario,
            this.colDetSubtotal});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalle.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.Location = new System.Drawing.Point(15, 75);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9F);
            this.dgvDetalle.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetalle.RowTemplate.Height = 24;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(972, 430);
            this.dgvDetalle.TabIndex = 1;
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
            // btnQuitar
            //
            this.btnQuitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnQuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnQuitar.Location = new System.Drawing.Point(15, 520);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(110, 29);
            this.btnQuitar.TabIndex = 2;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click_883SC);
            //
            // lblTotal
            //
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(780, 523);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(90, 20);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Total: $ 0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblCliente
            //
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCliente.Location = new System.Drawing.Point(15, 588);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(126, 15);
            this.lblCliente.TabIndex = 4;
            this.lblCliente.Text = "Nombre del cliente:";
            //
            // txtCliente
            //
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtCliente.Location = new System.Drawing.Point(160, 585);
            this.txtCliente.MaxLength = 50;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(260, 23);
            this.txtCliente.TabIndex = 5;
            //
            // btnSalir
            //
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSalir.Location = new System.Drawing.Point(750, 582);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(113, 29);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_883SC);
            //
            // btnConfirmar
            //
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnConfirmar.Location = new System.Drawing.Point(875, 582);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(113, 29);
            this.btnConfirmar.TabIndex = 7;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click_883SC);
            //
            // frmLlenarCarrito_883SC
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1028, 661);
            this.Controls.Add(this.pnlCarrito);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "frmLlenarCarrito_883SC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Llenar Carrito";
            this.Load += new System.EventHandler(this.frmLlenarCarrito_Load_883SC);
            this.Shown += new System.EventHandler(this.frmLlenarCarrito_Shown_883SC);
            this.pnlCarrito.ResumeLayout(false);
            this.pnlCarrito.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCarrito;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetSubtotal;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnConfirmar;
    }
}
