using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad_BE
{
    public class PermisoSimple_883SC : Permiso_883SC
    {
        public PermisoSimple_883SC(string nombre) : base(nombre)
        {
        }

        public override List<Permiso_883SC> RetornarListaHijos_883SC()
        {
            return new List<Permiso_883SC>();
        }
    }
}
