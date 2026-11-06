using Acceso_DAL;
using Entidad_BE;
using Servicios;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Negocio_BLL
{
    public class ListaPrecioBLL_883SC
    {
        MP_ListaPrecio_883SC mpListaPrecio_883SC = new MP_ListaPrecio_883SC();
        BitacoraBLL_883SC bitacora_883SC = new BitacoraBLL_883SC();
        LectorCSV_883SC lectorCSV_883SC = new LectorCSV_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        //Largos de ListaPrecio.CodigoProveedor y ListaPrecio.Descripcion
        private const int CODIGO_MAX_883SC = 50;
        private const int DESCRIPCION_MAX_883SC = 200;
        //Tope de la columna PrecioLista decimal(18,2)
        private const decimal PRECIO_MAXIMO_883SC = 9999999999999999.99m;
        //Filas del comienzo del archivo donde se busca el encabezado
        private const int FILAS_BUSQUEDA_ENCABEZADO_883SC = 40;

        /// Lee el .csv del proveedor (todas sus filas). Archivo ilegible, vacio o que no es .csv:
        /// ArgumentException con el mensaje traducido.
        public List<FilaCSV_883SC> LeerArchivo_883SC(string ruta)
        {
            try
            {
                return lectorCSV_883SC.LeerArchivo_883SC(ruta);
            }
            catch (FormatException)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("LIST_ERR_FORMATO"));
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("LIST_ERR_LEER_ARCHIVO"));
            }
        }

        /// Propone que columnas son el codigo, la descripcion y el precio, y donde empiezan los datos.
        /// Busca una fila de encabezado con "codigo" y "descripcion"; el precio es la primera columna a la
        /// derecha de la descripcion que tiene un precio valido en la primera fila de datos. Es solo una
        /// sugerencia: el usuario puede cambiarla. Lo que no se detecta queda en -1.
        public MapeoListaBE_883SC SugerirMapeo_883SC(List<FilaCSV_883SC> filas)
        {
            MapeoListaBE_883SC mapeo = new MapeoListaBE_883SC();
            int indiceEncabezado = -1;

            for (int i = 0; i < filas.Count && i < FILAS_BUSQUEDA_ENCABEZADO_883SC && indiceEncabezado < 0; i++)
            {
                string[] v = filas[i].Valores_883SC;
                int colCodigo = -1;
                int colDescripcion = -1;
                for (int c = 0; c < v.Length; c++)
                {
                    string texto = Normalizar_883SC(v[c]);
                    if (colCodigo < 0 && texto.StartsWith("cod")) { colCodigo = c; }
                    else if (colDescripcion < 0 && texto.StartsWith("descrip")) { colDescripcion = c; }
                }
                if (colCodigo >= 0 && colDescripcion >= 0)
                {
                    indiceEncabezado = i;
                    mapeo.ColCodigo_883SC = colCodigo;
                    mapeo.ColDescripcion_883SC = colDescripcion;
                }
            }

            if (indiceEncabezado < 0)
            {
                //Sin encabezado reconocible: se asume codigo, descripcion y precio en las primeras columnas
                mapeo.ColCodigo_883SC = 0;
                mapeo.ColDescripcion_883SC = 1;
                mapeo.ColPrecio_883SC = 2;
                mapeo.PrimeraFila_883SC = filas.Count > 0 ? filas[0].NumeroFila_883SC : 1;
                return mapeo;
            }

            //Primera fila de datos: la primera con codigo y descripcion cargados
            mapeo.PrimeraFila_883SC = filas[indiceEncabezado].NumeroFila_883SC + 1;
            for (int i = indiceEncabezado + 1; i < filas.Count; i++)
            {
                string[] v = filas[i].Valores_883SC;
                if (Valor_883SC(v, mapeo.ColCodigo_883SC).Trim() == "" || Valor_883SC(v, mapeo.ColDescripcion_883SC).Trim() == "")
                {
                    continue;
                }
                mapeo.PrimeraFila_883SC = filas[i].NumeroFila_883SC;
                decimal precio;
                for (int c = mapeo.ColDescripcion_883SC + 1; c < v.Length; c++)
                {
                    if (TryLeerPrecio_883SC(v[c], out precio)) { mapeo.ColPrecio_883SC = c; break; }
                }
                break;
            }
            return mapeo;
        }

        /// CUN-007. Valida las filas desde la fila inicial del mapeo, guarda las validas en una unica
        /// operacion y registra la bitacora.
        /// Columnas sin elegir o repetidas, o ninguna fila valida: ArgumentException y no se guarda nada.
        /// Error de base de datos: la excepcion original sube sin tratar (no se guarda nada).
        public ResumenImportacionBE_883SC ImportarLista_883SC(int idProveedor, List<FilaCSV_883SC> filas, MapeoListaBE_883SC mapeo)
        {
            if (idProveedor <= 0)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("LIST_ERR_PROVEEDOR"));
            }
            if (mapeo == null
                || mapeo.ColCodigo_883SC < 0 || mapeo.ColDescripcion_883SC < 0 || mapeo.ColPrecio_883SC < 0
                || mapeo.ColCodigo_883SC == mapeo.ColDescripcion_883SC
                || mapeo.ColCodigo_883SC == mapeo.ColPrecio_883SC
                || mapeo.ColDescripcion_883SC == mapeo.ColPrecio_883SC)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("LIST_ERR_COLUMNAS"));
            }

            List<ItemListaPrecioBE_883SC> validos = new List<ItemListaPrecioBE_883SC>();
            List<FilaRechazadaBE_883SC> rechazadas = ValidarFilas_883SC(idProveedor, filas ?? new List<FilaCSV_883SC>(), mapeo, validos);

            if (validos.Count == 0)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("LIST_MSG_SIN_VALIDOS"));
            }

            ResumenImportacionBE_883SC resumen = mpListaPrecio_883SC.GuardarLista_883SC(idProveedor, validos);
            resumen.Rechazadas_883SC = rechazadas;

            string usuario = SessionManager_883SC.Logged_883SC()
                ? SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC
                : "null";
            bitacora_883SC.RegistrarBitacora_883SC(usuario, TipoAccion_883SC.ImportacionListaPrecios,
                "proveedor=" + idProveedor
                + ";importados=" + resumen.Importados_883SC
                + ";preciosActualizados=" + resumen.PreciosVentaActualizados_883SC
                + ";pendientes=" + resumen.Pendientes_883SC
                + ";rechazados=" + rechazadas.Count);

            return resumen;
        }

        /// Precios de lista del producto en cada proveedor que lo tiene vinculado, de menor a mayor.
        /// Lista vacia si ningun proveedor lo tiene.
        public List<LineaCompraBE_883SC> CompararPrecios_883SC(ProductoBE_883SC producto)
        {
            if (producto == null)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("OC_ERR_SEL_PRODUCTO"));
            }
            return mpListaPrecio_883SC.ListarPreciosProducto_883SC(producto);
        }

        /// Items pendientes de vinculacion; idProveedor null = de todos los proveedores.
        public List<ItemListaPrecioBE_883SC> ListarPendientes_883SC(int? idProveedor)
        {
            return mpListaPrecio_883SC.ListarPendientes_883SC(idProveedor);
        }

        /// Codigos de proveedor vinculados a un producto.
        public List<ItemListaPrecioBE_883SC> ListarVinculados_883SC(string codigoProducto)
        {
            return mpListaPrecio_883SC.ListarVinculados_883SC(codigoProducto);
        }

        /// Vincula un item pendiente con un producto existente. No cambia el proveedor de referencia
        /// ni el precio. Si el producto ya tiene un codigo de ese proveedor: ArgumentException.
        public void Vincular_883SC(ItemListaPrecioBE_883SC item, ProductoBE_883SC producto)
        {
            if (item == null)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROD_ERR_SEL_ITEM"));
            }
            if (producto == null)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROD_ERR_SEL_PRODUCTO"));
            }
            foreach (ItemListaPrecioBE_883SC vinculado in mpListaPrecio_883SC.ListarVinculados_883SC(producto.Codigo_883SC))
            {
                if (vinculado.IdProveedor_883SC == item.IdProveedor_883SC)
                {
                    throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROD_ERR_YA_VINCULADO_PROV"));
                }
            }

            mpListaPrecio_883SC.VincularItem_883SC(item, producto.Codigo_883SC);

            bitacora_883SC.RegistrarBitacora_883SC(UsuarioActual_883SC(), TipoAccion_883SC.VinculacionProducto,
                "codigo=" + producto.Codigo_883SC + ";proveedor=" + item.IdProveedor_883SC + ";codigoProveedor=" + item.CodigoProveedor_883SC);
        }

        /// Desvincula un codigo de proveedor del producto (el item vuelve a quedar pendiente).
        /// Si es el proveedor de referencia y el producto tiene otros codigos vinculados: ArgumentException.
        public void Desvincular_883SC(ItemListaPrecioBE_883SC item, ProductoBE_883SC producto)
        {
            if (producto == null)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROD_ERR_SEL_PRODUCTO"));
            }
            if (item == null || item.Codigo_883SC != producto.Codigo_883SC)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROD_ERR_SEL_VINCULO"));
            }
            //El codigo de la referencia solo se puede soltar si es el unico vinculado (el producto queda como uno
            //viejo sin vinculos: conserva su referencia y su precio)
            if (item.IdProveedor_883SC == producto.Proveedor_883SC
                && mpListaPrecio_883SC.ListarVinculados_883SC(producto.Codigo_883SC).Count > 1)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("PROD_ERR_DESVINC_REF"));
            }

            mpListaPrecio_883SC.DesvincularItem_883SC(item);

            bitacora_883SC.RegistrarBitacora_883SC(UsuarioActual_883SC(), TipoAccion_883SC.DesvinculacionProducto,
                "codigo=" + producto.Codigo_883SC + ";proveedor=" + item.IdProveedor_883SC + ";codigoProveedor=" + item.CodigoProveedor_883SC);
        }

        private string UsuarioActual_883SC()
        {
            return SessionManager_883SC.Logged_883SC()
                ? SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC
                : "null";
        }

        /// Separa las filas en validas (se agregan a <paramref name="validos"/>) y rechazadas con su motivo.
        /// Se ignoran, sin rechazarlas, las filas que no son de datos: las anteriores a la fila inicial y las
        /// que no tienen codigo y tampoco descripcion o un precio valido (titulos de seccion, separadores).
        /// De un codigo repetido se conserva la primera fila valida; las siguientes se rechazan.
        public List<FilaRechazadaBE_883SC> ValidarFilas_883SC(int idProveedor, List<FilaCSV_883SC> filas, MapeoListaBE_883SC mapeo, List<ItemListaPrecioBE_883SC> validos)
        {
            List<FilaRechazadaBE_883SC> rechazadas = new List<FilaRechazadaBE_883SC>();
            //Sin distinguir mayusculas: es la collation de la base y el MERGE trata A1 y a1 como la misma clave
            HashSet<string> codigosLeidos = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (FilaCSV_883SC fila in filas)
            {
                if (fila.NumeroFila_883SC < mapeo.PrimeraFila_883SC) { continue; }

                string[] v = fila.Valores_883SC;
                string codigo = Valor_883SC(v, mapeo.ColCodigo_883SC).Trim();
                string descripcion = Valor_883SC(v, mapeo.ColDescripcion_883SC).Trim();
                string textoPrecio = Valor_883SC(v, mapeo.ColPrecio_883SC).Trim();

                string motivo = null;
                decimal precio = 0;

                //Sin codigo y sin un precio valido (o sin descripcion) no es un item: es un titulo o un separador
                if (codigo == "" && (descripcion == "" || !TryLeerPrecio_883SC(textoPrecio, out precio))) { continue; }

                if (codigo == "")
                {
                    motivo = "LIST_MOT_CODIGO";
                }
                else if (descripcion == "")
                {
                    motivo = "LIST_MOT_DESCRIPCION";
                }
                else if (codigo.Length > CODIGO_MAX_883SC || descripcion.Length > DESCRIPCION_MAX_883SC)
                {
                    motivo = "LIST_MOT_LONGITUD";
                }
                else if (!TryLeerPrecio_883SC(textoPrecio, out precio))
                {
                    motivo = "LIST_MOT_PRECIO";
                }
                else if (codigosLeidos.Contains(codigo))
                {
                    motivo = "LIST_MOT_DUPLICADO";
                }

                if (motivo != null)
                {
                    FilaRechazadaBE_883SC rechazada = new FilaRechazadaBE_883SC();
                    rechazada.NumeroFila_883SC = fila.NumeroFila_883SC;
                    rechazada.CodigoProveedor_883SC = codigo;
                    rechazada.Motivo_883SC = gestorIdioma_883SC.Traducir_883SC(motivo);
                    rechazadas.Add(rechazada);
                    continue;
                }

                codigosLeidos.Add(codigo);
                ItemListaPrecioBE_883SC item = new ItemListaPrecioBE_883SC();
                item.IdProveedor_883SC = idProveedor;
                item.CodigoProveedor_883SC = codigo;
                item.Descripcion_883SC = descripcion;
                item.PrecioLista_883SC = precio;
                validos.Add(item);
            }
            return rechazadas;
        }

        //Una fila mas corta que la columna pedida se trata como celda vacia
        private string Valor_883SC(string[] valores, int columna)
        {
            return (columna >= 0 && columna < valores.Length) ? valores[columna] : "";
        }

        //Minuscula y sin tildes, para reconocer "Código" y "DESCRIPCIÓN"
        private string Normalizar_883SC(string texto)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in (texto ?? "").Trim().ToLowerInvariant().Normalize(NormalizationForm.FormD))
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark) { sb.Append(c); }
            }
            return sb.ToString();
        }

        //Numero mayor a cero con hasta 2 decimales. Tolera el simbolo $ y los espacios ("$ 1.234,56").
        //Si trae punto y coma, el ultimo es el decimal y el otro es separador de miles. Una coma sola es
        //decimal; un punto solo es decimal, salvo que se repita (1.234.567: miles).
        //Usa la cultura invariante: el resultado no depende de la configuracion regional de la PC.
        private bool TryLeerPrecio_883SC(string texto, out decimal precio)
        {
            precio = 0;
            StringBuilder limpio = new StringBuilder();
            foreach (char c in (texto ?? ""))
            {
                if (c != '$' && !char.IsWhiteSpace(c)) { limpio.Append(c); }
            }
            string t = limpio.ToString();
            if (t == "") { return false; }

            int ultimoPunto = t.LastIndexOf('.');
            int ultimaComa = t.LastIndexOf(',');
            if (ultimoPunto >= 0 && ultimaComa >= 0)
            {
                char decimalSep = ultimaComa > ultimoPunto ? ',' : '.';
                char milesSep = decimalSep == ',' ? '.' : ',';
                //El separador de miles no puede aparecer despues del decimal
                if (t.LastIndexOf(milesSep) > t.LastIndexOf(decimalSep)) { return false; }
                t = t.Replace(milesSep.ToString(), "").Replace(decimalSep, '.');
            }
            else if (ultimaComa >= 0)
            {
                if (t.IndexOf(',') != ultimaComa) { return false; }
                t = t.Replace(',', '.');
            }
            else if (ultimoPunto >= 0 && t.IndexOf('.') != ultimoPunto)
            {
                t = t.Replace(".", "");
            }

            if (!decimal.TryParse(t, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out precio))
            {
                return false;
            }
            return precio > 0 && precio <= PRECIO_MAXIMO_883SC && Math.Round(precio, 2) == precio;
        }
    }
}
