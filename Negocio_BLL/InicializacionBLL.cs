using Acceso_DAL;
using Entidad_BE;
using Servicios;
using System;
using System.Collections.Generic;

namespace Negocio_BLL
{
    //Primer arranque: asegura que la base exista, tenga el esquema y tenga al menos un usuario (admin).
    //En los arranques siguientes solo hace 3 consultas baratas y no escribe nada.
    //No usa mensajes traducidos: las traducciones viven en la base, que puede no existir todavia.
    public class InicializacionBLL_883SC
    {
        private const string UsuarioAdmin_883SC = "admin";
        private const string RolAdmin_883SC = "Propietario";
        private const string ClaveInicialAdmin_883SC = "Admin123"; //Se guarda como SHA-256; PrimerInicio obliga a cambiarla en el primer login
        private const int DniAdmin_883SC = 10000000; //>= 3 digitos: GenerarPass_883SC (desbloqueo) usa Substring(0, 3)
        private const string NombreAdmin_883SC = "Administrador";
        private const string ApellidoAdmin_883SC = "Sistema"; //>= 3 letras por la misma razon
        private const string UsuarioSistema_883SC = "Sistema"; //Responsable en bitacora e historial; Bitacora.Usuario no tiene FK

        private MP_Instalacion_883SC mpInstalacion_883SC = new MP_Instalacion_883SC();

        //informarEtapa: delegado inyectado desde la GUI (la BLL no conoce formularios). Puede ser null.
        public ResultadoInicializacionBE_883SC Inicializar_883SC(Action<string> informarEtapa)
        {
            Action<string> etapa = informarEtapa ?? (t => { });
            ResultadoInicializacionBE_883SC resultado = new ResultadoInicializacionBE_883SC();

            etapa("Verificando la base de datos...");
            resultado.InstanciaConfigurada_883SC = mpInstalacion_883SC.ObtenerInstanciaConfigurada_883SC();
            resultado.InstanciaUsada_883SC = mpInstalacion_883SC.ObtenerInstanciaUsada_883SC();

            if (!mpInstalacion_883SC.ExisteBase_883SC())
            {
                etapa("Creando la base de datos...");
                mpInstalacion_883SC.CrearBase_883SC();
                resultado.BaseCreada_883SC = true;
            }

            if (!mpInstalacion_883SC.ExisteEsquema_883SC())
            {
                etapa("Creando tablas y procedimientos...");
                mpInstalacion_883SC.InstalarEsquemaYDatos_883SC(() => etapa("Cargando datos iniciales..."));
                resultado.EsquemaCreado_883SC = true;
            }

            if (!mpInstalacion_883SC.ExistenUsuarios_883SC())
            {
                etapa("Creando el usuario administrador...");
                CrearAdmin_883SC(resultado);
                resultado.AdminCreado_883SC = true;
            }

            return resultado;
        }

        private void CrearAdmin_883SC(ResultadoInicializacionBE_883SC resultado)
        {
            UsuarioBE_883SC admin = new UsuarioBE_883SC();
            admin.dni_883SC = DniAdmin_883SC;
            admin.nomb_883SC = NombreAdmin_883SC;
            admin.ape_883SC = ApellidoAdmin_883SC;
            admin.user_883SC = UsuarioAdmin_883SC;
            admin.rol_883SC = RolAdmin_883SC;
            admin.pass_883SC = Encriptador_883SC.EncriptarIrrev_883SC(ClaveInicialAdmin_883SC);
            admin.dir_883SC = "";
            admin.tel_883SC = "";
            admin.email_883SC = "";
            admin.estado_883SC = true;
            admin.bloq_883SC = false;
            admin.primer_883SC = true; //Antes del DVH: la bandera forma parte del digito

            string detalle = "instancia=" + resultado.InstanciaUsada_883SC +
                ";baseCreada=" + (resultado.BaseCreada_883SC ? 1 : 0) +
                ";esquemaCreado=" + (resultado.EsquemaCreado_883SC ? 1 : 0) +
                ";admin=" + UsuarioAdmin_883SC;
            EventoBE_883SC evento = Bitacora_883SC.RegistrarEvento_883SC(UsuarioSistema_883SC, TipoAccion_883SC.InicializacionBase, detalle);

            mpInstalacion_883SC.CrearAdmin_883SC(admin,
                codigo =>
                {
                    admin.cod_883SC = codigo;
                    return VerificadorIntegridad_883SC.CalcularDVH_883SC(admin);
                },
                dvhs => VerificadorIntegridad_883SC.CalcularDVV_883SC(dvhs),
                evento);
        }
    }
}
