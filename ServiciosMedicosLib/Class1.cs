using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosMedicosLib
{
    public class Class1
    {

    }
    //clase para conexiòn a la base de datos
    public class ConexionDB
    {
        private string cadena = "Data Source=localhost\\SQLEXPRESS2019; Initial Catalog=ServiciosMedicos;Integrated Security=True;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
    //clase usuario para acceso al sistema
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombreusuario { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }
    }
    public class UsuarioDAO
    {
        private ConexionDB conexion = new ConexionDB();

        public Usuario ValidarLogin(string usuario, string clave)
        {
            using (var conn = conexion.ObtenerConexion()) 
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Usuarios WHERE Usuario=@u AND Clave=@c",conn);
                cmd.Parameters.AddWithValue("@u",usuario);
                cmd.Parameters.AddWithValue("@c", clave);
                var reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    return new Usuario
                    {
                        IdUsuario = (int)reader["IdUsuario"],
                        Nombreusuario = reader["Usuario"].ToString(),
                        Clave = reader["Clave"].ToString(),
                        Rol = reader["Rol"].ToString()
                    };
                }
                return null;
            }
        }
    }

    public class Estudiante
    {
        public int IdEstudiante { get; set; }
        public string Nombre { get; set; }
        public string Matricula { get; set; }
        public string Carrera { get; set; }
    }
    public class EstudianteDAO
    {
        private ConexionDB conexion = new ConexionDB();

        public void Insertar(Estudiante e)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Estudiantes (Nombre,Matricula,Carrera) VALUES (@n,@m,@c)", conn);
                cmd.Parameters.AddWithValue("@n", e.Nombre);
                cmd.Parameters.AddWithValue("@m", e.Matricula);
                cmd.Parameters.AddWithValue("@c", e.Carrera);
                cmd.ExecuteNonQuery();
            }
        }
        public List<Estudiante> ObtenerTodos()
        {
            List<Estudiante> lista = new List<Estudiante>();
            using (var conn = conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Estudiantes", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Estudiante
                    {
                        IdEstudiante = (int)reader["IdEstudiante"],
                        Nombre = reader["Nombre"].ToString(),
                        Matricula = reader["Matricula"].ToString(),
                        Carrera = reader["Carrera"].ToString()
                    });
                }
            }
            return lista;
        }
    }
}
