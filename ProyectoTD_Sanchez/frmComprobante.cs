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
    public partial class frmComprobante_883SC : Form, IObservadorIdioma_883SC
    {
        public frmComprobante_883SC(FacturaBE_883SC factura)
        {
            InitializeComponent();
            factura_883SC = factura;
            cajero_883SC = ObtenerCajero_883SC();

            documento_883SC.BeginPrint += documento_BeginPrint_883SC;
            documento_883SC.PrintPage += documento_PrintPage_883SC;
        }

        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        private const int Ancho_883SC = 44;

        private FacturaBE_883SC factura_883SC;
        private string cajero_883SC;
        private List<string> lineas_883SC = new List<string>();
        private PrintDocument documento_883SC = new PrintDocument();
        private int lineaImpresion_883SC = 0;

        private void frmComprobante_Load_883SC(object sender, EventArgs e)
        {
            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmComprobante_FormClosed_883SC;
        }

        private void frmComprobante_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
            documento_883SC.Dispose();
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = Traducir_883SC("FACT_COMP_TITULO");
            btnImprimir.Text = Traducir_883SC("FACT_COMP_BTN_IMPRIMIR");
            btnCerrar.Text = Traducir_883SC("COMUN_SALIR");

            lineas_883SC = ArmarLineas_883SC();
            txtComprobante.Lines = lineas_883SC.ToArray();
            txtComprobante.SelectionStart = 0;
            txtComprobante.SelectionLength = 0;
        }

        #endregion

        private string Traducir_883SC(string clave)
        {
            return gestorIdioma_883SC.Traducir_883SC(clave);
        }

        //Usuario logueado que emitio la venta.
        private string ObtenerCajero_883SC()
        {
            if (!SessionManager_883SC.Logged_883SC()) { return "-"; }
            UsuarioBE_883SC usuario = SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC();
            return usuario == null ? "-" : usuario.user_883SC;
        }

        #region Armado del texto

        private List<string> ArmarLineas_883SC()
        {
            List<string> lineas = new List<string>();
            string simple = new string('-', Ancho_883SC);
            string doble = new string('=', Ancho_883SC);

            lineas.Add(Centrar_883SC("FerreSV"));
            lineas.Add(Centrar_883SC(Traducir_883SC("FACT_COMP_TITULO")));
            lineas.Add(doble);
            lineas.Add(Traducir_883SC("FACT_COMP_NRO") + " " + factura_883SC.IdFactura_883SC);
            lineas.Add(Traducir_883SC("COMUN_FECHA") + ": " + factura_883SC.FechaVenta_883SC.ToString("dd/MM/yyyy HH:mm"));
            lineas.Add(Traducir_883SC("FACT_COMP_CAJERO") + " " + cajero_883SC);
            lineas.Add(simple);

            ClienteBE_883SC cliente = factura_883SC.Cliente_883SC;
            lineas.AddRange(Envolver_883SC(Traducir_883SC("FACT_GRP_CLIENTE") + ": " + cliente.Nombre_883SC + " " + cliente.Apellido_883SC));
            lineas.Add(Traducir_883SC("FACT_LBL_DNI") + " " + cliente.Dni_883SC);
            lineas.Add(simple);

            //Nombre y Codigo de Producto, cantidad x precio y subtotal
            foreach (DetalleFacturaBE_883SC detalle in factura_883SC.Detalle_883SC)
            {
                lineas.AddRange(Envolver_883SC(detalle.Producto_883SC.Nombre_883SC + " (" + detalle.Producto_883SC.Codigo_883SC + ")"));
                decimal subtotal = detalle.Cantidad_883SC * detalle.PrecioUnitario_883SC;
                lineas.Add(ConDerecha_883SC(
                    "  " + detalle.Cantidad_883SC + " x $ " + detalle.PrecioUnitario_883SC.ToString("0.00"),
                    "$ " + subtotal.ToString("0.00")));
            }

            lineas.Add(simple);
            lineas.Add(ConDerecha_883SC(Traducir_883SC("FACT_LBL_TOTAL").ToUpper(), "$ " + factura_883SC.PrecioTotal_883SC.ToString("0.00")));
            lineas.Add(simple);
            lineas.Add(Traducir_883SC("FACT_LBL_METODO") + " " + factura_883SC.MetodoPago_883SC.Nombre_883SC);

            //Efectivo y Transferencia no tienen codigo de autorizacion
            if (!string.IsNullOrEmpty(factura_883SC.CodigoAutorizacion_883SC))
            {
                lineas.Add(Traducir_883SC("FACT_LBL_AUTORIZACION") + " " + factura_883SC.CodigoAutorizacion_883SC);
            }

            lineas.Add(doble);
            lineas.Add(Centrar_883SC(Traducir_883SC("FACT_COMP_GRACIAS")));
            return lineas;
        }

        private string Centrar_883SC(string texto)
        {
            if (texto.Length >= Ancho_883SC) { return texto; }
            return new string(' ', (Ancho_883SC - texto.Length) / 2) + texto;
        }

        //Texto izquierda,  valor derecha. Se recorta izquierda si falta espacio.
        private string ConDerecha_883SC(string izquierda, string derecha)
        {
            int espacios = Ancho_883SC - izquierda.Length - derecha.Length;
            if (espacios < 1)
            {
                izquierda = izquierda.Substring(0, Math.Max(0, Ancho_883SC - derecha.Length - 1));
                espacios = 1;
            }
            return izquierda + new string(' ', espacios) + derecha;
        }

        //Se separan los nombres en varias lineas si es largo.
        private List<string> Envolver_883SC(string texto)
        {
            List<string> partes = new List<string>();
            while (texto.Length > Ancho_883SC)
            {
                int corte = texto.LastIndexOf(' ', Ancho_883SC);
                if (corte <= 0) { corte = Ancho_883SC; }

                partes.Add(texto.Substring(0, corte).TrimEnd());
                texto = texto.Substring(corte).TrimStart();
            }
            partes.Add(texto);
            return partes;
        }

        #endregion

        #region Impresion

        private void btnImprimir_Click_883SC(object sender, EventArgs e)
        {
            try
            {
                using (PrintDialog dialogo = new PrintDialog())
                {
                    documento_883SC.DocumentName = "FerreSV - " + Traducir_883SC("FACT_COMP_NRO") + " " + factura_883SC.IdFactura_883SC;
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
