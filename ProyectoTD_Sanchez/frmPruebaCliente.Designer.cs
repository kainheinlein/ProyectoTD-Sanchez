// TEMPORAL: borrar cuando exista CUN-004 Generar Factura
namespace TP_SanchezVillaverde
{
    partial class frmPruebaCliente_883SC
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
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.lblDniTit = new System.Windows.Forms.Label();
            this.lblResDni = new System.Windows.Forms.Label();
            this.lblNombreTit = new System.Windows.Forms.Label();
            this.lblResNombre = new System.Windows.Forms.Label();
            this.lblApellidoTit = new System.Windows.Forms.Label();
            this.lblResApellido = new System.Windows.Forms.Label();
            this.lblDireccionTit = new System.Windows.Forms.Label();
            this.lblResDireccion = new System.Windows.Forms.Label();
            this.lblTelefonoTit = new System.Windows.Forms.Label();
            this.lblResTelefono = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btnProbarCobro = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.grpDatos.SuspendLayout();
            this.SuspendLayout();
            //
            // lblDni
            //
            this.lblDni.AutoSize = true;
            this.lblDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblDni.Location = new System.Drawing.Point(15, 20);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(34, 15);
            this.lblDni.TabIndex = 0;
            this.lblDni.Text = "DNI:";
            //
            // txtDni
            //
            this.txtDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtDni.Location = new System.Drawing.Point(60, 17);
            this.txtDni.MaxLength = 9;
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(180, 23);
            this.txtDni.TabIndex = 1;
            //
            // btnBuscar
            //
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnBuscar.Location = new System.Drawing.Point(260, 15);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 29);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_883SC);
            //
            // grpDatos
            //
            this.grpDatos.Controls.Add(this.lblDniTit);
            this.grpDatos.Controls.Add(this.lblResDni);
            this.grpDatos.Controls.Add(this.lblNombreTit);
            this.grpDatos.Controls.Add(this.lblResNombre);
            this.grpDatos.Controls.Add(this.lblApellidoTit);
            this.grpDatos.Controls.Add(this.lblResApellido);
            this.grpDatos.Controls.Add(this.lblDireccionTit);
            this.grpDatos.Controls.Add(this.lblResDireccion);
            this.grpDatos.Controls.Add(this.lblTelefonoTit);
            this.grpDatos.Controls.Add(this.lblResTelefono);
            this.grpDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grpDatos.Location = new System.Drawing.Point(15, 60);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(355, 175);
            this.grpDatos.TabIndex = 3;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Datos del cliente";
            //
            // lblDniTit
            //
            this.lblDniTit.AutoSize = true;
            this.lblDniTit.Location = new System.Drawing.Point(15, 28);
            this.lblDniTit.Name = "lblDniTit";
            this.lblDniTit.Size = new System.Drawing.Size(34, 15);
            this.lblDniTit.TabIndex = 0;
            this.lblDniTit.Text = "DNI:";
            //
            // lblResDni
            //
            this.lblResDni.AutoSize = true;
            this.lblResDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblResDni.Location = new System.Drawing.Point(110, 28);
            this.lblResDni.Name = "lblResDni";
            this.lblResDni.Size = new System.Drawing.Size(0, 15);
            this.lblResDni.TabIndex = 1;
            //
            // lblNombreTit
            //
            this.lblNombreTit.AutoSize = true;
            this.lblNombreTit.Location = new System.Drawing.Point(15, 56);
            this.lblNombreTit.Name = "lblNombreTit";
            this.lblNombreTit.Size = new System.Drawing.Size(58, 15);
            this.lblNombreTit.TabIndex = 2;
            this.lblNombreTit.Text = "Nombre:";
            //
            // lblResNombre
            //
            this.lblResNombre.AutoSize = true;
            this.lblResNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblResNombre.Location = new System.Drawing.Point(110, 56);
            this.lblResNombre.Name = "lblResNombre";
            this.lblResNombre.Size = new System.Drawing.Size(0, 15);
            this.lblResNombre.TabIndex = 3;
            //
            // lblApellidoTit
            //
            this.lblApellidoTit.AutoSize = true;
            this.lblApellidoTit.Location = new System.Drawing.Point(15, 84);
            this.lblApellidoTit.Name = "lblApellidoTit";
            this.lblApellidoTit.Size = new System.Drawing.Size(63, 15);
            this.lblApellidoTit.TabIndex = 4;
            this.lblApellidoTit.Text = "Apellido:";
            //
            // lblResApellido
            //
            this.lblResApellido.AutoSize = true;
            this.lblResApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblResApellido.Location = new System.Drawing.Point(110, 84);
            this.lblResApellido.Name = "lblResApellido";
            this.lblResApellido.Size = new System.Drawing.Size(0, 15);
            this.lblResApellido.TabIndex = 5;
            //
            // lblDireccionTit
            //
            this.lblDireccionTit.AutoSize = true;
            this.lblDireccionTit.Location = new System.Drawing.Point(15, 112);
            this.lblDireccionTit.Name = "lblDireccionTit";
            this.lblDireccionTit.Size = new System.Drawing.Size(71, 15);
            this.lblDireccionTit.TabIndex = 6;
            this.lblDireccionTit.Text = "Direccion:";
            //
            // lblResDireccion
            //
            this.lblResDireccion.AutoSize = true;
            this.lblResDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblResDireccion.Location = new System.Drawing.Point(110, 112);
            this.lblResDireccion.Name = "lblResDireccion";
            this.lblResDireccion.Size = new System.Drawing.Size(0, 15);
            this.lblResDireccion.TabIndex = 7;
            //
            // lblTelefonoTit
            //
            this.lblTelefonoTit.AutoSize = true;
            this.lblTelefonoTit.Location = new System.Drawing.Point(15, 140);
            this.lblTelefonoTit.Name = "lblTelefonoTit";
            this.lblTelefonoTit.Size = new System.Drawing.Size(66, 15);
            this.lblTelefonoTit.TabIndex = 8;
            this.lblTelefonoTit.Text = "Telefono:";
            //
            // lblResTelefono
            //
            this.lblResTelefono.AutoSize = true;
            this.lblResTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblResTelefono.Location = new System.Drawing.Point(110, 140);
            this.lblResTelefono.Name = "lblResTelefono";
            this.lblResTelefono.Size = new System.Drawing.Size(0, 15);
            this.lblResTelefono.TabIndex = 9;
            //
            // lblMonto
            //
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblMonto.Location = new System.Drawing.Point(15, 253);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(48, 15);
            this.lblMonto.TabIndex = 4;
            this.lblMonto.Text = "Monto:";
            //
            // txtMonto
            //
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtMonto.Location = new System.Drawing.Point(70, 250);
            this.txtMonto.MaxLength = 12;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(170, 23);
            this.txtMonto.TabIndex = 5;
            //
            // btnProbarCobro
            //
            this.btnProbarCobro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnProbarCobro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProbarCobro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProbarCobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnProbarCobro.Location = new System.Drawing.Point(260, 248);
            this.btnProbarCobro.Name = "btnProbarCobro";
            this.btnProbarCobro.Size = new System.Drawing.Size(110, 29);
            this.btnProbarCobro.TabIndex = 6;
            this.btnProbarCobro.Text = "Probar Cobro";
            this.btnProbarCobro.UseVisualStyleBackColor = false;
            this.btnProbarCobro.Click += new System.EventHandler(this.btnProbarCobro_Click_883SC);
            //
            // btnCerrar
            //
            this.btnCerrar.BackColor = System.Drawing.Color.LightCoral;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.Location = new System.Drawing.Point(260, 295);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(110, 29);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click_883SC);
            //
            // frmPruebaCliente
            //
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(390, 337);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnProbarCobro);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.lblDni);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPruebaCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TEMPORAL - Prueba Cliente";
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label lblDniTit;
        private System.Windows.Forms.Label lblResDni;
        private System.Windows.Forms.Label lblNombreTit;
        private System.Windows.Forms.Label lblResNombre;
        private System.Windows.Forms.Label lblApellidoTit;
        private System.Windows.Forms.Label lblResApellido;
        private System.Windows.Forms.Label lblDireccionTit;
        private System.Windows.Forms.Label lblResDireccion;
        private System.Windows.Forms.Label lblTelefonoTit;
        private System.Windows.Forms.Label lblResTelefono;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btnProbarCobro;
        private System.Windows.Forms.Button btnCerrar;
    }
}
