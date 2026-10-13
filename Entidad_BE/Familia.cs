using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad_BE
{
    public class Familia_883SC : Permiso_883SC
    {
        private List<Permiso_883SC> _hijos_883SC;
        private bool _esRol_883SC;

        public List<Permiso_883SC> Hijos_883SC
        {
            get { return _hijos_883SC; }
            set { _hijos_883SC = value; }
        }

        public bool EsRol_883SC
        {
            get { return _esRol_883SC; }
            set { _esRol_883SC = value; }
        }

        public Familia_883SC(string nombre, bool esRol = false) : base(nombre)
        {
            _hijos_883SC = new List<Permiso_883SC>();
            _esRol_883SC = esRol;
        }

        public override List<Permiso_883SC> RetornarListaHijos_883SC()
        {
            return _hijos_883SC;
        }

        public void AgregarHijo_883SC(Permiso_883SC hijo)
        {
            if (!_hijos_883SC.Contains(hijo))
            {
                _hijos_883SC.Add(hijo);
            }
        }

        public void EliminarHijo_883SC(Permiso_883SC hijo)
        {
            _hijos_883SC.Remove(hijo);
        }
    }
}