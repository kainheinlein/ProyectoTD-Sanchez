using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmProductoDatos_883SC : Form, IObservadorIdioma_883SC
    {
        /// Alta: el proveedor y el precio de lista salen del item pendiente
        public frmProductoDatos_883SC(ItemListaPrecioBE_883SC item, ProveedorBE_883SC proveedor)
        {
            InitializeComponent();
            _modificando_883SC = false;
            _item_883SC = item;
            _itemsPorProveedor_883SC[item.IdProveedor_883SC] = item;
            _proveedores_883SC = new List<ProveedorBE_883SC>();
            _proveedores_883SC.Add(proveedor);
        }

        /// Modificacion: el proveedor de referencia se elige entre los que tienen un codigo vinculado al producto
        /// (mas el actual, que se muestra aunque no tenga vinculo)
        public frmProductoDatos_883SC(ProductoBE_883SC producto, List<ItemListaPrecioBE_883SC> vinculados, List<ProveedorBE_883SC> proveedores)
        {
            InitializeComponent();
            _modificando_883SC = true;
            _producto_883SC = producto;
            _proveedores_883SC = new List<ProveedorBE_883SC>();
            foreach (ItemListaPrecioBE_883SC vinculado in vinculados)
            {
                _itemsPorProveedor_883SC[vinculado.IdProveedor_883SC] = vinculado;
            }
            foreach (ProveedorBE_883SC p in proveedores)
            {
                if (_itemsPorProveedor_883SC.ContainsKey(p.Id_883SC) || p.Id_883SC == producto.Proveedor_883SC)
                {
                    _proveedores_883SC.Add(p);
                }
            }
            _sinVinculos_883SC = vinculados.Count == 0;
        }

        ProductoBLL_883SC productoBLL_883SC = new ProductoBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        private bool _modificando_883SC;
        private bool _sinVinculos_883SC;
        private ItemListaPrecioBE_883SC _item_883SC;
        private ProductoBE_883SC _producto_883SC;
        private List<ProveedorBE_883SC> _proveedores_883SC;
        private Dictionary<int, ItemListaPrecioBE_883SC> _itemsPorProveedor_883SC = new Dictionary<int, ItemListaPrecioBE_883SC>();
        private ProductoBE_883SC _productoGuardado_883SC;

        /// Producto guardado (con su precio de venta), o null si se cancelo
        public ProductoBE_883SC ProductoGuardado_883SC
        {
            get { return _productoGuardado_883SC; }
        }

        private void frmProductoDatos_Load_883SC(object sender, EventArgs e)
        {
            cmbProveedor.DisplayMember = "Nombre_883SC";
            cmbProveedor.DataSource = _proveedores_883SC;

            if (_modificando_883SC)
            {
                txtCodigo.Text = _producto_883SC.Codigo_883SC;
                txtCodigo.ReadOnly = true;
                txtNombre.Text = _producto_883SC.Nombre_883SC;
                txtDescripcion.Text = _producto_883SC.Tipo_883SC;
                txtStockMinimo.Text = _producto_883SC.StockMinimo_883SC.ToString();
                foreach (ProveedorBE_883SC p in _proveedores_883SC)
                {
                    if (p.Id_883SC == _producto_883SC.Proveedor_883SC) { cmbProveedor.SelectedItem = p; }
                }
                cmbProveedor.Enabled = !_sinVinculos_883SC;
            }
            else
            {
                txtDescripcion.Text = _item_883SC.Descripcion_883SC;
                cmbProveedor.Enabled = false;
            }
            MostrarPrecioLista_883SC();

            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmProductoDatos_FormClosed_883SC;
            if (_modificando_883SC && _sinVinculos_883SC)
            {
                lblError.Text = gestorIdioma_883SC.Traducir_883SC("PROD_ERR_SIN_VINCULOS");
            }
            if (_modificando_883SC) { txtNombre.Focus(); } else { txtCodigo.Focus(); }
        }

        private void frmProductoDatos_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            string titulo = gestorIdioma_883SC.Traducir_883SC(_modificando_883SC ? "PROD_MOD_TITULO" : "PROD_ALTA_TITULO");
            this.Text = titulo;
            lblTitulo.Text = titulo;
            lblCodigo.Text = gestorIdioma_883SC.Traducir_883SC("PROD_LBL_CODIGO");
            lblNombre.Text = gestorIdioma_883SC.Traducir_883SC("PROD_LBL_NOMBRE");
            lblDescripcion.Text = gestorIdioma_883SC.Traducir_883SC("PROD_LBL_DESCRIPCION");
            lblStockMinimo.Text = gestorIdioma_883SC.Traducir_883SC("PROD_LBL_STOCK_MIN");
            lblProveedor.Text = gestorIdioma_883SC.Traducir_883SC(_modificando_883SC ? "PROD_LBL_PROV_REF" : "PROD_LBL_PROVEEDOR_ITEM");
            lblPrecioLista.Text = gestorIdioma_883SC.Traducir_883SC("PROD_LBL_PRECIO_LISTA");
            btnGuardar.Text = gestorIdioma_883SC.Traducir_883SC("PROD_BTN_GUARDAR");
            btnCancelar.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_CANCELAR");
        }

        #endregion

        private void cmbProveedor_SelectedIndexChanged_883SC(object sender, EventArgs e)
        {
            MostrarPrecioLista_883SC();
        }

        //Precio de lista del proveedor elegido; vacio si el actual no tiene codigo vinculado
        private void MostrarPrecioLista_883SC()
        {
            ProveedorBE_883SC proveedor = cmbProveedor.SelectedItem as ProveedorBE_883SC;
            ItemListaPrecioBE_883SC item;
            if (proveedor != null && _itemsPorProveedor_883SC.TryGetValue(proveedor.Id_883SC, out item))
            {
                txtPrecioLista.Text = item.PrecioLista_883SC.ToString("N2");
            }
            else
            {
                txtPrecioLista.Text = "";
            }
        }

        private void btnGuardar_Click_883SC(object sender, EventArgs e)
        {
            lblError.Text = "";

            int stockMinimo;
            if (!int.TryParse(txtStockMinimo.Text.Trim(), NumberStyles.None, CultureInfo.InvariantCulture, out stockMinimo))
            {
                lblError.Text = gestorIdioma_883SC.Traducir_883SC("PROD_ERR_STOCK_MIN");
                return;
            }

            ProductoBE_883SC producto = new ProductoBE_883SC();
            producto.Codigo_883SC = txtCodigo.Text;
            producto.Nombre_883SC = txtNombre.Text;
            producto.Tipo_883SC = txtDescripcion.Text;
            producto.StockMinimo_883SC = stockMinimo;

            try
            {
                if (_modificando_883SC)
                {
                    ProveedorBE_883SC elegido = (ProveedorBE_883SC)cmbProveedor.SelectedItem;
                    ItemListaPrecioBE_883SC item;
                    _itemsPorProveedor_883SC.TryGetValue(elegido.Id_883SC, out item);
                    producto.Proveedor_883SC = elegido.Id_883SC;
                    _productoGuardado_883SC = productoBLL_883SC.ModificarProducto_883SC(producto, item);
                }
                else
                {
                    _productoGuardado_883SC = productoBLL_883SC.RegistrarProducto_883SC(producto, _item_883SC);
                }
            }
            catch (ArgumentException ex)
            {
                //Dato invalido o codigo repetido: el dialogo queda abierto para corregir
                lblError.Text = ex.Message;
                return;
            }
            catch (Exception)
            {
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC(_modificando_883SC ? "PROD_MSG_ERROR_OPERACION" : "PROD_MSG_ERROR_ALTA"),
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                return;
            }

            string mensaje = _modificando_883SC
                ? string.Format(gestorIdioma_883SC.Traducir_883SC("PROD_MSG_MOD_OK"), _productoGuardado_883SC.Nombre_883SC)
                : string.Format(gestorIdioma_883SC.Traducir_883SC("PROD_MSG_ALTA_OK"), _productoGuardado_883SC.Nombre_883SC, _productoGuardado_883SC.Precio_883SC.ToString("N2"));
            MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click_883SC(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
