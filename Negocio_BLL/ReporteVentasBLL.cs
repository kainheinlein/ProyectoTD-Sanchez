using Acceso_DAL;
using Entidad_BE;
using Servicios;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Negocio_BLL
{
    public class ReporteVentasBLL_883SC
    {
        public const int CantidadTop_883SC = 10;

        MP_ReporteVentas_883SC mpReporte_883SC = new MP_ReporteVentas_883SC();
        BitacoraBLL_883SC bitacora_883SC = new BitacoraBLL_883SC();
        PerfilBLL_883SC perfilBLL_883SC = new PerfilBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        public ReporteVentasBE_883SC GenerarReporte_883SC(DateTime desde, DateTime hasta)
        {
            ValidarPermiso_883SC();
            ValidarRango_883SC(desde, hasta);

            ReporteVentasBE_883SC reporte = mpReporte_883SC.ObtenerResumen_883SC(desde, hasta);
            if (reporte.CantidadVentas_883SC > 0)
            {
                reporte.VentasPorDia_883SC = mpReporte_883SC.ObtenerVentasPorDia_883SC(desde, hasta);
                reporte.TopProductos_883SC = mpReporte_883SC.ObtenerTopProductos_883SC(desde, hasta, CantidadTop_883SC);
            }
            return reporte;
        }

        public void ExportarPdf_883SC(ReporteVentasBE_883SC reporte, string ruta)
        {
            ValidarPermiso_883SC();
            if (reporte == null || reporte.CantidadVentas_883SC == 0)
            {
                throw new ArgumentException(Traducir_883SC("REP_ERR_SIN_REPORTE"));
            }
            ValidarRuta_883SC(ruta);

            GeneradorPdf_883SC.Generar_883SC(ruta, Traducir_883SC("REP_TITULO"), ArmarEncabezado_883SC(reporte),
                ArmarSecciones_883SC(reporte), Traducir_883SC("REP_PDF_PAGINA"), Traducir_883SC("REP_PDF_DE"));

            //Verificacion posterior: el archivo existe y es un PDF con al menos una pagina
            if (!File.Exists(ruta) || GeneradorPdf_883SC.ContarPaginas_883SC(ruta) < 1)
            {
                throw new InvalidOperationException(Traducir_883SC("REP_ERR_VERIFICACION"));
            }

            string usuario = SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC;
            bitacora_883SC.RegistrarBitacora_883SC(usuario, TipoAccion_883SC.GeneracionReporteVentas,
                "desde=" + reporte.Desde_883SC.ToString("yyyyMMdd") + ";hasta=" + reporte.Hasta_883SC.ToString("yyyyMMdd")
                + ";archivo=" + Path.GetFileName(ruta));
        }

        public string NombreSugerido_883SC(DateTime desde, DateTime hasta)
        {
            return "ReporteVentas_" + desde.ToString("yyyyMMdd") + "_" + hasta.ToString("yyyyMMdd") + ".pdf";
        }

        #region Formato segun el idioma activo (es-AR para espanol, en-US para ingles)

        public string FormatearFecha_883SC(DateTime fecha)
        {
            return fecha.ToString(EsIngles_883SC() ? "MM/dd/yyyy" : "dd/MM/yyyy", Cultura_883SC());
        }

        public string FormatearImporte_883SC(decimal importe)
        {
            return "$ " + importe.ToString("N2", Cultura_883SC());
        }

        public string FormatearEntero_883SC(int valor)
        {
            return valor.ToString("N0", Cultura_883SC());
        }

        private bool EsIngles_883SC()
        {
            return gestorIdioma_883SC.IdiomaActual_883SC != null && gestorIdioma_883SC.IdiomaActual_883SC.Codigo_883SC == "EN";
        }

        private CultureInfo Cultura_883SC()
        {
            return CultureInfo.GetCultureInfo(EsIngles_883SC() ? "en-US" : "es-AR");
        }

        #endregion

        private void ValidarPermiso_883SC()
        {
            UsuarioBE_883SC usuario = SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC();
            if (usuario == null || !perfilBLL_883SC.TienePermiso_883SC(usuario.rol_883SC, TipoPermiso_883SC.VerReportes.ToString()))
            {
                throw new UnauthorizedAccessException(Traducir_883SC("REP_ERR_PERMISO"));
            }
        }

        private void ValidarRango_883SC(DateTime desde, DateTime hasta)
        {
            if (desde.Date > hasta.Date)
            {
                throw new ArgumentException(Traducir_883SC("REP_ERR_RANGO"));
            }
            if (desde.Date > DateTime.Today || hasta.Date > DateTime.Today)
            {
                throw new ArgumentException(Traducir_883SC("REP_ERR_FUTURA"));
            }
        }

        //La ruta debe ser un archivo .pdf dentro de una carpeta existente
        private void ValidarRuta_883SC(string ruta)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ruta)
                    || !string.Equals(Path.GetExtension(ruta), ".pdf", StringComparison.OrdinalIgnoreCase)
                    || string.IsNullOrEmpty(Path.GetFileNameWithoutExtension(ruta))
                    || !Directory.Exists(Path.GetDirectoryName(Path.GetFullPath(ruta))))
                {
                    throw new ArgumentException(Traducir_883SC("REP_ERR_RUTA"));
                }
            }
            catch (ArgumentException) { throw new ArgumentException(Traducir_883SC("REP_ERR_RUTA")); }
            catch (NotSupportedException) { throw new ArgumentException(Traducir_883SC("REP_ERR_RUTA")); }
            catch (PathTooLongException) { throw new ArgumentException(Traducir_883SC("REP_ERR_RUTA")); }
        }

        private List<string> ArmarEncabezado_883SC(ReporteVentasBE_883SC reporte)
        {
            string usuario = SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC;
            List<string> lineas = new List<string>();
            lineas.Add(string.Format(Traducir_883SC("REP_PDF_PERIODO"), FormatearFecha_883SC(reporte.Desde_883SC), FormatearFecha_883SC(reporte.Hasta_883SC)));
            lineas.Add(string.Format(Traducir_883SC("REP_PDF_GENERADO"),
                FormatearFecha_883SC(DateTime.Now) + " " + DateTime.Now.ToString("HH:mm", Cultura_883SC()), usuario));
            return lineas;
        }

        private List<SeccionPdf_883SC> ArmarSecciones_883SC(ReporteVentasBE_883SC reporte)
        {
            List<SeccionPdf_883SC> secciones = new List<SeccionPdf_883SC>();

            //Resumen del periodo: tabla de dos columnas (indicador, valor) sin encabezado
            SeccionPdf_883SC resumen = new SeccionPdf_883SC();
            resumen.Titulo_883SC = Traducir_883SC("REP_GRP_RESUMEN");
            resumen.Anchos_883SC = new List<double> { 3, 2 };
            resumen.AlinearDerecha_883SC = new List<bool> { false, true };
            resumen.Filas_883SC.Add(new string[] { Traducir_883SC("REP_LBL_CANT_VENTAS"), FormatearEntero_883SC(reporte.CantidadVentas_883SC) });
            resumen.Filas_883SC.Add(new string[] { Traducir_883SC("REP_LBL_UNIDADES"), FormatearEntero_883SC(reporte.UnidadesVendidas_883SC) });
            resumen.Filas_883SC.Add(new string[] { Traducir_883SC("REP_LBL_MONTO"), FormatearImporte_883SC(reporte.MontoTotal_883SC) });
            resumen.Filas_883SC.Add(new string[] { Traducir_883SC("REP_LBL_TICKET"), FormatearImporte_883SC(reporte.TicketPromedio_883SC) });
            secciones.Add(resumen);

            SeccionPdf_883SC porDia = new SeccionPdf_883SC();
            porDia.Titulo_883SC = Traducir_883SC("REP_LBL_VENTAS_DIA");
            porDia.Columnas_883SC = new List<string> { Traducir_883SC("COMUN_FECHA"), Traducir_883SC("REP_COL_CANT_VENTAS"), Traducir_883SC("REP_COL_IMPORTE") };
            porDia.Anchos_883SC = new List<double> { 2, 2, 2 };
            porDia.AlinearDerecha_883SC = new List<bool> { false, true, true };
            foreach (VentaDiariaBE_883SC dia in reporte.VentasPorDia_883SC)
            {
                porDia.Filas_883SC.Add(new string[] { FormatearFecha_883SC(dia.Fecha_883SC), FormatearEntero_883SC(dia.CantidadVentas_883SC), FormatearImporte_883SC(dia.Importe_883SC) });
            }
            porDia.FilaTotal_883SC = new string[] { Traducir_883SC("REP_LBL_TOTAL"), FormatearEntero_883SC(reporte.CantidadVentas_883SC), FormatearImporte_883SC(reporte.MontoTotal_883SC) };
            secciones.Add(porDia);

            SeccionPdf_883SC top = new SeccionPdf_883SC();
            top.Titulo_883SC = Traducir_883SC("REP_LBL_TOP");
            top.Columnas_883SC = new List<string> { Traducir_883SC("MAESTRO_COL_CODIGO"), Traducir_883SC("REP_COL_PRODUCTO"), Traducir_883SC("REP_COL_UNIDADES"), Traducir_883SC("REP_COL_IMPORTE") };
            top.Anchos_883SC = new List<double> { 1.5, 3.5, 1.3, 2 };
            top.AlinearDerecha_883SC = new List<bool> { false, false, true, true };
            foreach (ProductoVendidoBE_883SC producto in reporte.TopProductos_883SC)
            {
                top.Filas_883SC.Add(new string[] { producto.Codigo_883SC, producto.Nombre_883SC, FormatearEntero_883SC(producto.Unidades_883SC), FormatearImporte_883SC(producto.Importe_883SC) });
            }
            secciones.Add(top);

            return secciones;
        }

        private string Traducir_883SC(string clave)
        {
            return gestorIdioma_883SC.Traducir_883SC(clave);
        }
    }
}
