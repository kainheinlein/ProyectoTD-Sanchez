using Acceso_DAL;
using Entidad_BE;
using Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Negocio_BLL
{
    public class ClienteBLL_883SC
    {
        MP_Cliente_883SC mpCliente_883SC = new MP_Cliente_883SC();
        BitacoraBLL_883SC bitacora_883SC = new BitacoraBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        private const int NOMBRE_MAX_883SC = 50;       //Columnas Nombre / Apellido nvarchar(50)
        private const int DIRECCION_MAX_883SC = 100;   //Texto plano; cifrada entra en nvarchar(500)
        private const int TELEFONO_MIN_DIGITOS_883SC = 6;
        private const int TELEFONO_MAX_DIGITOS_883SC = 15;
        private static readonly Regex patronNombre_883SC = new Regex(@"^[\p{L}\s\-]+$");
        private static readonly Regex patronNombreReservado_883SC = new Regex(@"^(CON|PRN|AUX|NUL|COM[1-9]|LPT[1-9])$", RegexOptions.IgnoreCase);
        SerializadorXML_883SC serializador_883SC = new SerializadorXML_883SC();

        /// Ventas: devuelve solo clientes activos (un cliente dado de baja se trata como no encontrado).
        public ClienteBE_883SC BuscarCliente_883SC(int dni)
        {
            ClienteBE_883SC cliente = mpCliente_883SC.BuscarCliente_883SC(dni);
            if (cliente == null || !cliente.Activo_883SC) { return null; }

            cliente.Direccion_883SC = Encriptador_883SC.DesencriptarRev_883SC(cliente.Direccion_883SC);
            return cliente;
        }

        public List<ClienteBE_883SC> ListarClientes_883SC()
        {
            List<ClienteBE_883SC> clientes = mpCliente_883SC.ListarClientes_883SC();
            foreach (ClienteBE_883SC cliente in clientes)
            {
                cliente.Direccion_883SC = Encriptador_883SC.DesencriptarRev_883SC(cliente.Direccion_883SC);
            }
            return clientes;
        }

        public List<ClienteBE_883SC> ListarClientesAbm_883SC(bool incluirInactivos)
        {
            List<ClienteBE_883SC> todos = mpCliente_883SC.ListarClientes_883SC();
            List<ClienteBE_883SC> resultado = new List<ClienteBE_883SC>();
            foreach (ClienteBE_883SC cliente in todos)
            {
                if (!incluirInactivos && !cliente.Activo_883SC) { continue; }
                try
                {
                    cliente.Direccion_883SC = Encriptador_883SC.DesencriptarRev_883SC(cliente.Direccion_883SC);
                }
                catch (CryptographicException)
                {
                    cliente.DireccionSinCifrar_883SC = true;
                }
                resultado.Add(cliente);
            }
            return resultado;
        }

        public void CrearCliente_883SC(int dni, string nombre, string apellido, string direccion, string telefono)
        {
            nombre = (nombre ?? "").Trim();
            apellido = (apellido ?? "").Trim();
            direccion = (direccion ?? "").Trim();
            telefono = (telefono ?? "").Trim();
            ValidarDatos_883SC(dni, nombre, apellido, direccion, telefono);

            ClienteBE_883SC existente = mpCliente_883SC.BuscarCliente_883SC(dni);
            if (existente != null)
            {
                string clave = existente.Activo_883SC ? "CLI_ABM_MSG_EXISTE" : "CLI_ABM_MSG_EXISTE_BAJA";
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC(clave), "Dni");
            }

            ClienteBE_883SC cliente = new ClienteBE_883SC();
            cliente.Dni_883SC = dni;
            cliente.Nombre_883SC = nombre;
            cliente.Apellido_883SC = apellido;
            cliente.Direccion_883SC = Encriptador_883SC.EncriptarRev_883SC(direccion);
            cliente.Telefono_883SC = telefono;

            mpCliente_883SC.GuardarCliente_883SC(cliente);

            bitacora_883SC.RegistrarBitacora_883SC(UsuarioActual_883SC(), TipoAccion_883SC.AltaCliente, "dni=" + dni);
        }

        public void ModificarCliente_883SC(ClienteBE_883SC cliente)
        {
            string nombre = (cliente.Nombre_883SC ?? "").Trim();
            string apellido = (cliente.Apellido_883SC ?? "").Trim();
            string direccion = (cliente.Direccion_883SC ?? "").Trim();
            string telefono = (cliente.Telefono_883SC ?? "").Trim();
            ValidarDatos_883SC(cliente.Dni_883SC, nombre, apellido, direccion, telefono);
            ExigirActivo_883SC(cliente.Dni_883SC);

            ClienteBE_883SC aGuardar = new ClienteBE_883SC();
            aGuardar.Dni_883SC = cliente.Dni_883SC;
            aGuardar.Nombre_883SC = nombre;
            aGuardar.Apellido_883SC = apellido;
            aGuardar.Direccion_883SC = Encriptador_883SC.EncriptarRev_883SC(direccion);
            aGuardar.Telefono_883SC = telefono;
            mpCliente_883SC.ModificarCliente_883SC(aGuardar);

            cliente.Nombre_883SC = nombre;
            cliente.Apellido_883SC = apellido;
            cliente.Direccion_883SC = direccion;
            cliente.Telefono_883SC = telefono;
            cliente.DireccionSinCifrar_883SC = false;

            bitacora_883SC.RegistrarBitacora_883SC(UsuarioActual_883SC(), TipoAccion_883SC.ModificacionCliente, "dni=" + cliente.Dni_883SC);
        }

        /// Baja logica: la fila se conserva porque las facturas referencian el DNI.
        public void BajaCliente_883SC(int dni)
        {
            ExigirActivo_883SC(dni);
            mpCliente_883SC.BajaCliente_883SC(dni);
            bitacora_883SC.RegistrarBitacora_883SC(UsuarioActual_883SC(), TipoAccion_883SC.BajaCliente, "dni=" + dni);
        }

        public void ReactivarCliente_883SC(int dni)
        {
            ClienteBE_883SC existente = mpCliente_883SC.BuscarCliente_883SC(dni);
            if (existente == null)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("CLI_ABM_ERR_NO_EXISTE"), "Dni");
            }
            if (existente.Activo_883SC)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("CLI_ABM_ERR_YA_ACTIVO"), "Dni");
            }
            mpCliente_883SC.ReactivarCliente_883SC(dni);
            bitacora_883SC.RegistrarBitacora_883SC(UsuarioActual_883SC(), TipoAccion_883SC.ReactivacionCliente, "dni=" + dni);
        }

        //El ParamName de la excepcion indica el campo para que la GUI lo marque
        private void ValidarDatos_883SC(int dni, string nombre, string apellido, string direccion, string telefono)
        {
            if (dni <= 0)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("CLI_ABM_ERR_DNI"), "Dni");
            }
            if (nombre == "" || nombre.Length > NOMBRE_MAX_883SC || !patronNombre_883SC.IsMatch(nombre))
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("CLI_ABM_ERR_NOMBRE"), "Nombre");
            }
            if (apellido == "" || apellido.Length > NOMBRE_MAX_883SC || !patronNombre_883SC.IsMatch(apellido))
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("CLI_ABM_ERR_APELLIDO"), "Apellido");
            }
            if (direccion.Length > DIRECCION_MAX_883SC)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("CLI_ABM_ERR_DIRECCION"), "Direccion");
            }
            if (telefono != "" && !TelefonoValido_883SC(telefono))
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("CLI_ABM_ERR_TELEFONO"), "Telefono");
            }
        }

        private bool TelefonoValido_883SC(string telefono)
        {
            if (telefono.Length < TELEFONO_MIN_DIGITOS_883SC || telefono.Length > TELEFONO_MAX_DIGITOS_883SC)
            {
                return false;
            }
            foreach (char c in telefono)
            {
                if (c < '0' || c > '9') { return false; }
            }
            return true;
        }

        private void ExigirActivo_883SC(int dni)
        {
            ClienteBE_883SC existente = mpCliente_883SC.BuscarCliente_883SC(dni);
            if (existente == null)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("CLI_ABM_ERR_NO_EXISTE"), "Dni");
            }
            if (!existente.Activo_883SC)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("CLI_ABM_ERR_INACTIVO"), "Dni");
            }
        }

        #region Serializacion XML (M2)

        public bool ExisteArchivoXML_883SC(string carpeta, string nombre)
        {
            return File.Exists(ConstruirRutaXML_883SC(carpeta, nombre));
        }

        public string SerializarClientes_883SC(List<ClienteBE_883SC> clientes, string carpeta, string nombre)
        {
            if (clientes == null || clientes.Count == 0)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("CLI_SER_ERR_SIN_CLIENTES"));
            }
            string ruta = ConstruirRutaXML_883SC(carpeta, nombre);

            List<ClienteXMLBE_883SC> paraArchivo = new List<ClienteXMLBE_883SC>();
            foreach (ClienteBE_883SC cliente in clientes)
            {
                ClienteXMLBE_883SC dto = new ClienteXMLBE_883SC();
                dto.Dni_883SC = cliente.Dni_883SC;
                dto.Nombre_883SC = cliente.Nombre_883SC;
                dto.Apellido_883SC = cliente.Apellido_883SC;
                dto.Direccion_883SC = Encriptador_883SC.EncriptarRev_883SC(cliente.Direccion_883SC);
                dto.Telefono_883SC = cliente.Telefono_883SC;
                dto.Activo_883SC = cliente.Activo_883SC;
                paraArchivo.Add(dto);
            }

            List<ClienteXMLBE_883SC> leidos;
            try
            {
                serializador_883SC.Serializar_883SC(paraArchivo, ruta);
                leidos = serializador_883SC.Deserializar_883SC<ClienteXMLBE_883SC>(ruta);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is System.Security.SecurityException || ex is NotSupportedException)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("CLI_SER_ERR_ESCRITURA"));
            }
            catch (FormatException)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("CLI_SER_ERR_VERIFICACION"));
            }

            //Verificacion: mismos clientes (cantidad y DNIs, en el mismo orden) que los escritos
            bool coincide = leidos.Count == paraArchivo.Count;
            for (int i = 0; coincide && i < leidos.Count; i++)
            {
                coincide = leidos[i].Dni_883SC == paraArchivo[i].Dni_883SC;
            }
            if (!coincide)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("CLI_SER_ERR_VERIFICACION"));
            }

            bitacora_883SC.RegistrarBitacora_883SC(UsuarioActual_883SC(), TipoAccion_883SC.SerializacionClientes, "cantidad=" + paraArchivo.Count);
            return ruta;
        }

        public List<ClienteBE_883SC> DeserializarClientes_883SC(string ruta)
        {
            ruta = (ruta ?? "").Trim();
            if (ruta == "" || !string.Equals(Path.GetExtension(ruta), ".xml", StringComparison.OrdinalIgnoreCase) || !File.Exists(ruta))
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("CLI_SER_ERR_ARCHIVO"));
            }

            List<ClienteXMLBE_883SC> leidos;
            try
            {
                leidos = serializador_883SC.Deserializar_883SC<ClienteXMLBE_883SC>(ruta);
            }
            catch (FormatException)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("CLI_SER_ERR_FORMATO"));
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is System.Security.SecurityException)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("CLI_SER_ERR_LECTURA"));
            }
            if (leidos.Count == 0)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("CLI_SER_ERR_XML_VACIO"));
            }

            List<ClienteBE_883SC> clientes = new List<ClienteBE_883SC>();
            HashSet<int> dnis = new HashSet<int>();
            foreach (ClienteXMLBE_883SC dto in leidos)
            {
                if (dto == null)
                {
                    throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("CLI_SER_ERR_FORMATO"));
                }

                string direccion;
                try
                {
                    direccion = Encriptador_883SC.DesencriptarRev_883SC(dto.Direccion_883SC);
                }
                catch (CryptographicException)
                {
                    throw new ArgumentException(string.Format(gestorIdioma_883SC.Traducir_883SC("CLI_SER_ERR_DIRECCION"), dto.Dni_883SC));
                }

                string nombre = (dto.Nombre_883SC ?? "").Trim();
                string apellido = (dto.Apellido_883SC ?? "").Trim();
                direccion = (direccion ?? "").Trim();
                string telefono = (dto.Telefono_883SC ?? "").Trim();
                try
                {
                    ValidarDatos_883SC(dto.Dni_883SC, nombre, apellido, direccion, telefono);
                }
                catch (ArgumentException ex)
                {
                    throw new ArgumentException(string.Format(gestorIdioma_883SC.Traducir_883SC("CLI_SER_ERR_CLIENTE"), dto.Dni_883SC, ex.Message));
                }
                if (!dnis.Add(dto.Dni_883SC))
                {
                    throw new ArgumentException(string.Format(gestorIdioma_883SC.Traducir_883SC("CLI_SER_ERR_DUPLICADO"), dto.Dni_883SC));
                }

                ClienteBE_883SC cliente = new ClienteBE_883SC();
                cliente.Dni_883SC = dto.Dni_883SC;
                cliente.Nombre_883SC = nombre;
                cliente.Apellido_883SC = apellido;
                cliente.Direccion_883SC = direccion;
                cliente.Telefono_883SC = telefono;
                cliente.Activo_883SC = dto.Activo_883SC;
                clientes.Add(cliente);
            }

            bitacora_883SC.RegistrarBitacora_883SC(UsuarioActual_883SC(), TipoAccion_883SC.DeserializacionClientes, "cantidad=" + clientes.Count);
            return clientes;
        }

        /// Contenido del archivo XML, para la verificacion visual
        public string LeerContenidoXML_883SC(string ruta)
        {
            try
            {
                return serializador_883SC.LeerTexto_883SC(ruta);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is System.Security.SecurityException)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("CLI_SER_ERR_LECTURA"));
            }
        }

        //Valida carpeta y nombre y arma la ruta completa; agrega .xml si el nombre no lo trae
        private string ConstruirRutaXML_883SC(string carpeta, string nombre)
        {
            carpeta = (carpeta ?? "").Trim();
            nombre = (nombre ?? "").Trim();
            if (carpeta == "" || !Directory.Exists(carpeta))
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("CLI_SER_ERR_CARPETA"));
            }

            if (!nombre.EndsWith(".xml", StringComparison.OrdinalIgnoreCase)) { nombre += ".xml"; }
            string sinExtension = Path.GetFileNameWithoutExtension(nombre);
            if (sinExtension.Trim() == ""
                || nombre.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0
                || sinExtension.EndsWith(" ") || sinExtension.EndsWith(".")
                || patronNombreReservado_883SC.IsMatch(sinExtension))
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("CLI_SER_ERR_NOMBRE"));
            }

            try
            {
                return Path.GetFullPath(Path.Combine(carpeta, nombre));
            }
            catch (Exception ex) when (ex is PathTooLongException || ex is NotSupportedException || ex is ArgumentException)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("CLI_SER_ERR_NOMBRE"));
            }
        }

        #endregion

        private string UsuarioActual_883SC()
        {
            return SessionManager_883SC.Logged_883SC()
                ? SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC
                : "null";
        }
    }
}
