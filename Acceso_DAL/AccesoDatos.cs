using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_DAL
{
    public class AccesoDatos_883SC
    {
        private SqlConnection _conexion_883SC;
        private readonly string cadenaSQL_883SC = @"Data Source=KAINMPC;Initial Catalog=FerreDB;Integrated Security=True";

        public SqlConnection conexion_883SC { get => _conexion_883SC; }

        public void AbrirConexion_883SC()
        {
            _conexion_883SC = new SqlConnection(cadenaSQL_883SC);
            _conexion_883SC.Open();
        }

        public void CerrarConexion_883SC()
        {
            _conexion_883SC.Close();
        }

        public bool VerificarConexion_883SC()
        {
            try
            {
                AbrirConexion_883SC();
                if (_conexion_883SC.State == ConnectionState.Open)
                {
                    CerrarConexion_883SC();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable LeerTabla_883SC(string sp, SqlParameter[] datos)
        {
            try
            {
                AbrirConexion_883SC();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter();
                ad.SelectCommand = new SqlCommand();
                ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                ad.SelectCommand.CommandText = sp;
                if (datos != null)
                {
                    ad.SelectCommand.Parameters.AddRange(datos);
                }
                ad.SelectCommand.Connection = conexion_883SC;
                ad.Fill(dt);

                return dt;
            }
            catch (Exception) { throw; }
            finally { CerrarConexion_883SC(); }
        }

        public void Escribir_883SC(string sp, SqlParameter[] parametros)
        {
            SqlTransaction tr;
            AbrirConexion_883SC();
            tr = conexion_883SC.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp;
                cmd.Connection = conexion_883SC;
                cmd.Parameters.AddRange(parametros);
                cmd.Transaction = tr;
                cmd.ExecuteNonQuery();
                tr.Commit();
            }
            catch (Exception)
            {
                tr.Rollback();
                throw;
            }
            finally { CerrarConexion_883SC(); }
        }

        public object EscribirRetornar_883SC(string sp, SqlParameter[] parametros)
        {
            SqlTransaction tr;
            AbrirConexion_883SC();
            tr = conexion_883SC.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp;
                cmd.Connection = conexion_883SC;
                cmd.Parameters.AddRange(parametros);
                cmd.Transaction = tr;
                object result = cmd.ExecuteScalar();
                tr.Commit();
                return result;
            }
            catch (Exception)
            {
                tr.Rollback();
                throw;
            }
            finally { CerrarConexion_883SC(); }
        }

        public int Consulta_883SC(string sp, SqlParameter[] parametros)
        {
            int result;

            try
            {
                AbrirConexion_883SC();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp;
                cmd.Connection = conexion_883SC;
                cmd.Parameters.AddRange(parametros);
                cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                return result = Convert.ToInt32(cmd.Parameters["@Result"].Value);
            }
            catch (Exception) { throw; }
            finally { CerrarConexion_883SC(); }
        }

        public object ExtraerDato_883SC(string sp, SqlParameter[] parametros)
        {
            try
            {
                AbrirConexion_883SC();
                SqlCommand cmd = new SqlCommand(sp, conexion_883SC);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                {
                    cmd.Parameters.AddRange(parametros);
                }
                object valor = cmd.ExecuteScalar();
                if(valor == DBNull.Value) { return null; }
                else return valor;
            }
            catch (Exception)
            {
                throw;
            }
            finally { CerrarConexion_883SC(); }
        }
    }
}
