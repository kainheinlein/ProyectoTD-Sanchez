using Entidad_BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class VerificadorIntegridad_883SC
    {
        public static string CalcularDVH_883SC(IVerificable_883SC entidad)
        {
            string datos = entidad.ObtenerCamposDV_883SC();
            return Encriptador_883SC.EncriptarIrrev_883SC(datos);
        }

        public static string CalcularDVV_883SC(List<string>dvh)
        {
            string aux = string.Join("|", dvh);
            return Encriptador_883SC.EncriptarIrrev_883SC(aux);
        }

        public static bool VerificarIntegridad_883SC(IEnumerable<IVerificable_883SC> entidad,string DVV)
        {
            List<string>dvhs = new List<string>();

            foreach(IVerificable_883SC ent in entidad)
            {
                string auxDVH = CalcularDVH_883SC(ent);

                if(auxDVH == ent.digito_883SC)
                {
                    dvhs.Add(auxDVH);
                }
                else return false;
            }

            string auxDVV = CalcularDVV_883SC(dvhs);
            return auxDVV == DVV;
        }
    }
}
