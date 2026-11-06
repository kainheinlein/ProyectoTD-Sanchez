using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmAdministrarProductos_883SC : Form, IObservadorIdioma_883SC
    {
        public frmAdministrarProductos_883SC()
        {
            InitializeComponent();
        }

        ProductoBLL_883SC productoBLL_883SC = new ProductoBLL_883SC();
        ListaPrecioBLL_883SC listaPrecioBLL_883SC = new ListaPrecioBLL_883SC();
        ProveedorBLL_883SC proveedorBLL_883SC = new ProveedorBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        private List<ProveedorBE_883SC> _proveedores_883SC = new List<ProveedorBE_883SC>();
        //Evita recargar la grilla mientras se arma el combo del filtro
        private bool _cargandoFiltro_883SC;

        private void frmAdministrarProductos_Load_883SC(object sender, EventArgs e)
        {
            ConfigurarColumnas_883SC();
            try
            {
                _proveedores_883SC = proveedorBLL_883SC.ListarProveedores_883SC();
                CargarFiltro_883SC();
                CargarProductos_883SC(null);
                CargarPendientes_883SC();
            }
            catch (Exception ex)
            {
                lblError.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_ERROR_BD") + ex.Message;
            }

            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmAdministrarProductos_FormClosed_883SC;
        }

        private void frmAdministrarProductos_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = Traducir_883SC("PROD_TITULO");
            lblTitulo.Text = Traducir_883SC("PROD_TITULO");
            lblProductos.Text = Traducir_883SC("PROD_LBL_PRODUCTOS");
            lblPendientes.Text = Traducir_883SC("PROD_LBL_PENDIENTES");
            lblVinculados.Text = Traducir_883SC("PROD_LBL_VINCULADOS");
            lblFiltro.Text = Traducir_883SC("PROD_LBL_FILTRO");
            btnCrear.Text = Traducir_883SC("PROD_BTN_CREAR");
            btnVincular.Text = Traducir_883SC("PROD_BTN_VINCULAR");
            btnModificar.Text = Traducir_883SC("PROD_BTN_MODIFICAR");
            btnDesvincular.Text = Traducir_883SC("PROD_BTN_DESVINCULAR");
            btnSalir.Text = Traducir_883SC("COMUN_SALIR");
            foreach (DataGridView dgv in new DataGridView[] { dgvProductos, dgvPendientes, dgvVinculados })
            {
                foreach (DataGridViewColumn columna in dgv.Columns)
                {
                    columna.HeaderText = Traducir_883SC(columna.Tag.ToString());
                }
            }
            //La primera entrada del filtro ("Todos") es texto traducible
            if (_proveedores_883SC.Count > 0) { CargarFiltro_883SC(); }
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
            AgregarColumna_883SC(dgvProductos, "colProvRef", "PROD_COL_PROV_REF");
            AgregarColumna_883SC(dgvProductos, "colPrecio", "MAESTRO_COL_PRECIO", "N2");

            foreach (DataGridView dgv in new DataGridView[] { dgvPendientes, dgvVinculados })
            {
                AgregarColumna_883SC(dgv, "colProveedor", "PROD_COL_PROVEEDOR");
                AgregarColumna_883SC(dgv, "colCodigoProv", "PROD_COL_CODIGO_PROV");
                AgregarColumna_883SC(dgv, "colDescripcion", "PROD_COL_DESCRIPCION");
                AgregarColumna_883SC(dgv, "colPrecioLista", "PROD_COL_PRECIO_LISTA", "N2");
                AgregarColumna_883SC(dgv, "colFecha", "PROD_COL_FECHA", "d");
            }
        }

        private string NombreProveedor_883SC(int id)
        {
            foreach (ProveedorBE_883SC p in _proveedores_883SC)
            {
                if (p.Id_883SC == id) { return p.Nombre_883SC; }
            }
            return id.ToString();
        }

        private ProveedorBE_883SC BuscarProveedor_883SC(int id)
        {
            foreach (ProveedorBE_883SC p in _proveedores_883SC)
            {
                if (p.Id_883SC == id) { return p; }
            }
            return null;
        }

        //Combo del filtro: clave 0 = todos los proveedores
        private void CargarFiltro_883SC()
        {
            _cargandoFiltro_883SC = true;
            int seleccionado = cmbFiltro.SelectedValue is int ? (int)cmbFiltro.SelectedValue : 0;
            List<KeyValuePair<int, string>> opciones = new List<KeyValuePair<int, string>>();
            opciones.Add(new KeyValuePair<int, string>(0, Traducir_883SC("PROD_FILTRO_TODOS")));
            foreach (ProveedorBE_883SC p in _proveedores_883SC)
            {
                opciones.Add(new KeyValuePair<int, string>(p.Id_883SC, p.Nombre_883SC));
            }
            cmbFiltro.DataSource = null;
            cmbFiltro.DisplayMember = "Value";
            cmbFiltro.ValueMember = "Key";
            cmbFiltro.DataSource = opciones;
            cmbFiltro.SelectedValue = seleccionado;
            _cargandoFiltro_883SC = false;
        }

        //Recarga los productos; si codigoSeleccionar no es null deja elegido ese producto
        private void CargarProductos_883SC(string codigoSeleccionar)
        {
            dgvProductos.Rows.Clear();
            foreach (ProductoBE_883SC p in productoBLL_883SC.ListarProductos_883SC())
            {
                int fila = dgvProductos.Rows.Add(p.Codigo_883SC, p.Nombre_883SC, p.Stock_883SC, p.StockMinimo_883SC,
                    NombreProveedor_883SC(p.Proveedor_883SC), p.Precio_883SC);
                dgvProductos.Rows[fila].Tag = p;
                if (p.Codigo_883SC == codigoSeleccionar) { dgvProductos.CurrentCell = dgvProductos.Rows[fila].Cells[0]; }
            }
            CargarVinculados_883SC();
        }

        private void CargarPendientes_883SC()
        {
            int? idProveedor = null;
            if (cmbFiltro.SelectedValue is int && (int)cmbFiltro.SelectedValue > 0)
            {
                idProveedor = (int)cmbFiltro.SelectedValue;
            }

            dgvPendientes.SuspendLayout();
            dgvPendientes.Rows.Clear();
            List<ItemListaPrecioBE_883SC> items = listaPrecioBLL_883SC.ListarPendientes_883SC(idProveedor);
            foreach (ItemListaPrecioBE_883SC item in items)
            {
                int fila = dgvPendientes.Rows.Add(NombreProveedor_883SC(item.IdProveedor_883SC), item.CodigoProveedor_883SC,
                    item.Descripcion_883SC, item.PrecioLista_883SC, item.FechaActualizacion_883SC);
                dgvPendientes.Rows[fila].Tag = item;
            }
            dgvPendientes.ResumeLayout();
            if (items.Count == 0) { lblError.Text = Traducir_883SC("PROD_MSG_SIN_PENDIENTES"); }
        }

        //Codigos de proveedor del producto elegido
        private void CargarVinculados_883SC()
        {
            dgvVinculados.Rows.Clear();
            ProductoBE_883SC producto = ProductoSeleccionado_883SC();
            if (producto == null) { return; }
            try
            {
                foreach (ItemListaPrecioBE_883SC item in listaPrecioBLL_883SC.ListarVinculados_883SC(producto.Codigo_883SC))
                {
                    int fila = dgvVinculados.Rows.Add(NombreProveedor_883SC(item.IdProveedor_883SC), item.CodigoProveedor_883SC,
                        item.Descripcion_883SC, item.PrecioLista_883SC, item.FechaActualizacion_883SC);
                    dgvVinculados.Rows[fila].Tag = item;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = Traducir_883SC("COMUN_ERROR_BD") + ex.Message;
            }
        }

        private ProductoBE_883SC ProductoSeleccionado_883SC()
        {
            return dgvProductos.CurrentRow == null ? null : dgvProductos.CurrentRow.Tag as ProductoBE_883SC;
        }

        private ItemListaPrecioBE_883SC PendienteSeleccionado_883SC()
        {
            return dgvPendientes.CurrentRow == null ? null : dgvPendientes.CurrentRow.Tag as ItemListaPrecioBE_883SC;
        }

        private ItemListaPrecioBE_883SC VinculadoSeleccionado_883SC()
        {
            return dgvVinculados.CurrentRow == null ? null : dgvVinculados.CurrentRow.Tag as ItemListaPrecioBE_883SC;
        }

        private void dgvProductos_SelectionChanged_883SC(object sender, EventArgs e)
        {
            CargarVinculados_883SC();
        }

        private void cmbFiltro_SelectedIndexChanged_883SC(object sender, EventArgs e)
        {
            if (_cargandoFiltro_883SC) { return; }
            lblError.Text = "";
            try
            {
                CargarPendientes_883SC();
            }
            catch (Exception ex)
            {
                lblError.Text = Traducir_883SC("COMUN_ERROR_BD") + ex.Message;
            }
        }

        //Recarga productos, vinculados y pendientes despues de una operacion
        private void Refrescar_883SC(string codigoProducto)
        {
            try
            {
                CargarProductos_883SC(codigoProducto);
                CargarPendientes_883SC();
            }
            catch (Exception ex)
            {
                lblError.Text = Traducir_883SC("COMUN_ERROR_BD") + ex.Message;
            }
        }

        private void btnCrear_Click_883SC(object sender, EventArgs e)
        {
            lblError.Text = "";
            ItemListaPrecioBE_883SC item = PendienteSeleccionado_883SC();
            if (item == null)
            {
                lblError.Text = Traducir_883SC("PROD_ERR_SEL_ITEM");
                return;
            }

            frmProductoDatos_883SC dialogo = new frmProductoDatos_883SC(item, BuscarProveedor_883SC(item.IdProveedor_883SC));
            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                Refrescar_883SC(dialogo.ProductoGuardado_883SC.Codigo_883SC);
            }
        }

        private void btnVincular_Click_883SC(object sender, EventArgs e)
        {
            lblError.Text = "";
            ItemListaPrecioBE_883SC item = PendienteSeleccionado_883SC();
            ProductoBE_883SC producto = ProductoSeleccionado_883SC();
            if (item == null)
            {
                lblError.Text = Traducir_883SC("PROD_ERR_SEL_ITEM");
                return;
            }
            if (producto == null)
            {
                lblError.Text = Traducir_883SC("PROD_ERR_SEL_PRODUCTO");
                return;
            }

            try
            {
                listaPrecioBLL_883SC.Vincular_883SC(item, producto);
            }
            catch (ArgumentException ex)
            {
                lblError.Text = ex.Message;
                return;
            }
            catch (Exception)
            {
                MessageBox.Show(Traducir_883SC("PROD_MSG_ERROR_OPERACION"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Refrescar_883SC(producto.Codigo_883SC);
                return;
            }

            MessageBox.Show(string.Format(Traducir_883SC("PROD_MSG_VINCULO_OK"), item.CodigoProveedor_883SC,
                NombreProveedor_883SC(item.IdProveedor_883SC), producto.Nombre_883SC),
                "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Refrescar_883SC(producto.Codigo_883SC);
        }

        private void btnModificar_Click_883SC(object sender, EventArgs e)
        {
            lblError.Text = "";
            ProductoBE_883SC producto = ProductoSeleccionado_883SC();
            if (producto == null)
            {
                lblError.Text = Traducir_883SC("PROD_ERR_SEL_PRODUCTO");
                return;
            }

            List<ItemListaPrecioBE_883SC> vinculados;
            try
            {
                vinculados = listaPrecioBLL_883SC.ListarVinculados_883SC(producto.Codigo_883SC);
            }
            catch (Exception ex)
            {
                lblError.Text = Traducir_883SC("COMUN_ERROR_BD") + ex.Message;
                return;
            }

            frmProductoDatos_883SC dialogo = new frmProductoDatos_883SC(producto, vinculados, _proveedores_883SC);
            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                Refrescar_883SC(producto.Codigo_883SC);
            }
        }

        private void btnDesvincular_Click_883SC(object sender, EventArgs e)
        {
            lblError.Text = "";
            ProductoBE_883SC producto = ProductoSeleccionado_883SC();
            ItemListaPrecioBE_883SC item = VinculadoSeleccionado_883SC();
            if (producto == null)
            {
                lblError.Text = Traducir_883SC("PROD_ERR_SEL_PRODUCTO");
                return;
            }
            if (item == null)
            {
                lblError.Text = Traducir_883SC("PROD_ERR_SEL_VINCULO");
                return;
            }

            try
            {
                listaPrecioBLL_883SC.Desvincular_883SC(item, producto);
            }
            catch (ArgumentException ex)
            {
                lblError.Text = ex.Message;
                return;
            }
            catch (Exception)
            {
                MessageBox.Show(Traducir_883SC("PROD_MSG_ERROR_OPERACION"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Refrescar_883SC(producto.Codigo_883SC);
                return;
            }

            MessageBox.Show(string.Format(Traducir_883SC("PROD_MSG_DESVINCULO_OK"), item.CodigoProveedor_883SC, producto.Nombre_883SC),
                "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Refrescar_883SC(producto.Codigo_883SC);
        }

        private void btnSalir_Click_883SC(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
