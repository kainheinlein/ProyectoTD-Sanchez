// TEMPORAL: borrar cuando exista CUN-004 Generar Factura
// Pantalla descartable para probar CUN-003 Registrar Cliente mientras no exista
// la pantalla de facturacion, que es la que va a pedir el DNI de verdad.
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

        private void btnCerrar_Click_883SC(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
