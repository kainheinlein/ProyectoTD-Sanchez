using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad_BE;

namespace Acceso_DAL
{
    public class MP_Usuario_883SC
    {
        AccesoDatos_883SC conexDB_883SC = new AccesoDatos_883SC();

        public List<UsuarioBE_883SC> ListarUsuarios_883SC()
        {
            List<UsuarioBE_883SC> usuarios = new List<UsuarioBE_883SC>();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@tabla", "Usuarios");
            DataTable dt = conexDB_883SC.LeerTabla_883SC("SP_ExtTabla", param);
            foreach (DataRow dr in dt.Rows)
            {
                UsuarioBE_883SC us = new UsuarioBE_883SC();
                us.cod_883SC = Convert.ToInt32(dr[0].ToString());
                us.dni_883SC = Convert.ToInt32(dr[1].ToString());
                us.nomb_883SC = dr[2].ToString();
                us.ape_883SC = dr[3].ToString();
                us.user_883SC = dr[4].ToString();
                us.rol_883SC = dr[5].ToString();
                us.pass_883SC = dr[6].ToString();
                us.dir_883SC = dr[7].ToString();
                us.tel_883SC = dr[8].ToString();
                us.email_883SC = dr[9].ToString();
                us.estado_883SC = Convert.ToBoolean(dr[10].ToString());
                us.bloq_883SC = Convert.ToBoolean(dr[11].ToString());
                us.dvh_883SC = dr[12].ToString();
                usuarios.Add(us);
            }
            return usuarios;
        }

        public LoginResult_883SC Login_883SC(UsuarioBE_883SC us)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@user", us.user_883SC);
            parametros[1] = new SqlParameter("@pass", us.pass_883SC);

            return (LoginResult_883SC)conexDB_883SC.Consulta_883SC("SP_Login", parametros);
        }

        public void ActualizarBloqueo_883SC(UsuarioBE_883SC us)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("@Usuario", us.user_883SC);
            parametros[1] = new SqlParameter("@pass", us.pass_883SC);
            parametros[2] = new SqlParameter("@Bloqueado", us.bloq_883SC);
            parametros[3] = new SqlParameter("@DVH", us.dvh_883SC);

            conexDB_883SC.Escribir_883SC("SP_ActualizarBloqueado", parametros);
        }

        public int CrearUsuarioConHistorial_883SC(UsuarioBE_883SC us, string usuarioResponsable)
        {
            SqlParameter[] parametros = new SqlParameter[12];
            parametros[0] = new SqlParameter("@DNI", us.dni_883SC);
            parametros[1] = new SqlParameter("@Nombre", us.nomb_883SC);
            parametros[2] = new SqlParameter("@Apellido", us.ape_883SC);
            parametros[3] = new SqlParameter("@Usuario", us.user_883SC);
            parametros[4] = new SqlParameter("@Rol", us.rol_883SC);
            parametros[5] = new SqlParameter("@Contraseña", us.pass_883SC);
            parametros[6] = new SqlParameter("@Direccion", us.dir_883SC);
            parametros[7] = new SqlParameter("@Telefono", us.tel_883SC);
            parametros[8] = new SqlParameter("@Email", us.email_883SC);
            parametros[9] = new SqlParameter("@Activo", us.estado_883SC);
            parametros[10] = new SqlParameter("@Bloqueado", us.bloq_883SC);
            parametros[11] = new SqlParameter("@UsuarioResponsable", usuarioResponsable);

            return Convert.ToInt32(conexDB_883SC.EscribirRetornar_883SC("SP_CrearUsuario", parametros));
        }

        public void EliminarUsuarioConHistorial_883SC(UsuarioBE_883SC us, string usuarioResponsable)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@Usuario", us.user_883SC);
            parametros[1] = new SqlParameter("@DVH", us.dvh_883SC);
            parametros[2] = new SqlParameter("@UsuarioResponsable", usuarioResponsable);

            conexDB_883SC.Escribir_883SC("SP_ElimUsuario", parametros);
        }

        public void ActualizarUsuario_883SC(UsuarioBE_883SC us) //Uso exclusivo para actualizar DVH
        {
            SqlParameter[] parametros = new SqlParameter[12];
            parametros[0] = new SqlParameter("@Codigo", us.cod_883SC);
            parametros[1] = new SqlParameter("@DNI", us.dni_883SC);
            parametros[2] = new SqlParameter("@Nombre", us.nomb_883SC);
            parametros[3] = new SqlParameter("@Apellido", us.ape_883SC);
            parametros[4] = new SqlParameter("@Usuario", us.user_883SC);
            parametros[5] = new SqlParameter("@Rol", us.rol_883SC);
            parametros[6] = new SqlParameter("@Direccion", us.dir_883SC);
            parametros[7] = new SqlParameter("@Telefono", us.tel_883SC);
            parametros[8] = new SqlParameter("@Email", us.email_883SC);
            parametros[9] = new SqlParameter("@Activo", us.estado_883SC);
            parametros[10] = new SqlParameter("@Bloqueado", us.bloq_883SC);
            parametros[11] = new SqlParameter("@DVH", us.dvh_883SC);

            conexDB_883SC.Escribir_883SC("SP_ActualizarUs", parametros);
        }

        public void CambiarPass_883SC(UsuarioBE_883SC us)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@Usuario", us.user_883SC);
            parametros[1] = new SqlParameter("@pass", us.pass_883SC);
            parametros[2] = new SqlParameter("@DVH", us.dvh_883SC);

            conexDB_883SC.Escribir_883SC("SP_CambiarPass", parametros);
        }

        public UsuarioBE_883SC ExtraerUsuario_883SC(string us)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@user", us);
            DataTable dt = conexDB_883SC.LeerTabla_883SC("SP_ExtUser", param);
            if (dt.Rows.Count > 0)
            {
                UsuarioBE_883SC aux = new UsuarioBE_883SC();
                aux.cod_883SC = Convert.ToInt32(dt.Rows[0][0].ToString());
                aux.dni_883SC = Convert.ToInt32(dt.Rows[0][1].ToString());
                aux.nomb_883SC = dt.Rows[0][2].ToString();
                aux.ape_883SC = dt.Rows[0][3].ToString();
                aux.user_883SC = dt.Rows[0][4].ToString();
                aux.rol_883SC = dt.Rows[0][5].ToString();
                aux.pass_883SC = dt.Rows[0][6].ToString();
                aux.dir_883SC = dt.Rows[0][7].ToString();
                aux.tel_883SC = dt.Rows[0][8].ToString();
                aux.email_883SC = dt.Rows[0][9].ToString();
                aux.estado_883SC = Convert.ToBoolean(dt.Rows[0][10].ToString());
                aux.bloq_883SC = Convert.ToBoolean(dt.Rows[0][11].ToString());
                aux.dvh_883SC = dt.Rows[0][12].ToString();
                return aux;
            }
            else return null;
        }

        public void ActualizarUsuarioConHistorial_883SC(UsuarioBE_883SC us, string usuarioResponsable, TipoAccion_883SC accion)
        {
            SqlParameter[] parametros = new SqlParameter[14];
            parametros[0] = new SqlParameter("@Codigo", us.cod_883SC);
            parametros[1] = new SqlParameter("@DNI", us.dni_883SC);
            parametros[2] = new SqlParameter("@Nombre", us.nomb_883SC);
            parametros[3] = new SqlParameter("@Apellido", us.ape_883SC);
            parametros[4] = new SqlParameter("@Usuario", us.user_883SC);
            parametros[5] = new SqlParameter("@Rol", us.rol_883SC);
            parametros[6] = new SqlParameter("@Direccion", us.dir_883SC);
            parametros[7] = new SqlParameter("@Telefono", us.tel_883SC);
            parametros[8] = new SqlParameter("@Email", us.email_883SC);
            parametros[9] = new SqlParameter("@Activo", us.estado_883SC);
            parametros[10] = new SqlParameter("@Bloqueado", us.bloq_883SC);
            parametros[11] = new SqlParameter("@DVH", us.dvh_883SC);
            parametros[12] = new SqlParameter("@UsuarioResponsable", usuarioResponsable);
            parametros[13] = new SqlParameter("@Accion", (int)accion);

            conexDB_883SC.Escribir_883SC("SP_ActualizarUsuarioConHistorial", parametros);
        }


    }
}
