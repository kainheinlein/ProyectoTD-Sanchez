using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmRegistrarRecepcion_883SC : Form, IObservadorIdioma_883SC
    {
        public frmRegistrarRecepcion_883SC()
        {
            InitializeComponent();
        }

        OrdenCompraBLL_883SC ordenCompraBLL_883SC = new OrdenCompraBLL_883SC();
        ComprobanteOrdenCompraBLL_883SC comprobanteBLL_883SC = new ComprobanteOrdenCompraBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        private void frmRegistrarRecepcion_Load_883SC(object sender, EventArgs e)
        {
            ConfigurarColumnas_883SC();

            //Solo los dos estados que gestiona este caso de uso
            cboEstado.Items.Add(EstadoOrdenCompra_883SC.Autorizada);
            cboEstado.Items.Add(EstadoOrdenCompra_883SC.EnEjecucion);
            cboEstado.SelectedItem = EstadoOrdenCompra_883SC.Autorizada;
            CargarOrdenes_883SC();

            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmRegistrarRecepcion_FormClosed_883SC;
        }

        private void frmRegistrarRecepcion_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = Traducir_883SC("REC_TITULO");
            lblTitulo.Text = Traducir_883SC("REC_TITULO");
            lblEstado.Text = Traducir_883SC("OC_AUT_LBL_ESTADO");
            lblOrdenes.Text = Traducir_883SC("OC_AUT_LBL_ORDENES");
            lblDetalle.Text = Traducir_883SC("OC_AUT_LBL_DETALLE");
            btnEnviar.Text = Traducir_883SC("REC_BTN_ENVIAR");
            btnRecibir.Text = Traducir_883SC("REC_BTN_RECIBIR");
            btnReimprimir.Text = Traducir_883SC("OC_COMP_BTN_REIMPRIMIR");
            btnSalir.Text = Traducir_883SC("COMUN_SALIR");
            foreach (DataGridView dgv in new DataGridView[] { dgvOrdenes, dgvDetalle })
            {
                foreach (DataGridViewColumn columna in dgv.Columns)
                {
                    columna.HeaderText = Traducir_883SC(columna.Tag.ToString());
                }
            }
            //Vuelve a aplicar el evento Format al combo y refresca la columna de estado de la grilla
            cboEstado.Refresh();
            CargarOrdenes_883SC();
        }

        #endregion

        private string Traducir_883SC(string clave)
        {
            return gestorIdioma_883SC.Traducir_883SC(clave);
        }

        //Clave de traduccion del estado: OC_ESTADO_AUTORIZADA, OC_ESTADO_ENEJECUCION...
        private string TextoEstado_883SC(EstadoOrdenCompra_883SC estado)
        {
            return Traducir_883SC("OC_ESTADO_" + estado.ToString().ToUpper());
        }

        private void cboEstado_Format_883SC(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is EstadoOrdenCompra_883SC)
            {
                e.Value = TextoEstado_883SC((EstadoOrdenCompra_883SC)e.ListItem);
            }
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
            AgregarColumna_883SC(dgvOrdenes, "colNro", "OC_COL_NRO");
            AgregarColumna_883SC(dgvOrdenes, "colFecha", "COMUN_FECHA", "g");
            AgregarColumna_883SC(dgvOrdenes, "colProveedor", "PROD_COL_PROVEEDOR");
            AgregarColumna_883SC(dgvOrdenes, "colEstado", "OC_COL_ESTADO");
            AgregarColumna_883SC(dgvOrdenes, "colTotal", "OC_COL_TOTAL", "N2");

            AgregarColumna_883SC(dgvDetalle, "colCodigo", "MAESTRO_COL_CODIGO");
            AgregarColumna_883SC(dgvDetalle, "colNombre", "COMUN_NOMBRE");
            AgregarColumna_883SC(dgvDetalle, "colCantidad", "REC_COL_PEDIDA");
            AgregarColumna_883SC(dgvDetalle, "colRecibida", "REC_COL_RECIBIDA");
            AgregarColumna_883SC(dgvDetalle, "colPrecio", "OC_COL_PRECIO", "N2");
            AgregarColumna_883SC(dgvDetalle, "colSubtotal", "OC_COL_SUBTOTAL", "N2");
        }

        private EstadoOrdenCompra_883SC EstadoElegido_883SC()
        {
            return (EstadoOrdenCompra_883SC)cboEstado.SelectedItem;
        }

        private OrdenCompraBE_883SC OrdenSeleccionada_883SC()
        {
            return dgvOrdenes.CurrentRow == null ? null : dgvOrdenes.CurrentRow.Tag as OrdenCompraBE_883SC;
        }

        private void CargarOrdenes_883SC()
        {
            if (cboEstado.SelectedItem == null) { return; }

            //Conserva la orden elegida si sigue en la lista
            OrdenCompraBE_883SC anterior = OrdenSeleccionada_883SC();
            dgvOrdenes.Rows.Clear();
            try
            {
                List<OrdenCompraBE_883SC> ordenes = ordenCompraBLL_883SC.ListarPorEstado_883SC(EstadoElegido_883SC());
                foreach (OrdenCompraBE_883SC o in ordenes)
                {
                    int fila = dgvOrdenes.Rows.Add(o.IdOrdenCompra_883SC, o.FechaCreacion_883SC, o.Proveedor_883SC.Nombre_883SC,
                        TextoEstado_883SC(o.Estado_883SC), o.PrecioTotal_883SC);
                    dgvOrdenes.Rows[fila].Tag = o;
                    if (anterior != null && anterior.IdOrdenCompra_883SC == o.IdOrdenCompra_883SC)
                    {
                        dgvOrdenes.CurrentCell = dgvOrdenes.Rows[fila].Cells[0];
                    }
                }
                if (ordenes.Count == 0 && lblError.Text == "")
                {
                    lblError.Text = Traducir_883SC("REC_MSG_SIN_ORDENES");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = Traducir_883SC("COMUN_ERROR_BD") + ex.Message;
            }
            MostrarDetalle_883SC();
        }

        private void MostrarDetalle_883SC()
        {
            dgvDetalle.Rows.Clear();
            OrdenCompraBE_883SC orden = OrdenSeleccionada_883SC();
            if (orden != null)
            {
                foreach (DetalleOrdenCompraBE_883SC d in orden.Detalle_883SC)
                {
                    dgvDetalle.Rows.Add(d.Producto_883SC.Codigo_883SC, d.Producto_883SC.Nombre_883SC, d.Cantidad_883SC,
                        d.CantidadRecibida_883SC.HasValue ? d.CantidadRecibida_883SC.Value.ToString() : "",
                        d.PrecioUnitario_883SC, d.Subtotal_883SC);
                }
            }
            //El envio solo corresponde a una orden Autorizada y la recepcion a una EnEjecucion
            btnEnviar.Enabled = orden != null && orden.Estado_883SC == EstadoOrdenCompra_883SC.Autorizada;
            btnRecibir.Enabled = orden != null && orden.Estado_883SC == EstadoOrdenCompra_883SC.EnEjecucion;
            //El comprobante existe desde el envio
            btnReimprimir.Enabled = btnRecibir.Enabled;
        }

        private void cboEstado_SelectedIndexChanged_883SC(object sender, EventArgs e)
        {
            lblError.Text = "";
            CargarOrdenes_883SC();
        }

        private void dgvOrdenes_SelectionChanged_883SC(object sender, EventArgs e)
        {
            lblError.Text = "";
            MostrarDetalle_883SC();
        }

        private void btnEnviar_Click_883SC(object sender, EventArgs e)
        {
            lblError.Text = "";
            OrdenCompraBE_883SC orden = OrdenSeleccionada_883SC();
            if (orden == null)
            {
                lblError.Text = Traducir_883SC("REC_ERR_SEL_ORDEN");
                return;
            }

            if (MessageBox.Show(string.Format(Traducir_883SC("REC_CONFIRMA_ENVIAR"), orden.IdOrdenCompra_883SC),
                Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                ordenCompraBLL_883SC.Enviar_883SC(orden);
            }
            catch (ArgumentException ex)
            {
                //Orden ya enviada por otro usuario: se recarga la lista para mostrar el estado real
                lblError.Text = ex.Message;
                CargarOrdenes_883SC();
                return;
            }
            catch (Exception)
            {
                //La orden no se modifico: el SP es transaccional
                MessageBox.Show(Traducir_883SC("REC_MSG_ERROR_ENVIO"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(string.Format(Traducir_883SC("REC_MSG_ENVIADA"), orden.IdOrdenCompra_883SC),
                "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //El envio ya esta hecho: si el comprobante falla, se puede reimprimir despues
            MostrarComprobante_883SC(orden.IdOrdenCompra_883SC);
            CargarOrdenes_883SC();
        }

        private void btnReimprimir_Click_883SC(object sender, EventArgs e)
        {
            lblError.Text = "";
            OrdenCompraBE_883SC orden = OrdenSeleccionada_883SC();
            if (orden == null)
            {
                lblError.Text = Traducir_883SC("REC_ERR_SEL_ORDEN");
                return;
            }
            MostrarComprobante_883SC(orden.IdOrdenCompra_883SC);
        }

        private void MostrarComprobante_883SC(int idOrden)
        {
            try
            {
                ComprobanteOrdenCompraBE_883SC comprobante = comprobanteBLL_883SC.Obtener_883SC(idOrden);
                using (frmComprobanteOrdenCompra_883SC frm = new frmComprobanteOrdenCompra_883SC(comprobante))
                {
                    frm.ShowDialog();
                }
            }
            catch (ArgumentException ex)
            {
                lblError.Text = ex.Message;
            }
            catch (Exception)
            {
                MessageBox.Show(Traducir_883SC("OC_COMP_MSG_ERROR"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRecibir_Click_883SC(object sender, EventArgs e)
        {
            lblError.Text = "";
            OrdenCompraBE_883SC orden = OrdenSeleccionada_883SC();
            if (orden == null)
            {
                lblError.Text = Traducir_883SC("REC_ERR_SEL_ORDEN");
                return;
            }

            using (frmRecepcionDatos_883SC dialogo = new frmRecepcionDatos_883SC(orden))
            {
                DialogResult resultado = dialogo.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    string clave = orden.TieneDiferencias_883SC ? "REC_MSG_RECIBIDA_DIF" : "REC_MSG_RECIBIDA";
                    MessageBox.Show(string.Format(Traducir_883SC(clave), orden.IdOrdenCompra_883SC),
                        "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (dialogo.HuboError_883SC)
                {
                    MessageBox.Show(Traducir_883SC("REC_MSG_ERROR_RECEPCION"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //Se recarga siempre: puede haberse cerrado la orden o haber cambiado de estado
            CargarOrdenes_883SC();
        }

        private void btnSalir_Click_883SC(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
