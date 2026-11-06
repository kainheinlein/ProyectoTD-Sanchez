using Acceso_DAL;
using Entidad_BE;
using System.Collections.Generic;

namespace Negocio_BLL
{
    public class ProveedorBLL_883SC
    {
        MP_Proveedor_883SC mpProveedor_883SC = new MP_Proveedor_883SC();

        public List<ProveedorBE_883SC> ListarProveedores_883SC()
        {
            return mpProveedor_883SC.ListarProveedores_883SC();
        }
    }
}
