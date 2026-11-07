using System;

namespace Acceso_DAL
{
    /// Se lanza cuando el SP detecta (dentro de su transaccion) que la orden ya no esta Pendiente,
    /// por ejemplo porque otro usuario la resolvio primero. La BLL la traduce a un mensaje.
    public class OrdenNoPendienteException_883SC : Exception
    {
        public OrdenNoPendienteException_883SC(Exception causa) : base("La orden ya no esta pendiente", causa)
        {
        }
    }
}
