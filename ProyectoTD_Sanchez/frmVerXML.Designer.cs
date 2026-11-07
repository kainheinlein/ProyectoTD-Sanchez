namespace TP_SanchezVillaverde
{
    partial class frmVerXML_883SC
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
            this.txtContenido = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // txtContenido
            //
            this.txtContenido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContenido.BackColor = System.Drawing.Color.White;
            this.txtContenido.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtContenido.Location = new System.Drawing.Point(12, 12);
            this.txtContenido.Multiline = true;
            this.txtContenido.Name = "txtContenido";
            this.txtContenido.ReadOnly = true;
            this.txtContenido.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContenido.Size = new System.Drawing.Size(660, 360);
            this.txtContenido.TabIndex = 0;
            this.txtContenido.WordWrap = false;
            //
            // btnCerrar
            //
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnCerrar.Location = new System.Drawing.Point(554, 382);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(118, 29);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Salir";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click_883SC);
            //
            // frmVerXML_883SC
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(684, 423);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.txtContenido);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVerXML";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contenido del archivo XML";
            this.Load += new System.EventHandler(this.frmVerXML_Load_883SC);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtContenido;
        private System.Windows.Forms.Button btnCerrar;
    }
}
