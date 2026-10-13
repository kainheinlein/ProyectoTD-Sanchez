using Acceso_DAL;
using Entidad_BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio_BLL
{
    public class PerfilBLL_883SC
    {
        private PerfilDAL_883SC perfilDAL_883SC = new PerfilDAL_883SC();

        public List<Permiso_883SC> ListaPermisos_883SC(string pTipo = "")
        {
            return perfilDAL_883SC.ListaPermisos_883SC(pTipo);
        }

        public bool ValidarNombre_883SC(string pNombre)
        {
            if (perfilDAL_883SC.ListaPermisos_883SC("Compuesto").Exists(x => x.Nombre_883SC == pNombre))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PerfilEnUso_883SC(string nombre)
        {
            return perfilDAL_883SC.PerfilEnUso_883SC(nombre);
        }

        public void EliminarFamilia_883SC(Familia_883SC pFamilia)
        {
            perfilDAL_883SC.EliminarFamilia_883SC(pFamilia);
        }

        public List<Permiso_883SC> ListaPermisosEnArbol_883SC()
        {
            return perfilDAL_883SC.ListaPermisosEnArbol_883SC();
        }

        public List<Permiso_883SC> ListaPermisosRaiz_883SC()
        {
            return perfilDAL_883SC.ListaPermisosRaiz_883SC();
        }

        public bool TienePermiso_883SC(string nombreRol, string nombrePermiso)
        {
            if (string.IsNullOrEmpty(nombreRol))
            {
                return false;
            }

            Familia_883SC rol = ListaPermisosEnArbol_883SC().OfType<Familia_883SC>().FirstOrDefault(f => f.Nombre_883SC == nombreRol);
            if (rol == null)
            {
                return false;
            }

            return BuscarPermisoRecursivo_883SC(rol, nombrePermiso);
        }

        private bool BuscarPermisoRecursivo_883SC(Familia_883SC familia, string nombrePermiso)
        {
            foreach (var hijo in familia.RetornarListaHijos_883SC())
            {
                if (hijo.Nombre_883SC == nombrePermiso)
                {
                    return true;
                }

                if (hijo is Familia_883SC familiaHijo && BuscarPermisoRecursivo_883SC(familiaHijo, nombrePermiso))
                {
                    return true;
                }
            }
            return false;
        }

        public void AgregarFamilia_883SC(Familia_883SC pFamilia)
        {
            perfilDAL_883SC.AgregarFamilia_883SC(pFamilia);
        }

        public void ModificarFamilia_883SC(Familia_883SC pFamilia, List<string> permisos)
        {
            perfilDAL_883SC.ModificarFamilia_883SC(pFamilia, permisos);
        }

        public void AgregarPermisoFamilia_883SC(string pNombreFamilia, List<string> pNombrePermisos)
        {
            foreach (var s in pNombrePermisos)
            {
                perfilDAL_883SC.AgregarPermisoAFamilia_883SC(pNombreFamilia, s);
            }
        }

        public List<Permiso_883SC> ObtenerHijosDeFamilia_883SC(string nombreFamilia)
        {
            List<Permiso_883SC> permisosEnArbol = ListaPermisosEnArbol_883SC();

            // Verificar si permisosEnArbol no es nulo
            if (permisosEnArbol == null)
            {
                return new List<Permiso_883SC>();
            }

            // Encontrar la familia con el nombre dado
            Familia_883SC familia = permisosEnArbol.OfType<Familia_883SC>().FirstOrDefault(f => f.Nombre_883SC == nombreFamilia);

            // Devolver los hijos si se encuentra la familia, de lo contrario una lista vac�a
            return familia?.RetornarListaHijos_883SC() ?? new List<Permiso_883SC>();
        }

        public void EliminarPermisoDeFamilia_883SC(string familia, string permiso)
        {
            perfilDAL_883SC.EliminarPermisoDeFamilia_883SC(familia, permiso);
        }
    }
}
