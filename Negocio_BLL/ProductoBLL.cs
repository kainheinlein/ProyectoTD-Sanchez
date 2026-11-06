using Acceso_DAL;
using Entidad_BE;
using Servicios;
using System;
using System.Collections.Generic;

namespace Negocio_BLL
{
    public class ProductoBLL_883SC
    {
        MP_Producto_883SC mpProducto_883SC = new MP_Producto_883SC();
        ProveedorBLL_883SC proveedorBLL_883SC = new ProveedorBLL_883SC();
        BitacoraBLL_883SC bitacora_883SC = new BitacoraBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        //Largos de Productos.Codigo y Productos.Nombre
        private const int CODIGO_MAX_883SC = 50;
        private const int NOMBRE_MAX_883SC = 50;

        public List<ProductoBE_883SC> ListarProductos_883SC()
        {
            return mpProducto_883SC.ListarProductos_883SC();
        }

        public List<ProductoBE_883SC> BuscarProductos_883SC(string criterio, string dato)
        {
            return mpProducto_883SC.BuscarProductos_883SC(criterio, dato);
        }

        public List<ProductoBE_883SC> ListarBajoStock_883SC()
        {
            return mpProducto_883SC.ListarBajoStock_883SC();
        }

        /// Da de alta el producto a partir de un item pendiente: stock 0, proveedor de referencia el
        /// del item y precio de venta = precio de lista * (1 + margen/100). Producto e item se guardan juntos
        /// (el SP los inserta y vincula en una transaccion). La descripcion viaja en Tipo_883SC.
        /// Dato invalido o codigo repetido: ArgumentException con el mensaje traducido.
        /// Error de base de datos: la excepcion original sube sin tratar (no se guarda nada).
        public ProductoBE_883SC RegistrarProducto_883SC(ProductoBE_883SC producto, ItemListaPrecioBE_883SC item)
        {
            if (producto == null || item == null)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROD_ERR_SEL_ITEM"));
            }
            producto.Codigo_883SC = (producto.Codigo_883SC ?? "").Trim();
            ValidarDatos_883SC(producto);

            if (mpProducto_883SC.ExisteProducto_883SC(producto.Codigo_883SC))
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROD_ERR_EXISTE"));
            }

            producto.Stock_883SC = 0;
            producto.Proveedor_883SC = item.IdProveedor_883SC;
            producto.Precio_883SC = CalcularPrecioVenta_883SC(item);

            mpProducto_883SC.GuardarProducto_883SC(producto, item);

            bitacora_883SC.RegistrarBitacora_883SC(UsuarioActual_883SC(), TipoAccion_883SC.AltaProducto,
                "codigo=" + producto.Codigo_883SC + ";proveedor=" + item.IdProveedor_883SC + ";codigoProveedor=" + item.CodigoProveedor_883SC);
            return producto;
        }

        public ProductoBE_883SC ModificarProducto_883SC(ProductoBE_883SC producto, ItemListaPrecioBE_883SC item)
        {
            if (producto == null)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROD_ERR_SEL_PRODUCTO"));
            }
            ValidarDatos_883SC(producto);

            //El stock y el precio vigentes salen de la base, no de lo que trae la pantalla
            List<ProductoBE_883SC> actuales = mpProducto_883SC.BuscarProductos_883SC("Codigo", producto.Codigo_883SC);
            if (actuales.Count == 0)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROD_ERR_SEL_PRODUCTO"));
            }
            ProductoBE_883SC actual = actuales[0];

            producto.Stock_883SC = actual.Stock_883SC;
            if (producto.Proveedor_883SC == actual.Proveedor_883SC)
            {
                producto.Precio_883SC = actual.Precio_883SC;
            }
            else
            {
                if (item == null || item.IdProveedor_883SC != producto.Proveedor_883SC || item.Codigo_883SC != producto.Codigo_883SC)
                {
                    throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROD_ERR_PROV_REF"));
                }
                producto.Precio_883SC = CalcularPrecioVenta_883SC(item);
            }

            mpProducto_883SC.ModificarProducto_883SC(producto);

            bitacora_883SC.RegistrarBitacora_883SC(UsuarioActual_883SC(), TipoAccion_883SC.ModificacionProducto,
                "codigo=" + producto.Codigo_883SC);
            return producto;
        }

        private void ValidarDatos_883SC(ProductoBE_883SC producto)
        {
            producto.Nombre_883SC = (producto.Nombre_883SC ?? "").Trim();
            producto.Tipo_883SC = (producto.Tipo_883SC ?? "").Trim();

            if (string.IsNullOrEmpty(producto.Codigo_883SC) || producto.Nombre_883SC == "" || producto.Tipo_883SC == "")
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROD_ERR_INCOMPLETO"));
            }
            if (producto.StockMinimo_883SC < 0)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROD_ERR_STOCK_MIN"));
            }
            if (producto.Codigo_883SC.Length > CODIGO_MAX_883SC || producto.Nombre_883SC.Length > NOMBRE_MAX_883SC)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROD_ERR_LARGO"));
            }
        }

        //Precio de lista del item * (1 + margen del proveedor del item / 100)
        private decimal CalcularPrecioVenta_883SC(ItemListaPrecioBE_883SC item)
        {
            foreach (ProveedorBE_883SC proveedor in proveedorBLL_883SC.ListarProveedores_883SC())
            {
                if (proveedor.Id_883SC == item.IdProveedor_883SC)
                {
                    return proveedor.CalcularPrecioVenta_883SC(item.PrecioLista_883SC);
                }
            }
            throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROD_ERR_PROV_REF"));
        }

        private string UsuarioActual_883SC()
        {
            return SessionManager_883SC.Logged_883SC()
                ? SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC
                : "null";
        }
    }
}
