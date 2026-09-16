using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmRealizarCobro_883SC : Form, IObservadorIdioma_883SC
    {
        public frmRealizarCobro_883SC(decimal monto)
        {
            InitializeComponent();
            montoCobro_883SC = monto;
            lblMontoValor.Text = monto.ToString("C");
        }

        CobroBLL_883SC cobroBLL_883SC = new CobroBLL_883SC();
        MetodoPagoBLL_883SC metodoPagoBLL_883SC = new MetodoPagoBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        //El monto llega calculado por quien invoca la pantalla (CUN-004)
        private decimal montoCobro_883SC;

        //Null si el metodo no requiere validacion bancaria (Efectivo/Transferencia)
        private string _codigoAutorizacion_883SC;
        public string CodigoAutorizacion_883SC
        {
            get { return _codigoAutorizacion_883SC; }
        }

        private void frmRealizarCobro_Load_883SC(object sender, EventArgs e)
        {
            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmRealizarCobro_FormClosed_883SC;

            try
            {
                CargarMetodos_883SC(metodoPagoBLL_883SC.ListarMetodos_883SC());
            }
            catch (Exception ex)
            {
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("COMUN_ERROR_BD") + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmRealizarCobro_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = gestorIdioma_883SC.Traducir_883SC("COBRO_TITULO");
            lblTitulo.Text = gestorIdioma_883SC.Traducir_883SC("COBRO_TITULO");
            lblMonto.Text = gestorIdioma_883SC.Traducir_883SC("COBRO_LBL_MONTO");
            grpMetodo.Text = gestorIdioma_883SC.Traducir_883SC("COBRO_GRP_METODO");
            grpTarjeta.Text = gestorIdioma_883SC.Traducir_883SC("COBRO_GRP_TARJETA");
            lblNumero.Text = gestorIdioma_883SC.Traducir_883SC("COBRO_LBL_NUMERO");
            lblTitular.Text = gestorIdioma_883SC.Traducir_883SC("COBRO_LBL_TITULAR");
            lblDni.Text = gestorIdioma_883SC.Traducir_883SC("COBRO_LBL_DNI");
            lblVencimiento.Text = gestorIdioma_883SC.Traducir_883SC("COBRO_LBL_VENCIMIENTO");
            lblCvv.Text = gestorIdioma_883SC.Traducir_883SC("COBRO_LBL_CVV");
            btnConfirmar.Text = gestorIdioma_883SC.Traducir_883SC("COBRO_BTN_CONFIRMAR");
            btnCancelar.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_CANCELAR");
        }

        #endregion

        private void CargarMetodos_883SC(List<MetodoPagoBE_883SC> metodos)
        {
            grpMetodo.Controls.Clear();
            int y = 25;
            foreach (MetodoPagoBE_883SC metodo in metodos)
            {
                //Cada radio guarda su metodo en Tag para recuperarlo al confirmar
                RadioButton rb = new RadioButton();
                rb.AutoSize = true;
                rb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
                rb.Location = new System.Drawing.Point(15, y);
                rb.Text = metodo.Nombre_883SC;
                rb.Tag = metodo;
                rb.CheckedChanged += rbMetodo_CheckedChanged_883SC;
                grpMetodo.Controls.Add(rb);
                y += 26;
            }
        }

        private void rbMetodo_CheckedChanged_883SC(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (!rb.Checked) { return; }

            MetodoPagoBE_883SC metodoSeleccionado = (MetodoPagoBE_883SC)rb.Tag;
            bool conTarjeta = metodoSeleccionado.RequiereDatosTarjeta_883SC;
            grpTarjeta.Enabled = conTarjeta;
            if (!conTarjeta) { LimpiarDatosTarjeta_883SC(); }
        }

        private void LimpiarDatosTarjeta_883SC()
        {
            txtNumero.Text = "";
            txtTitular.Text = "";
            txtDni.Text = "";
            txtVencimiento.Text = "";
            txtCvv.Text = "";
        }

        private MetodoPagoBE_883SC MetodoSeleccionado_883SC()
        {
            foreach (Control control in grpMetodo.Controls)
            {
                RadioButton rb = control as RadioButton;
                if (rb != null && rb.Checked) { return (MetodoPagoBE_883SC)rb.Tag; }
            }
            return null;
        }

        private void btnConfirmar_Click_883SC(object sender, EventArgs e)
        {
            MetodoPagoBE_883SC metodoPago = MetodoSeleccionado_883SC();
            if (metodoPago == null)
            {
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("COBRO_MSG_SIN_METODO"), gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Sin tarjeta no hay datos de pago que enviar: la lista va vacia
            List<string> datos = new List<string>();
            if (metodoPago.RequiereDatosTarjeta_883SC)
            {
                try
                {
                    cobroBLL_883SC.ValidarDatosTarjeta_883SC(txtNumero.Text.Trim(), txtTitular.Text.Trim(),
                        txtDni.Text.Trim(), txtVencimiento.Text.Trim(), txtCvv.Text.Trim());
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Orden fijo: numero, titular, DNI del titular, vencimiento, CVV
                datos.Add(txtNumero.Text.Trim());
                datos.Add(txtTitular.Text.Trim());
                datos.Add(txtDni.Text.Trim());
                datos.Add(txtVencimiento.Text.Trim());
                datos.Add(txtCvv.Text.Trim());
            }

            try
            {
                //El delegado es la unica via por la que la BLL "consulta" a la entidad bancaria simulada
                _codigoAutorizacion_883SC = cobroBLL_883SC.Cobrar_883SC(metodoPago, montoCobro_883SC, datos,
                    (m) => MessageBox.Show($"¿Aprobar el pago de {m:C}?", "Simulación Entidad Bancaria",
                        MessageBoxButtons.YesNo) == DialogResult.Yes);

                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("COBRO_MSG_AUTORIZADO"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (PagoRechazadoException_883SC)
            {
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("COBRO_MSG_RECHAZADO"), gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click_883SC(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
