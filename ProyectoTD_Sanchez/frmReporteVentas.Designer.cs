namespace TP_SanchezVillaverde
{
    partial class frmReporteVentas_883SC
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
            this.pReporte = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbPeriodo = new System.Windows.Forms.GroupBox();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.gbResumen = new System.Windows.Forms.GroupBox();
            this.lblCantVentasTit = new System.Windows.Forms.Label();
            this.lblCantVentas = new System.Windows.Forms.Label();
            this.lblUnidadesTit = new System.Windows.Forms.Label();
            this.lblUnidades = new System.Windows.Forms.Label();
            this.lblMontoTit = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblTicketTit = new System.Windows.Forms.Label();
            this.lblTicket = new System.Windows.Forms.Label();
            this.lblVentasDia = new System.Windows.Forms.Label();
            this.dgvDias = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTop = new System.Windows.Forms.Label();
            this.dgvTop = new System.Windows.Forms.DataGridView();
            this.lblError = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pReporte.SuspendLayout();
            this.gbPeriodo.SuspendLayout();
            this.gbResumen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop)).BeginInit();
            this.SuspendLayout();
            //
            // pReporte
            //
            this.pReporte.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pReporte.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pReporte.Controls.Add(this.btnSalir);
            this.pReporte.Controls.Add(this.btnExportar);
            this.pReporte.Controls.Add(this.lblError);
            this.pReporte.Controls.Add(this.dgvTop);
            this.pReporte.Controls.Add(this.lblTop);
            this.pReporte.Controls.Add(this.lblTotal);
            this.pReporte.Controls.Add(this.dgvDias);
            this.pReporte.Controls.Add(this.lblVentasDia);
            this.pReporte.Controls.Add(this.gbResumen);
            this.pReporte.Controls.Add(this.btnLimpiar);
            this.pReporte.Controls.Add(this.btnGenerar);
            this.pReporte.Controls.Add(this.gbPeriodo);
            this.pReporte.Controls.Add(this.lblTitulo);
            this.pReporte.Location = new System.Drawing.Point(12, 11);
            this.pReporte.Name = "pReporte";
            this.pReporte.Size = new System.Drawing.Size(900, 560);
            this.pReporte.TabIndex = 0;
            //
            // lblTitulo
            //
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Verdana", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblTitulo.Location = new System.Drawing.Point(327, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(245, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "REPORTE DE VENTAS";
            //
            // gbPeriodo
            //
            this.gbPeriodo.Controls.Add(this.dtpHasta);
            this.gbPeriodo.Controls.Add(this.lblHasta);
            this.gbPeriodo.Controls.Add(this.dtpDesde);
            this.gbPeriodo.Controls.Add(this.lblDesde);
            this.gbPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gbPeriodo.Location = new System.Drawing.Point(20, 50);
            this.gbPeriodo.Name = "gbPeriodo";
            this.gbPeriodo.Size = new System.Drawing.Size(500, 65);
            this.gbPeriodo.TabIndex = 1;
            this.gbPeriodo.TabStop = false;
            this.gbPeriodo.Text = "Periodo";
            //
            // lblDesde
            //
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(15, 30);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(43, 13);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde:";
            //
            // dtpDesde
            //
            this.dtpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(75, 26);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(150, 20);
            this.dtpDesde.TabIndex = 1;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged_883SC);
            //
            // lblHasta
            //
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(255, 30);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(41, 13);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.Text = "Hasta:";
            //
            // dtpHasta
            //
            this.dtpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(310, 26);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(150, 20);
            this.dtpHasta.TabIndex = 3;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged_883SC);
            //
            // btnGenerar
            //
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnGenerar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnGenerar.Location = new System.Drawing.Point(560, 67);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(150, 29);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click_883SC);
            //
            // btnLimpiar
            //
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.Location = new System.Drawing.Point(730, 67);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(150, 29);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click_883SC);
            //
            // gbResumen
            //
            this.gbResumen.Controls.Add(this.lblTicket);
            this.gbResumen.Controls.Add(this.lblTicketTit);
            this.gbResumen.Controls.Add(this.lblMonto);
            this.gbResumen.Controls.Add(this.lblMontoTit);
            this.gbResumen.Controls.Add(this.lblUnidades);
            this.gbResumen.Controls.Add(this.lblUnidadesTit);
            this.gbResumen.Controls.Add(this.lblCantVentas);
            this.gbResumen.Controls.Add(this.lblCantVentasTit);
            this.gbResumen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gbResumen.Location = new System.Drawing.Point(20, 125);
            this.gbResumen.Name = "gbResumen";
            this.gbResumen.Size = new System.Drawing.Size(860, 75);
            this.gbResumen.TabIndex = 4;
            this.gbResumen.TabStop = false;
            this.gbResumen.Text = "Resumen del periodo";
            //
            // lblCantVentasTit
            //
            this.lblCantVentasTit.AutoSize = true;
            this.lblCantVentasTit.Location = new System.Drawing.Point(15, 22);
            this.lblCantVentasTit.Name = "lblCantVentasTit";
            this.lblCantVentasTit.Size = new System.Drawing.Size(100, 13);
            this.lblCantVentasTit.TabIndex = 0;
            this.lblCantVentasTit.Text = "Cantidad de ventas";
            //
            // lblCantVentas
            //
            this.lblCantVentas.AutoSize = true;
            this.lblCantVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblCantVentas.Location = new System.Drawing.Point(15, 44);
            this.lblCantVentas.Name = "lblCantVentas";
            this.lblCantVentas.Size = new System.Drawing.Size(14, 15);
            this.lblCantVentas.TabIndex = 1;
            this.lblCantVentas.Text = "0";
            //
            // lblUnidadesTit
            //
            this.lblUnidadesTit.AutoSize = true;
            this.lblUnidadesTit.Location = new System.Drawing.Point(230, 22);
            this.lblUnidadesTit.Name = "lblUnidadesTit";
            this.lblUnidadesTit.Size = new System.Drawing.Size(93, 13);
            this.lblUnidadesTit.TabIndex = 2;
            this.lblUnidadesTit.Text = "Unidades vendidas";
            //
            // lblUnidades
            //
            this.lblUnidades.AutoSize = true;
            this.lblUnidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblUnidades.Location = new System.Drawing.Point(230, 44);
            this.lblUnidades.Name = "lblUnidades";
            this.lblUnidades.Size = new System.Drawing.Size(14, 15);
            this.lblUnidades.TabIndex = 3;
            this.lblUnidades.Text = "0";
            //
            // lblMontoTit
            //
            this.lblMontoTit.AutoSize = true;
            this.lblMontoTit.Location = new System.Drawing.Point(445, 22);
            this.lblMontoTit.Name = "lblMontoTit";
            this.lblMontoTit.Size = new System.Drawing.Size(66, 13);
            this.lblMontoTit.TabIndex = 4;
            this.lblMontoTit.Text = "Monto total";
            //
            // lblMonto
            //
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblMonto.Location = new System.Drawing.Point(445, 44);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(40, 15);
            this.lblMonto.TabIndex = 5;
            this.lblMonto.Text = "$ 0,00";
            //
            // lblTicketTit
            //
            this.lblTicketTit.AutoSize = true;
            this.lblTicketTit.Location = new System.Drawing.Point(660, 22);
            this.lblTicketTit.Name = "lblTicketTit";
            this.lblTicketTit.Size = new System.Drawing.Size(83, 13);
            this.lblTicketTit.TabIndex = 6;
            this.lblTicketTit.Text = "Ticket promedio";
            //
            // lblTicket
            //
            this.lblTicket.AutoSize = true;
            this.lblTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblTicket.Location = new System.Drawing.Point(660, 44);
            this.lblTicket.Name = "lblTicket";
            this.lblTicket.Size = new System.Drawing.Size(40, 15);
            this.lblTicket.TabIndex = 7;
            this.lblTicket.Text = "$ 0,00";
            //
            // lblVentasDia
            //
            this.lblVentasDia.AutoSize = true;
            this.lblVentasDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblVentasDia.Location = new System.Drawing.Point(20, 213);
            this.lblVentasDia.Name = "lblVentasDia";
            this.lblVentasDia.Size = new System.Drawing.Size(86, 15);
            this.lblVentasDia.TabIndex = 5;
            this.lblVentasDia.Text = "Ventas por dia";
            //
            // dgvDias
            //
            this.dgvDias.AllowUserToAddRows = false;
            this.dgvDias.AllowUserToDeleteRows = false;
            this.dgvDias.AllowUserToResizeRows = false;
            this.dgvDias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDias.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvDias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDias.ColumnHeadersHeight = 32;
            this.dgvDias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDias.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDias.EnableHeadersVisualStyles = false;
            this.dgvDias.Location = new System.Drawing.Point(20, 233);
            this.dgvDias.MultiSelect = false;
            this.dgvDias.Name = "dgvDias";
            this.dgvDias.ReadOnly = true;
            this.dgvDias.RowHeadersVisible = false;
            this.dgvDias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDias.Size = new System.Drawing.Size(420, 220);
            this.dgvDias.TabIndex = 6;
            //
            // lblTotal
            //
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(20, 458);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(420, 18);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Total: $ 0,00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblTop
            //
            this.lblTop.AutoSize = true;
            this.lblTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTop.Location = new System.Drawing.Point(460, 213);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(196, 15);
            this.lblTop.TabIndex = 8;
            this.lblTop.Text = "Productos mas vendidos (Top 10)";
            //
            // dgvTop
            //
            this.dgvTop.AllowUserToAddRows = false;
            this.dgvTop.AllowUserToDeleteRows = false;
            this.dgvTop.AllowUserToResizeRows = false;
            this.dgvTop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvTop.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTop.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTop.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvTop.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTop.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTop.ColumnHeadersHeight = 32;
            this.dgvTop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvTop.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTop.EnableHeadersVisualStyles = false;
            this.dgvTop.Location = new System.Drawing.Point(460, 233);
            this.dgvTop.MultiSelect = false;
            this.dgvTop.Name = "dgvTop";
            this.dgvTop.ReadOnly = true;
            this.dgvTop.RowHeadersVisible = false;
            this.dgvTop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTop.Size = new System.Drawing.Size(420, 220);
            this.dgvTop.TabIndex = 9;
            //
            // lblError
            //
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(20, 495);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(600, 32);
            this.lblError.TabIndex = 10;
            //
            // btnExportar
            //
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.Enabled = false;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExportar.Location = new System.Drawing.Point(640, 496);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(130, 29);
            this.btnExportar.TabIndex = 11;
            this.btnExportar.Text = "Exportar a PDF";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click_883SC);
            //
            // btnSalir
            //
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSalir.Location = new System.Drawing.Point(785, 496);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(95, 29);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_883SC);
            //
            // frmReporteVentas_883SC
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(924, 582);
            this.Controls.Add(this.pReporte);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.MinimumSize = new System.Drawing.Size(924, 582);
            this.Name = "frmReporteVentas_883SC";
            this.Text = "Reporte de Ventas";
            this.Load += new System.EventHandler(this.frmReporteVentas_Load_883SC);
            this.pReporte.ResumeLayout(false);
            this.pReporte.PerformLayout();
            this.gbPeriodo.ResumeLayout(false);
            this.gbPeriodo.PerformLayout();
            this.gbResumen.ResumeLayout(false);
            this.gbResumen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pReporte;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbPeriodo;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox gbResumen;
        private System.Windows.Forms.Label lblCantVentasTit;
        private System.Windows.Forms.Label lblCantVentas;
        private System.Windows.Forms.Label lblUnidadesTit;
        private System.Windows.Forms.Label lblUnidades;
        private System.Windows.Forms.Label lblMontoTit;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblTicketTit;
        private System.Windows.Forms.Label lblTicket;
        private System.Windows.Forms.Label lblVentasDia;
        private System.Windows.Forms.DataGridView dgvDias;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.DataGridView dgvTop;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnSalir;
    }
}
