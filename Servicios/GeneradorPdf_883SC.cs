using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.IO;

namespace Servicios
{
    public static class GeneradorPdf_883SC
    {
        private const double MargenCm_883SC = 2.0;
        private const double AnchoUtilCm_883SC = 21.0 - 2 * MargenCm_883SC;//A4 vertical

        public static void Generar_883SC(string ruta, string titulo, List<string> lineasEncabezado,
            List<SeccionPdf_883SC> secciones, string textoPagina, string textoDe)
        {
            if (string.IsNullOrWhiteSpace(ruta)) { throw new ArgumentException("Ruta de archivo vacia", "ruta"); }

            Document documento = ArmarDocumento_883SC(titulo, lineasEncabezado, secciones, textoPagina, textoDe);

            PdfDocumentRenderer renderizador = new PdfDocumentRenderer();
            renderizador.Document = documento;
            renderizador.RenderDocument();

            string temporal = ruta + ".tmp";
            try
            {
                renderizador.PdfDocument.Save(temporal);
                //Si el destino esta abierto en otro programa, Delete lanza IOException y el original no se toca
                if (File.Exists(ruta)) { File.Delete(ruta); }
                File.Move(temporal, ruta);
            }
            finally
            {
                if (File.Exists(temporal)) { File.Delete(temporal); }
            }
        }

        //Cuenta la cantidad de paginas de un PDF ya generado
        public static int ContarPaginas_883SC(string ruta)
        {
            using (PdfDocument pdf = PdfReader.Open(ruta, PdfDocumentOpenMode.Import))
            {
                return pdf.PageCount;
            }
        }

        private static Document ArmarDocumento_883SC(string titulo, List<string> lineasEncabezado,
            List<SeccionPdf_883SC> secciones, string textoPagina, string textoDe)
        {
            Document documento = new Document();
            documento.Info.Title = titulo;

            Style normal = documento.Styles[StyleNames.Normal];
            normal.Font.Name = "Arial";
            normal.Font.Size = 10;

            Section seccion = documento.AddSection();
            seccion.PageSetup.PageFormat = PageFormat.A4;
            seccion.PageSetup.Orientation = Orientation.Portrait;
            seccion.PageSetup.LeftMargin = Unit.FromCentimeter(MargenCm_883SC);
            seccion.PageSetup.RightMargin = Unit.FromCentimeter(MargenCm_883SC);
            seccion.PageSetup.TopMargin = Unit.FromCentimeter(MargenCm_883SC);
            seccion.PageSetup.BottomMargin = Unit.FromCentimeter(2.2);

            Paragraph parrafoTitulo = seccion.AddParagraph(titulo);
            parrafoTitulo.Format.Font.Size = 18;
            parrafoTitulo.Format.Font.Bold = true;
            parrafoTitulo.Format.Font.Color = Color.FromRgb(178, 34, 34);
            parrafoTitulo.Format.SpaceAfter = Unit.FromPoint(6);

            if (lineasEncabezado != null)
            {
                foreach (string linea in lineasEncabezado)
                {
                    Paragraph p = seccion.AddParagraph(linea);
                    p.Format.SpaceAfter = Unit.FromPoint(2);
                }
            }

            if (secciones != null)
            {
                foreach (SeccionPdf_883SC datos in secciones)
                {
                    AgregarSeccion_883SC(seccion, datos);
                }
            }

            //Pie de pagina
            Paragraph pie = seccion.Footers.Primary.AddParagraph();
            pie.Format.Alignment = ParagraphAlignment.Center;
            pie.Format.Font.Size = 8;
            pie.AddText(textoPagina + " ");
            pie.AddPageField();
            pie.AddText(" " + textoDe + " ");
            pie.AddNumPagesField();

            return documento;
        }

        private static void AgregarSeccion_883SC(Section seccion, SeccionPdf_883SC datos)
        {
            if (!string.IsNullOrEmpty(datos.Titulo_883SC))
            {
                Paragraph subtitulo = seccion.AddParagraph(datos.Titulo_883SC);
                subtitulo.Format.Font.Size = 12;
                subtitulo.Format.Font.Bold = true;
                subtitulo.Format.SpaceBefore = Unit.FromPoint(14);
                subtitulo.Format.SpaceAfter = Unit.FromPoint(4);
                subtitulo.Format.KeepWithNext = true;
            }

            int cantidadColumnas = CantidadColumnas_883SC(datos);
            if (cantidadColumnas == 0) { return; }

            Table tabla = seccion.AddTable();
            tabla.Borders.Width = 0.5;
            tabla.Borders.Color = Color.FromRgb(160, 160, 160);
            tabla.Format.Font.Size = 9;
            tabla.TopPadding = Unit.FromPoint(2);
            tabla.BottomPadding = Unit.FromPoint(2);
            tabla.LeftPadding = Unit.FromPoint(4);
            tabla.RightPadding = Unit.FromPoint(4);

            double totalPesos = 0;
            for (int i = 0; i < cantidadColumnas; i++) { totalPesos += PesoColumna_883SC(datos, i); }
            for (int i = 0; i < cantidadColumnas; i++)
            {
                double ancho = AnchoUtilCm_883SC * PesoColumna_883SC(datos, i) / totalPesos;
                tabla.AddColumn(Unit.FromCentimeter(ancho));
            }

            if (datos.Columnas_883SC.Count > 0)
            {
                Row encabezado = tabla.AddRow();
                encabezado.HeadingFormat = true;//Se repite en cada pagina
                encabezado.Shading.Color = Color.FromRgb(178, 34, 34);
                encabezado.Format.Font.Color = Colors.White;
                encabezado.Format.Font.Bold = true;
                for (int i = 0; i < cantidadColumnas; i++)
                {
                    LlenarCelda_883SC(encabezado.Cells[i], i < datos.Columnas_883SC.Count ? datos.Columnas_883SC[i] : "", datos, i);
                }
            }

            foreach (string[] fila in datos.Filas_883SC)
            {
                AgregarFila_883SC(tabla, fila, datos, cantidadColumnas, false);
            }
            if (datos.FilaTotal_883SC != null)
            {
                AgregarFila_883SC(tabla, datos.FilaTotal_883SC, datos, cantidadColumnas, true);
            }
        }

        private static void AgregarFila_883SC(Table tabla, string[] valores, SeccionPdf_883SC datos, int cantidadColumnas, bool esTotal)
        {
            Row fila = tabla.AddRow();
            if (esTotal)
            {
                fila.Format.Font.Bold = true;
                fila.Shading.Color = Color.FromRgb(220, 220, 220);
            }
            for (int i = 0; i < cantidadColumnas; i++)
            {
                LlenarCelda_883SC(fila.Cells[i], i < valores.Length ? valores[i] : "", datos, i);
            }
        }

        private static void LlenarCelda_883SC(Cell celda, string texto, SeccionPdf_883SC datos, int indice)
        {
            Paragraph p = celda.AddParagraph(texto ?? "");
            bool derecha = indice < datos.AlinearDerecha_883SC.Count && datos.AlinearDerecha_883SC[indice];
            p.Format.Alignment = derecha ? ParagraphAlignment.Right : ParagraphAlignment.Left;
            celda.VerticalAlignment = VerticalAlignment.Center;
        }

        private static int CantidadColumnas_883SC(SeccionPdf_883SC datos)
        {
            int max = datos.Columnas_883SC.Count;
            foreach (string[] fila in datos.Filas_883SC) { if (fila.Length > max) { max = fila.Length; } }
            if (datos.FilaTotal_883SC != null && datos.FilaTotal_883SC.Length > max) { max = datos.FilaTotal_883SC.Length; }
            return max;
        }

        private static double PesoColumna_883SC(SeccionPdf_883SC datos, int indice)
        {
            return indice < datos.Anchos_883SC.Count && datos.Anchos_883SC[indice] > 0 ? datos.Anchos_883SC[indice] : 1.0;
        }
    }
}
