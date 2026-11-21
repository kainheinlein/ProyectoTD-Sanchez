using Acceso_DAL;
using Entidad_BE;
using Servicios;
using System;
using System.Collections.Generic;

namespace Negocio_BLL
{
    /// Admin -> Cargar datos de prueba. Orden: permiso -> la base no tiene datos -> backup PreDatosPrueba_fecha_hora.bak (verificado)
    /// -> script embebido (proveedores, listas de precios, productos con stock, en una transaccion) -> clientes (ClienteBLL: cifra la
    /// direccion) -> usuarios (UsuarioBLL: digito verificador) -> bitacora.
    /// Si el backup falla se aborta sin cargar nada. Si algo falla despues del backup, el mensaje nombra el backup para volver con Restore.
    /// Los fallos se señalan con excepciones traducidas; el avance se informa con el delegado inyectado (la BLL no conoce la GUI).
    public class DatosPruebaBLL_883SC
    {
        private const string PrefijoBackup_883SC = "PreDatosPrueba";
        private const string ClaveUsuariosPrueba_883SC = "Prueba123"; //Conocida a proposito: se muestra al terminar; PrimerInicio obliga a cambiarla

        private MP_DatosPrueba_883SC mpDatosPrueba_883SC = new MP_DatosPrueba_883SC();
        private BackupBLL_883SC backupBLL_883SC = new BackupBLL_883SC();
        private ClienteBLL_883SC clienteBLL_883SC = new ClienteBLL_883SC();
        private UsuarioBLL_883SC usuarioBLL_883SC = new UsuarioBLL_883SC();
        private PerfilBLL_883SC perfilBLL_883SC = new PerfilBLL_883SC();
        private BitacoraBLL_883SC bitacora_883SC = new BitacoraBLL_883SC();
        private VerificadorIntegridadBLL_883SC integridad_883SC = new VerificadorIntegridadBLL_883SC();
        private GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        //Clientes ficticios (dni, nombre, apellido, direccion, telefono). DNI distintos de los de FerreDB.
        private static readonly string[][] ClientesPrueba_883SC =
        {
            new[] { "30111222", "Marcos", "Benítez", "Av. Corrientes 1234, CABA", "1144556677" },
            new[] { "31222333", "Lucía", "Fernández", "Calle San Lorenzo 450, Rosario", "3415667788" },
            new[] { "32333444", "Hernán", "Quiroga", "Belgrano 77, Córdoba", "3514778899" },
            new[] { "33444555", "Paula", "Giménez", "Mitre 990, Mendoza", "2614889900" },
            new[] { "34555666", "Diego", "Acosta", "Ruta 3 km 12, Bahía Blanca", "2914990011" },
            new[] { "35666777", "Sofía", "Romero", "Sarmiento 2210, Tucumán", "3814001122" },
            new[] { "36777888", "Ramiro", "Paz", "Alberdi 305, Salta", "3874112233" }
        };

        //Un usuario por rol (el Propietario es el admin ya existente): usuario, rol, nombre, apellido, dni
        private static readonly string[][] UsuariosPrueba_883SC =
        {
            new[] { "test_admin", "Admin", "Admin", "Prueba", "90000001" },
            new[] { "test_vendedor", "Vendedor", "Vendedor", "Prueba", "90000002" },
            new[] { "test_cajero", "Cajero", "Cajero", "Prueba", "90000003" }
        };

        private string T_883SC(string clave)
        {
            return gestorIdioma_883SC.Traducir_883SC(clave);
        }

        /// etapa: delegado (puede ser null) que recibe el texto traducido de cada paso.
        public ResultadoDatosPruebaBE_883SC CargarDatosPrueba_883SC(Action<string> etapa)
        {
            Action<string> informar = etapa ?? (t => { });

            if (!SessionManager_883SC.Logged_883SC())
            {
                throw new UnauthorizedAccessException(T_883SC("DAT_ERR_PERMISO"));
            }
            UsuarioBE_883SC actual = SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC();
            if (!perfilBLL_883SC.TienePermiso_883SC(actual.rol_883SC, TipoPermiso_883SC.CargarDatosPrueba.ToString()))
            {
                throw new UnauthorizedAccessException(T_883SC("DAT_ERR_PERMISO"));
            }

            informar(T_883SC("DAT_ETAPA_VERIFICANDO"));
            string existente = DescribirDatosExistentes_883SC(mpDatosPrueba_883SC.ObtenerContenido_883SC());
            if (existente.Length > 0)
            {
                throw new InvalidOperationException(string.Format(T_883SC("DAT_ERR_HAY_DATOS"), existente));
            }

            informar(T_883SC("DAT_ETAPA_BACKUP"));
            string nombreBackup;
            try
            {
                nombreBackup = backupBLL_883SC.RealizarBackup_883SC(PrefijoBackup_883SC).NombreArchivo_883SC;
            }
            catch (Exception ex)
            {
                //Sin backup verificado no se carga nada
                throw new InvalidOperationException(string.Format(T_883SC("DAT_ERR_BACKUP"), ex.Message), ex);
            }

            ResultadoDatosPruebaBE_883SC resultado = new ResultadoDatosPruebaBE_883SC();
            resultado.NombreBackup_883SC = nombreBackup;
            resultado.Usuarios_883SC = new List<UsuarioPruebaBE_883SC>();
            try
            {
                informar(T_883SC("DAT_ETAPA_SCRIPT"));
                mpDatosPrueba_883SC.CargarProveedoresYProductos_883SC();

                informar(T_883SC("DAT_ETAPA_CLIENTES"));
                foreach (string[] c in ClientesPrueba_883SC)
                {
                    clienteBLL_883SC.CrearCliente_883SC(int.Parse(c[0]), c[1], c[2], c[3], c[4]);
                }

                informar(T_883SC("DAT_ETAPA_USUARIOS"));
                foreach (string[] u in UsuariosPrueba_883SC)
                {
                    UsuarioBE_883SC us = new UsuarioBE_883SC();
                    us.user_883SC = u[0];
                    us.rol_883SC = u[1];
                    us.nomb_883SC = u[2];
                    us.ape_883SC = u[3];
                    us.dni_883SC = int.Parse(u[4]);
                    us.pass_883SC = ClaveUsuariosPrueba_883SC; //CrearUsuario_883SC la encripta (SHA-256) y marca PrimerInicio
                    us.dir_883SC = " ";
                    us.tel_883SC = " ";
                    us.email_883SC = " ";
                    us.estado_883SC = true;
                    us.bloq_883SC = false;
                    usuarioBLL_883SC.CrearUsuario_883SC(us);

                    UsuarioPruebaBE_883SC datos = new UsuarioPruebaBE_883SC();
                    datos.Usuario_883SC = u[0];
                    datos.Rol_883SC = u[1];
                    datos.Clave_883SC = ClaveUsuariosPrueba_883SC;
                    resultado.Usuarios_883SC.Add(datos);
                }
                //Usuarios nuevos = DVH nuevos: el DVV se refresca ya (si no, quedaria desfasado hasta el logout)
                integridad_883SC.ActualizarDVVSiVerificado_883SC();

                informar(T_883SC("DAT_ETAPA_FIN"));
                ContenidoBaseBE_883SC despues = mpDatosPrueba_883SC.ObtenerContenido_883SC();
                resultado.Proveedores_883SC = despues.Proveedores_883SC;
                resultado.Productos_883SC = despues.Productos_883SC;
                resultado.Clientes_883SC = despues.Clientes_883SC;

                bitacora_883SC.RegistrarBitacora_883SC(actual.user_883SC, TipoAccion_883SC.CargaDatosPrueba,
                    "backup=" + nombreBackup + ";proveedores=" + resultado.Proveedores_883SC + ";productos=" + resultado.Productos_883SC +
                    ";clientes=" + resultado.Clientes_883SC + ";usuarios=" + resultado.Usuarios_883SC.Count);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(string.Format(T_883SC("DAT_ERR_FALLO_CARGA"), ex.Message, nombreBackup), ex);
            }
            return resultado;
        }

        //Texto "2 proveedores, 5 clientes" con lo que ya hay; vacio si la base no tiene datos de negocio.
        //Los usuarios cuentan solo por encima del administrador inicial.
        private string DescribirDatosExistentes_883SC(ContenidoBaseBE_883SC c)
        {
            List<string> partes = new List<string>();
            Agregar_883SC(partes, c.Proveedores_883SC, "DAT_TABLA_PROVEEDORES");
            Agregar_883SC(partes, c.Productos_883SC, "DAT_TABLA_PRODUCTOS");
            Agregar_883SC(partes, c.Clientes_883SC, "DAT_TABLA_CLIENTES");
            Agregar_883SC(partes, c.Facturas_883SC, "DAT_TABLA_FACTURAS");
            Agregar_883SC(partes, c.ListasPrecio_883SC, "DAT_TABLA_LISTAS");
            Agregar_883SC(partes, c.OrdenesCompra_883SC, "DAT_TABLA_ORDENES");
            Agregar_883SC(partes, c.Carritos_883SC, "DAT_TABLA_CARRITOS");
            Agregar_883SC(partes, c.Usuarios_883SC - 1, "DAT_TABLA_USUARIOS");
            return string.Join(", ", partes);
        }

        private void Agregar_883SC(List<string> partes, int cantidad, string claveTabla)
        {
            if (cantidad > 0) { partes.Add(cantidad + " " + T_883SC(claveTabla)); }
        }
    }
}
