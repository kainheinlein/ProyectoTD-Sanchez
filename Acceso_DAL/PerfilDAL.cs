using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad_BE;

namespace Acceso_DAL
{
    public class PerfilDAL_883SC
    {
        private AccesoDatos_883SC conexDB_883SC = new AccesoDatos_883SC();

        public List<Permiso_883SC> ListaPermisos_883SC(string tipo = "")
        {
            string command;
            SqlCommand cmd;
            if (tipo == "Compuesto" || tipo == "Simple")
            {
                command = "select * from Permiso where Tipo = @Tipo";
                cmd = new SqlCommand(command);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
            }
            else if (tipo == "Rol")
            {
                command = "select * from Permiso where Rol = 1";
                cmd = new SqlCommand(command);
            }
            else
            {
                command = "select * from Permiso";
                cmd = new SqlCommand(command);
            }

            conexDB_883SC.AbrirConexion_883SC();
            cmd.Connection = conexDB_883SC.conexion_883SC;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            conexDB_883SC.CerrarConexion_883SC();

            List<Permiso_883SC> listaPermiso = new List<Permiso_883SC>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr[1].ToString() == "Simple")
                {
                    listaPermiso.Add(new PermisoSimple_883SC(dr[0].ToString()));
                }
                else
                {
                    if (bool.Parse(dr[2].ToString()))
                    {
                        listaPermiso.Add(new Familia_883SC(dr[0].ToString(), true));
                    }
                    else
                    {
                        listaPermiso.Add(new Familia_883SC(dr[0].ToString(), false));
                    }
                }
            }

            return listaPermiso;
        }

        public bool PerfilEnUso_883SC(string nombre)
        {
            conexDB_883SC.AbrirConexion_883SC();
            string query = "SELECT * FROM Usuarios WHERE Rol = @Nombre";
            SqlCommand cmd = new SqlCommand(query, conexDB_883SC.conexion_883SC);
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            conexDB_883SC.CerrarConexion_883SC();

            int count = ds.Tables[0].Rows.Count;
            return count > 0;
        }

        public List<Permiso_883SC> ListaPermisosEnArbol_883SC()
        {
            List<Permiso_883SC> todos = new List<Permiso_883SC>();
            Dictionary<string, string> padres = new Dictionary<string, string>();

            string command = "select * from Permiso";
            conexDB_883SC.AbrirConexion_883SC();
            SqlCommand cmd = new SqlCommand(command, conexDB_883SC.conexion_883SC);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            conexDB_883SC.CerrarConexion_883SC();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Permiso_883SC p;
                if (dr[1].ToString() == "Simple")
                {
                    p = new PermisoSimple_883SC(dr[0].ToString());
                }
                else
                {
                    p = new Familia_883SC(dr[0].ToString(), bool.Parse(dr[2].ToString()));
                }

                todos.Add(p);
                if (dr[3] != DBNull.Value)
                {
                    padres[p.Nombre_883SC] = dr[3].ToString();
                }
            }

            List<Familia_883SC> compuestos = todos.OfType<Familia_883SC>().ToList();

            foreach (Permiso_883SC hijo in todos)
            {
                if (padres.TryGetValue(hijo.Nombre_883SC, out string nombrePadre))
                {
                    Familia_883SC padre = compuestos.Find(f => f.Nombre_883SC == nombrePadre);
                    padre?.AgregarHijo_883SC(hijo);
                }
            }

            return compuestos.Cast<Permiso_883SC>().ToList();
        }

        public List<Permiso_883SC> ListaPermisosRaiz_883SC()
        {
            List<Permiso_883SC> arbol = ListaPermisosEnArbol_883SC();

            HashSet<string> raices = new HashSet<string>();
            conexDB_883SC.AbrirConexion_883SC();
            SqlCommand cmd = new SqlCommand("Select Nombre_Permiso from Permiso where Nombre_PermisoPadre is null", conexDB_883SC.conexion_883SC);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            conexDB_883SC.CerrarConexion_883SC();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                raices.Add(dr[0].ToString());
            }

            return arbol.Where(x => raices.Contains(x.Nombre_883SC)).ToList();
        }

        public void AgregarFamilia_883SC(Familia_883SC pFamilia)
        {
            conexDB_883SC.AbrirConexion_883SC();
            string query = "INSERT INTO Permiso (Nombre_Permiso, Tipo, Rol) VALUES (@Nombre, 'Compuesto', @Rol)";
            SqlCommand cmd = new SqlCommand(query, conexDB_883SC.conexion_883SC);
            cmd.Parameters.AddWithValue("@Nombre", pFamilia.Nombre_883SC);
            cmd.Parameters.AddWithValue("@Rol", pFamilia.EsRol_883SC ? 1 : 0);
            cmd.ExecuteNonQuery();
            conexDB_883SC.CerrarConexion_883SC();
        }

        public void EliminarFamilia_883SC(Familia_883SC pFamilia)
        {
            conexDB_883SC.AbrirConexion_883SC();

            string command = "update Permiso set Nombre_PermisoPadre = null where Nombre_PermisoPadre = @Nombre";
            SqlCommand cmd = new SqlCommand(command, conexDB_883SC.conexion_883SC);
            cmd.Parameters.AddWithValue("@Nombre", pFamilia.Nombre_883SC);
            cmd.ExecuteNonQuery();

            command = "delete from Permiso where Nombre_Permiso = @Nombre";
            cmd = new SqlCommand(command, conexDB_883SC.conexion_883SC);
            cmd.Parameters.AddWithValue("@Nombre", pFamilia.Nombre_883SC);
            cmd.ExecuteNonQuery();

            conexDB_883SC.CerrarConexion_883SC();
        }

        public void ModificarFamilia_883SC(Familia_883SC pFamilia, List<string> permisos)
        {
            conexDB_883SC.AbrirConexion_883SC();

            string command = "update Permiso set Nombre_PermisoPadre = null where Nombre_PermisoPadre = @Nombre";
            SqlCommand cmd = new SqlCommand(command, conexDB_883SC.conexion_883SC);
            cmd.Parameters.AddWithValue("@Nombre", pFamilia.Nombre_883SC);
            cmd.ExecuteNonQuery();

            foreach (var p in permisos)
            {
                command = "update Permiso set Nombre_PermisoPadre = @Familia where Nombre_Permiso = @Permiso";
                cmd = new SqlCommand(command, conexDB_883SC.conexion_883SC);
                cmd.Parameters.AddWithValue("@Familia", pFamilia.Nombre_883SC);
                cmd.Parameters.AddWithValue("@Permiso", p);
                cmd.ExecuteNonQuery();
            }

            conexDB_883SC.CerrarConexion_883SC();
        }

        public void AgregarPermisoAFamilia_883SC(string familia, string permiso)
        {
            conexDB_883SC.AbrirConexion_883SC();
            string command = "update Permiso set Nombre_PermisoPadre = @Familia where Nombre_Permiso = @Permiso";
            SqlCommand cmd = new SqlCommand(command, conexDB_883SC.conexion_883SC);
            cmd.Parameters.AddWithValue("@Familia", familia);
            cmd.Parameters.AddWithValue("@Permiso", permiso);
            cmd.ExecuteNonQuery();
            conexDB_883SC.CerrarConexion_883SC();
        }

        public void EliminarPermisoDeFamilia_883SC(string familia, string permiso)
        {
            conexDB_883SC.AbrirConexion_883SC();
            string command = "update Permiso set Nombre_PermisoPadre = null where Nombre_PermisoPadre = @Familia AND Nombre_Permiso = @Permiso";
            SqlCommand cmd = new SqlCommand(command, conexDB_883SC.conexion_883SC);
            cmd.Parameters.AddWithValue("@Familia", familia);
            cmd.Parameters.AddWithValue("@Permiso", permiso);
            cmd.ExecuteNonQuery();
            conexDB_883SC.CerrarConexion_883SC();
        }
    }
}

