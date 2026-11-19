using System;

namespace Servicios
{
    public enum MotivoInicializacion_883SC
    {
        SinPermisosCrearBase = 1,
        CarpetaDeDatos = 2,
        ErrorCrearBase = 3,
        SinAccesoBase = 4,
        EsquemaFallido = 5,
        AdminFallido = 6
    }

    //Fallo al preparar la base en el primer arranque. El mensaje esta en espanol fijo: las traducciones viven en la base,
    //que puede no existir todavia (igual que ConexionNoDisponibleException_883SC).
    public class InicializacionException_883SC : Exception
    {
        private readonly MotivoInicializacion_883SC _motivo_883SC;

        public InicializacionException_883SC(MotivoInicializacion_883SC motivo, string mensaje, Exception interna)
            : base(mensaje, interna)
        {
            _motivo_883SC = motivo;
        }

        public MotivoInicializacion_883SC Motivo_883SC { get => _motivo_883SC; }
    }
}
