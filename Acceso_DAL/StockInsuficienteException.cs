using System;

namespace Acceso_DAL
{
    // Se lanza cuando GuardarFactura_SP detecta (dentro de su transaccion) que algun producto de la venta
    // no tiene stock suficiente. El SP ya revirtio todo. La BLL la traduce a un mensaje.
    public class StockInsuficienteException_883SC : Exception
    {
        public StockInsuficienteException_883SC(Exception causa) : base("Stock insuficiente para completar la venta", causa)
        {
        }
    }
}
