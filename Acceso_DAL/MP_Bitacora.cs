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
    public class MP_Bitacora_883SC
    {
        AccesoDatos_883SC conexDB_883SC = new AccesoDatos_883SC();

        public List<EventoBE_883SC> ListarEventos_883SC()
        {
            List<EventoBE_883SC> eventos = new List<EventoBE_883SC>();
            DataTable dt = conexDB_883SC.LeerTabla_883SC("SP_ExtBitacora", null);
            foreach (DataRow dr in dt.Rows)
            {
                EventoBE_883SC ev = new EventoBE_883SC();
                ev.registro_883SC = Convert.ToInt32(dr[0].ToString());
                ev.usuario_883SC = dr[1].ToString();
                ev.accion_883SC = (TipoAccion_883SC)dr[2];
                ev.fecha_883SC = Convert.ToDateTime(dr[3].ToString());
                eventos.Add(ev);
            }
            return eventos;
        }

        public void RegistrarEvento_883SC(EventoBE_883SC ev)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@usuario", ev.usuario_883SC);
            parametros[1] = new SqlParameter("@accion", (int)ev.accion_883SC);
            parametros[2] = new SqlParameter("fecha", ev.fecha_883SC);

            conexDB_883SC.Escribir_883SC("SP_RegistrarEvento", parametros);
        }

        public List<EventoBE_883SC> BuscarEventos_883SC(string us, TipoAccion_883SC? acc, DateTime fIni, DateTime fFin)
        {
            List<EventoBE_883SC> eventos = new List<EventoBE_883SC>();
            SqlParameter[] parametros = new SqlParameter[4];
            if (us == null) { parametros[0] = new SqlParameter("@usuario", DBNull.Value); }
            else { parametros[0] = new SqlParameter("@usuario", us); }
            if (acc == null) { parametros[1] = new SqlParameter("@accion", DBNull.Value); }
            else { parametros[1] = new SqlParameter("@accion", (int)acc); }
            parametros[2] = new SqlParameter("fechadesde", fIni);
            parametros[3] = new SqlParameter("fechahasta", fFin);
            DataTable dt = conexDB_883SC.LeerTabla_883SC("SP_BuscarBitacora", parametros);
            foreach (DataRow dr in dt.Rows)
            {
                EventoBE_883SC ev = new EventoBE_883SC();
                ev.registro_883SC = Convert.ToInt32(dr[0].ToString());
                ev.usuario_883SC = dr[1].ToString();
                ev.accion_883SC = (TipoAccion_883SC)dr[2];
                ev.fecha_883SC = Convert.ToDateTime(dr[3].ToString());
                eventos.Add(ev);
            }
            return eventos;
        }
    }
}
