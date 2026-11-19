using System;
using System.Collections.Generic;

namespace Servicios
{
    //Ninguna instancia de SQL Server respondio (ni la del config ni las alternativas)
    public class ConexionNoDisponibleException_883SC : Exception
    {
        private readonly List<string> _instanciasProbadas_883SC;

        public ConexionNoDisponibleException_883SC(string mensaje, List<string> instanciasProbadas, Exception interna)
            : base(mensaje, interna)
        {
            _instanciasProbadas_883SC = instanciasProbadas;
        }

        public IReadOnlyList<string> InstanciasProbadas_883SC { get => _instanciasProbadas_883SC; }
    }
}
