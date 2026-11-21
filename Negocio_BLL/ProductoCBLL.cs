using Acceso_DAL;
using Entidad_BE;
using Servicios;
using System;
using System.Collections.Generic;

namespace Negocio_BLL
{
    public class ProductoCBLL_883SC
    {
        MP_ProductoC_883SC mpProductoC_883SC = new MP_ProductoC_883SC();
        PerfilBLL_883SC perfilBLL_883SC = new PerfilBLL_883SC();
        BitacoraBLL_883SC bitacora_883SC = new BitacoraBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        public List<ProductoCBE_883SC> ListarCambios_883SC()
        {
            ValidarPermiso_883SC();
            return mpProductoC_883SC.ListarCambios_883SC();
        }

        // Filtros opcionales y combinables. Fecha inicial posterior a la final: ArgumentException traducida.
        public List<ProductoCBE_883SC> BuscarCambios_883SC(string codigo, string nombre, DateTime? desde, DateTime? hasta)
        {
            ValidarPermiso_883SC();
            if (desde.HasValue && hasta.HasValue && desde.Value.Date > hasta.Value.Date)
            {
                throw new ArgumentException(Traducir_883SC("BITC_ERR_FECHAS"));
            }
            return mpProductoC_883SC.BuscarCambios_883SC((codigo ?? "").Trim(), (nombre ?? "").Trim(), desde, hasta);
        }

        public List<string> ListarCodigos_883SC()
        {
            ValidarPermiso_883SC();
            return mpProductoC_883SC.ListarCodigos_883SC();
        }

        public List<string> ListarNombres_883SC()
        {
            ValidarPermiso_883SC();
            return mpProductoC_883SC.ListarNombres_883SC();
        }

        // Restaura en Productos los valores de la version (incluye stock y precio) y la deja como vigente.
        // Version inexistente, ya vigente o con proveedor dado de baja: ArgumentException con el mensaje traducido
        // (no se cambia nada). Error de base de datos: la excepcion original sube sin tratar.
        public void ActivarVersion_883SC(ProductoCBE_883SC version)
        {
            ValidarPermiso_883SC();
            if (version == null)
            {
                throw new ArgumentException(Traducir_883SC("BITC_ERR_SELECCION"));
            }

            try
            {
                mpProductoC_883SC.ActivarVersion_883SC(version.IdCambio_883SC);
            }
            catch (ActivarVersionException_883SC ex)
            {
                throw new ArgumentException(Traducir_883SC(ClaveError_883SC(ex.Numero_883SC)));
            }

            //Igual que el resto del sistema, la bitacora general se escribe despues de confirmar el SP
            bitacora_883SC.RegistrarBitacora_883SC(UsuarioActual_883SC().user_883SC, TipoAccion_883SC.ActivacionVersionProducto,
                "codigo=" + version.Codigo_883SC + ";version=" + version.IdCambio_883SC);
        }

        private static string ClaveError_883SC(int numero)
        {
            switch (numero)
            {
                case 50002: return "BITC_ERR_YA_VIGENTE";
                case 50003: return "BITC_ERR_PROV_INACTIVO";
                default: return "BITC_ERR_NO_EXISTE";
            }
        }

        private void ValidarPermiso_883SC()
        {
            UsuarioBE_883SC usuario = UsuarioActual_883SC();
            if (usuario == null || !perfilBLL_883SC.TienePermiso_883SC(usuario.rol_883SC, TipoPermiso_883SC.GestionBitacoraCambios.ToString()))
            {
                throw new UnauthorizedAccessException(Traducir_883SC("BITC_ERR_PERMISO"));
            }
        }

        private UsuarioBE_883SC UsuarioActual_883SC()
        {
            return SessionManager_883SC.Logged_883SC() ? SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC() : null;
        }

        private string Traducir_883SC(string clave)
        {
            return gestorIdioma_883SC.Traducir_883SC(clave);
        }
    }
}
