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

        /// CUN-008. Valida, guarda el proveedor (queda activo) y registra la bitacora.
        public ProveedorBE_883SC RegistrarProveedor_883SC(string nombre, string especialidad, string telefono, string direccion, decimal margen, string observaciones)
        {
            nombre = (nombre ?? "").Trim();
            telefono = (telefono ?? "").Trim();
            ValidarDatos_883SC(nombre, especialidad, telefono, direccion, margen);

            if (mpProveedor_883SC.ExisteProveedor_883SC(nombre))
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROV_MSG_EXISTE"));
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

        private void ValidarDatos_883SC(string nombre, string especialidad, string telefono, string direccion, decimal margen)
        {
            if (nombre == "" || telefono == "")
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROV_ERR_INCOMPLETO"));
            }
            if (!TelefonoValido_883SC(telefono))
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROV_ERR_TELEFONO"));
            }
            //Mayor o igual a cero, dentro de lo que entra en decimal(5,2) y con hasta 2 decimales
            if (margen < 0 || margen > MARGEN_MAXIMO_883SC || Math.Round(margen, 2) != margen)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROV_ERR_MARGEN"));
            }
            //Longitudes de las columnas de Proveedores
            if (nombre.Length > 50
                || (direccion ?? "").Trim().Length > 50
                || (especialidad ?? "").Trim().Length > 100)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROV_ERR_LONGITUD"));
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
