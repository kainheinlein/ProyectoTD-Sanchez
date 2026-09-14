using Entidad_BE;

namespace Negocio_BLL
{
    public class CarritoBLL_883SC
    {
        public DetalleCarritoBE_883SC CrearDetalleCarrito_883SC(ProductoBE_883SC producto, int cantidad)
        {
            DetalleCarritoBE_883SC detalle = new DetalleCarritoBE_883SC();
            detalle.Producto_883SC = producto;
            detalle.Cantidad_883SC = cantidad;
            detalle.PrecioUnitario_883SC = producto.Precio_883SC;
            return detalle;
        }
    }
}
