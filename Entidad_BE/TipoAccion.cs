using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad_BE
{
    public enum TipoAccion_883SC
    {
        Login = 1,
        Logout = 2,
        AltaUsuario = 3,
        BajaUsuario = 4,
        ModificacionUsuario = 5,
        CambioClave = 6,
        BitacoraAbierta = 7,
        GestionUsuariosAbierta = 8,
        AppClose = 9,
        DesbloqueoUsuario = 10,
        BloqueoUsuario = 11,
        LoginFail = 12,
        NoSesion = 13,
        CambioIdioma = 14,
        AltaIdioma = 15,
        ModificacionIdioma = 16,
        RestauracionUsuario = 17,
        AltaCliente = 18,
        AltaFactura = 19,
        BackupRealizado = 20,
        RestoreRealizado = 21,
        BackupEliminado = 22,
        AccesoBloqueadoIntegridad = 23,
        RecalculoIntegridad = 24,
        AltaProducto = 25,
        ModificacionProducto = 26,
        VinculacionProducto = 27,
        DesvinculacionProducto = 28,
        AltaProveedor = 29,
        ImportacionListaPrecios = 30,
        AltaOrdenCompra = 31,
        AutorizacionOrdenCompra = 32,
        RechazoOrdenCompra = 33,
        EnvioOrdenCompra = 34,
        RecepcionMercaderia = 35,
        ModificacionCliente = 36,
        BajaCliente = 37,
        ReactivacionCliente = 38,
        SerializacionClientes = 39,
        DeserializacionClientes = 40
    }
}
