using Acceso_DAL;
using Entidad_BE;
using System.Collections.Generic;

namespace Negocio_BLL
{
    public class ProductoBLL_883SC
    {
        MP_Producto_883SC mpProducto_883SC = new MP_Producto_883SC();

        public List<ProductoBE_883SC> BuscarProductos_883SC(string criterio, string dato)
        {
            return mpProducto_883SC.BuscarProductos_883SC(criterio, dato);
        }
    }
}
