using Negocio_BLL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    /// Mapa pantalla -> tema de ayuda (clave de AyudaTema). Solo datos: las pantallas no saben que existe.
    /// Una pantalla que no figura aca abre la ayuda en el tema de inicio.
    internal static class AyudaMapa_883SC
    {
        private static readonly Dictionary<Type, string> _mapa_883SC = new Dictionary<Type, string>
        {
            { typeof(frmIdiomas_883SC), "AYUDA_IDIOMA" },
            { typeof(frmLlenarCarrito_883SC), "AYUDA_CARRITO" },
            { typeof(frmRealizarVenta_883SC), "AYUDA_VENTA" },
            { typeof(frmClientes_883SC), "AYUDA_CLIENTES" },
            { typeof(frmAdministrarProductos_883SC), "AYUDA_PRODUCTOS" },
            { typeof(frmProveedores_883SC), "AYUDA_PROVEEDORES" },
            { typeof(frmImportarListaPrecios_883SC), "AYUDA_COMPRAS" },
            { typeof(frmGenerarOrdenesCompra_883SC), "AYUDA_COMPRAS" },
            { typeof(frmAutorizarOrdenesCompra_883SC), "AYUDA_COMPRAS" },
            { typeof(frmRegistrarRecepcion_883SC), "AYUDA_COMPRAS" },
            { typeof(frmReporteVentas_883SC), "AYUDA_REPORTES" },
            { typeof(frmBitacora_883SC), "AYUDA_BIT_EVENTOS" },
            { typeof(frmBitacoraCambios_883SC), "AYUDA_BIT_CAMBIOS" },
            { typeof(frmBackup_883SC), "AYUDA_BACKUP" },
            { typeof(frmUsuario_883SC), "AYUDA_USUARIOS" },
            { typeof(frmGestionPerfiles_883SC), "AYUDA_USUARIOS" }
        };

        /// Clave del tema de la pantalla indicada (null, cerrada o sin tema propio: el tema de inicio)
        public static string TemaDe_883SC(Form pantalla)
        {
            string clave;
            if (pantalla != null && !pantalla.IsDisposed && _mapa_883SC.TryGetValue(pantalla.GetType(), out clave))
            {
                return clave;
            }
            return AyudaBLL_883SC.TemaInicio_883SC;
        }
    }
}
