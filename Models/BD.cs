using Microsoft.Data.SqlClient;
using Dapper;

namespace TP06_ToDoList;

static public class BD
{
    private static string _connectionString = @"Server=localhost;DataBase=Presentacion;Integrated Security=True;TrustServerCertificate=True;";



// login
     public static int Login(string username, string password)
    {
        int IDusuarioBuscado = -1;
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT ID FROM Usuarios WHERE password = @pPassword";
            IDusuarioBuscado = connection.QueryFirstOrDefault<int>(query, new { pPassword = password});
        }
            return IDusuarioBuscado;
    }

// sign in
    public static int SignIn(string username, string password, string nombre, string apellido, string foto, string fechaUltimoLogin)
    {
        if(Login(username, password) == -1)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Usuario VALUES ()"
            }

        }
    }

}