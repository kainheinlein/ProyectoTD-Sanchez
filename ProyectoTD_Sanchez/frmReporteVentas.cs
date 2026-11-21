using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmReporteVentas_883SC : Form, IObservadorIdioma_883SC
    {
        public frmReporteVentas_883SC()
        {
            InitializeComponent();
        }

        ReporteVentasBLL_883SC reporteBLL_883SC = new ReporteVentasBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        private ReporteVentasBE_883SC reporteActual_883SC = null;
        private bool cargandoFechas_883SC = false;

        private void frmReporteVentas_Load_883SC(object sender, EventArgs e)
        {
            ConfigurarColumnas_883SC();
            dtpDesde.MaxDate = DateTime.Today;
            dtpHasta.MaxDate = DateTime.Today;
            RestablecerFechas_883SC();
            MostrarVistaPrevia_883SC();

            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmReporteVentas_FormClosed_883SC;
        }

        private void frmReporteVentas_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = Traducir_883SC("REP_TITULO");
            lblTitulo.Text = Traducir_883SC("REP_TITULO").ToUpper();
            gbPeriodo.Text = Traducir_883SC("REP_GRP_PERIODO");
            lblDesde.Text = Traducir_883SC("REP_LBL_DESDE");
            lblHasta.Text = Traducir_883SC("REP_LBL_HASTA");
            btnGenerar.Text = Traducir_883SC("REP_BTN_GENERAR");
            btnLimpiar.Text = Traducir_883SC("REP_BTN_LIMPIAR");
            btnExportar.Text = Traducir_883SC("REP_BTN_EXPORTAR");
            btnSalir.Text = Traducir_883SC("COMUN_SALIR");
            gbResumen.Text = Traducir_883SC("REP_GRP_RESUMEN");
            lblCantVentasTit.Text = Traducir_883SC("REP_LBL_CANT_VENTAS");
            lblUnidadesTit.Text = Traducir_883SC("REP_LBL_UNIDADES");
            lblMontoTit.Text = Traducir_883SC("REP_LBL_MONTO");
            lblTicketTit.Text = Traducir_883SC("REP_LBL_TICKET");
            lblVentasDia.Text = Traducir_883SC("REP_LBL_VENTAS_DIA");
            lblTop.Text = Traducir_883SC("REP_LBL_TOP");
            foreach (DataGridView dgv in new DataGridView[] { dgvDias, dgvTop })
            {
                foreach (DataGridViewColumn columna in dgv.Columns)
                {
                    columna.HeaderText = Traducir_883SC(columna.Tag.ToString());
                }
            }
            //Los formatos de fecha e importe dependen del idioma: se vuelve a dibujar lo que haya en pantalla
            lblError.Text = "";
            MostrarVistaPrevia_883SC();
        }

        #endregion

        private string Traducir_883SC(string clave)
        {
            return gestorIdioma_883SC.Traducir_883SC(clave);
        }

        private void AgregarColumna_883SC(DataGridView dgv, string nombre, string claveEncabezado, bool derecha)
        {
            DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
            columna.Name = nombre;
            columna.Tag = claveEncabezado;
            columna.ReadOnly = true;
            columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            if (derecha) { columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; }
            dgv.Columns.Add(columna);
        }

        private void ConfigurarColumnas_883SC()
        {
            AgregarColumna_883SC(dgvDias, "colFecha", "COMUN_FECHA", false);
            AgregarColumna_883SC(dgvDias, "colCantidad", "REP_COL_CANT_VENTAS", true);
            AgregarColumna_883SC(dgvDias, "colImporte", "REP_COL_IMPORTE", true);

            AgregarColumna_883SC(dgvTop, "colCodigo", "MAESTRO_COL_CODIGO", false);
            AgregarColumna_883SC(dgvTop, "colProducto", "REP_COL_PRODUCTO", false);
            AgregarColumna_883SC(dgvTop, "colUnidades", "REP_COL_UNIDADES", true);
            AgregarColumna_883SC(dgvTop, "colImporteTop", "REP_COL_IMPORTE", true);
        }

        private void RestablecerFechas_883SC()
        {
            cargandoFechas_883SC = true;
            DateTime hoy = DateTime.Today;
            dtpDesde.Value = new DateTime(hoy.Year, hoy.Month, 1);
            dtpHasta.Value = hoy;
            cargandoFechas_883SC = false;
        }

        //Dibuja reporteActual_883SC; con null deja los indicadores en cero y las grillas vacias
        private void MostrarVistaPrevia_883SC()
        {
            ReporteVentasBE_883SC r = reporteActual_883SC;
            lblCantVentas.Text = reporteBLL_883SC.FormatearEntero_883SC(r == null ? 0 : r.CantidadVentas_883SC);
            lblUnidades.Text = reporteBLL_883SC.FormatearEntero_883SC(r == null ? 0 : r.UnidadesVendidas_883SC);
            lblMonto.Text = reporteBLL_883SC.FormatearImporte_883SC(r == null ? 0m : r.MontoTotal_883SC);
            lblTicket.Text = reporteBLL_883SC.FormatearImporte_883SC(r == null ? 0m : r.TicketPromedio_883SC);
            lblTotal.Text = Traducir_883SC("REP_LBL_TOTAL") + " " + reporteBLL_883SC.FormatearImporte_883SC(r == null ? 0m : r.MontoTotal_883SC);

            dgvDias.Rows.Clear();
            dgvTop.Rows.Clear();
            if (r != null)
            {
                foreach (VentaDiariaBE_883SC dia in r.VentasPorDia_883SC)
                {
                    dgvDias.Rows.Add(reporteBLL_883SC.FormatearFecha_883SC(dia.Fecha_883SC),
                        reporteBLL_883SC.FormatearEntero_883SC(dia.CantidadVentas_883SC),
                        reporteBLL_883SC.FormatearImporte_883SC(dia.Importe_883SC));
                }
                foreach (ProductoVendidoBE_883SC p in r.TopProductos_883SC)
                {
                    dgvTop.Rows.Add(p.Codigo_883SC, p.Nombre_883SC,
                        reporteBLL_883SC.FormatearEntero_883SC(p.Unidades_883SC),
                        reporteBLL_883SC.FormatearImporte_883SC(p.Importe_883SC));
                }
            }
            //Solo se exporta un reporte con ventas
            btnExportar.Enabled = r != null && r.CantidadVentas_883SC > 0;
        }

        private void LimpiarVistaPrevia_883SC()
        {
            reporteActual_883SC = null;
            MostrarVistaPrevia_883SC();
        }

        //Cambiar una fecha despues de generar invalida la vista previa
        private void dtpFecha_ValueChanged_883SC(object sender, EventArgs e)
        {
            if (cargandoFechas_883SC) { return; }
            lblError.Text = "";
            if (reporteActual_883SC != null) { LimpiarVistaPrevia_883SC(); }
        }

        private void btnGenerar_Click_883SC(object sender, EventArgs e)
        {
            lblError.Text = "";
            LimpiarVistaPrevia_883SC();
            try
            {
                ReporteVentasBE_883SC reporte = reporteBLL_883SC.GenerarReporte_883SC(dtpDesde.Value.Date, dtpHasta.Value.Date);
                reporteActual_883SC = reporte;
                MostrarVistaPrevia_883SC();
                if (reporte.CantidadVentas_883SC == 0)
                {
                    lblError.Text = Traducir_883SC("REP_MSG_SIN_VENTAS");
                }
            }
            catch (ArgumentException ex)
            {
                lblError.Text = ex.Message;
            }
            catch (UnauthorizedAccessException ex)
            {
                lblError.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblError.Text = Traducir_883SC("REP_ERR_GENERAR") + ex.Message;
            }
        }

        private void btnLimpiar_Click_883SC(object sender, EventArgs e)
        {
            lblError.Text = "";
            RestablecerFechas_883SC();
            LimpiarVistaPrevia_883SC();
        }

        private void btnExportar_Click_883SC(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (reporteActual_883SC == null) { return; }

            string ruta = ElegirRuta_883SC();
            if (ruta == null) { return; }//Cancelo el cuadro de guardado: no se genera nada ni se registra el evento

            try
            {
                reporteBLL_883SC.ExportarPdf_883SC(reporteActual_883SC, ruta);
            }
            catch (ArgumentException ex)
            {
                lblError.Text = ex.Message;
                return;
            }
            catch (UnauthorizedAccessException ex)
            {
                lblError.Text = ex.Message;
                return;
            }
            catch (Exception ex)
            {
                //Archivo en uso, sin permisos, verificacion fallida, etc.
                lblError.Text = Traducir_883SC("REP_ERR_EXPORTAR") + ex.Message;
                return;
            }

            if (MessageBox.Show(Traducir_883SC("REP_MSG_EXPORTADO") + Environment.NewLine + Traducir_883SC("REP_MSG_ABRIR"),
                Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    lblError.Text = Traducir_883SC("REP_MSG_ERROR_ABRIR") + ex.Message;
                }
            }
        }

        //Devuelve la ruta elegida o null si se cancela. Si el archivo existe pide confirmar; si el usuario no acepta vuelve al cuadro de guardado
        private string ElegirRuta_883SC()
        {
            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Title = Traducir_883SC("REP_DLG_TITULO");
                dialogo.Filter = Traducir_883SC("REP_DLG_FILTRO");
                dialogo.DefaultExt = "pdf";
                dialogo.AddExtension = true;
                dialogo.OverwritePrompt = false;//La confirmacion se hace abajo, en el idioma de la aplicacion
                dialogo.InitialDirectory = RutasUsuario_883SC.CarpetaDocumentos_883SC();
                dialogo.FileName = reporteBLL_883SC.NombreSugerido_883SC(reporteActual_883SC.Desde_883SC, reporteActual_883SC.Hasta_883SC);

                while (dialogo.ShowDialog(this) == DialogResult.OK)
                {
                    if (!File.Exists(dialogo.FileName)
                        || MessageBox.Show(Traducir_883SC("REP_CONFIRMA_SOBRESCRIBIR"), Traducir_883SC("COMUN_ATENCION"),
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        return dialogo.FileName;
                    }
                }
            }
            return null;
        }

        private void btnSalir_Click_883SC(object sender, EventArgs e)
        {
            if (frmMenu_883SC.opcActivo_883SC != null) { frmMenu_883SC.opcActivo_883SC.BackColor = Color.WhiteSmoke; }
            this.Close();
        }
    }
}
