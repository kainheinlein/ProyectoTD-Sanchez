using Acceso_DAL;
using Entidad_BE;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio_BLL
{
    public class VerificadorIntegridadBLL_883SC
    {
        MP_VerificadorIntegridad_883SC verificadorMP_883SC = new MP_VerificadorIntegridad_883SC();

        public List<string> ExtraerDVH_883SC()
        {
            return verificadorMP_883SC.ExtraerDVH_883SC("Usuarios");
        }

        public string ExtraerDVV_883SC()
        {
            return verificadorMP_883SC.ExtraerDVV_883SC("Usuarios");
        }

        public void ActualizarDVV_883SC()
        {
            verificadorMP_883SC.ActualizarDVV_883SC(VerificadorIntegridad_883SC.CalcularDVV_883SC(ExtraerDVH_883SC()),"Usuarios");
        }

        public bool VerificarIntegridad_883SC()
        {
            UsuarioBLL_883SC usuarioBLL = new UsuarioBLL_883SC();
            List<UsuarioBE_883SC> usuarios = usuarioBLL.ListarUsuarios_883SC();
            usuarios = usuarios
                .OrderBy(u => u.cod_883SC)
                .ToList();

            return VerificadorIntegridad_883SC.VerificarIntegridad_883SC(usuarios,ExtraerDVV_883SC());
        }

        public void RecalcularDV_883SC()
        {
            UsuarioBLL_883SC usuario = new UsuarioBLL_883SC();
            List<UsuarioBE_883SC> usuarios = usuario.ListarUsuarios_883SC();
            List<string> dvhs = new List<string>();
            usuarios = usuarios
                .OrderBy(u => u.cod_883SC)
                .ToList();
            foreach (UsuarioBE_883SC ent  in usuarios)
            {
                ent.dvh_883SC = VerificadorIntegridad_883SC.CalcularDVH_883SC(ent);
                dvhs.Add(ent.dvh_883SC);
                usuario.ActualizarUsuario_883SC(ent);
            }
            verificadorMP_883SC.ActualizarDVV_883SC(VerificadorIntegridad_883SC.CalcularDVV_883SC(dvhs),"Usuarios");
        }
    }
}
