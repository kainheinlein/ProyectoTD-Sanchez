using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad_BE
{
    public enum LoginResult_883SC
    {
        UserInexistente_883SC = 0,
        LoginOK_883SC = 1,
        UserBloqueado_883SC = 2,
        PassIncorrecta_883SC = 3,
        UserInactivo_883SC = 4,
        FinIntentos_883SC = 5,
        SesionIniciada_883SC = 6,
        ExisteSesion_883SC = 7
    }
}
