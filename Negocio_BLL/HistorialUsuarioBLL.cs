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
    public class HistorialUsuarioBLL_883SC
    {
        private MP_HistorialUsuario_883SC mpHistorial_883SC = new MP_HistorialUsuario_883SC();
        private MP_Usuario_883SC mpUsuario_883SC = new MP_Usuario_883SC();
        private BitacoraBLL_883SC bitacora_883SC = new BitacoraBLL_883SC();

        public List<HistorialUsuarioBE_883SC> ListarHistorial_883SC()
        {
            return mpHistorial_883SC.ListarHistorial_883SC();
        }
        public List<HistorialUsuarioBE_883SC> BuscarHistorial_883SC(TipoAccion_883SC? accion, DateTime fIni, DateTime fFin)
        {
            return mpHistorial_883SC.ListarHistorial_883SC(accion, fIni, fFin);
        }

        public void RestaurarVersion_883SC(int idHistorial, string usuarioResponsable)
        {
            HistorialUsuarioBE_883SC version = mpHistorial_883SC.ObtenerVersion_883SC(idHistorial);
            if (version == null) { throw new Exception("La versión seleccionada no existe."); }

            UsuarioBE_883SC us = mpUsuario_883SC.ExtraerUsuario_883SC(version.usuario_883SC); // trae el estado actual (incluye pass, que no se toca)
            if (us == null) { throw new Exception("El usuario ya no existe."); }

            us.dni_883SC = Convert.ToInt32(version.dni_883SC);
            us.nomb_883SC = version.nombre_883SC;
            us.ape_883SC = version.apellido_883SC;
            us.rol_883SC = version.rol_883SC;
            us.dir_883SC = version.direccion_883SC;
            us.tel_883SC = version.telefono_883SC;
            us.email_883SC = version.email_883SC;
            us.estado_883SC = version.activo_883SC;
            us.bloq_883SC = version.bloqueado_883SC;
            us.dvh_883SC = VerificadorIntegridad_883SC.CalcularDVH_883SC(us);

            mpUsuario_883SC.ActualizarUsuarioConHistorial_883SC(us, usuarioResponsable, TipoAccion_883SC.RestauracionUsuario);
            bitacora_883SC.RegistrarBitacora_883SC(usuarioResponsable, TipoAccion_883SC.RestauracionUsuario);
        }
    }
}
