namespace TP_SanchezVillaverde
{
    partial class frmBackup_883SC
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
            this.pBackup = new System.Windows.Forms.Panel();
            this.lblHuerfanos = new System.Windows.Forms.Label();
            this.lblFaltantes = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnRealizar = new System.Windows.Forms.Button();
            this.dgvBackups = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pBackup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).BeginInit();
            this.SuspendLayout();
            //
            // pBackup
            //
            this.pBackup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pBackup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pBackup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBackup.Controls.Add(this.lblHuerfanos);
            this.pBackup.Controls.Add(this.lblFaltantes);
            this.pBackup.Controls.Add(this.btnSalir);
            this.pBackup.Controls.Add(this.btnVerificar);
            this.pBackup.Controls.Add(this.btnEliminar);
            this.pBackup.Controls.Add(this.btnRealizar);
            this.pBackup.Controls.Add(this.dgvBackups);
            this.pBackup.Controls.Add(this.lblTitulo);
            this.pBackup.Location = new System.Drawing.Point(12, 12);
            this.pBackup.Name = "pBackup";
            this.pBackup.Size = new System.Drawing.Size(560, 470);
            this.pBackup.TabIndex = 0;
            //
            // lblHuerfanos
            //
            this.lblHuerfanos.AutoSize = true;
            this.lblHuerfanos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblHuerfanos.Location = new System.Drawing.Point(200, 358);
            this.lblHuerfanos.Name = "lblHuerfanos";
            this.lblHuerfanos.Size = new System.Drawing.Size(0, 13);
            this.lblHuerfanos.TabIndex = 7;
            //
            // lblFaltantes
            //
            this.lblFaltantes.AutoSize = true;
            this.lblFaltantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFaltantes.Location = new System.Drawing.Point(12, 358);
            this.lblFaltantes.Name = "lblFaltantes";
            this.lblFaltantes.Size = new System.Drawing.Size(0, 13);
            this.lblFaltantes.TabIndex = 6;
            //
            // btnSalir
            //
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalir.Location = new System.Drawing.Point(448, 392);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(98, 38);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_883SC);
            //
            // btnVerificar
            //
            this.btnVerificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnVerificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnVerificar.Location = new System.Drawing.Point(290, 392);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(148, 38);
            this.btnVerificar.TabIndex = 4;
            this.btnVerificar.Text = "Verificar archivos";
            this.btnVerificar.UseVisualStyleBackColor = false;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click_883SC);
            //
            // btnEliminar
            //
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.Location = new System.Drawing.Point(172, 392);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(108, 38);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_883SC);
            //
            // btnRealizar
            //
            this.btnRealizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRealizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRealizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnRealizar.Location = new System.Drawing.Point(12, 392);
            this.btnRealizar.Name = "btnRealizar";
            this.btnRealizar.Size = new System.Drawing.Size(150, 38);
            this.btnRealizar.TabIndex = 2;
            this.btnRealizar.Text = "Realizar backup";
            this.btnRealizar.UseVisualStyleBackColor = false;
            this.btnRealizar.Click += new System.EventHandler(this.btnRealizar_Click_883SC);
            //
            // dgvBackups
            //
            this.dgvBackups.AllowUserToAddRows = false;
            this.dgvBackups.AllowUserToDeleteRows = false;
            this.dgvBackups.AllowUserToResizeRows = false;
            this.dgvBackups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBackups.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvBackups.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBackups.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBackups.ColumnHeadersHeight = 40;
            this.dgvBackups.EnableHeadersVisualStyles = false;
            this.dgvBackups.Location = new System.Drawing.Point(12, 48);
            this.dgvBackups.MultiSelect = false;
            this.dgvBackups.Name = "dgvBackups";
            this.dgvBackups.ReadOnly = true;
            this.dgvBackups.RowHeadersVisible = false;
            this.dgvBackups.RowHeadersWidth = 51;
            this.dgvBackups.RowTemplate.Height = 24;
            this.dgvBackups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBackups.Size = new System.Drawing.Size(534, 300);
            this.dgvBackups.TabIndex = 1;
            //
            // lblTitulo
            //
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Verdana", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblTitulo.Location = new System.Drawing.Point(222, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(105, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "BACKUP";
            //
            // frmBackup_883SC
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(584, 494);
            this.Controls.Add(this.pBackup);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmBackup_883SC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Gestion de Backup";
            this.Load += new System.EventHandler(this.frmBackup_Load_883SC);
            this.pBackup.ResumeLayout(false);
            this.pBackup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBackup;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvBackups;
        private System.Windows.Forms.Button btnRealizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblFaltantes;
        private System.Windows.Forms.Label lblHuerfanos;
    }
}
