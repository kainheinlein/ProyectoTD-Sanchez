namespace TP_SanchezVillaverde
{
    partial class frmAyuda_883SC
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
            this.pBotones = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.tvTemas = new System.Windows.Forms.TreeView();
            this.lblTemas = new System.Windows.Forms.Label();
            this.rtbContenido = new System.Windows.Forms.RichTextBox();
            this.pBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblTitulo.Size = new System.Drawing.Size(900, 44);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "AYUDA";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // pBotones
            //
            this.pBotones.Controls.Add(this.btnSalir);
            this.pBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pBotones.Location = new System.Drawing.Point(0, 560);
            this.pBotones.Name = "pBotones";
            this.pBotones.Size = new System.Drawing.Size(900, 44);
            this.pBotones.TabIndex = 2;
            //
            // btnSalir
            //
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Location = new System.Drawing.Point(788, 8);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 28);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_883SC);
            //
            // splitMain
            //
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 44);
            this.splitMain.Name = "splitMain";
            this.splitMain.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            //
            // splitMain.Panel1
            //
            this.splitMain.Panel1.Controls.Add(this.tvTemas);
            this.splitMain.Panel1.Controls.Add(this.lblTemas);
            this.splitMain.Panel1MinSize = 160;
            //
            // splitMain.Panel2
            //
            this.splitMain.Panel2.Controls.Add(this.rtbContenido);
            this.splitMain.Size = new System.Drawing.Size(900, 516);
            this.splitMain.SplitterDistance = 260;
            this.splitMain.TabIndex = 1;
            //
            // tvTemas
            //
            this.tvTemas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvTemas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTemas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tvTemas.FullRowSelect = true;
            this.tvTemas.HideSelection = false;
            this.tvTemas.ItemHeight = 22;
            this.tvTemas.Location = new System.Drawing.Point(0, 22);
            this.tvTemas.Name = "tvTemas";
            this.tvTemas.ShowLines = false;
            this.tvTemas.ShowRootLines = false;
            this.tvTemas.Size = new System.Drawing.Size(260, 494);
            this.tvTemas.TabIndex = 1;
            this.tvTemas.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTemas_AfterSelect_883SC);
            //
            // lblTemas
            //
            this.lblTemas.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTemas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTemas.Location = new System.Drawing.Point(0, 0);
            this.lblTemas.Name = "lblTemas";
            this.lblTemas.Size = new System.Drawing.Size(260, 22);
            this.lblTemas.TabIndex = 0;
            this.lblTemas.Text = "Temas";
            this.lblTemas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // rtbContenido
            //
            this.rtbContenido.BackColor = System.Drawing.Color.White;
            this.rtbContenido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbContenido.DetectUrls = false;
            this.rtbContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbContenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rtbContenido.Location = new System.Drawing.Point(0, 0);
            this.rtbContenido.Name = "rtbContenido";
            this.rtbContenido.ReadOnly = true;
            this.rtbContenido.Size = new System.Drawing.Size(624, 516);
            this.rtbContenido.TabIndex = 0;
            this.rtbContenido.Text = "";
            //
            // frmAyuda_883SC
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(900, 604);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pBotones);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.MinimumSize = new System.Drawing.Size(640, 400);
            this.Name = "frmAyuda_883SC";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ayuda en línea";
            this.Load += new System.EventHandler(this.frmAyuda_Load_883SC);
            this.pBotones.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pBotones;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.TreeView tvTemas;
        private System.Windows.Forms.Label lblTemas;
        private System.Windows.Forms.RichTextBox rtbContenido;
    }
}
