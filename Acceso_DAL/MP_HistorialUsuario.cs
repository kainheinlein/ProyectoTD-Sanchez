using Entidad_BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_DAL
{
    public class MP_HistorialUsuario_883SC
    {
        AccesoDatos_883SC conexDB_883SC = new AccesoDatos_883SC();


        public List<HistorialUsuarioBE_883SC> ListarHistorial_883SC()
        {
            List<HistorialUsuarioBE_883SC> historial = new List<HistorialUsuarioBE_883SC>();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("tabla", "HistorialUsuario");
            DataTable dt = conexDB_883SC.LeerTabla_883SC("SP_ExtTabla", parametros);
            foreach (DataRow dr in dt.Rows)
            {
                historial.Add(MapearFila_883SC(dr));
            }
            return historial;
        }

        public List<HistorialUsuarioBE_883SC> ListarHistorial_883SC(TipoAccion_883SC? accion, DateTime fIni, DateTime fFin)
        {
            List<HistorialUsuarioBE_883SC> historial = new List<HistorialUsuarioBE_883SC>();
            SqlParameter[] parametros = new SqlParameter[3];
            if (accion == null) { parametros[0] = new SqlParameter("@accion", DBNull.Value); }
            else { parametros[0] = new SqlParameter("@accion", (int)accion); }
            parametros[1] = new SqlParameter("@fechaDesde", fIni);
            parametros[2] = new SqlParameter("@fechaHasta", fFin);

            DataTable dt = conexDB_883SC.LeerTabla_883SC("SP_ListarHistorialUsuario", parametros);
            foreach (DataRow dr in dt.Rows)
            {
                historial.Add(MapearFila_883SC(dr));
            }
            return historial;
        }

        public HistorialUsuarioBE_883SC ObtenerVersion_883SC(int idHistorial)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@idHistorial", idHistorial);

            DataTable dt = conexDB_883SC.LeerTabla_883SC("SP_ExtHistorialUsuario", parametros);
            if (dt.Rows.Count > 0) { return MapearFila_883SC(dt.Rows[0]); }
            return null;
        }

        private HistorialUsuarioBE_883SC MapearFila_883SC(DataRow dr)
        {
            HistorialUsuarioBE_883SC h = new HistorialUsuarioBE_883SC();
            h.idHistorial_883SC = Convert.ToInt32(dr[0].ToString());
            h.usuarioId_883SC = Convert.ToInt32(dr[1].ToString());
            h.dni_883SC = dr[2].ToString();
            h.nombre_883SC = dr[3].ToString();
            h.apellido_883SC = dr[4].ToString();
            h.usuario_883SC = dr[5].ToString();
            h.rol_883SC = dr[6].ToString();
            h.direccion_883SC = dr[7] == DBNull.Value ? null : dr[7].ToString();
            h.telefono_883SC = dr[8] == DBNull.Value ? null : dr[8].ToString();
            h.email_883SC = dr[9] == DBNull.Value ? null : dr[9].ToString();
            h.activo_883SC = Convert.ToBoolean(dr[10]);
            h.bloqueado_883SC = Convert.ToBoolean(dr[11]);
            h.accion_883SC = (TipoAccion_883SC)Convert.ToInt32(dr[12].ToString());
            h.usuarioResponsable_883SC = dr[13].ToString();
            h.fecha_883SC = Convert.ToDateTime(dr[14].ToString());
            return h;
        }
    }
}
