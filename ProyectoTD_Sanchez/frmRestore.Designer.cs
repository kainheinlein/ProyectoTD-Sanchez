namespace TP_SanchezVillaverde
{
    partial class frmRestore_883SC
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
            this.pRestore = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.lblAviso = new System.Windows.Forms.Label();
            this.dgvBackups = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pRestore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).BeginInit();
            this.SuspendLayout();
            //
            // pRestore
            //
            this.pRestore.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pRestore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRestore.Controls.Add(this.btnCancelar);
            this.pRestore.Controls.Add(this.btnRestaurar);
            this.pRestore.Controls.Add(this.lblAviso);
            this.pRestore.Controls.Add(this.dgvBackups);
            this.pRestore.Controls.Add(this.lblTitulo);
            this.pRestore.Location = new System.Drawing.Point(8, 8);
            this.pRestore.Name = "pRestore";
            this.pRestore.Size = new System.Drawing.Size(544, 404);
            this.pRestore.TabIndex = 0;
            //
            // btnCancelar
            //
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.Location = new System.Drawing.Point(290, 350);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 38);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_883SC);
            //
            // btnRestaurar
            //
            this.btnRestaurar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnRestaurar.Location = new System.Drawing.Point(134, 350);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(120, 38);
            this.btnRestaurar.TabIndex = 3;
            this.btnRestaurar.Text = "Restaurar";
            this.btnRestaurar.UseVisualStyleBackColor = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click_883SC);
            //
            // lblAviso
            //
            this.lblAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblAviso.ForeColor = System.Drawing.Color.Red;
            this.lblAviso.Location = new System.Drawing.Point(12, 288);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(518, 48);
            this.lblAviso.TabIndex = 2;
            this.lblAviso.Text = "Aviso";
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
            this.dgvBackups.Size = new System.Drawing.Size(518, 230);
            this.dgvBackups.TabIndex = 1;
            //
            // lblTitulo
            //
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Verdana", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblTitulo.Location = new System.Drawing.Point(208, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(114, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "RESTORE";
            //
            // frmRestore_883SC
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(560, 420);
            this.Controls.Add(this.pRestore);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmRestore_883SC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restaurar Backup";
            this.Load += new System.EventHandler(this.frmRestore_Load_883SC);
            this.pRestore.ResumeLayout(false);
            this.pRestore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pRestore;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvBackups;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
