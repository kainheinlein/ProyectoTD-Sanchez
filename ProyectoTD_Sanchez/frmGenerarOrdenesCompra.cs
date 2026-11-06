using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmGenerarOrdenesCompra_883SC : Form, IObservadorIdioma_883SC
    {
        public frmGenerarOrdenesCompra_883SC()
        {
            InitializeComponent();
        }

        ProductoBLL_883SC productoBLL_883SC = new ProductoBLL_883SC();
        ListaPrecioBLL_883SC listaPrecioBLL_883SC = new ListaPrecioBLL_883SC();
        OrdenCompraBLL_883SC ordenCompraBLL_883SC = new OrdenCompraBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        //Lista de compra: temporal, no se persiste hasta presionar "Generar Ordenes"
        private List<LineaCompraBE_883SC> _listaCompra_883SC = new List<LineaCompraBE_883SC>();

        private void frmGenerarOrdenesCompra_Load_883SC(object sender, EventArgs e)
        {
            ConfigurarColumnas_883SC();
            try
            {
                CargarProductos_883SC();
            }
            catch (Exception ex)
            {
                lblError.Text = Traducir_883SC("COMUN_ERROR_BD") + ex.Message;
            }

            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmGenerarOrdenesCompra_FormClosed_883SC;
        }

        private void frmGenerarOrdenesCompra_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = Traducir_883SC("OC_TITULO");
            lblTitulo.Text = Traducir_883SC("OC_TITULO");
            lblBajoStock.Text = Traducir_883SC("OC_LBL_BAJO_STOCK");
            lblPrecios.Text = Traducir_883SC("OC_LBL_PRECIOS");
            lblListaCompra.Text = Traducir_883SC("OC_LBL_LISTA_COMPRA");
            lblTotales.Text = Traducir_883SC("OC_LBL_TOTALES");
            lblCantidad.Text = Traducir_883SC("OC_LBL_CANTIDAD");
            btnAgregar.Text = Traducir_883SC("OC_BTN_AGREGAR");
            btnQuitar.Text = Traducir_883SC("OC_BTN_QUITAR");
            btnGenerar.Text = Traducir_883SC("OC_BTN_GENERAR");
            btnSalir.Text = Traducir_883SC("COMUN_SALIR");
            foreach (DataGridView dgv in new DataGridView[] { dgvProductos, dgvPrecios, dgvLista, dgvTotales })
            {
                foreach (DataGridViewColumn columna in dgv.Columns)
                {
                    columna.HeaderText = Traducir_883SC(columna.Tag.ToString());
                }
            }
        }

        #endregion

        private string Traducir_883SC(string clave)
        {
            return gestorIdioma_883SC.Traducir_883SC(clave);
        }

        private void AgregarColumna_883SC(DataGridView dgv, string nombre, string claveEncabezado, string formato = null)
        {
            DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
            columna.Name = nombre;
            columna.Tag = claveEncabezado;
            columna.ReadOnly = true;
            if (formato != null) { columna.DefaultCellStyle.Format = formato; }
            dgv.Columns.Add(columna);
        }

        private void ConfigurarColumnas_883SC()
        {
            AgregarColumna_883SC(dgvProductos, "colCodigo", "MAESTRO_COL_CODIGO");
            AgregarColumna_883SC(dgvProductos, "colNombre", "COMUN_NOMBRE");
            AgregarColumna_883SC(dgvProductos, "colStock", "MAESTRO_COL_STOCK");
            AgregarColumna_883SC(dgvProductos, "colStockMin", "PROD_COL_STOCK_MIN");
            AgregarColumna_883SC(dgvProductos, "colFaltante", "OC_COL_FALTANTE");
            AgregarColumna_883SC(dgvProductos, "colProveedores", "OC_COL_PROVEEDORES");

            AgregarColumna_883SC(dgvPrecios, "colProveedor", "PROD_COL_PROVEEDOR");
            AgregarColumna_883SC(dgvPrecios, "colCodigoProv", "PROD_COL_CODIGO_PROV");
            AgregarColumna_883SC(dgvPrecios, "colPrecioLista", "PROD_COL_PRECIO_LISTA", "N2");
            AgregarColumna_883SC(dgvPrecios, "colFecha", "PROD_COL_FECHA", "d");

            AgregarColumna_883SC(dgvLista, "colProducto", "COMUN_NOMBRE");
            AgregarColumna_883SC(dgvLista, "colProveedorL", "PROD_COL_PROVEEDOR");
            AgregarColumna_883SC(dgvLista, "colCantidad", "OC_COL_CANTIDAD");
            AgregarColumna_883SC(dgvLista, "colPrecioL", "PROD_COL_PRECIO_LISTA", "N2");
            AgregarColumna_883SC(dgvLista, "colSubtotal", "OC_COL_SUBTOTAL", "N2");

            AgregarColumna_883SC(dgvTotales, "colProveedorT", "PROD_COL_PROVEEDOR");
            AgregarColumna_883SC(dgvTotales, "colTotal", "OC_COL_TOTAL", "N2");
        }

        private void CargarProductos_883SC()
        {
            dgvProductos.Rows.Clear();
            List<ProductoBE_883SC> productos = productoBLL_883SC.ListarBajoStock_883SC();
            foreach (ProductoBE_883SC p in productos)
            {
                int fila = dgvProductos.Rows.Add(p.Codigo_883SC, p.Nombre_883SC, p.Stock_883SC, p.StockMinimo_883SC,
                    p.CantidadFaltante_883SC, p.CantidadProveedores_883SC);
                dgvProductos.Rows[fila].Tag = p;
                //Sin proveedores con precio: se muestra, pero atenuado y sin poder agregarse a la lista
                if (p.CantidadProveedores_883SC == 0)
                {
                    dgvProductos.Rows[fila].DefaultCellStyle.ForeColor = Color.Gray;
                }
            }
            if (productos.Count == 0)
            {
                lblError.Text = Traducir_883SC("OC_MSG_SIN_BAJO_STOCK");
            }
            CargarPrecios_883SC();
        }

        //Precios de lista del producto elegido, de menor a mayor
        private void CargarPrecios_883SC()
        {
            dgvPrecios.Rows.Clear();
            ProductoBE_883SC producto = ProductoSeleccionado_883SC();
            if (producto == null) { return; }

            try
            {
                List<LineaCompraBE_883SC> opciones = listaPrecioBLL_883SC.CompararPrecios_883SC(producto);
                foreach (LineaCompraBE_883SC opcion in opciones)
                {
                    int fila = dgvPrecios.Rows.Add(opcion.Proveedor_883SC.Nombre_883SC, opcion.CodigoProveedor_883SC,
                        opcion.PrecioLista_883SC, opcion.FechaActualizacion_883SC);
                    dgvPrecios.Rows[fila].Tag = opcion;
                }
                if (opciones.Count == 0)
                {
                    lblError.Text = Traducir_883SC("OC_MSG_SIN_LISTAS");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = Traducir_883SC("COMUN_ERROR_BD") + ex.Message;
            }
        }

        private void CargarListaCompra_883SC()
        {
            dgvLista.Rows.Clear();
            foreach (LineaCompraBE_883SC linea in _listaCompra_883SC)
            {
                int fila = dgvLista.Rows.Add(linea.Producto_883SC.Nombre_883SC, linea.Proveedor_883SC.Nombre_883SC,
                    linea.Cantidad_883SC, linea.PrecioLista_883SC, linea.Subtotal_883SC);
                dgvLista.Rows[fila].Tag = linea;
            }

            dgvTotales.Rows.Clear();
            foreach (KeyValuePair<ProveedorBE_883SC, decimal> total in ordenCompraBLL_883SC.CalcularTotales_883SC(_listaCompra_883SC))
            {
                dgvTotales.Rows.Add(total.Key.Nombre_883SC, total.Value);
            }
        }

        private ProductoBE_883SC ProductoSeleccionado_883SC()
        {
            return dgvProductos.CurrentRow == null ? null : dgvProductos.CurrentRow.Tag as ProductoBE_883SC;
        }

        private LineaCompraBE_883SC PrecioSeleccionado_883SC()
        {
            return dgvPrecios.CurrentRow == null ? null : dgvPrecios.CurrentRow.Tag as LineaCompraBE_883SC;
        }

        private LineaCompraBE_883SC LineaSeleccionada_883SC()
        {
            return dgvLista.CurrentRow == null ? null : dgvLista.CurrentRow.Tag as LineaCompraBE_883SC;
        }

        private void dgvProductos_SelectionChanged_883SC(object sender, EventArgs e)
        {
            lblError.Text = "";
            CargarPrecios_883SC();
        }

        private void btnAgregar_Click_883SC(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (ProductoSeleccionado_883SC() == null)
            {
                lblError.Text = Traducir_883SC("OC_ERR_SEL_PRODUCTO");
                return;
            }
            LineaCompraBE_883SC opcion = PrecioSeleccionado_883SC();
            if (opcion == null)
            {
                //Producto sin proveedores con precio (escenario 4.1) o sin elegir ninguno
                lblError.Text = dgvPrecios.Rows.Count == 0
                    ? Traducir_883SC("OC_MSG_SIN_LISTAS")
                    : Traducir_883SC("OC_ERR_SEL_PROVEEDOR");
                return;
            }

            int cantidad;
            if (!int.TryParse(txtCantidad.Text.Trim(), out cantidad))
            {
                lblError.Text = Traducir_883SC("OC_ERR_CANTIDAD");
                return;
            }

            try
            {
                ordenCompraBLL_883SC.AgregarALista_883SC(_listaCompra_883SC, opcion, cantidad);
            }
            catch (ArgumentException ex)
            {
                lblError.Text = ex.Message;
                return;
            }
            txtCantidad.Text = "";
            CargarListaCompra_883SC();
        }

        private void btnQuitar_Click_883SC(object sender, EventArgs e)
        {
            lblError.Text = "";
            try
            {
                ordenCompraBLL_883SC.QuitarDeLista_883SC(_listaCompra_883SC, LineaSeleccionada_883SC());
            }
            catch (ArgumentException ex)
            {
                lblError.Text = ex.Message;
                return;
            }
            CargarListaCompra_883SC();
        }

        private void btnGenerar_Click_883SC(object sender, EventArgs e)
        {
            lblError.Text = "";
            List<OrdenCompraBE_883SC> ordenes;
            try
            {
                ordenes = ordenCompraBLL_883SC.GenerarOrdenes_883SC(_listaCompra_883SC);
            }
            catch (ArgumentException ex)
            {
                lblError.Text = ex.Message;
                return;
            }
            catch (Exception)
            {
                //No se genero ninguna orden: el SP es transaccional
                MessageBox.Show(Traducir_883SC("OC_MSG_ERROR_GENERAR"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> numeros = new List<string>();
            foreach (OrdenCompraBE_883SC orden in ordenes)
            {
                numeros.Add(orden.IdOrdenCompra_883SC.ToString());
            }
            MessageBox.Show(string.Format(Traducir_883SC("OC_MSG_GENERADAS"), ordenes.Count, string.Join(", ", numeros.ToArray())),
                "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            _listaCompra_883SC.Clear();
            CargarListaCompra_883SC();
        }

        private void btnSalir_Click_883SC(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
