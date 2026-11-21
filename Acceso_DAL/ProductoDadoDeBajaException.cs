using System;

namespace Acceso_DAL
{
    // Se lanza cuando un SP rechaza la operacion porque el producto esta dado de baja
    // (venta, orden de compra o modificacion). La BLL la traduce a un mensaje.
    public class ProductoDadoDeBajaException_883SC : Exception
    {
        public ProductoDadoDeBajaException_883SC(Exception causa) : base("El producto esta dado de baja", causa)
        {
        }
    }
}
