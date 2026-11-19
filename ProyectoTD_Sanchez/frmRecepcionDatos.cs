using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    /// Dialogo para cargar la cantidad recibida de cada linea de una orden EnEjecucion.
    /// DialogResult.OK = recepcion registrada; Cancel = no se registro (HuboError_883SC indica si fue por un error de la base).
    public partial class frmRecepcionDatos_883SC : Form, IObservadorIdioma_883SC
    {
        public frmRecepcionDatos_883SC(OrdenCompraBE_883SC orden)
        {
            InitializeComponent();
            _orden_883SC = orden;
        }

        OrdenCompraBLL_883SC ordenCompraBLL_883SC = new OrdenCompraBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        private OrdenCompraBE_883SC _orden_883SC;
        private bool _huboError_883SC;

        /// true si el dialogo se cerro porque fallo el guardado en la base de datos
        public bool HuboError_883SC
        {
            get { return _huboError_883SC; }
        }

        private void frmRecepcionDatos_Load_883SC(object sender, EventArgs e)
        {
            //Cantidad recibida inicial = cantidad pedida; el usuario corrige las que llegaron incompletas
            foreach (DetalleOrdenCompraBE_883SC d in _orden_883SC.Detalle_883SC)
            {
                dgvLineas.Rows.Add(d.Producto_883SC.Codigo_883SC, d.Producto_883SC.Nombre_883SC, d.Cantidad_883SC, d.Cantidad_883SC);
            }

            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmRecepcionDatos_FormClosed_883SC;
        }

        private void frmRecepcionDatos_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = gestorIdioma_883SC.Traducir_883SC("REC_DLG_TITULO");
            lblTitulo.Text = gestorIdioma_883SC.Traducir_883SC("REC_DLG_TITULO");
            lblOrden.Text = string.Format(gestorIdioma_883SC.Traducir_883SC("REC_DLG_LBL_ORDEN"),
                _orden_883SC.IdOrdenCompra_883SC, _orden_883SC.Proveedor_883SC.Nombre_883SC);
            lblObservaciones.Text = gestorIdioma_883SC.Traducir_883SC("REC_LBL_OBSERVACIONES");
            btnConfirmar.Text = gestorIdioma_883SC.Traducir_883SC("REC_BTN_CONFIRMAR");
            btnCancelar.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_CANCELAR");
            colCodigo.HeaderText = gestorIdioma_883SC.Traducir_883SC("MAESTRO_COL_CODIGO");
            colNombre.HeaderText = gestorIdioma_883SC.Traducir_883SC("COMUN_NOMBRE");
            colPedida.HeaderText = gestorIdioma_883SC.Traducir_883SC("REC_COL_PEDIDA");
            colRecibida.HeaderText = gestorIdioma_883SC.Traducir_883SC("REC_COL_RECIBIDA");
        }

        #endregion

        private void btnConfirmar_Click_883SC(object sender, EventArgs e)
        {
            lblError.Text = "";
            dgvLineas.EndEdit();

            //Cantidades tal como las tipeo el usuario (formato no numerico o negativo = REC_ERR_CANTIDAD)
            Dictionary<string, int> recibidas = new Dictionary<string, int>();
            foreach (DataGridViewRow fila in dgvLineas.Rows)
            {
                int cantidad;
                string texto = Convert.ToString(fila.Cells["colRecibida"].Value);
                if (!int.TryParse(texto.Trim(), NumberStyles.None, CultureInfo.InvariantCulture, out cantidad))
                {
                    lblError.Text = gestorIdioma_883SC.Traducir_883SC("REC_ERR_CANTIDAD");
                    return;
                }
                recibidas[fila.Cells["colCodigo"].Value.ToString()] = cantidad;
            }

            try
            {
                ordenCompraBLL_883SC.RegistrarRecepcion_883SC(_orden_883SC, recibidas, txtObservaciones.Text);
            }
            catch (ArgumentException ex)
            {
                //Cantidad fuera de rango, observaciones largas u orden que ya cambio de estado. En el ultimo caso
                //el usuario cancela y la lista principal se recarga
                lblError.Text = ex.Message;
                return;
            }
            catch (Exception)
            {
                //No se modifico la orden ni el stock: el SP es transaccional
                _huboError_883SC = true;
                this.DialogResult = DialogResult.Cancel;
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click_883SC(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
