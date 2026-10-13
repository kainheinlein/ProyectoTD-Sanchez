using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmSeleccionarProducto_883SC : Form, IObservadorIdioma_883SC
    {
        public frmSeleccionarProducto_883SC()
        {
            InitializeComponent();
        }

        ProductoBLL_883SC productoBLL_883SC = new ProductoBLL_883SC();
        CarritoBLL_883SC carritoBLL_883SC = new CarritoBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        List<ProductoBE_883SC> productosEncontrados_883SC = new List<ProductoBE_883SC>();
        List<DetalleCarritoBE_883SC> carritoEnProgreso_883SC = new List<DetalleCarritoBE_883SC>();

        public List<DetalleCarritoBE_883SC> CarritoEnProgreso_883SC
        {
            get { return carritoEnProgreso_883SC; }
        }

        private void frmSeleccionarProducto_Load_883SC(object sender, EventArgs e)
        {
            cmbCriterio.SelectedIndex = 0;
            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmSeleccionarProducto_FormClosed_883SC;
        }

        private void frmSeleccionarProducto_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = gestorIdioma_883SC.Traducir_883SC("PROD_SEL_TITULO");
            lblCriterio.Text = gestorIdioma_883SC.Traducir_883SC("PROD_SEL_LBL_CRITERIO");
            lblBusqueda.Text = gestorIdioma_883SC.Traducir_883SC("PROD_SEL_LBL_BUSQUEDA");
            btnBuscar.Text = gestorIdioma_883SC.Traducir_883SC("PROD_SEL_BTN_BUSCAR");
            lblCantidad.Text = gestorIdioma_883SC.Traducir_883SC("PROD_SEL_LBL_CANTIDAD");
            btnAgregarCarrito.Text = gestorIdioma_883SC.Traducir_883SC("PROD_SEL_BTN_AGREGAR");
            lblCarrito.Text = gestorIdioma_883SC.Traducir_883SC("PROD_SEL_LBL_CARRITO");
            lblCantEditar.Text = gestorIdioma_883SC.Traducir_883SC("PROD_SEL_LBL_CANT_EDITAR");
            btnEditarCarrito.Text = gestorIdioma_883SC.Traducir_883SC("PROD_SEL_BTN_EDITAR");
            btnEliminarCarrito.Text = gestorIdioma_883SC.Traducir_883SC("PROD_SEL_BTN_ELIMINAR");
            btnFinalizar.Text = gestorIdioma_883SC.Traducir_883SC("PROD_SEL_BTN_FINALIZAR");

            colCarrCodigo.HeaderText = gestorIdioma_883SC.Traducir_883SC("PROD_SEL_COL_CODIGO");
            colCarrNombre.HeaderText = gestorIdioma_883SC.Traducir_883SC("PROD_SEL_COL_NOMBRE");
            colCarrCantidad.HeaderText = gestorIdioma_883SC.Traducir_883SC("PROD_SEL_COL_CANTIDAD");
            colCarrPrecioUnitario.HeaderText = gestorIdioma_883SC.Traducir_883SC("PROD_SEL_COL_PRECIO_UNITARIO");
            colCarrSubtotal.HeaderText = gestorIdioma_883SC.Traducir_883SC("PROD_SEL_COL_SUBTOTAL");

            AplicarEncabezadosProductos_883SC();
            ActualizarTotalCarrito_883SC();
        }

        #endregion

        private void btnBuscar_Click_883SC(object sender, EventArgs e)
        {
            try
            {
                string criterio = cmbCriterio.SelectedItem.ToString();
                string dato = txtBusqueda.Text.Trim();

                productosEncontrados_883SC = productoBLL_883SC.BuscarProductos_883SC(criterio, dato);
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = productosEncontrados_883SC;

                if (productosEncontrados_883SC.Count == 0)
                {
                    MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("PROD_MSG_INEXISTENTE"), gestorIdioma_883SC.Traducir_883SC("PROD_TIT_INEXISTENTE"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductos_DataBindingComplete_883SC(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AplicarEncabezadosProductos_883SC();

            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                ProductoBE_883SC producto = fila.DataBoundItem as ProductoBE_883SC;
                if (producto != null && producto.Stock_883SC == 0)
                {
                    fila.DefaultCellStyle.BackColor = Color.LightSalmon;
                }
            }
        }

        private void AplicarEncabezadosProductos_883SC()
        {
            if (dgvProductos.Columns["Codigo_883SC"] != null)
            {
                dgvProductos.Columns["Codigo_883SC"].HeaderText = gestorIdioma_883SC.Traducir_883SC("PROD_SEL_COL_CODIGO");
                dgvProductos.Columns["Nombre_883SC"].HeaderText = gestorIdioma_883SC.Traducir_883SC("PROD_SEL_COL_NOMBRE");
                dgvProductos.Columns["Stock_883SC"].HeaderText = gestorIdioma_883SC.Traducir_883SC("PROD_SEL_COL_STOCK");
                dgvProductos.Columns["Tipo_883SC"].HeaderText = gestorIdioma_883SC.Traducir_883SC("PROD_SEL_COL_TIPO");
                dgvProductos.Columns["Precio_883SC"].HeaderText = gestorIdioma_883SC.Traducir_883SC("PROD_SEL_COL_PRECIO");
                dgvProductos.Columns["Proveedor_883SC"].HeaderText = gestorIdioma_883SC.Traducir_883SC("PROD_SEL_COL_PROVEEDOR");
            }
        }

        private void btnAgregarCarrito_Click_883SC(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.CurrentRow == null)
                {
                    MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("PROD_MSG_SIN_SELECCION"), gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                ProductoBE_883SC producto = dgvProductos.CurrentRow.DataBoundItem as ProductoBE_883SC;
                if (producto == null) { return; }

                int cantidad = (int)numCantidad.Value;

                //Si el producto ya esta en el carrito la BLL suma las cantidades en la misma linea
                carritoBLL_883SC.AgregarAlCarrito_883SC(carritoEnProgreso_883SC, producto, cantidad);
                CargarGrillaCarrito_883SC();
                numCantidad.Value = 1;
            }
            catch (InvalidOperationException ex)
            {
                //Stock insuficiente para la cantidad acumulada
                MessageBox.Show(ex.Message, gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrillaCarrito_883SC()
        {
            dgvCarrito.Rows.Clear();
            foreach (DetalleCarritoBE_883SC detalle in carritoEnProgreso_883SC)
            {
                decimal subtotal = detalle.Cantidad_883SC * detalle.PrecioUnitario_883SC;
                dgvCarrito.Rows.Add(
                    detalle.Producto_883SC.Codigo_883SC,
                    detalle.Producto_883SC.Nombre_883SC,
                    detalle.Cantidad_883SC,
                    detalle.PrecioUnitario_883SC,
                    subtotal);
            }
            ActualizarTotalCarrito_883SC();
        }

        private void ActualizarTotalCarrito_883SC()
        {
            decimal total = 0;
            foreach (DetalleCarritoBE_883SC detalle in carritoEnProgreso_883SC)
            {
                total += detalle.Cantidad_883SC * detalle.PrecioUnitario_883SC;
            }
            lblTotalCarrito.Text = gestorIdioma_883SC.Traducir_883SC("PROD_SEL_LBL_TOTAL") + " $ " + total.ToString("0.00");
        }

        private void dgvCarrito_SelectionChanged_883SC(object sender, EventArgs e)
        {
            if (dgvCarrito.CurrentRow != null && dgvCarrito.CurrentRow.Index < carritoEnProgreso_883SC.Count)
            {
                numCantidadEditar.Value = carritoEnProgreso_883SC[dgvCarrito.CurrentRow.Index].Cantidad_883SC;
            }
        }

        private void btnEditarCarrito_Click_883SC(object sender, EventArgs e)
        {
            try
            {
                if (dgvCarrito.CurrentRow == null)
                {
                    MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("PROD_MSG_SIN_SELECCION_CARRITO"), gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                DetalleCarritoBE_883SC detalle = carritoEnProgreso_883SC[dgvCarrito.CurrentRow.Index];
                int nuevaCantidad = (int)numCantidadEditar.Value;

                if (nuevaCantidad > detalle.Producto_883SC.Stock_883SC)
                {
                    MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("PROD_MSG_STOCK_INSUFICIENTE"), gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                detalle.Cantidad_883SC = nuevaCantidad;
                CargarGrillaCarrito_883SC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarCarrito_Click_883SC(object sender, EventArgs e)
        {
            if (dgvCarrito.CurrentRow == null)
            {
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("PROD_MSG_SIN_SELECCION_CARRITO"), gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("PROD_MSG_CONFIRMA_ELIMINAR"), gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion != DialogResult.Yes) { return; }

            carritoEnProgreso_883SC.RemoveAt(dgvCarrito.CurrentRow.Index);
            CargarGrillaCarrito_883SC();
        }

        private void btnFinalizar_Click_883SC(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
