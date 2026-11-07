using System;

namespace Servicios
{
    public enum MotivoBackup_883SC
    {
        SqlSinAcceso = 1,       //Error de SO 5: el servicio de SQL Server no puede acceder a la ruta
        SqlRutaInexistente = 2, //Error de SO 3: la ruta no existe en el servidor
        SqlDiscoLleno = 3,      //Error de SO 112: sin espacio en disco
        SqlOtro = 4,            //Otro error de SO (o sin codigo): se muestra el texto de SQL Server
        ClienteSinPermiso = 5   //El usuario de Windows de la app no puede acceder al archivo/carpeta: no se pudo comprobar
    }

    //Fallo de backup/restore con causa conocida. Servicios no puede traducir (el gestor de idiomas esta en Negocio_BLL),
    //asi que lleva el motivo y los datos y BackupBLL_883SC arma el mensaje traducido.
    public class BackupException_883SC : Exception
    {
        private readonly MotivoBackup_883SC _motivo_883SC;
        private readonly string _ruta_883SC;
        private readonly string _detalle_883SC;

        public BackupException_883SC(MotivoBackup_883SC motivo, string ruta, string detalle, Exception interna)
            : base(detalle, interna)
        {
            _motivo_883SC = motivo;
            _ruta_883SC = ruta;
            _detalle_883SC = detalle;
        }

        public MotivoBackup_883SC Motivo_883SC { get => _motivo_883SC; }

        //Ruta del archivo involucrado
        public string Ruta_883SC { get => _ruta_883SC; }

        //Texto original de SQL Server (vacio si el motivo es ClienteSinPermiso)
        public string Detalle_883SC { get => _detalle_883SC; }
    }
}
