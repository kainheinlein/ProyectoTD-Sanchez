using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmLlenarCarrito_883SC : Form, IObservadorIdioma_883SC
    {
        public frmLlenarCarrito_883SC()
        {
            InitializeComponent();
        }

        CarritoBLL_883SC carritoBLL_883SC = new CarritoBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        List<DetalleCarritoBE_883SC> detalleCarrito_883SC = new List<DetalleCarritoBE_883SC>();
        bool productosSolicitados_883SC = false;

        private void frmLlenarCarrito_Load_883SC(object sender, EventArgs e)
        {
            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmLlenarCarrito_FormClosed_883SC;
        }

        private void frmLlenarCarrito_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        ///BeginInvoke: permite que SeleccionProductos (ShowDialog)
        ///se muestre al terminar de cargar el formulario frmLlenarCarrito, y no antes (lo que generaba un parpadeo).
        private void frmLlenarCarrito_Shown_883SC(object sender, EventArgs e)
        {
            if (productosSolicitados_883SC) { return; }
            productosSolicitados_883SC = true;
            this.BeginInvoke(new MethodInvoker(PedirProductos_883SC));
        }

        private void PedirProductos_883SC()
        {
            frmSeleccionarProducto_883SC frmProductos = new frmSeleccionarProducto_883SC();
            frmProductos.ShowDialog();
            detalleCarrito_883SC = frmProductos.CarritoEnProgreso_883SC;

            if (detalleCarrito_883SC.Count == 0)
            {
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("CARR_MSG_VACIO"), gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            CargarGrilla_883SC();
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = gestorIdioma_883SC.Traducir_883SC("CARR_TITULO");
            lblResumen.Text = gestorIdioma_883SC.Traducir_883SC("CARR_LBL_RESUMEN");
            lblCliente.Text = gestorIdioma_883SC.Traducir_883SC("CARR_LBL_CLIENTE");
            btnQuitar.Text = gestorIdioma_883SC.Traducir_883SC("CARR_BTN_QUITAR");
            btnConfirmar.Text = gestorIdioma_883SC.Traducir_883SC("CARR_BTN_CONFIRMAR");
            btnSalir.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_SALIR");

            colDetCodigo.HeaderText = gestorIdioma_883SC.Traducir_883SC("CARR_COL_CODIGO");
            colDetNombre.HeaderText = gestorIdioma_883SC.Traducir_883SC("CARR_COL_NOMBRE");
            colDetCantidad.HeaderText = gestorIdioma_883SC.Traducir_883SC("CARR_COL_CANTIDAD");
            colDetPrecioUnitario.HeaderText = gestorIdioma_883SC.Traducir_883SC("CARR_COL_PRECIO_UNITARIO");
            colDetSubtotal.HeaderText = gestorIdioma_883SC.Traducir_883SC("CARR_COL_SUBTOTAL");

            ActualizarTotal_883SC();
        }

        #endregion

        private void CargarGrilla_883SC()
        {
            dgvDetalle.Rows.Clear();
            foreach (DetalleCarritoBE_883SC detalle in detalleCarrito_883SC)
            {
                decimal subtotal = detalle.Cantidad_883SC * detalle.PrecioUnitario_883SC;
                dgvDetalle.Rows.Add(
                    detalle.Producto_883SC.Codigo_883SC,
                    detalle.Producto_883SC.Nombre_883SC,
                    detalle.Cantidad_883SC,
                    detalle.PrecioUnitario_883SC,
                    subtotal);
            }
            ActualizarTotal_883SC();
        }

        private void ActualizarTotal_883SC()
        {
            decimal total = 0;
            foreach (DetalleCarritoBE_883SC detalle in detalleCarrito_883SC)
            {
                total += detalle.Cantidad_883SC * detalle.PrecioUnitario_883SC;
            }
            lblTotal.Text = gestorIdioma_883SC.Traducir_883SC("CARR_LBL_TOTAL") + " $ " + total.ToString("0.00");
        }

        private void btnQuitar_Click_883SC(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow == null)
            {
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("CARR_MSG_SIN_SELECCION"), gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("CARR_MSG_CONFIRMA_QUITAR"), gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion != DialogResult.Yes) { return; }

            detalleCarrito_883SC.RemoveAt(dgvDetalle.CurrentRow.Index);
            CargarGrilla_883SC();

            if (detalleCarrito_883SC.Count == 0)
            {
                btnConfirmar.Enabled = false;
            }
        }

        private void btnConfirmar_Click_883SC(object sender, EventArgs e)
        {
            try
            {
                if (detalleCarrito_883SC.Count == 0)
                {
                    MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("CARR_MSG_SIN_LINEAS"), gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string nombre = txtCliente.Text.Trim();
                if (nombre == "")
                {
                    MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("CARR_MSG_SIN_NOMBRE"), gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCliente.Focus();
                    return;
                }

                CarritoBE_883SC carrito = carritoBLL_883SC.CrearCarrito_883SC(detalleCarrito_883SC, nombre);

                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("CARR_MSG_EXITO") + carrito.IdCarrito_883SC, gestorIdioma_883SC.Traducir_883SC("CARR_TITULO"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click_883SC(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
