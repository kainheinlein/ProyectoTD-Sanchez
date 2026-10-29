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
        BitacoraBLL_883SC bitacora_883SC = new BitacoraBLL_883SC();

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

        public void ActualizarDVVSiVerificado_883SC()
        {
            if (SessionManager_883SC.Logged_883SC() && SessionManager_883SC.GetInstance_883SC.IntegridadVerificada_883SC)
            {
                ActualizarDVV_883SC();
            }
        }

        public bool VerificarIntegridad_883SC()
        {
            UsuarioBLL_883SC usuarioBLL = new UsuarioBLL_883SC();
            List<UsuarioBE_883SC> usuarios = usuarioBLL.ListarUsuarios_883SC();
            usuarios = usuarios
                .OrderBy(u => u.cod_883SC)
                .ToList();

            bool ok = VerificadorIntegridad_883SC.VerificarIntegridad_883SC(usuarios,ExtraerDVV_883SC());
            if (ok && SessionManager_883SC.Logged_883SC())
            {
                SessionManager_883SC.GetInstance_883SC.IntegridadVerificada_883SC = true;
            }
            return ok;
        }

        //Actualiza SOLO el DVH de cada usuario (sin historial ni evento ModificacionUsuario),
        //recalcula el DVV y verifica. Lanza excepcion si la integridad no quedo restaurada.
        public void RecalcularDV_883SC()
        {
            UsuarioBLL_883SC usuario = new UsuarioBLL_883SC();
            List<UsuarioBE_883SC> usuarios = usuario.ListarUsuarios_883SC()
                .OrderBy(u => u.cod_883SC)
                .ToList();
            List<string> dvhs = new List<string>();
            foreach (UsuarioBE_883SC ent in usuarios)
            {
                string dvh = VerificadorIntegridad_883SC.CalcularDVH_883SC(ent);
                verificadorMP_883SC.ActualizarDVH_883SC(ent.cod_883SC, dvh);
                dvhs.Add(dvh);
            }
            verificadorMP_883SC.ActualizarDVV_883SC(VerificadorIntegridad_883SC.CalcularDVV_883SC(dvhs),"Usuarios");

            if (!VerificarIntegridad_883SC())
            {
                throw new InvalidOperationException(GestorDeIdioma_883SC.GetInstance_883SC.Traducir_883SC("ERRORDB_MSG_NO_RECALCULADO"));
            }
            if (SessionManager_883SC.Logged_883SC())
            {
                bitacora_883SC.RegistrarBitacora_883SC(SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC, TipoAccion_883SC.RecalculoIntegridad, "resultado=OK");
            }
        }

        public void DenegarAccesoPorIntegridad_883SC()
        {
            try
            {
                if (SessionManager_883SC.Logged_883SC())
                {
                    bitacora_883SC.RegistrarBitacora_883SC(SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC, TipoAccion_883SC.AccesoBloqueadoIntegridad, "motivo=IntegridadDV");
                }
            }
            finally
            {
                SessionManager_883SC.GetInstance_883SC.Logout_883SC();
            }
        }
    }
}
