namespace TP_SanchezVillaverde
{
    partial class frmCargaDatosPrueba_883SC
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
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(0, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(500, 26);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Cargando datos de prueba...";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblEtapa
            //
            this.lblEtapa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblEtapa.Location = new System.Drawing.Point(20, 80);
            this.lblEtapa.Name = "lblEtapa";
            this.lblEtapa.Size = new System.Drawing.Size(460, 18);
            this.lblEtapa.TabIndex = 1;
            this.lblEtapa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // barra
            //
            this.barra.Location = new System.Drawing.Point(80, 115);
            this.barra.MarqueeAnimationSpeed = 30;
            this.barra.Name = "barra";
            this.barra.Size = new System.Drawing.Size(340, 14);
            this.barra.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.barra.TabIndex = 2;
            //
            // txtResultado
            //
            this.txtResultado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtResultado.Location = new System.Drawing.Point(20, 60);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultado.Size = new System.Drawing.Size(460, 200);
            this.txtResultado.TabIndex = 3;
            this.txtResultado.Visible = false;
            //
            // btnCerrar
            //
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCerrar.Enabled = false;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.Location = new System.Drawing.Point(190, 275);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 30);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Salir";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click_883SC);
            //
            // frmCargaDatosPrueba_883SC
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(500, 320);
            this.ControlBox = false;
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.barra);
            this.Controls.Add(this.lblEtapa);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCargaDatosPrueba_883SC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargar datos de prueba";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCargaDatosPrueba_FormClosing_883SC);
            this.Load += new System.EventHandler(this.frmCargaDatosPrueba_Load_883SC);
            this.Shown += new System.EventHandler(this.frmCargaDatosPrueba_Shown_883SC);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEtapa;
        private System.Windows.Forms.ProgressBar barra;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Button btnCerrar;
    }
}
