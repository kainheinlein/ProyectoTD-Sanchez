using Acceso_DAL;
using Entidad_BE;
using Servicios;

namespace Negocio_BLL
{
    public class ClienteBLL_883SC
    {
        MP_Cliente_883SC mpCliente_883SC = new MP_Cliente_883SC();
        BitacoraBLL_883SC bitacora_883SC = new BitacoraBLL_883SC();

        public ClienteBE_883SC BuscarCliente_883SC(int dni)
        {
            return mpCliente_883SC.BuscarCliente_883SC(dni);
        }

        public void CrearCliente_883SC(int dni, string nombre, string apellido, string direccion, string telefono)
        {
            ClienteBE_883SC cliente = new ClienteBE_883SC();
            cliente.Dni_883SC = dni;
            cliente.Nombre_883SC = nombre;
            cliente.Apellido_883SC = apellido;
            cliente.Direccion_883SC = direccion;
            cliente.Telefono_883SC = telefono;

            mpCliente_883SC.GuardarCliente_883SC(cliente);

            string usuario = SessionManager_883SC.Logged_883SC()
                ? SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC
                : "null";
            bitacora_883SC.RegistrarBitacora_883SC(usuario, TipoAccion_883SC.AltaCliente);
        }
    }
}
