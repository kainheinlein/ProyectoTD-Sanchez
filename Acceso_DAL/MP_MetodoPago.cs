using Entidad_BE;
using System;
using System.Collections.Generic;
using System.Data;

namespace Acceso_DAL
{
    public class MP_MetodoPago_883SC
    {
        AccesoDatos_883SC conexDB_883SC = new AccesoDatos_883SC();

        public List<MetodoPagoBE_883SC> ListarMetodos_883SC()
        {
            List<MetodoPagoBE_883SC> metodos = new List<MetodoPagoBE_883SC>();

            DataTable dt = conexDB_883SC.LeerTabla_883SC("ListarMetodosPago_SP", null);
            foreach (DataRow dr in dt.Rows)
            {
                metodos.Add(MapearFila_883SC(dr));
            }

            return metodos;
        }

        private MetodoPagoBE_883SC MapearFila_883SC(DataRow dr)
        {
            MetodoPagoBE_883SC metodo = new MetodoPagoBE_883SC();
            metodo.AsignarId_883SC(Convert.ToInt32(dr["IdMetodoPago"]));
            metodo.Nombre_883SC = dr["Nombre"].ToString();
            metodo.Validacion_883SC = Convert.ToBoolean(dr["Validacion"]);
            metodo.RequiereDatosTarjeta_883SC = Convert.ToBoolean(dr["RequiereDatosTarjeta"]);
            return metodo;
        }
    }
}
