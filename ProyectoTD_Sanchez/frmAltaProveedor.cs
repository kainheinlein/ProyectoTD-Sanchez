using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmAltaProveedor_883SC : Form, IObservadorIdioma_883SC
    {
        public frmAltaProveedor_883SC()
        {
            InitializeComponent();
        }

        ProveedorBLL_883SC proveedorBLL_883SC = new ProveedorBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        private ProveedorBE_883SC _proveedorRegistrado_883SC;

        /// Proveedor recien registrado (con su Id), o null si se cancelo
        public ProveedorBE_883SC ProveedorRegistrado_883SC
        {
            get { return _proveedorRegistrado_883SC; }
        }

        private void frmAltaProveedor_Load_883SC(object sender, EventArgs e)
        {
            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmAltaProveedor_FormClosed_883SC;
            txtNombre.Focus();
        }

        private void frmAltaProveedor_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = gestorIdioma_883SC.Traducir_883SC("PROV_ALTA_TITULO");
            lblTitulo.Text = gestorIdioma_883SC.Traducir_883SC("PROV_ALTA_TITULO");
            lblNombre.Text = gestorIdioma_883SC.Traducir_883SC("PROV_LBL_NOMBRE");
            lblEspecialidad.Text = gestorIdioma_883SC.Traducir_883SC("PROV_LBL_ESPECIALIDAD");
            lblTelefono.Text = gestorIdioma_883SC.Traducir_883SC("PROV_LBL_TELEFONO");
            lblDireccion.Text = gestorIdioma_883SC.Traducir_883SC("PROV_LBL_DIRECCION");
            lblMargen.Text = gestorIdioma_883SC.Traducir_883SC("PROV_LBL_MARGEN");
            lblObservaciones.Text = gestorIdioma_883SC.Traducir_883SC("PROV_LBL_OBSERVACIONES");
            btnRegistrar.Text = gestorIdioma_883SC.Traducir_883SC("PROV_BTN_REGISTRAR");
            btnCancelar.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_CANCELAR");
        }

        #endregion

        private void btnRegistrar_Click_883SC(object sender, EventArgs e)
        {
            lblError.Text = "";

            decimal margen;
            if (!TryLeerMargen_883SC(out margen))
            {
                lblError.Text = gestorIdioma_883SC.Traducir_883SC("PROV_ERR_MARGEN");
                return;
            }

            try
            {
                _proveedorRegistrado_883SC = proveedorBLL_883SC.RegistrarProveedor_883SC(
                    txtNombre.Text,
                    txtEspecialidad.Text,
                    txtTelefono.Text,
                    txtDireccion.Text,
                    margen,
                    txtObservaciones.Text);
            }
            catch (ArgumentException ex)
            {
                //Dato invalido o nombre repetido: la pantalla queda abierta para corregir
                lblError.Text = ex.Message;
                return;
            }
            catch (Exception)
            {
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("PROV_MSG_ERROR_GUARDAR"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                return;
            }

            MessageBox.Show(
                string.Format(gestorIdioma_883SC.Traducir_883SC("PROV_MSG_OK"), _proveedorRegistrado_883SC.Id_883SC, _proveedorRegistrado_883SC.Nombre_883SC),
                "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        //Acepta punto o coma como separador decimal, sin separador de miles
        private bool TryLeerMargen_883SC(out decimal margen)
        {
            string separador = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            string texto = txtMargen.Text.Trim().Replace(".", separador).Replace(",", separador);
            return decimal.TryParse(texto, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out margen);
        }

        private void btnCancelar_Click_883SC(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
