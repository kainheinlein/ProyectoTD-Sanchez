using Acceso_DAL;
using Entidad_BE;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio_BLL
{
    public class BitacoraBLL_883SC
    {
        private MP_Bitacora_883SC mpBitacora_883SC = new MP_Bitacora_883SC();

        public List<EventoBE_883SC> ListarBitacora_883SC()
        {
            return mpBitacora_883SC.ListarEventos_883SC();
        }

        public void RegistrarBitacora_883SC(string us, TipoAccion_883SC acc)
        {
            mpBitacora_883SC.RegistrarEvento_883SC(Bitacora_883SC.RegistrarEvento_883SC(us, acc));
        }

        public List<EventoBE_883SC> BuscarEventos_883SC(string us, TipoAccion_883SC? acc, DateTime fIni, DateTime fFin)
        {
            return mpBitacora_883SC.BuscarEventos_883SC(us,acc,fIni, fFin);
        }
    }
}
