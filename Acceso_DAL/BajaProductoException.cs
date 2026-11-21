using System;

namespace Acceso_DAL
{
    // Se lanza cuando BajaProducto_SP o ReactivarProducto_SP rechazan la operacion.
    // Numero: 50001 el producto no existe, 50002 el estado no corresponde (ya esta de baja / no esta de baja),
    // 50003 (solo reactivar) el proveedor de referencia esta dado de baja. La BLL la traduce a un mensaje.
    public class BajaProductoException_883SC : Exception
    {
        private readonly int _numero_883SC;
        public int Numero_883SC
        {
            get { return _numero_883SC; }
        }

        public BajaProductoException_883SC(int numero, Exception causa) : base("No se pudo cambiar el estado del producto", causa)
        {
            _numero_883SC = numero;
        }
    }
}
