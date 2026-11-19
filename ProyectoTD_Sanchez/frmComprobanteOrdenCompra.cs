using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    //Muestra e imprime el comprobante de una orden de compra enviada. El contenido lo arma ComprobanteOrdenCompraBLL.
    public partial class frmComprobanteOrdenCompra_883SC : Form, IObservadorIdioma_883SC
    {
        public frmComprobanteOrdenCompra_883SC(ComprobanteOrdenCompraBE_883SC comprobante)
        {
            InitializeComponent();
            comprobante_883SC = comprobante;

            documento_883SC.BeginPrint += documento_BeginPrint_883SC;
            documento_883SC.PrintPage += documento_PrintPage_883SC;
        }

        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;
        ComprobanteOrdenCompraBLL_883SC comprobanteBLL_883SC = new ComprobanteOrdenCompraBLL_883SC();

        private const int Ancho_883SC = 44;

        private ComprobanteOrdenCompraBE_883SC comprobante_883SC;
        private List<string> lineas_883SC = new List<string>();
        private PrintDocument documento_883SC = new PrintDocument();
        private int lineaImpresion_883SC = 0;

        private void frmComprobanteOrdenCompra_Load_883SC(object sender, EventArgs e)
        {
            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmComprobanteOrdenCompra_FormClosed_883SC;
        }

        private void frmComprobanteOrdenCompra_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
            documento_883SC.Dispose();
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = gestorIdioma_883SC.Traducir_883SC("OC_COMP_TITULO");
            btnImprimir.Text = gestorIdioma_883SC.Traducir_883SC("FACT_COMP_BTN_IMPRIMIR");
            btnCerrar.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_SALIR");

            lineas_883SC = comprobanteBLL_883SC.ArmarLineas_883SC(comprobante_883SC, Ancho_883SC);
            txtComprobante.Lines = lineas_883SC.ToArray();
            txtComprobante.SelectionStart = 0;
            txtComprobante.SelectionLength = 0;
        }

        #endregion

        #region Impresion

        private void btnImprimir_Click_883SC(object sender, EventArgs e)
        {
            try
            {
                using (PrintDialog dialogo = new PrintDialog())
                {
                    documento_883SC.DocumentName = "FerreSV - " + gestorIdioma_883SC.Traducir_883SC("OC_COMP_NRO") + " " + comprobante_883SC.IdOrdenCompra_883SC;
                    dialogo.Document = documento_883SC;
                    if (dialogo.ShowDialog(this) != DialogResult.OK) { return; }

                    documento_883SC.Print();
                }
            }
            catch (Exception ex)
            {
                //Si no hay impresora, se muestra error. Sigue visible el comprobante.
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void documento_BeginPrint_883SC(object sender, PrintEventArgs e)
        {
            lineaImpresion_883SC = 0;
        }

        private void documento_PrintPage_883SC(object sender, PrintPageEventArgs e)
        {
            using (Font fuente = new Font("Courier New", 10F))
            {
                float alto = fuente.GetHeight(e.Graphics);
                float y = e.MarginBounds.Top;

                while (lineaImpresion_883SC < lineas_883SC.Count && y + alto <= e.MarginBounds.Bottom)
                {
                    e.Graphics.DrawString(lineas_883SC[lineaImpresion_883SC], fuente, Brushes.Black, e.MarginBounds.Left, y);
                    y += alto;
                    lineaImpresion_883SC++;
                }

                e.HasMorePages = lineaImpresion_883SC < lineas_883SC.Count;
            }
        }

        #endregion

        private void btnCerrar_Click_883SC(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
