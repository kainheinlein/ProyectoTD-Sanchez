using Acceso_DAL;
using Entidad_BE;
using Servicios;
using System;
using System.Collections.Generic;

namespace Negocio_BLL
{
    public class FacturaBLL_883SC
    {
        MP_Factura_883SC mpFactura_883SC = new MP_Factura_883SC();
        BitacoraBLL_883SC bitacora_883SC = new BitacoraBLL_883SC();

        public FacturaBE_883SC CrearFactura_883SC(CarritoBE_883SC carrito, ClienteBE_883SC cliente,
            MetodoPagoBE_883SC metodoPago, string codigoAutorizacion)
        {
            if (carrito == null || carrito.Detalle_883SC == null || carrito.Detalle_883SC.Count == 0)
            {
                throw new InvalidOperationException("No se puede facturar un carrito sin productos");
            }
            if (cliente == null)
            {
                throw new InvalidOperationException("Debe indicar el cliente de la factura");
            }
            if (metodoPago == null)
            {
                throw new InvalidOperationException("Debe realizar el cobro antes de generar la factura");
            }
            if (!SessionManager_883SC.Logged_883SC())
            {
                throw new InvalidOperationException("Debe iniciar sesion para facturar");
            }

            //El precio ya viene congelado desde el carrito (CUN-002),
            //no se vuelve a leer Producto_883SC.Precio_883SC
            List<DetalleFacturaBE_883SC> detalle = new List<DetalleFacturaBE_883SC>();
            foreach (DetalleCarritoBE_883SC lineaCarrito in carrito.Detalle_883SC)
            {
                DetalleFacturaBE_883SC lineaFactura = new DetalleFacturaBE_883SC();
                lineaFactura.Producto_883SC = lineaCarrito.Producto_883SC;
                lineaFactura.Cantidad_883SC = lineaCarrito.Cantidad_883SC;
                lineaFactura.PrecioUnitario_883SC = lineaCarrito.PrecioUnitario_883SC;
                detalle.Add(lineaFactura);
            }

            FacturaBE_883SC factura = FacturaBE_883SC.CrearFactura_883SC(
                cliente, detalle, carrito.IdCarrito_883SC, metodoPago, codigoAutorizacion);

            UsuarioBE_883SC usuario = SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC();
            factura.IdUsuario_883SC = usuario.cod_883SC;

            int id = mpFactura_883SC.GuardarFactura_883SC(factura);
            factura.AsignarId_883SC(id);

            bitacora_883SC.RegistrarBitacora_883SC(usuario.user_883SC, TipoAccion_883SC.AltaFactura);
            return factura;
        }
    }
}
