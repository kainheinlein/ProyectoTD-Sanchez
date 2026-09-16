using Negocio_BLL;
using Servicios;
using System;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmAltaClienteRapida_883SC : Form, IObservadorIdioma_883SC
    {
        public frmAltaClienteRapida_883SC(int dni)
        {
            InitializeComponent();
            dniCliente_883SC = dni;
            lblDniValor.Text = dni.ToString();
        }

        ClienteBLL_883SC clienteBLL_883SC = new ClienteBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        //El DNI llega ya conocido por quien invoca la pantalla: no se tipea aca
        private int dniCliente_883SC;

        private void frmAltaClienteRapida_Load_883SC(object sender, EventArgs e)
        {
            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmAltaClienteRapida_FormClosed_883SC;
            txtNombre.Focus();
        }

        private void frmAltaClienteRapida_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = gestorIdioma_883SC.Traducir_883SC("CLI_ALTA_TITULO");
            lblTitulo.Text = gestorIdioma_883SC.Traducir_883SC("CLI_ALTA_TITULO");
            lblDni.Text = gestorIdioma_883SC.Traducir_883SC("CLI_ALTA_LBL_DNI");
            lblNombre.Text = gestorIdioma_883SC.Traducir_883SC("CLI_ALTA_LBL_NOMBRE");
            lblApellido.Text = gestorIdioma_883SC.Traducir_883SC("CLI_ALTA_LBL_APELLIDO");
            lblDireccion.Text = gestorIdioma_883SC.Traducir_883SC("CLI_ALTA_LBL_DIRECCION");
            lblTelefono.Text = gestorIdioma_883SC.Traducir_883SC("CLI_ALTA_LBL_TELEFONO");
            btnRegistrar.Text = gestorIdioma_883SC.Traducir_883SC("CLI_ALTA_BTN_REGISTRAR");
            btnCancelar.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_CANCELAR");
        }

        #endregion

        private void btnRegistrar_Click_883SC(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "" || txtApellido.Text.Trim() == "")
            {
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("CLI_ALTA_MSG_INCOMPLETO"), gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                clienteBLL_883SC.CrearCliente_883SC(
                    dniCliente_883SC,
                    txtNombre.Text.Trim(),
                    txtApellido.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    txtTelefono.Text.Trim());

                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("CLI_ALTA_MSG_OK"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                //DNI duplicado o error de base: la pantalla queda abierta para corregir
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("COMUN_ERROR_BD") + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click_883SC(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
