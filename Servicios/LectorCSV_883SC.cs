using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Servicios
{
    /// Lee archivos CSV con separador ';'. Solo parsea: no valida datos de negocio. Los valores se devuelven como texto crudo.
    public class LectorCSV_883SC
    {
        private const char SEPARADOR_883SC = ';';

        /// Devuelve todas las filas del archivo, encabezado incluido, sin validar su contenido: los archivos
        /// de los proveedores traen titulos, separadores y columnas de mas, y la BLL decide cuales usar.
        /// Saltea las filas totalmente vacias (por ejemplo ";;;;").
        /// Archivo que no es .csv, vacio o con comillas sin cerrar: FormatException.
        /// Problemas de lectura del archivo (no existe, en uso, sin permiso): la excepcion de IO original.
        public List<FilaCSV_883SC> LeerArchivo_883SC(string ruta)
        {
            if (string.IsNullOrWhiteSpace(ruta)
                || !string.Equals(Path.GetExtension(ruta), ".csv", StringComparison.OrdinalIgnoreCase))
            {
                throw new FormatException("El archivo no es .csv");
            }

            List<FilaCSV_883SC> registros = Separar_883SC(LeerTexto_883SC(ruta));
            if (registros.Count == 0)
            {
                throw new FormatException("El archivo no tiene filas");
            }
            return registros;
        }

        private string LeerTexto_883SC(string ruta)
        {
            byte[] bytes = File.ReadAllBytes(ruta);
            int inicio = (bytes.Length >= 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF) ? 3 : 0;
            try
            {
                return new UTF8Encoding(false, true).GetString(bytes, inicio, bytes.Length - inicio);
            }
            catch (DecoderFallbackException)
            {
                return Encoding.GetEncoding(1252).GetString(bytes, inicio, bytes.Length - inicio);
            }
        }

        //Separa en registros y campos. Un campo entre comillas puede contener ';', saltos de linea
        //y comillas dobles escapadas ("").
        private List<FilaCSV_883SC> Separar_883SC(string texto)
        {
            List<FilaCSV_883SC> registros = new List<FilaCSV_883SC>();
            List<string> campos = new List<string>();
            StringBuilder campo = new StringBuilder();
            bool entreComillas = false;
            int linea = 1;
            int lineaInicio = 1;

            for (int i = 0; i < texto.Length; i++)
            {
                char c = texto[i];
                if (entreComillas)
                {
                    if (c == '"')
                    {
                        if (i + 1 < texto.Length && texto[i + 1] == '"') { campo.Append('"'); i++; }
                        else { entreComillas = false; }
                    }
                    else
                    {
                        if (c == '\n') { linea++; }
                        campo.Append(c);
                    }
                }
                else if (c == '"')
                {
                    entreComillas = true;
                }
                else if (c == SEPARADOR_883SC)
                {
                    campos.Add(campo.ToString());
                    campo.Clear();
                }
                else if (c == '\r' || c == '\n')
                {
                    if (c == '\r' && i + 1 < texto.Length && texto[i + 1] == '\n') { i++; }
                    CerrarRegistro_883SC(registros, campos, campo, lineaInicio);
                    linea++;
                    lineaInicio = linea;
                }
                else
                {
                    campo.Append(c);
                }
            }

            if (entreComillas)
            {
                throw new FormatException("Comillas sin cerrar");
            }
            CerrarRegistro_883SC(registros, campos, campo, lineaInicio);
            return registros;
        }

        //Cierra el registro en curso; una linea sin ningun valor no genera fila
        private void CerrarRegistro_883SC(List<FilaCSV_883SC> registros, List<string> campos, StringBuilder campo, int lineaInicio)
        {
            campos.Add(campo.ToString());
            campo.Clear();

            bool enBlanco = true;
            foreach (string valor in campos)
            {
                if (valor.Trim() != "") { enBlanco = false; }
            }
            if (!enBlanco)
            {
                FilaCSV_883SC fila = new FilaCSV_883SC();
                fila.NumeroFila_883SC = lineaInicio;
                fila.Valores_883SC = campos.ToArray();
                registros.Add(fila);
            }
            campos.Clear();
        }
    }
}
