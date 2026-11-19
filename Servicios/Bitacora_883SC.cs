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
        private const int LargoMaxDetalle_883SC = 500;

        public static EventoBE_883SC RegistrarEvento_883SC(string us, TipoAccion_883SC accion, string detalle = null)
        {
            EventoBE_883SC evento = new EventoBE_883SC();
            evento.usuario_883SC = us;
            evento.accion_883SC = accion;
            evento.fecha_883SC = DateTime.Now;
            //Se recorta al largo de la columna para que un detalle largo nunca haga fallar la operacion de negocio
            if (detalle != null && detalle.Length > LargoMaxDetalle_883SC)
            {
                detalle = detalle.Substring(0, LargoMaxDetalle_883SC);
            }
            evento.detalle_883SC = detalle;
            return evento;
        }
    }
}
