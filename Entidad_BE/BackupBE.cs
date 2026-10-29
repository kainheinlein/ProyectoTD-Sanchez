using System;
using System.IO;

namespace Entidad_BE
{
    public class BackupBE_883SC
    {
        //Id de catalogo generado por la base
        private int _id_883SC;
        public int Id_883SC
        {
            get { return _id_883SC; }
        }

        public void AsignarId_883SC(int id)
        {
            _id_883SC = id;
        }

        private string _nombreArchivo_883SC;
        public string NombreArchivo_883SC
        {
            get { return _nombreArchivo_883SC; }
            set { _nombreArchivo_883SC = value; }
        }

        private string _ruta_883SC;
        public string Ruta_883SC
        {
            get { return _ruta_883SC; }
            set { _ruta_883SC = value; }
        }

        private DateTime _fecha_883SC;
        public DateTime Fecha_883SC
        {
            get { return _fecha_883SC; }
            set { _fecha_883SC = value; }
        }

        private string _usuario_883SC;
        public string Usuario_883SC
        {
            get { return _usuario_883SC; }
            set { _usuario_883SC = value; }
        }

        private long? _tamanioBytes_883SC;
        public long? TamanioBytes_883SC
        {
            get { return _tamanioBytes_883SC; }
            set { _tamanioBytes_883SC = value; }
        }

        private bool _verificado_883SC;
        public bool Verificado_883SC
        {
            get { return _verificado_883SC; }
            set { _verificado_883SC = value; }
        }

        public string RutaCompleta_883SC
        {
            get { return Path.Combine(_ruta_883SC, _nombreArchivo_883SC); }
        }
    }
}
