using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmRealizarVenta_883SC : Form, IObservadorIdioma_883SC
    {
        public frmRealizarVenta_883SC()
        {
            InitializeComponent();
        }

        CarritoBLL_883SC carritoBLL_883SC = new CarritoBLL_883SC();
        ClienteBLL_883SC clienteBLL_883SC = new ClienteBLL_883SC();
        FacturaBLL_883SC facturaBLL_883SC = new FacturaBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        List<CarritoBE_883SC> pendientes_883SC = new List<CarritoBE_883SC>();
        CarritoBE_883SC carritoSeleccionado_883SC = null;
        ClienteBE_883SC clienteSeleccionado_883SC = null;

        //Resultado del cobro (CUN-005): se limpia si se cambia de carrito porque el monto ya no corresponde
        MetodoPagoBE_883SC metodoPago_883SC = null;
        string codigoAutorizacion_883SC = null;

        //Evita que SelectionChanged consulte la base mientras se recarga la grilla de pendientes
        bool cargandoPendientes_883SC = false;

        private void frmRealizarVenta_Load_883SC(object sender, EventArgs e)
        {
            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmRealizarVenta_FormClosed_883SC;
            CargarPendientes_883SC();
        }

        private void frmRealizarVenta_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = gestorIdioma_883SC.Traducir_883SC("FACT_TITULO");
            lblTitulo.Text = gestorIdioma_883SC.Traducir_883SC("FACT_LBL_TITULO");
            lblPendientes.Text = gestorIdioma_883SC.Traducir_883SC("FACT_LBL_PENDIENTES");
            lblDetalle.Text = gestorIdioma_883SC.Traducir_883SC("FACT_LBL_DETALLE");
            grpCliente.Text = gestorIdioma_883SC.Traducir_883SC("FACT_GRP_CLIENTE");
            lblDni.Text = gestorIdioma_883SC.Traducir_883SC("FACT_LBL_DNI");
            btnBuscarCliente.Text = gestorIdioma_883SC.Traducir_883SC("FACT_BTN_BUSCAR_CLIENTE");
            lblNombre.Text = gestorIdioma_883SC.Traducir_883SC("FACT_LBL_NOMBRE");
            lblApellido.Text = gestorIdioma_883SC.Traducir_883SC("FACT_LBL_APELLIDO");
            lblDireccion.Text = gestorIdioma_883SC.Traducir_883SC("FACT_LBL_DIRECCION");
            lblTelefono.Text = gestorIdioma_883SC.Traducir_883SC("FACT_LBL_TELEFONO");
            grpPago.Text = gestorIdioma_883SC.Traducir_883SC("FACT_GRP_PAGO");
            lblMetodo.Text = gestorIdioma_883SC.Traducir_883SC("FACT_LBL_METODO");
            lblAutorizacion.Text = gestorIdioma_883SC.Traducir_883SC("FACT_LBL_AUTORIZACION");
            btnCobrar.Text = gestorIdioma_883SC.Traducir_883SC("FACT_BTN_COBRAR");
            btnGenerar.Text = gestorIdioma_883SC.Traducir_883SC("FACT_BTN_GENERAR");
            btnSalir.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_SALIR");

            colPenId.HeaderText = gestorIdioma_883SC.Traducir_883SC("FACT_COL_ID_CARRITO");
            colPenNombre.HeaderText = gestorIdioma_883SC.Traducir_883SC("FACT_COL_NOMBRE_CARRITO");
            colPenFecha.HeaderText = gestorIdioma_883SC.Traducir_883SC("FACT_COL_FECHA");

            colDetCodigo.HeaderText = gestorIdioma_883SC.Traducir_883SC("FACT_COL_CODIGO");
            colDetNombre.HeaderText = gestorIdioma_883SC.Traducir_883SC("FACT_COL_PRODUCTO");
            colDetCantidad.HeaderText = gestorIdioma_883SC.Traducir_883SC("FACT_COL_CANTIDAD");
            colDetPrecioUnitario.HeaderText = gestorIdioma_883SC.Traducir_883SC("FACT_COL_PRECIO_UNITARIO");
            colDetSubtotal.HeaderText = gestorIdioma_883SC.Traducir_883SC("FACT_COL_SUBTOTAL");

            ActualizarTotal_883SC();
        }

        #endregion

        #region Carritos pendientes

        private void CargarPendientes_883SC()
        {
            try
            {
                cargandoPendientes_883SC = true;
                pendientes_883SC = carritoBLL_883SC.ListarCarritosPendientes_883SC();

                dgvPendientes.Rows.Clear();
                foreach (CarritoBE_883SC carrito in pendientes_883SC)
                {
                    dgvPendientes.Rows.Add(
                        carrito.IdCarrito_883SC,
                        carrito.Nombre_883SC,
                        carrito.FechaCreacion_883SC.ToString("g"));
                }
                dgvPendientes.ClearSelection();
                dgvPendientes.CurrentCell = null;
                cargandoPendientes_883SC = false;

                LimpiarSeleccion_883SC();

                if (pendientes_883SC.Count == 0)
                {
                    MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("FACT_MSG_SIN_PENDIENTES"), gestorIdioma_883SC.Traducir_883SC("FACT_TITULO"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                cargandoPendientes_883SC = false;
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("COMUN_ERROR_BD") + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPendientes_SelectionChanged_883SC(object sender, EventArgs e)
        {
            if (cargandoPendientes_883SC) { return; }
            if (dgvPendientes.CurrentRow == null || dgvPendientes.CurrentRow.Index >= pendientes_883SC.Count) { return; }

            int idCarrito = pendientes_883SC[dgvPendientes.CurrentRow.Index].IdCarrito_883SC;
            if (carritoSeleccionado_883SC != null && carritoSeleccionado_883SC.IdCarrito_883SC == idCarrito) { return; }

            try
            {
                carritoSeleccionado_883SC = carritoBLL_883SC.ObtenerCarritoCompleto_883SC(idCarrito);
                CargarDetalle_883SC();
                //El cobro es por el monto de un carrito puntual: cambiar de carrito lo invalida
                LimpiarPago_883SC();
                ActualizarBotones_883SC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("COMUN_ERROR_BD") + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDetalle_883SC()
        {
            dgvDetalle.Rows.Clear();
            if (carritoSeleccionado_883SC != null)
            {
                foreach (DetalleCarritoBE_883SC detalle in carritoSeleccionado_883SC.Detalle_883SC)
                {
                    decimal subtotal = detalle.Cantidad_883SC * detalle.PrecioUnitario_883SC;
                    dgvDetalle.Rows.Add(
                        detalle.Producto_883SC.Codigo_883SC,
                        detalle.Producto_883SC.Nombre_883SC,
                        detalle.Cantidad_883SC,
                        detalle.PrecioUnitario_883SC,
                        subtotal);
                }
            }
            ActualizarTotal_883SC();
        }

        private void ActualizarTotal_883SC()
        {
            decimal total = carritoSeleccionado_883SC == null ? 0 : carritoSeleccionado_883SC.PrecioTotal_883SC;
            lblTotal.Text = gestorIdioma_883SC.Traducir_883SC("FACT_LBL_TOTAL") + " $ " + total.ToString("0.00");
        }

        #endregion

        #region Cliente

        private void btnBuscarCliente_Click_883SC(object sender, EventArgs e)
        {
            int dni;
            if (!int.TryParse(txtDni.Text.Trim(), out dni))
            {
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("FACT_MSG_DNI_INVALIDO"), gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDni.Focus();
                return;
            }

            try
            {
                if (BuscarYMostrar_883SC(dni)) { return; }

                LimpiarCliente_883SC();
                DialogResult respuesta = MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("FACT_MSG_CLIENTE_NO_ENCONTRADO"), gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("COMUN_ERROR_BD") + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool BuscarYMostrar_883SC(int dni)
        {
            ClienteBE_883SC cliente = clienteBLL_883SC.BuscarCliente_883SC(dni);
            if (cliente == null) { return false; }

            clienteSeleccionado_883SC = cliente;
            lblNombreValor.Text = cliente.Nombre_883SC;
            lblApellidoValor.Text = cliente.Apellido_883SC;
            lblDireccionValor.Text = cliente.Direccion_883SC;
            lblTelefonoValor.Text = cliente.Telefono_883SC;
            ActualizarBotones_883SC();
            return true;
        }

        #endregion

        #region Cobro y factura

        private void btnCobrar_Click_883SC(object sender, EventArgs e)
        {
            if (carritoSeleccionado_883SC == null || clienteSeleccionado_883SC == null) { return; }

            using (frmRealizarCobro_883SC frmCobro = new frmRealizarCobro_883SC(carritoSeleccionado_883SC.PrecioTotal_883SC))
            {
                if (frmCobro.ShowDialog() != DialogResult.OK) { return; }

                metodoPago_883SC = frmCobro.MetodoPago_883SC;
                codigoAutorizacion_883SC = frmCobro.CodigoAutorizacion_883SC;
            }

            lblMetodoValor.Text = metodoPago_883SC.Nombre_883SC;
            lblAutorizacionValor.Text = codigoAutorizacion_883SC ?? "-";
            ActualizarBotones_883SC();
        }

        private void btnGenerar_Click_883SC(object sender, EventArgs e)
        {
            try
            {
                FacturaBE_883SC factura = facturaBLL_883SC.CrearFactura_883SC(
                    carritoSeleccionado_883SC, clienteSeleccionado_883SC, metodoPago_883SC, codigoAutorizacion_883SC);

                MessageBox.Show(string.Format(gestorIdioma_883SC.Traducir_883SC("FACT_MSG_EXITO"), factura.IdFactura_883SC),
                    gestorIdioma_883SC.Traducir_883SC("FACT_TITULO"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                //El carrito recien facturado ya no es pendiente: la lista se refresca desde la base
                CargarPendientes_883SC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Estado de la pantalla

        //Cobrar solo con carrito Y cliente; Generar solo si ademas ya se cobro
        private void ActualizarBotones_883SC()
        {
            btnCobrar.Enabled = carritoSeleccionado_883SC != null && clienteSeleccionado_883SC != null;
            btnGenerar.Enabled = btnCobrar.Enabled && metodoPago_883SC != null;
        }

        private void LimpiarSeleccion_883SC()
        {
            carritoSeleccionado_883SC = null;
            CargarDetalle_883SC();
            LimpiarCliente_883SC();
            txtDni.Text = "";
            LimpiarPago_883SC();
            ActualizarBotones_883SC();
        }

        private void LimpiarCliente_883SC()
        {
            clienteSeleccionado_883SC = null;
            lblNombreValor.Text = "";
            lblApellidoValor.Text = "";
            lblDireccionValor.Text = "";
            lblTelefonoValor.Text = "";
            ActualizarBotones_883SC();
        }

        private void LimpiarPago_883SC()
        {
            metodoPago_883SC = null;
            codigoAutorizacion_883SC = null;
            lblMetodoValor.Text = "";
            lblAutorizacionValor.Text = "";
        }

        #endregion

        private void btnSalir_Click_883SC(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
