using Acceso_DAL;
using Entidad_BE;
using Servicios;
using System;
using System.Collections.Generic;

namespace Negocio_BLL
{
    public class ProveedorBLL_883SC
    {
        MP_Proveedor_883SC mpProveedor_883SC = new MP_Proveedor_883SC();
        BitacoraBLL_883SC bitacora_883SC = new BitacoraBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        private const decimal MARGEN_MAXIMO_883SC = 999.99m; //Tope de la columna Margen decimal(5,2)
        private const int TELEFONO_MIN_DIGITOS_883SC = 6;
        private const int TELEFONO_MAX_DIGITOS_883SC = 15;

        public List<ProveedorBE_883SC> ListarProveedores_883SC()
        {
            return mpProveedor_883SC.ListarProveedores_883SC();
        }

        /// Valida, guarda el proveedor (queda activo) y registra la bitacora.
        public ProveedorBE_883SC RegistrarProveedor_883SC(string nombre, string especialidad, string telefono, string direccion, decimal margen, string observaciones)
        {
            nombre = (nombre ?? "").Trim();
            telefono = (telefono ?? "").Trim();
            ValidarDatos_883SC(nombre, especialidad, telefono, direccion, margen);

            if (mpProveedor_883SC.ExisteProveedor_883SC(nombre))
            {
                throw CrearError_883SC("PROV_MSG_EXISTE", "Nombre");
            }

            ProveedorBE_883SC proveedor = new ProveedorBE_883SC();
            proveedor.Nombre_883SC = nombre;
            proveedor.Especialidad_883SC = NormalizarOpcional_883SC(especialidad);
            proveedor.Telefono_883SC = telefono;
            proveedor.Direccion_883SC = NormalizarOpcional_883SC(direccion);
            proveedor.Margen_883SC = margen;
            proveedor.Observaciones_883SC = NormalizarOpcional_883SC(observaciones);
            proveedor.Activo_883SC = true;

            int id = mpProveedor_883SC.GuardarProveedor_883SC(proveedor);
            proveedor.AsignarId_883SC(id);

            string usuario = SessionManager_883SC.Logged_883SC()
                ? SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC
                : "null";
            bitacora_883SC.RegistrarBitacora_883SC(usuario, TipoAccion_883SC.AltaProveedor, "id=" + id);

            return proveedor;
        }

        /// Lista solo los proveedores activos (los que pueden usarse en importaciones y ordenes nuevas).
        public List<ProveedorBE_883SC> ListarProveedoresActivos_883SC()
        {
            return ListarProveedores_883SC().FindAll(p => p.Activo_883SC);
        }

        /// Modifica un proveedor activo. Si cambia el margen, el SP recalcula en la misma transaccion el precio
        /// de venta de los productos cuyo proveedor de referencia es este. Devuelve cuantos precios cambiaron.
        public int ModificarProveedor_883SC(int id, string nombre, string especialidad, string telefono, string direccion, decimal margen, string observaciones)
        {
            nombre = (nombre ?? "").Trim();
            telefono = (telefono ?? "").Trim();
            ExigirActivo_883SC(id);
            ValidarDatos_883SC(nombre, especialidad, telefono, direccion, margen);

            //Nombre unico entre los demas proveedores (el propio nombre se puede conservar)
            foreach (ProveedorBE_883SC otro in mpProveedor_883SC.ListarProveedores_883SC())
            {
                if (otro.Id_883SC != id && string.Equals(otro.Nombre_883SC, nombre, StringComparison.OrdinalIgnoreCase))
                {
                    throw CrearError_883SC("PROV_MSG_EXISTE", "Nombre");
                }
            }

            ProveedorBE_883SC proveedor = new ProveedorBE_883SC();
            proveedor.AsignarId_883SC(id);
            proveedor.Nombre_883SC = nombre;
            proveedor.Especialidad_883SC = NormalizarOpcional_883SC(especialidad);
            proveedor.Telefono_883SC = telefono;
            proveedor.Direccion_883SC = NormalizarOpcional_883SC(direccion);
            proveedor.Margen_883SC = margen;
            proveedor.Observaciones_883SC = NormalizarOpcional_883SC(observaciones);

            int preciosActualizados = mpProveedor_883SC.ModificarProveedor_883SC(proveedor);

            bitacora_883SC.RegistrarBitacora_883SC(UsuarioActual_883SC(), TipoAccion_883SC.ModificacionProveedor,
                "id=" + id + ";preciosActualizados=" + preciosActualizados);
            return preciosActualizados;
        }

        public void BajaProveedor_883SC(int id)
        {
            ExigirActivo_883SC(id);

            int productos = mpProveedor_883SC.ContarProductosReferencia_883SC(id);
            if (productos > 0)
            {
                throw new ArgumentException(string.Format(gestorIdioma_883SC.Traducir_883SC("PROV_ABM_ERR_REFERENCIA"), productos));
            }

            mpProveedor_883SC.BajaProveedor_883SC(id);
            bitacora_883SC.RegistrarBitacora_883SC(UsuarioActual_883SC(), TipoAccion_883SC.BajaProveedor, "id=" + id);
        }

        public void ReactivarProveedor_883SC(int id)
        {
            ProveedorBE_883SC existente = BuscarProveedor_883SC(id);
            if (existente == null)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROV_ABM_ERR_NO_EXISTE"));
            }
            if (existente.Activo_883SC)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROV_ABM_ERR_YA_ACTIVO"));
            }
            mpProveedor_883SC.ReactivarProveedor_883SC(id);
            bitacora_883SC.RegistrarBitacora_883SC(UsuarioActual_883SC(), TipoAccion_883SC.ReactivacionProveedor, "id=" + id);
        }

        private ProveedorBE_883SC BuscarProveedor_883SC(int id)
        {
            foreach (ProveedorBE_883SC proveedor in mpProveedor_883SC.ListarProveedores_883SC())
            {
                if (proveedor.Id_883SC == id) { return proveedor; }
            }
            return null;
        }

        private void ExigirActivo_883SC(int id)
        {
            ProveedorBE_883SC existente = BuscarProveedor_883SC(id);
            if (existente == null)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROV_ABM_ERR_NO_EXISTE"));
            }
            if (!existente.Activo_883SC)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROV_ABM_ERR_INACTIVO"));
            }
        }

        private string UsuarioActual_883SC()
        {
            return SessionManager_883SC.Logged_883SC()
                ? SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC
                : "null";
        }

        //El campo viaja en Data y no en ParamName: ParamName se agrega al texto de Message y ensuciaria el mensaje
        private ArgumentException CrearError_883SC(string clave, string campo)
        {
            ArgumentException ex = new ArgumentException(gestorIdioma_883SC.Traducir_883SC(clave));
            ex.Data["Campo"] = campo;
            return ex;
        }

        private void ValidarDatos_883SC(string nombre, string especialidad, string telefono, string direccion, decimal margen)
        {
            if (nombre == "")
            {
                throw CrearError_883SC("PROV_ERR_INCOMPLETO", "Nombre");
            }
            if (telefono == "")
            {
                throw CrearError_883SC("PROV_ERR_INCOMPLETO", "Telefono");
            }
            if (!TelefonoValido_883SC(telefono))
            {
                throw CrearError_883SC("PROV_ERR_TELEFONO", "Telefono");
            }
            //Mayor o igual a cero, dentro de lo que entra en decimal(5,2) y con hasta 2 decimales
            if (margen < 0 || margen > MARGEN_MAXIMO_883SC || Math.Round(margen, 2) != margen)
            {
                throw CrearError_883SC("PROV_ERR_MARGEN", "Margen");
            }
            //Longitudes de las columnas de Proveedores
            if (nombre.Length > 50)
            {
                throw CrearError_883SC("PROV_ERR_LONGITUD", "Nombre");
            }
            if ((direccion ?? "").Trim().Length > 50)
            {
                throw CrearError_883SC("PROV_ERR_LONGITUD", "Direccion");
            }
            if ((especialidad ?? "").Trim().Length > 100)
            {
                throw CrearError_883SC("PROV_ERR_LONGITUD", "Especialidad");
            }
        }

        //Solo digitos 0-9 y cantidad dentro del rango. Se guarda como texto.
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

        //Los datos opcionales vacios se guardan como NULL
        private string NormalizarOpcional_883SC(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor)) { return null; }
            return valor.Trim();
        }
    }
}
