using System;

namespace Acceso_DAL
{
    public class ActivarVersionException_883SC : Exception
    {
        private readonly int _numero_883SC;
        public int Numero_883SC
        {
            get { return _numero_883SC; }
        }

        public ActivarVersionException_883SC(int numero, Exception causa) : base("No se pudo activar la version del producto", causa)
        {
            _numero_883SC = numero;
        }
    }
}
