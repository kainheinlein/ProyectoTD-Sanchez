using Entidad_BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Bitacora_883SC
    {
        public static EventoBE_883SC RegistrarEvento_883SC(string us, TipoAccion_883SC accion)
        {
            EventoBE_883SC evento = new EventoBE_883SC();
            evento.usuario_883SC = us;
            evento.accion_883SC = accion;
            evento.fecha_883SC = DateTime.Now;
            return evento;
        }
    }
}
