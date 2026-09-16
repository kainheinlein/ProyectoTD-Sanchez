using Acceso_DAL;
using Entidad_BE;
using System.Collections.Generic;

namespace Negocio_BLL
{
    public class MetodoPagoBLL_883SC
    {
        MP_MetodoPago_883SC mpMetodoPago_883SC = new MP_MetodoPago_883SC();

        public List<MetodoPagoBE_883SC> ListarMetodos_883SC()
        {
            return mpMetodoPago_883SC.ListarMetodos_883SC();
        }
    }
}
