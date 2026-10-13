namespace TP_SanchezVillaverde
{
    partial class frmRealizarCobro_883SC
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblMontoValor = new System.Windows.Forms.Label();
            this.grpMetodo = new System.Windows.Forms.GroupBox();
            this.grpTarjeta = new System.Windows.Forms.GroupBox();
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblTitular = new System.Windows.Forms.Label();
            this.txtTitular = new System.Windows.Forms.TextBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblVencimiento = new System.Windows.Forms.Label();
            this.txtVencimiento = new System.Windows.Forms.TextBox();
            this.lblCvv = new System.Windows.Forms.Label();
            this.txtCvv = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpTarjeta.SuspendLayout();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(0, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(325, 26);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Realizar Cobro";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblMonto
            //
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblMonto.Location = new System.Drawing.Point(25, 58);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(48, 15);
            this.lblMonto.TabIndex = 1;
            this.lblMonto.Text = "Monto:";
            //
            // lblMontoValor
            //
            this.lblMontoValor.AutoSize = true;
            this.lblMontoValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblMontoValor.Location = new System.Drawing.Point(110, 58);
            this.lblMontoValor.Name = "lblMontoValor";
            this.lblMontoValor.Size = new System.Drawing.Size(0, 15);
            this.lblMontoValor.TabIndex = 2;
            //
            // grpMetodo
            //
            this.grpMetodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grpMetodo.Location = new System.Drawing.Point(25, 88);
            this.grpMetodo.Name = "grpMetodo";
            this.grpMetodo.Size = new System.Drawing.Size(275, 135);
            this.grpMetodo.TabIndex = 3;
            this.grpMetodo.TabStop = false;
            this.grpMetodo.Text = "Metodo de pago";
            //
            // grpTarjeta
            //
            this.grpTarjeta.Controls.Add(this.lblNumero);
            this.grpTarjeta.Controls.Add(this.txtNumero);
            this.grpTarjeta.Controls.Add(this.lblTitular);
            this.grpTarjeta.Controls.Add(this.txtTitular);
            this.grpTarjeta.Controls.Add(this.lblDni);
            this.grpTarjeta.Controls.Add(this.txtDni);
            this.grpTarjeta.Controls.Add(this.lblVencimiento);
            this.grpTarjeta.Controls.Add(this.txtVencimiento);
            this.grpTarjeta.Controls.Add(this.lblCvv);
            this.grpTarjeta.Controls.Add(this.txtCvv);
            this.grpTarjeta.Enabled = false;
            this.grpTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grpTarjeta.Location = new System.Drawing.Point(25, 233);
            this.grpTarjeta.Name = "grpTarjeta";
            this.grpTarjeta.Size = new System.Drawing.Size(275, 192);
            this.grpTarjeta.TabIndex = 4;
            this.grpTarjeta.TabStop = false;
            this.grpTarjeta.Text = "Datos de la tarjeta";
            //
            // lblNumero
            //
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(12, 30);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(58, 15);
            this.lblNumero.TabIndex = 0;
            this.lblNumero.Text = "Numero:";
            //
            // txtNumero
            //
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtNumero.Location = new System.Drawing.Point(140, 27);
            this.txtNumero.MaxLength = 19;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(120, 21);
            this.txtNumero.TabIndex = 1;
            //
            // lblTitular
            //
            this.lblTitular.AutoSize = true;
            this.lblTitular.Location = new System.Drawing.Point(12, 62);
            this.lblTitular.Name = "lblTitular";
            this.lblTitular.Size = new System.Drawing.Size(97, 15);
            this.lblTitular.TabIndex = 2;
            this.lblTitular.Text = "Nombre y apellido:";
            //
            // txtTitular
            //
            this.txtTitular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTitular.Location = new System.Drawing.Point(140, 59);
            this.txtTitular.MaxLength = 50;
            this.txtTitular.Name = "txtTitular";
            this.txtTitular.Size = new System.Drawing.Size(120, 21);
            this.txtTitular.TabIndex = 3;
            //
            // lblDni
            //
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(12, 94);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(80, 15);
            this.lblDni.TabIndex = 4;
            this.lblDni.Text = "DNI del titular:";
            //
            // txtDni
            //
            this.txtDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtDni.Location = new System.Drawing.Point(140, 91);
            this.txtDni.MaxLength = 9;
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(120, 21);
            this.txtDni.TabIndex = 5;
            //
            // lblVencimiento
            //
            this.lblVencimiento.AutoSize = true;
            this.lblVencimiento.Location = new System.Drawing.Point(12, 126);
            this.lblVencimiento.Name = "lblVencimiento";
            this.lblVencimiento.Size = new System.Drawing.Size(97, 15);
            this.lblVencimiento.TabIndex = 6;
            this.lblVencimiento.Text = "Vencimiento:";
            //
            // txtVencimiento
            //
            this.txtVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtVencimiento.Location = new System.Drawing.Point(140, 123);
            this.txtVencimiento.MaxLength = 5;
            this.txtVencimiento.Name = "txtVencimiento";
            this.txtVencimiento.Size = new System.Drawing.Size(60, 21);
            this.txtVencimiento.TabIndex = 7;
            //
            // lblCvv
            //
            this.lblCvv.AutoSize = true;
            this.lblCvv.Location = new System.Drawing.Point(12, 158);
            this.lblCvv.Name = "lblCvv";
            this.lblCvv.Size = new System.Drawing.Size(36, 15);
            this.lblCvv.TabIndex = 8;
            this.lblCvv.Text = "CVV:";
            //
            // txtCvv
            //
            this.txtCvv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtCvv.Location = new System.Drawing.Point(140, 155);
            this.txtCvv.MaxLength = 4;
            this.txtCvv.Name = "txtCvv";
            this.txtCvv.Size = new System.Drawing.Size(60, 21);
            this.txtCvv.TabIndex = 9;
            this.txtCvv.UseSystemPasswordChar = true;
            //
            // btnConfirmar
            //
            this.btnConfirmar.BackColor = System.Drawing.Color.Gray;
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnConfirmar.Location = new System.Drawing.Point(58, 444);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(105, 29);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Text = "Confirmar Pago";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click_883SC);
            //
            // btnCancelar
            //
            this.btnCancelar.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(175, 444);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(92, 29);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_883SC);
            //
            // frmRealizarCobro
            //
            this.AcceptButton = this.btnConfirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(325, 497);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.grpTarjeta);
            this.Controls.Add(this.grpMetodo);
            this.Controls.Add(this.lblMontoValor);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmRealizarCobro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Realizar Cobro";
            this.Load += new System.EventHandler(this.frmRealizarCobro_Load_883SC);
            this.grpTarjeta.ResumeLayout(false);
            this.grpTarjeta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblMontoValor;
        private System.Windows.Forms.GroupBox grpMetodo;
        private System.Windows.Forms.GroupBox grpTarjeta;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblTitular;
        private System.Windows.Forms.TextBox txtTitular;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblVencimiento;
        private System.Windows.Forms.TextBox txtVencimiento;
        private System.Windows.Forms.Label lblCvv;
        private System.Windows.Forms.TextBox txtCvv;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
