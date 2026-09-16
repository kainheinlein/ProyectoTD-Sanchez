// TEMPORAL: borrar cuando exista CUN-004 Generar Factura
// Pantalla descartable para probar CUN-003 Registrar Cliente mientras no exista
// la pantalla de facturacion, que es la que va a pedir el DNI de verdad.
// Tambien permite probar CUN-005 Realizar Cobro con un monto tipeado a mano:
// en CUN-004 el monto sale de la factura y frmRealizarCobro se abre desde ahi.
// No implementa IObservadorIdioma a proposito: los textos van fijos en espaniol
// para que borrarla sea limpio y no deje claves de idioma huerfanas.
using Entidad_BE;
using Negocio_BLL;
using System;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmPruebaCliente_883SC : Form
    {
        public frmPruebaCliente_883SC()
        {
            InitializeComponent();
        }

        ClienteBLL_883SC clienteBLL_883SC = new ClienteBLL_883SC();

        private void btnBuscar_Click_883SC(object sender, EventArgs e)
        {
            int dni;
            if (!int.TryParse(txtDni.Text.Trim(), out dni))
            {
                MessageBox.Show("Ingrese un DNI numerico valido.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                if (BuscarYMostrar_883SC(dni)) { return; }

                LimpiarDatos_883SC();
                DialogResult respuesta = MessageBox.Show("Cliente no encontrado. Desea registrarlo?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta != DialogResult.Yes) { return; }

                using (frmAltaClienteRapida_883SC frmAlta = new frmAltaClienteRapida_883SC(dni))
                {
                    if (frmAlta.ShowDialog() == DialogResult.OK)
                    {
                        //Se vuelve a buscar el mismo DNI para mostrar los datos recien cargados
                        BuscarYMostrar_883SC(dni);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool BuscarYMostrar_883SC(int dni)
        {
            ClienteBE_883SC cliente = clienteBLL_883SC.BuscarCliente_883SC(dni);
            if (cliente == null) { return false; }

            lblResDni.Text = cliente.Dni_883SC.ToString();
            lblResNombre.Text = cliente.Nombre_883SC;
            lblResApellido.Text = cliente.Apellido_883SC;
            lblResDireccion.Text = cliente.Direccion_883SC;
            lblResTelefono.Text = cliente.Telefono_883SC;
            return true;
        }

        private void LimpiarDatos_883SC()
        {
            lblResDni.Text = "";
            lblResNombre.Text = "";
            lblResApellido.Text = "";
            lblResDireccion.Text = "";
            lblResTelefono.Text = "";
        }

        private void btnProbarCobro_Click_883SC(object sender, EventArgs e)
        {
            decimal monto;
            if (!decimal.TryParse(txtMonto.Text.Trim(), out monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un monto numerico mayor a cero.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            using (frmRealizarCobro_883SC frmCobro = new frmRealizarCobro_883SC(monto))
            {
                if (frmCobro.ShowDialog() == DialogResult.OK)
                {
                    string codigo = frmCobro.CodigoAutorizacion_883SC ?? "(sin codigo: metodo sin validacion bancaria)";
                    MessageBox.Show("Cobro OK. Codigo de autorizacion: " + codigo, "Prueba Cobro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCerrar_Click_883SC(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
