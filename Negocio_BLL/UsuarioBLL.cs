using Acceso_DAL;
using Entidad_BE;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Negocio_BLL
{
    public class UsuarioBLL_883SC
    {
        public int maxIntentos_883SC = 3;
        private UsuarioBE_883SC usuario_883SC;
        private MP_Usuario_883SC mpUsuario_883SC = new MP_Usuario_883SC();
        private BitacoraBLL_883SC bitacora_883SC = new BitacoraBLL_883SC();
        private VerificadorIntegridadBLL_883SC integridad_883SC = new VerificadorIntegridadBLL_883SC();

        public List<UsuarioBE_883SC> ListarUsuarios_883SC()
        {
            return mpUsuario_883SC.ListarUsuarios_883SC();
        }

        public LoginResult_883SC Login_883SC(UsuarioBE_883SC us)
        {
            LoginResult_883SC AuthOK;
            us.pass_883SC = Encriptador_883SC.EncriptarIrrev_883SC(us.pass_883SC);
            if (!SessionManager_883SC.Logged_883SC())
            {
                AuthOK = mpUsuario_883SC.Login_883SC(us);
                if (AuthOK == LoginResult_883SC.LoginOK_883SC)
                {
                    us = mpUsuario_883SC.ExtraerUsuario_883SC(us.user_883SC);
                    SessionManager_883SC.GetInstance_883SC.Login_883SC(us);
                    bitacora_883SC.RegistrarBitacora_883SC(us.user_883SC, TipoAccion_883SC.Login);
                    maxIntentos_883SC = 3;
                }
            }
            else
            {
                usuario_883SC = SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC();
                if ((usuario_883SC.user_883SC == us.user_883SC) && (usuario_883SC.pass_883SC == us.pass_883SC))
                {
                    AuthOK = LoginResult_883SC.SesionIniciada_883SC;
                    maxIntentos_883SC = 3;
                }
                else { AuthOK = LoginResult_883SC.ExisteSesion_883SC; }
            }
            if (AuthOK != LoginResult_883SC.LoginOK_883SC && AuthOK != LoginResult_883SC.SesionIniciada_883SC)
            {
                if(AuthOK != LoginResult_883SC.ExisteSesion_883SC){ maxIntentos_883SC--; }
            }
            if (maxIntentos_883SC == 0)
            {
                usuario_883SC = new UsuarioBE_883SC();
                usuario_883SC = mpUsuario_883SC.ExtraerUsuario_883SC(us.user_883SC);
                if (!string.IsNullOrEmpty(usuario_883SC.user_883SC))
                {
                    usuario_883SC.bloq_883SC = true;
                    usuario_883SC.pass_883SC = " ";
                    usuario_883SC.pass_883SC = Encriptador_883SC.EncriptarIrrev_883SC(usuario_883SC.pass_883SC);
                    usuario_883SC.dvh_883SC = VerificadorIntegridad_883SC.CalcularDVH_883SC(usuario_883SC);
                    mpUsuario_883SC.ActualizarBloqueo_883SC(usuario_883SC);
                }
                bitacora_883SC.RegistrarBitacora_883SC(us.user_883SC, TipoAccion_883SC.BloqueoUsuario);
                integridad_883SC.ActualizarDVV_883SC();
                AuthOK = LoginResult_883SC.FinIntentos_883SC;
            }
            bitacora_883SC.RegistrarBitacora_883SC(us.user_883SC, TipoAccion_883SC.LoginFail);
            return AuthOK;
        }

        public int VerifUsuario_883SC(UsuarioBE_883SC us, int tipo)//tipo 0 = Verificar Actual -- tipo == 1 Verificar Nueva
        {
            string encPass = Encriptador_883SC.EncriptarIrrev_883SC(us.pass_883SC);
            if (SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().pass_883SC == encPass)
            {
                maxIntentos_883SC = 3;
                return 1;//Usuario Verificado OK -- Nueva = Anterior
            }
            else
            {
                if (tipo == 1)//Verificar Nueva
                {
                    UsuarioBE_883SC aux = SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC();
                    aux.pass_883SC = encPass;
                    aux.dvh_883SC = VerificadorIntegridad_883SC.CalcularDVH_883SC(aux);
                    mpUsuario_883SC.CambiarPass_883SC(aux);
                    maxIntentos_883SC = 3;
                    bitacora_883SC.RegistrarBitacora_883SC(aux.user_883SC, TipoAccion_883SC.CambioClave);
                    return 2;//Cambio de pass ok
                }
                maxIntentos_883SC--;
                if (maxIntentos_883SC == 0)
                {
                    if (tipo == 0)//Verificar Actual
                    {
                        UsuarioBE_883SC aux = SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC();
                        aux.bloq_883SC = true;
                        aux.dvh_883SC = VerificadorIntegridad_883SC.CalcularDVH_883SC(aux);
                        mpUsuario_883SC.ActualizarBloqueo_883SC(aux);
                        bitacora_883SC.RegistrarBitacora_883SC(aux.user_883SC, TipoAccion_883SC.BloqueoUsuario);
                        return 2; //Falla Verificacion, Bloquea usuario
                    }
                    else
                    {
                        maxIntentos_883SC = 3;
                        return 3;
                    }
                }
                bitacora_883SC.RegistrarBitacora_883SC(SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC, TipoAccion_883SC.LoginFail);
                return 0; //Reintentar
            }
        }

        public void Logout_883SC()
        {
            if(SessionManager_883SC.Logged_883SC())
            {
                bitacora_883SC.RegistrarBitacora_883SC(SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC, TipoAccion_883SC.Logout);
                integridad_883SC.ActualizarDVV_883SC();
                SessionManager_883SC.GetInstance_883SC.Logout_883SC();
            }
        }

        public void DesbloquearUS_883SC(UsuarioBE_883SC us)
        {
            usuario_883SC = us;
            us.pass_883SC = Encriptador_883SC.EncriptarIrrev_883SC(GenerarPass_883SC(us.ape_883SC, us.dni_883SC.ToString()));
            us.bloq_883SC = false;
            us.dvh_883SC = VerificadorIntegridad_883SC.CalcularDVH_883SC(us);
            mpUsuario_883SC.ActualizarBloqueo_883SC(us);
            bitacora_883SC.RegistrarBitacora_883SC(SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC, TipoAccion_883SC.DesbloqueoUsuario);
        }

        public void CrearUsuario_883SC(UsuarioBE_883SC us)
        {
            usuario_883SC = us;
            us.pass_883SC = Encriptador_883SC.EncriptarIrrev_883SC(us.pass_883SC);
            string responsable = SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC;

            us.cod_883SC = mpUsuario_883SC.CrearUsuarioConHistorial_883SC(us, responsable);
            us.dvh_883SC = VerificadorIntegridad_883SC.CalcularDVH_883SC(us);
            mpUsuario_883SC.ActualizarUsuario_883SC(usuario_883SC);

            bitacora_883SC.RegistrarBitacora_883SC(responsable, TipoAccion_883SC.AltaUsuario);
        }

        public void EliminarUs_883SC(UsuarioBE_883SC us)
        {
            us.dvh_883SC = VerificadorIntegridad_883SC.CalcularDVH_883SC(us);
            string responsable = SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC;
            mpUsuario_883SC.EliminarUsuarioConHistorial_883SC(us, responsable);
            bitacora_883SC.RegistrarBitacora_883SC(responsable, TipoAccion_883SC.BajaUsuario);
        }

        public void ActualizarUsuario_883SC(UsuarioBE_883SC us)
        {
            us.dvh_883SC = VerificadorIntegridad_883SC.CalcularDVH_883SC(us);
            if(SessionManager_883SC.Logged_883SC())
            {
                string responsable = SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC;
                mpUsuario_883SC.ActualizarUsuarioConHistorial_883SC(us, responsable, TipoAccion_883SC.ModificacionUsuario);
                bitacora_883SC.RegistrarBitacora_883SC(responsable, TipoAccion_883SC.ModificacionUsuario);
            }
        }

        public string GenerarPass_883SC(string ape, string dni)
        {
            string pass = ape.Substring(0, 3) + dni.Substring(0, 3);
            return pass;
        }
    }
}
