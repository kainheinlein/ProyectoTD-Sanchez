using Acceso_DAL;
using Entidad_BE;
using Servicios;
using System;
using System.Collections.Generic;

namespace Negocio_BLL
{
    public class OrdenCompraBLL_883SC
    {
        MP_OrdenCompra_883SC mpOrdenCompra_883SC = new MP_OrdenCompra_883SC();
        ListaPrecioBLL_883SC listaPrecioBLL_883SC = new ListaPrecioBLL_883SC();
        BitacoraBLL_883SC bitacora_883SC = new BitacoraBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        /// Valida el cambio de estado de una orden. Transiciones permitidas:
        /// Pendiente -> Autorizada o Rechazada; Autorizada -> EnEjecucion; EnEjecucion -> Recibida.
        /// Cualquier otra (incluido quedarse en el mismo estado) lanza ArgumentException (OC_ERR_TRANSICION).
        public void ValidarTransicion_883SC(EstadoOrdenCompra_883SC actual, EstadoOrdenCompra_883SC nuevo)
        {
            bool valida =
                (actual == EstadoOrdenCompra_883SC.Pendiente && (nuevo == EstadoOrdenCompra_883SC.Autorizada || nuevo == EstadoOrdenCompra_883SC.Rechazada))
                || (actual == EstadoOrdenCompra_883SC.Autorizada && nuevo == EstadoOrdenCompra_883SC.EnEjecucion)
                || (actual == EstadoOrdenCompra_883SC.EnEjecucion && nuevo == EstadoOrdenCompra_883SC.Recibida);

            if (!valida)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("OC_ERR_TRANSICION"));
            }
        }

        /// Agrega a la lista de compra (en memoria, no se persiste) la opcion de precio elegida con la cantidad
        /// indicada. Si el producto ya esta en la lista con ese proveedor, suma la cantidad a la linea existente.
        /// La lista queda ordenada por proveedor y producto. Cantidad invalida u opcion nula: ArgumentException.
        public void AgregarALista_883SC(List<LineaCompraBE_883SC> lista, LineaCompraBE_883SC opcion, int cantidad)
        {
            if (opcion == null || opcion.Proveedor_883SC == null || opcion.Producto_883SC == null)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("OC_ERR_SEL_PROVEEDOR"));
            }
            if (cantidad <= 0)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("OC_ERR_CANTIDAD"));
            }

            LineaCompraBE_883SC existente = null;
            foreach (LineaCompraBE_883SC linea in lista)
            {
                if (linea.Producto_883SC.Codigo_883SC == opcion.Producto_883SC.Codigo_883SC
                    && linea.Proveedor_883SC.Id_883SC == opcion.Proveedor_883SC.Id_883SC)
                {
                    existente = linea;
                }
            }

            if (existente != null)
            {
                //Evita que la suma desborde el int de la columna Cantidad
                if ((long)existente.Cantidad_883SC + cantidad > int.MaxValue)
                {
                    throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("OC_ERR_CANTIDAD"));
                }
                existente.Cantidad_883SC += cantidad;
            }
            else
            {
                LineaCompraBE_883SC nueva = new LineaCompraBE_883SC();
                nueva.Producto_883SC = opcion.Producto_883SC;
                nueva.Proveedor_883SC = opcion.Proveedor_883SC;
                nueva.CodigoProveedor_883SC = opcion.CodigoProveedor_883SC;
                nueva.PrecioLista_883SC = opcion.PrecioLista_883SC;
                nueva.FechaActualizacion_883SC = opcion.FechaActualizacion_883SC;
                nueva.Cantidad_883SC = cantidad;
                lista.Add(nueva);
            }

            lista.Sort(delegate (LineaCompraBE_883SC a, LineaCompraBE_883SC b)
            {
                int porProveedor = string.Compare(a.Proveedor_883SC.Nombre_883SC, b.Proveedor_883SC.Nombre_883SC, StringComparison.CurrentCultureIgnoreCase);
                if (porProveedor != 0) { return porProveedor; }
                return string.Compare(a.Producto_883SC.Codigo_883SC, b.Producto_883SC.Codigo_883SC, StringComparison.CurrentCultureIgnoreCase);
            });
        }

        /// Quita una linea de la lista de compra.
        public void QuitarDeLista_883SC(List<LineaCompraBE_883SC> lista, LineaCompraBE_883SC linea)
        {
            if (linea == null)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("OC_ERR_SEL_LINEA"));
            }
            lista.Remove(linea);
        }

        /// Total de la lista de compra por proveedor (suma de subtotales), en el orden de la lista.
        public List<KeyValuePair<ProveedorBE_883SC, decimal>> CalcularTotales_883SC(List<LineaCompraBE_883SC> lista)
        {
            List<KeyValuePair<ProveedorBE_883SC, decimal>> totales = new List<KeyValuePair<ProveedorBE_883SC, decimal>>();
            foreach (LineaCompraBE_883SC linea in lista)
            {
                int i = totales.FindIndex(t => t.Key.Id_883SC == linea.Proveedor_883SC.Id_883SC);
                if (i < 0)
                {
                    totales.Add(new KeyValuePair<ProveedorBE_883SC, decimal>(linea.Proveedor_883SC, linea.Subtotal_883SC));
                }
                else
                {
                    totales[i] = new KeyValuePair<ProveedorBE_883SC, decimal>(totales[i].Key, totales[i].Value + linea.Subtotal_883SC);
                }
            }
            return totales;
        }

        /// Genera UNA orden Pendiente por cada proveedor de la lista de compra, todas en una unica
        /// operacion, y registra una entrada de bitacora por orden.
        /// El precio de cada linea (DetalleOrdenCompra.PrecioUnitario) se vuelve a leer de la lista del proveedor en
        /// este momento y queda congelado en la orden: no se usa el que trae la pantalla.
        /// Lista vacia o producto sin precio vigente del proveedor: ArgumentException con el mensaje traducido.
        /// Error de base de datos: la excepcion original sube sin tratar (no se guarda ninguna orden).
        public List<OrdenCompraBE_883SC> GenerarOrdenes_883SC(List<LineaCompraBE_883SC> lista)
        {
            if (lista == null || lista.Count == 0)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("OC_ERR_LISTA_VACIA"));
            }

            UsuarioBE_883SC usuario = SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC();
            List<OrdenCompraBE_883SC> ordenes = new List<OrdenCompraBE_883SC>();
            foreach (LineaCompraBE_883SC linea in lista)
            {
                decimal precio = PrecioVigente_883SC(linea);

                OrdenCompraBE_883SC orden = ordenes.Find(o => o.Proveedor_883SC.Id_883SC == linea.Proveedor_883SC.Id_883SC);
                if (orden == null)
                {
                    orden = new OrdenCompraBE_883SC();
                    orden.Proveedor_883SC = linea.Proveedor_883SC;
                    orden.Estado_883SC = EstadoOrdenCompra_883SC.Pendiente;
                    orden.FechaCreacion_883SC = DateTime.Now;
                    ordenes.Add(orden);
                }

                DetalleOrdenCompraBE_883SC detalle = new DetalleOrdenCompraBE_883SC();
                detalle.Producto_883SC = linea.Producto_883SC;
                detalle.Cantidad_883SC = linea.Cantidad_883SC;
                detalle.PrecioUnitario_883SC = precio;
                orden.Detalle_883SC.Add(detalle);
            }

            mpOrdenCompra_883SC.GuardarOrdenes_883SC(usuario.cod_883SC, ordenes);

            foreach (OrdenCompraBE_883SC orden in ordenes)
            {
                bitacora_883SC.RegistrarBitacora_883SC(usuario.user_883SC, TipoAccion_883SC.AltaOrdenCompra,
                    "orden=" + orden.IdOrdenCompra_883SC + ";proveedor=" + orden.Proveedor_883SC.Id_883SC);
            }
            return ordenes;
        }

        //Precio de lista actual del producto en el proveedor de la linea
        private decimal PrecioVigente_883SC(LineaCompraBE_883SC linea)
        {
            foreach (LineaCompraBE_883SC opcion in listaPrecioBLL_883SC.CompararPrecios_883SC(linea.Producto_883SC))
            {
                if (opcion.Proveedor_883SC.Id_883SC == linea.Proveedor_883SC.Id_883SC)
                {
                    return opcion.PrecioLista_883SC;
                }
            }
            throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("OC_ERR_SIN_PRECIO"));
        }
    }
}
