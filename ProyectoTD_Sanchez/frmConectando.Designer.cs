namespace TP_SanchezVillaverde
{
    partial class frmConectando_883SC
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblEtapa = new System.Windows.Forms.Label();
            this.barra = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(0, 24);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(325, 26);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Conectando...";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblEtapa
            //
            this.lblEtapa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblEtapa.Location = new System.Drawing.Point(15, 66);
            this.lblEtapa.Name = "lblEtapa";
            this.lblEtapa.Size = new System.Drawing.Size(295, 18);
            this.lblEtapa.TabIndex = 1;
            this.lblEtapa.Text = "Iniciando...";
            this.lblEtapa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // barra
            //
            this.barra.Location = new System.Drawing.Point(40, 100);
            this.barra.MarqueeAnimationSpeed = 30;
            this.barra.Name = "barra";
            this.barra.Size = new System.Drawing.Size(245, 14);
            this.barra.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.barra.TabIndex = 2;
            //
            // frmConectando_883SC
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(325, 140);
            this.ControlBox = false;
            this.Controls.Add(this.barra);
            this.Controls.Add(this.lblEtapa);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConectando_883SC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FerreSV";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEtapa;
        private System.Windows.Forms.ProgressBar barra;
    }
}
