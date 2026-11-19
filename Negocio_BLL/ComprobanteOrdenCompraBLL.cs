using Acceso_DAL;
using Entidad_BE;
using Servicios;
using System;
using System.Collections.Generic;

namespace Negocio_BLL
{
    public class ComprobanteOrdenCompraBLL_883SC
    {
        MP_OrdenCompra_883SC mpOrdenCompra_883SC = new MP_OrdenCompra_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        /// Lee los datos del comprobante desde la base. Solo lee: no cambia el estado ni registra bitacora, por eso sirve
        /// tanto al mostrarlo despues del envio como para reimprimirlo. Solo ordenes EnEjecucion o Recibida (ya tienen
        /// fecha de envio); otro estado: ArgumentException OC_COMP_ERR_ESTADO. Orden inexistente: OC_COMP_ERR_NO_EXISTE.
        /// Error de base de datos: la excepcion original sube sin tratar.
        public ComprobanteOrdenCompraBE_883SC Obtener_883SC(int idOrden)
        {
            ComprobanteOrdenCompraBE_883SC comprobante = mpOrdenCompra_883SC.ObtenerComprobante_883SC(idOrden);
            if (comprobante == null)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("OC_COMP_ERR_NO_EXISTE"));
            }
            if (comprobante.Estado_883SC != EstadoOrdenCompra_883SC.EnEjecucion && comprobante.Estado_883SC != EstadoOrdenCompra_883SC.Recibida)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("OC_COMP_ERR_ESTADO"));
            }
            return comprobante;
        }

        /// Arma las lineas de texto del comprobante, traducidas al idioma actual, para un ancho en caracteres.
        public List<string> ArmarLineas_883SC(ComprobanteOrdenCompraBE_883SC comprobante, int ancho)
        {
            List<string> lineas = new List<string>();
            string simple = new string('-', ancho);
            string doble = new string('=', ancho);

            lineas.Add(Centrar_883SC("FerreSV", ancho));
            lineas.Add(Centrar_883SC(Traducir_883SC("OC_COMP_TITULO"), ancho));
            lineas.Add(doble);
            lineas.Add(Traducir_883SC("OC_COMP_NRO") + " " + comprobante.IdOrdenCompra_883SC);
            lineas.AddRange(Envolver_883SC(Traducir_883SC("OC_COMP_PROVEEDOR") + " " + comprobante.Proveedor_883SC, ancho));
            lineas.Add(simple);

            lineas.Add(Traducir_883SC("OC_COMP_GENERADA") + " " + Fecha_883SC(comprobante.FechaCreacion_883SC));
            lineas.Add(Traducir_883SC("OC_COMP_GENERO") + " " + Texto_883SC(comprobante.UsuarioCreacion_883SC));
            lineas.Add(Traducir_883SC("OC_COMP_AUTORIZO") + " " + Texto_883SC(comprobante.UsuarioDecision_883SC)
                + " (" + Fecha_883SC(comprobante.FechaDecision_883SC) + ")");
            lineas.Add(Traducir_883SC("OC_COMP_ENVIADA") + " " + Fecha_883SC(comprobante.FechaEnvio_883SC));
            lineas.Add(simple);

            //Codigo del proveedor y descripcion, luego cantidad x precio congelado y subtotal
            foreach (LineaComprobanteOCBE_883SC linea in comprobante.Lineas_883SC)
            {
                lineas.AddRange(Envolver_883SC(linea.CodigoProveedor_883SC + " - " + linea.Descripcion_883SC, ancho));
                lineas.Add(ConDerecha_883SC(
                    "  " + linea.Cantidad_883SC + " x $ " + linea.PrecioUnitario_883SC.ToString("0.00"),
                    "$ " + linea.Subtotal_883SC.ToString("0.00"), ancho));
            }

            lineas.Add(simple);
            lineas.Add(ConDerecha_883SC(Traducir_883SC("FACT_LBL_TOTAL").ToUpper(), "$ " + comprobante.PrecioTotal_883SC.ToString("0.00"), ancho));
            lineas.Add(doble);
            return lineas;
        }

        private string Traducir_883SC(string clave)
        {
            return gestorIdioma_883SC.Traducir_883SC(clave);
        }

        private string Fecha_883SC(DateTime? fecha)
        {
            return fecha.HasValue ? fecha.Value.ToString("dd/MM/yyyy HH:mm") : "-";
        }

        private string Texto_883SC(string texto)
        {
            return string.IsNullOrEmpty(texto) ? "-" : texto;
        }

        private string Centrar_883SC(string texto, int ancho)
        {
            if (texto.Length >= ancho) { return texto; }
            return new string(' ', (ancho - texto.Length) / 2) + texto;
        }

        //Texto izquierda, valor derecha. Se recorta la izquierda si falta espacio.
        private string ConDerecha_883SC(string izquierda, string derecha, int ancho)
        {
            int espacios = ancho - izquierda.Length - derecha.Length;
            if (espacios < 1)
            {
                izquierda = izquierda.Substring(0, Math.Max(0, ancho - derecha.Length - 1));
                espacios = 1;
            }
            return izquierda + new string(' ', espacios) + derecha;
        }

        //Separa un texto largo en varias lineas
        private List<string> Envolver_883SC(string texto, int ancho)
        {
            List<string> partes = new List<string>();
            while (texto.Length > ancho)
            {
                int corte = texto.LastIndexOf(' ', ancho);
                if (corte <= 0) { corte = ancho; }

                partes.Add(texto.Substring(0, corte).TrimEnd());
                texto = texto.Substring(corte).TrimStart();
            }
            partes.Add(texto);
            return partes;
        }
    }
}
