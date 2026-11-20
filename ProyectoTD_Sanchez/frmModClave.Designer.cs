namespace TP_SanchezVillaverde
{
    partial class frmModClave_883SC
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
            this.txtActual = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.txtClaveRep = new System.Windows.Forms.TextBox();
            this.lblActual = new System.Windows.Forms.Label();
            this.lblNuevo = new System.Windows.Forms.Label();
            this.lblRep = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblInstrucciones = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtActual
            // 
            this.txtActual.Location = new System.Drawing.Point(23, 89);
            this.txtActual.Name = "txtActual";
            this.txtActual.Size = new System.Drawing.Size(189, 20);
            this.txtActual.TabIndex = 0;
            this.txtActual.UseSystemPasswordChar = true;
            this.txtActual.TextChanged += new System.EventHandler(this.txtActual_TextChanged_883SC);
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(23, 167);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(189, 20);
            this.txtClave.TabIndex = 1;
            this.txtClave.UseSystemPasswordChar = true;
            this.txtClave.Visible = false;
            this.txtClave.TextChanged += new System.EventHandler(this.txtClave_TextChanged_883SC);
            // 
            // txtClaveRep
            // 
            this.txtClaveRep.Location = new System.Drawing.Point(23, 218);
            this.txtClaveRep.Name = "txtClaveRep";
            this.txtClaveRep.Size = new System.Drawing.Size(189, 20);
            this.txtClaveRep.TabIndex = 2;
            this.txtClaveRep.UseSystemPasswordChar = true;
            this.txtClaveRep.Visible = false;
            this.txtClaveRep.TextChanged += new System.EventHandler(this.txtClaveRep_TextChanged_883SC);
            // 
            // lblActual
            // 
            this.lblActual.AutoSize = true;
            this.lblActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblActual.Location = new System.Drawing.Point(66, 78);
            this.lblActual.Name = "lblActual";
            this.lblActual.Size = new System.Drawing.Size(111, 13);
            this.lblActual.TabIndex = 3;
            this.lblActual.Text = "Contraseña Actual";
            this.lblActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNuevo
            // 
            this.lblNuevo.AutoSize = true;
            this.lblNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNuevo.Location = new System.Drawing.Point(63, 154);
            this.lblNuevo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNuevo.Name = "lblNuevo";
            this.lblNuevo.Size = new System.Drawing.Size(112, 13);
            this.lblNuevo.TabIndex = 4;
            this.lblNuevo.Text = "Nueva Contraseña";
            this.lblNuevo.Visible = false;
            // 
            // lblRep
            // 
            this.lblRep.AutoSize = true;
            this.lblRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblRep.Location = new System.Drawing.Point(62, 204);
            this.lblRep.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRep.Name = "lblRep";
            this.lblRep.Size = new System.Drawing.Size(116, 13);
            this.lblRep.TabIndex = 5;
            this.lblRep.Text = "Repetir Contraseña";
            this.lblRep.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Enabled = false;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Location = new System.Drawing.Point(76, 112);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Confirmar";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_883SC);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.Location = new System.Drawing.Point(74, 295);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 32);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Visible = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click_883SC);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(74, 333);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_883SC);
            // 
            // lblInstrucciones
            // 
            this.lblInstrucciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstrucciones.Location = new System.Drawing.Point(14, 9);
            this.lblInstrucciones.Name = "lblInstrucciones";
            this.lblInstrucciones.Size = new System.Drawing.Size(206, 46);
            this.lblInstrucciones.TabIndex = 9;
            this.lblInstrucciones.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(9, 251);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(216, 41);
            this.lblError.TabIndex = 10;
            // 
            // frmModClave_883SC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 377);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblInstrucciones);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblRep);
            this.Controls.Add(this.lblNuevo);
            this.Controls.Add(this.lblActual);
            this.Controls.Add(this.txtClaveRep);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.txtActual);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModClave_883SC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar Contraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtActual;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtClaveRep;
        private System.Windows.Forms.Label lblActual;
        private System.Windows.Forms.Label lblNuevo;
        private System.Windows.Forms.Label lblRep;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblInstrucciones;
        private System.Windows.Forms.Label lblError;
    }
}