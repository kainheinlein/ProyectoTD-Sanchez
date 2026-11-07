using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmImportarListaPrecios_883SC : Form, IObservadorIdioma_883SC
    {
        public frmImportarListaPrecios_883SC()
        {
            InitializeComponent();
        }

        ListaPrecioBLL_883SC listaPrecioBLL_883SC = new ListaPrecioBLL_883SC();
        ProveedorBLL_883SC proveedorBLL_883SC = new ProveedorBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        private const int FILAS_VISTA_PREVIA_883SC = 40;
        //Filas del archivo ya leidas; se vuelven a leer solo al elegir otro archivo
        private List<FilaCSV_883SC> _filasArchivo_883SC;

        private void frmImportarListaPrecios_Load_883SC(object sender, EventArgs e)
        {
            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmImportarListaPrecios_FormClosed_883SC;
            CargarProveedores_883SC(0);
        }

        private void frmImportarListaPrecios_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = gestorIdioma_883SC.Traducir_883SC("LIST_TITULO");
            lblTitulo.Text = gestorIdioma_883SC.Traducir_883SC("LIST_TITULO");
            lblProveedor.Text = gestorIdioma_883SC.Traducir_883SC("LIST_LBL_PROVEEDOR");
            lblArchivo.Text = gestorIdioma_883SC.Traducir_883SC("LIST_LBL_ARCHIVO");
            lblRechazadas.Text = gestorIdioma_883SC.Traducir_883SC("LIST_LBL_RECHAZADAS");
            btnNuevoProveedor.Text = gestorIdioma_883SC.Traducir_883SC("LIST_BTN_NUEVO_PROVEEDOR");
            btnExaminar.Text = gestorIdioma_883SC.Traducir_883SC("LIST_BTN_EXAMINAR");
            btnImportar.Text = gestorIdioma_883SC.Traducir_883SC("LIST_BTN_IMPORTAR");
            lblColCodigo.Text = gestorIdioma_883SC.Traducir_883SC("LIST_LBL_COL_CODIGO");
            lblColDescripcion.Text = gestorIdioma_883SC.Traducir_883SC("LIST_LBL_COL_DESCRIPCION");
            lblColPrecio.Text = gestorIdioma_883SC.Traducir_883SC("LIST_LBL_COL_PRECIO");
            lblPrimeraFila.Text = gestorIdioma_883SC.Traducir_883SC("LIST_LBL_PRIMERA_FILA");
            lblVistaPrevia.Text = gestorIdioma_883SC.Traducir_883SC("LIST_LBL_VISTA_PREVIA");
            if (dgvVista.Columns.Count > 0) { dgvVista.Columns[0].HeaderText = gestorIdioma_883SC.Traducir_883SC("LIST_COL_FILA"); }
            colFila.HeaderText = gestorIdioma_883SC.Traducir_883SC("LIST_COL_FILA");
            colCodigo.HeaderText = gestorIdioma_883SC.Traducir_883SC("LIST_COL_CODIGO");
            colMotivo.HeaderText = gestorIdioma_883SC.Traducir_883SC("LIST_COL_MOTIVO");
        }

        #endregion

        //Carga el combo; si idSeleccionar > 0 deja elegido ese proveedor
        private void CargarProveedores_883SC(int idSeleccionar)
        {
            try
            {
                cmbProveedor.DataSource = null;
                List<ProveedorBE_883SC> proveedores = proveedorBLL_883SC.ListarProveedoresActivos_883SC();
                cmbProveedor.DisplayMember = "Nombre_883SC";
                cmbProveedor.DataSource = proveedores;
                cmbProveedor.SelectedIndex = -1;
                foreach (ProveedorBE_883SC p in proveedores)
                {
                    if (p.Id_883SC == idSeleccionar) { cmbProveedor.SelectedItem = p; }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_ERROR_BD") + ex.Message;
            }
        }

        private void btnNuevoProveedor_Click_883SC(object sender, EventArgs e)
        {
            frmAltaProveedor_883SC frmAlta = new frmAltaProveedor_883SC();
            if (frmAlta.ShowDialog() == DialogResult.OK)
            {
                CargarProveedores_883SC(frmAlta.ProveedorRegistrado_883SC.Id_883SC);
            }
        }

        private void btnExaminar_Click_883SC(object sender, EventArgs e)
        {
            string ruta;
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Filter = gestorIdioma_883SC.Traducir_883SC("LIST_FILTRO_ARCHIVO");
                dialogo.CheckFileExists = true;
                if (dialogo.ShowDialog() != DialogResult.OK) { return; }
                ruta = dialogo.FileName;
            }

            lblError.Text = "";
            dgvRechazadas.Rows.Clear();
            try
            {
                _filasArchivo_883SC = listaPrecioBLL_883SC.LeerArchivo_883SC(ruta);
            }
            catch (ArgumentException ex)
            {
                _filasArchivo_883SC = null;
                txtArchivo.Text = "";
                LimpiarVistaPrevia_883SC();
                lblError.Text = ex.Message;
                return;
            }
            txtArchivo.Text = ruta;
            MostrarVistaPrevia_883SC();
        }

        private void LimpiarVistaPrevia_883SC()
        {
            dgvVista.Columns.Clear();
            dgvVista.Rows.Clear();
            cmbColCodigo.Items.Clear();
            cmbColDescripcion.Items.Clear();
            cmbColPrecio.Items.Clear();
        }

        //Muestra las primeras filas con las columnas rotuladas A, B, C... y propone el mapeo
        private void MostrarVistaPrevia_883SC()
        {
            LimpiarVistaPrevia_883SC();

            int cantidadColumnas = 0;
            foreach (FilaCSV_883SC fila in _filasArchivo_883SC)
            {
                if (fila.Valores_883SC.Length > cantidadColumnas) { cantidadColumnas = fila.Valores_883SC.Length; }
            }

            dgvVista.Columns.Add("colNroFila", gestorIdioma_883SC.Traducir_883SC("LIST_COL_FILA"));
            for (int c = 0; c < cantidadColumnas; c++)
            {
                string letra = LetraColumna_883SC(c);
                dgvVista.Columns.Add("colVista" + c, letra);
                cmbColCodigo.Items.Add(letra);
                cmbColDescripcion.Items.Add(letra);
                cmbColPrecio.Items.Add(letra);
            }

            for (int i = 0; i < _filasArchivo_883SC.Count && i < FILAS_VISTA_PREVIA_883SC; i++)
            {
                object[] celdas = new object[cantidadColumnas + 1];
                celdas[0] = _filasArchivo_883SC[i].NumeroFila_883SC;
                for (int c = 0; c < _filasArchivo_883SC[i].Valores_883SC.Length; c++)
                {
                    celdas[c + 1] = _filasArchivo_883SC[i].Valores_883SC[c];
                }
                dgvVista.Rows.Add(celdas);
            }

            MapeoListaBE_883SC sugerido = listaPrecioBLL_883SC.SugerirMapeo_883SC(_filasArchivo_883SC);
            cmbColCodigo.SelectedIndex = sugerido.ColCodigo_883SC;
            cmbColDescripcion.SelectedIndex = sugerido.ColDescripcion_883SC;
            cmbColPrecio.SelectedIndex = sugerido.ColPrecio_883SC;
            nudPrimeraFila.Value = Math.Max(nudPrimeraFila.Minimum, Math.Min(nudPrimeraFila.Maximum, sugerido.PrimeraFila_883SC));
        }

        //0 -> A, 25 -> Z, 26 -> AA (como las columnas de una planilla)
        private string LetraColumna_883SC(int indice)
        {
            string letra = "";
            for (int n = indice + 1; n > 0; n = (n - 1) / 26)
            {
                letra = (char)('A' + (n - 1) % 26) + letra;
            }
            return letra;
        }

        private void btnImportar_Click_883SC(object sender, EventArgs e)
        {
            lblError.Text = "";
            dgvRechazadas.Rows.Clear();

            ProveedorBE_883SC proveedor = cmbProveedor.SelectedItem as ProveedorBE_883SC;
            if (proveedor == null)
            {
                lblError.Text = gestorIdioma_883SC.Traducir_883SC("LIST_ERR_PROVEEDOR");
                return;
            }
            if (_filasArchivo_883SC == null)
            {
                lblError.Text = gestorIdioma_883SC.Traducir_883SC("LIST_ERR_ARCHIVO");
                return;
            }

            MapeoListaBE_883SC mapeo = new MapeoListaBE_883SC();
            mapeo.ColCodigo_883SC = cmbColCodigo.SelectedIndex;
            mapeo.ColDescripcion_883SC = cmbColDescripcion.SelectedIndex;
            mapeo.ColPrecio_883SC = cmbColPrecio.SelectedIndex;
            mapeo.PrimeraFila_883SC = (int)nudPrimeraFila.Value;

            ResumenImportacionBE_883SC resumen;
            try
            {
                resumen = listaPrecioBLL_883SC.ImportarLista_883SC(proveedor.Id_883SC, _filasArchivo_883SC, mapeo);
            }
            catch (ArgumentException ex)
            {
                //Columnas mal elegidas o sin items validos: se puede corregir y reintentar
                lblError.Text = ex.Message;
                return;
            }
            catch (Exception)
            {
                //Error al guardar: no se guardo nada
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("LIST_MSG_ERROR_GUARDAR"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (FilaRechazadaBE_883SC rechazada in resumen.Rechazadas_883SC)
            {
                dgvRechazadas.Rows.Add(rechazada.NumeroFila_883SC, rechazada.CodigoProveedor_883SC, rechazada.Motivo_883SC);
            }
            MessageBox.Show(
                string.Format(gestorIdioma_883SC.Traducir_883SC("LIST_MSG_OK"),
                    resumen.Importados_883SC, resumen.PreciosVentaActualizados_883SC,
                    resumen.Pendientes_883SC, resumen.Rechazadas_883SC.Count),
                "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
