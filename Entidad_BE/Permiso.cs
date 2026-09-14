using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad_BE
{
    public abstract class Permiso_883SC
    {
        protected string _nombre_883SC;

        public string Nombre_883SC
        {
            get { return _nombre_883SC; }
            set { _nombre_883SC = value; }
        }

        public Permiso_883SC(string nombre)
        {
            _nombre_883SC = nombre;
        }

        public abstract List<Permiso_883SC> RetornarListaHijos_883SC();

        public string getPermisoNombre_883SC()
        {
            return _nombre_883SC;
        }
    }
}
