using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Servicios
{
    //Unico punto de lectura de la cadena de conexion. AccesoDatos_883SC y BackupService_883SC la obtienen de aca.
    public static class ConexionConfig_883SC
    {
        private const string NombreConfig_883SC = "FerreDB";
        private const int TimeoutPruebaSegundos_883SC = 4;
        private static readonly string[] InstanciasAlternativas_883SC = { @".\SQLEXPRESS", "localhost", @"(localdb)\MSSQLLocalDB" };
        //Pedidos: 53 red, 26 instancia no encontrada, 40 no se pudo abrir la conexion, -1 conexion, 2 servidor no encontrado.
        //Agregados porque el Number varia segun DNS/protocolo (se vio 64 y 11001 con un servidor inexistente):
        //-2 timeout, 52 LocalDB no instalado, 64 red, 233, 10051, 10054, 10060, 10061 y 11001 (errores de socket/DNS).
        //Login (18456...) y base inexistente (4060) NO estan: no se arreglan cambiando de instancia.
        private static readonly int[] ErroresDeRedOInstancia_883SC = { 53, 26, 40, -1, 2, -2, 52, 64, 233, 10051, 10054, 10060, 10061, 11001 };

        private static string cadena_883SC;
        private static readonly object bloqueo_883SC = new object();

        //Cadena para usar en la aplicacion (apunta a la base del config)
        public static string ObtenerCadena_883SC()
        {
            if (cadena_883SC != null) { return cadena_883SC; }
            lock (bloqueo_883SC)
            {
                if (cadena_883SC == null)
                {
                    cadena_883SC = Resolver_883SC();
                }
                return cadena_883SC;
            }
        }

        //Misma cadena (mismo servidor) pero apuntando a master, para crear FerreDB
        public static string ObtenerCadenaMaster_883SC()
        {
            SqlConnectionStringBuilder master = new SqlConnectionStringBuilder(ObtenerCadena_883SC());
            master.InitialCatalog = "master";
            return master.ConnectionString;
        }

        private static string RutaConfig_883SC()
        {
            return AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
        }

        private static SqlConnectionStringBuilder LeerConfig_883SC()
        {
            ConnectionStringSettings entrada = ConfigurationManager.ConnectionStrings[NombreConfig_883SC];
            if (entrada == null || string.IsNullOrWhiteSpace(entrada.ConnectionString))
            {
                throw new InvalidOperationException("Falta la configuracion '" + NombreConfig_883SC + "' en connectionStrings del App.config (" + RutaConfig_883SC() + "). No se puede conectar a la base de datos.");
            }

            SqlConnectionStringBuilder builder;
            try
            {
                builder = new SqlConnectionStringBuilder(entrada.ConnectionString);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is FormatException)
            {
                throw new InvalidOperationException("La cadena de conexion '" + NombreConfig_883SC + "' del App.config (" + RutaConfig_883SC() + ") no es valida: " + ex.Message, ex);
            }

            if (string.IsNullOrWhiteSpace(builder.DataSource))
            {
                throw new InvalidOperationException("La cadena de conexion '" + NombreConfig_883SC + "' del App.config (" + RutaConfig_883SC() + ") no indica el servidor (Data Source).");
            }
            return builder;
        }

        private static string Resolver_883SC()
        {
            SqlConnectionStringBuilder original = LeerConfig_883SC();
            List<string> probadas = new List<string>();

            try
            {
                Probar_883SC(original);
                return original.ConnectionString;
            }
            catch (SqlException ex) when (ErroresDeRedOInstancia_883SC.Contains(ex.Number))
            {
                //Instancia inexistente o inaccesible: se intentan las alternativas. Login o base inexistente NO entran aca y se propagan.
                probadas.Add(original.DataSource);
                Exception ultima = ex;

                foreach (string instancia in InstanciasAlternativas_883SC)
                {
                    if (probadas.Any(p => string.Equals(p, instancia, StringComparison.OrdinalIgnoreCase))) { continue; }
                    probadas.Add(instancia);

                    //Se conserva el resto de la cadena original; solo cambia el servidor
                    SqlConnectionStringBuilder candidata = new SqlConnectionStringBuilder(original.ConnectionString);
                    candidata.DataSource = instancia;
                    try
                    {
                        Probar_883SC(candidata);
                        return candidata.ConnectionString;
                    }
                    catch (SqlException ex2)
                    {
                        ultima = ex2;
                    }
                }

                throw new ConexionNoDisponibleException_883SC(
                    "No se pudo conectar a SQL Server. Instancias probadas: " + string.Join(", ", probadas) +
                    ". Edite la cadena '" + NombreConfig_883SC + "' en " + RutaConfig_883SC() + " con el servidor correcto.",
                    probadas, ultima);
            }
        }

        //Prueba con timeout corto, sin pool y contra master (no cambia el catalogo de la cadena que se devuelve)
        private static void Probar_883SC(SqlConnectionStringBuilder cadenaBase)
        {
            SqlConnectionStringBuilder prueba = new SqlConnectionStringBuilder(cadenaBase.ConnectionString);
            prueba.ConnectTimeout = TimeoutPruebaSegundos_883SC;
            prueba.InitialCatalog = "master";
            prueba.Pooling = false;
            using (SqlConnection cn = new SqlConnection(prueba.ConnectionString))
            {
                cn.Open();
            }
        }
    }
}
