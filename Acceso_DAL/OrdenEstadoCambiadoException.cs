using System;

namespace Acceso_DAL
{
    /// Se lanza cuando el SP detecta (dentro de su transaccion) que la orden ya no esta en el estado que la
    /// operacion necesita (Autorizada para el envio, EnEjecucion para la recepcion), por ejemplo porque otro
    /// usuario la gestiono primero. La BLL la traduce a un mensaje.
    public class OrdenEstadoCambiadoException_883SC : Exception
    {
        public OrdenEstadoCambiadoException_883SC(Exception causa) : base("La orden ya no esta en el estado esperado", causa)
        {
        }
    }
}
