using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmBitacoraCambios_883SC : Form, IObservadorIdioma_883SC
    {
        public frmBitacoraCambios_883SC()
        {
            InitializeComponent();
        }

        ProductoCBLL_883SC productoCBLL_883SC = new ProductoCBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        //Aviso de resultado vacio: se vuelve a calcular al cambiar de idioma
        private bool _sinResultados_883SC = false;

        private void frmBitacoraCambios_Load_883SC(object sender, EventArgs e)
        {
            ConfigurarColumnas_883SC();
            LimpiarFiltros_883SC();
            CargarCombos_883SC();
            Cargar_883SC(null, null, null, null);

            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmBitacoraCambios_FormClosed_883SC;
            ActualizarTextos_883SC();
        }

        private void frmBitacoraCambios_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = Traducir_883SC("BITC_TITULO");
            lblTitulo.Text = Traducir_883SC("BITC_TITULO").ToUpper();
            lblCodigo.Text = Traducir_883SC("MAESTRO_COL_CODIGO");
            lblNombre.Text = Traducir_883SC("COMUN_NOMBRE");
            lblDesde.Text = Traducir_883SC("BITC_LBL_DESDE");
            lblHasta.Text = Traducir_883SC("BITC_LBL_HASTA");
            btnAplicar.Text = Traducir_883SC("BITC_BTN_APLICAR");
            btnLimpiar.Text = Traducir_883SC("BITC_BTN_LIMPIAR");
            btnActivar.Text = Traducir_883SC("BITC_BTN_ACTIVAR");
            btnSalir.Text = Traducir_883SC("COMUN_SALIR");
            foreach (DataGridViewColumn columna in dgvCambios.Columns)
            {
                columna.HeaderText = Traducir_883SC(columna.Tag.ToString());
            }
            if (_sinResultados_883SC) { lblError.Text = Traducir_883SC("BITC_MSG_SIN_RESULTADOS"); }
        }

        #endregion

        private string Traducir_883SC(string clave)
        {
            return gestorIdioma_883SC.Traducir_883SC(clave);
        }

        private void AgregarColumna_883SC(string nombre, string claveEncabezado, int peso, string formato = null)
        {
            DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
            columna.Name = nombre;
            columna.Tag = claveEncabezado;
            columna.ReadOnly = true;
            columna.FillWeight = peso;
            if (formato != null) { columna.DefaultCellStyle.Format = formato; }
            dgvCambios.Columns.Add(columna);
        }

        private void AgregarColumnaCheck_883SC(string nombre, string claveEncabezado, int peso)
        {
            DataGridViewCheckBoxColumn columna = new DataGridViewCheckBoxColumn();
            columna.Name = nombre;
            columna.Tag = claveEncabezado;
            columna.ReadOnly = true;
            columna.FillWeight = peso;
            dgvCambios.Columns.Add(columna);
        }

        private void ConfigurarColumnas_883SC()
        {
            AgregarColumna_883SC("colId", "BITC_COL_ID", 8);
            AgregarColumna_883SC("colCodigo", "MAESTRO_COL_CODIGO", 10);
            AgregarColumna_883SC("colFecha", "COMUN_FECHA", 11, "d");
            AgregarColumna_883SC("colHora", "BITC_COL_HORA", 9);
            AgregarColumna_883SC("colProveedor", "PROD_COL_PROVEEDOR", 9);
            AgregarColumna_883SC("colNombre", "COMUN_NOMBRE", 18);
            AgregarColumna_883SC("colDescripcion", "MAESTRO_COL_DESCRIPCION", 20);
            AgregarColumna_883SC("colStock", "MAESTRO_COL_STOCK", 8);
            AgregarColumna_883SC("colPrecio", "MAESTRO_COL_PRECIO", 11, "N2");
            AgregarColumna_883SC("colStockMin", "PROD_COL_STOCK_MIN", 9);
            AgregarColumnaCheck_883SC("colBaja", "BITC_COL_BAJA", 7);
            AgregarColumnaCheck_883SC("colVigente", "BITC_COL_VIGENTE", 8);
        }

        private void CargarCombos_883SC()
        {
            try
            {
                CargarCombo_883SC(cboCodigo, productoCBLL_883SC.ListarCodigos_883SC());
                CargarCombo_883SC(cboNombre, productoCBLL_883SC.ListarNombres_883SC());
            }
            catch (Exception ex)
            {
                MostrarError_883SC(ex);
            }
        }

        private void CargarCombo_883SC(ComboBox combo, List<string> valores)
        {
            combo.Items.Clear();
            combo.Items.AddRange(valores.ToArray());
            combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combo.AutoCompleteSource = AutoCompleteSource.ListItems;
            combo.Text = "";
        }

        private void LimpiarFiltros_883SC()
        {
            cboCodigo.Text = "";
            cboNombre.Text = "";
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
            //Sin tilde = sin filtro de fecha
            dtpDesde.Checked = false;
            dtpHasta.Checked = false;
        }

        private DateTime? FechaFiltro_883SC(DateTimePicker dtp)
        {
            return dtp.Checked ? (DateTime?)dtp.Value.Date : null;
        }

        private void MostrarError_883SC(Exception ex)
        {
            if (ex is ArgumentException || ex is UnauthorizedAccessException)
            {
                lblError.Text = ex.Message;
            }
            else
            {
                lblError.Text = Traducir_883SC("COMUN_ERROR_BD") + ex.Message;
            }
        }

        private ProductoCBE_883SC VersionSeleccionada_883SC()
        {
            return dgvCambios.CurrentRow == null ? null : dgvCambios.CurrentRow.Tag as ProductoCBE_883SC;
        }

        //Sin filtros (todo null) lista todas las versiones; con filtros usa la busqueda
        private void Cargar_883SC(string codigo, string nombre, DateTime? desde, DateTime? hasta)
        {
            lblError.Text = "";
            _sinResultados_883SC = false;
            dgvCambios.Rows.Clear();
            try
            {
                bool sinFiltros = string.IsNullOrEmpty(codigo) && string.IsNullOrEmpty(nombre) && !desde.HasValue && !hasta.HasValue;
                List<ProductoCBE_883SC> cambios = sinFiltros
                    ? productoCBLL_883SC.ListarCambios_883SC()
                    : productoCBLL_883SC.BuscarCambios_883SC(codigo, nombre, desde, hasta);
                foreach (ProductoCBE_883SC c in cambios)
                {
                    int fila = dgvCambios.Rows.Add(c.IdCambio_883SC, c.Codigo_883SC, c.Fecha_883SC, c.Hora_883SC.ToString(@"hh\:mm\:ss"),
                        c.Proveedor_883SC, c.Nombre_883SC, c.Descripcion_883SC, c.Stock_883SC, c.Precio_883SC, c.StockMinimo_883SC,
                        c.Baja_883SC, c.Vigente_883SC);
                    DataGridViewRow row = dgvCambios.Rows[fila];
                    row.Tag = c;
                    if (c.Vigente_883SC)
                    {
                        //La version vigente (Act = 1) se resalta
                        row.DefaultCellStyle.BackColor = Color.FromArgb(198, 239, 206);
                        row.DefaultCellStyle.Font = new Font(dgvCambios.Font, FontStyle.Bold);
                    }
                }
                if (cambios.Count == 0)
                {
                    _sinResultados_883SC = true;
                    lblError.Text = Traducir_883SC("BITC_MSG_SIN_RESULTADOS");
                }
            }
            catch (Exception ex)
            {
                MostrarError_883SC(ex);
            }
            ActualizarBotones_883SC();
        }

        //Activar solo con una fila elegida que no sea la vigente
        private void ActualizarBotones_883SC()
        {
            ProductoCBE_883SC version = VersionSeleccionada_883SC();
            btnActivar.Enabled = version != null && !version.Vigente_883SC;
        }

        private void dgvCambios_SelectionChanged_883SC(object sender, EventArgs e)
        {
            ActualizarBotones_883SC();
        }

        private void btnAplicar_Click_883SC(object sender, EventArgs e)
        {
            Cargar_883SC(cboCodigo.Text, cboNombre.Text, FechaFiltro_883SC(dtpDesde), FechaFiltro_883SC(dtpHasta));
        }

        private void btnLimpiar_Click_883SC(object sender, EventArgs e)
        {
            LimpiarFiltros_883SC();
            Cargar_883SC(null, null, null, null);
        }

        private void btnActivar_Click_883SC(object sender, EventArgs e)
        {
            lblError.Text = "";
            ProductoCBE_883SC version = VersionSeleccionada_883SC();
            if (version == null)
            {
                lblError.Text = Traducir_883SC("BITC_ERR_SELECCION");
                return;
            }
            if (version.Vigente_883SC)
            {
                lblError.Text = Traducir_883SC("BITC_ERR_YA_VIGENTE");
                return;
            }

            string si = Traducir_883SC("BITC_VAL_SI");
            string no = Traducir_883SC("BITC_VAL_NO");
            string mensaje = string.Format(Traducir_883SC("BITC_MSG_CONFIRMAR"), version.IdCambio_883SC, version.Codigo_883SC,
                version.Nombre_883SC, version.Proveedor_883SC, version.Stock_883SC, version.Precio_883SC.ToString("N2"),
                version.StockMinimo_883SC, version.Baja_883SC ? si : no);
            if (MessageBox.Show(mensaje, Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                productoCBLL_883SC.ActivarVersion_883SC(version);
            }
            catch (ArgumentException ex)
            {
                //Version inexistente, ya vigente o proveedor dado de baja. Se recarga para mostrar el estado real
                Recargar_883SC();
                lblError.Text = ex.Message;
                return;
            }
            catch (UnauthorizedAccessException ex)
            {
                lblError.Text = ex.Message;
                return;
            }
            catch (Exception)
            {
                //El SP es transaccional: no se cambio nada
                MessageBox.Show(Traducir_883SC("BITC_MSG_ERROR_ACTIVAR"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(string.Format(Traducir_883SC("BITC_MSG_OK"), version.Codigo_883SC, version.IdCambio_883SC),
                "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Recargar_883SC();
        }

        //Vuelve a consultar con los filtros que estan en pantalla
        private void Recargar_883SC()
        {
            Cargar_883SC(cboCodigo.Text, cboNombre.Text, FechaFiltro_883SC(dtpDesde), FechaFiltro_883SC(dtpHasta));
        }

        private void btnSalir_Click_883SC(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
