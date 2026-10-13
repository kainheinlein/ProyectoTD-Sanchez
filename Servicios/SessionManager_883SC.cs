using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Entidad_BE;

namespace Servicios
{
    public class SessionManager_883SC
    {
        private static SessionManager_883SC _sesion_883SC = null;
        private static object _lock_883SC = new object();//Bloquear acceso multihilo
        private UsuarioBE_883SC _usuario_883SC;
        private bool logged_883SC = false;

        private SessionManager_883SC() { }

        public static SessionManager_883SC GetInstance_883SC
        {
            get
            {
                if (_sesion_883SC == null)
                {
                    lock (_lock_883SC)
                    {
                        if (_sesion_883SC == null)
                        {
                            _sesion_883SC = new SessionManager_883SC();
                        }
                    }
                }
                return _sesion_883SC;
            }
        }

        public UsuarioBE_883SC UsuarioActual_883SC()
        {
            return _usuario_883SC;
        }

        public void Login_883SC(UsuarioBE_883SC usuario)
        {
            logged_883SC = true;
            _usuario_883SC = usuario;
        }

        public void Logout_883SC()
        {
            logged_883SC = false;
            _usuario_883SC = null;
            _sesion_883SC = null;
        }

        public static bool Logged_883SC()
        {
            return GetInstance_883SC.logged_883SC;
        }
    }
}
