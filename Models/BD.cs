using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;


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
    public static void SignIn(string username, string password, string nombre, string apellido, string foto, string fechaUltimoLogin)
    {
        if(GetUsuario(username) == null)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Usuario (username, password, nombre, apellido, foto, fechaUltimoLogin) VALUES (@pUsername, @pPassword, @pNombre, @pApellido, @pFoto, @pFechaUltimoLogin)";
                connection.Execute(query, new {pUsername = username, pPassword = password, pNombre = nombre, pApellido = apellido, pFoto = foto, pFechaUltimoLogin = fechaUltimoLogin});
            }
        }
    }

    public static Usuario GetUsuario(string username)
    {
       Usuario usuarioBuscado = null;
         using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Usuarios WHERE username = @pUsername";
            usuarioBuscado = connection.QueryFirstOrDefault<Usuario>(query, new { pUsername = username});
        }

        return usuarioBuscado;
    }

    public static List<Tarea> getListaTareas(int idUsuario)
    {
        List<Tarea> listaDeTareas = new List<Tarea>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Tareas WHERE IDUsuario = @pIDUsuario AND finalizada = 0";
            listaDeTareas = connection.Query<Tarea>(query, new { pIDUsuario = idUsuario}).ToList();
        }

        return listaDeTareas;
    }

    public static void crearTarea(string titulo, string descripcion, DateTime fecha, bool finalizada, int IDUsuario)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "INSERT INTO Tareas (titulo, descripcion, fecha, finalizada, IDUsuario) VALUES (@pTitulo, @pDescripcion, @pFecha, @pFinalizada, @pIDUsuario)";
            connection.Execute(query, new {pTitulo = titulo, pDescripcion = descripcion, pFecha = fecha, pFinalizada = finalizada, pIDUsuario = IDUsuario});
        }
    }

    public static void editarTarea(string titulo, string descripcion, DateTime fecha, bool finalizada, int IDUsuario)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE Tareas SET titulo = @pTitulo, descripcion = @pDescripcion, fecha = @pFecha, finalizada = @pFinalizada, IDUsuario = @pIDUsuario";
            connection.Execute(query, new {pTitulo = titulo, pDescripcion = descripcion, pFecha = fecha, pFinalizada = finalizada, pIDUsuario = IDUsuario});
        }
    }

    public static int borrarTarea(string titulo, int idUsuario)
    {
        int numeroDeTareasBorradas;
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "DELETE FROM Tarea WHERE titulo = @pTitulo AND IDUsuario = @pIDUsuario";
            numeroDeTareasBorradas = connection.Execute(query, new {pTitulo = titulo, pIDUsuario = idUsuario});
        }
        return numeroDeTareasBorradas;
    }

    public static void marcarTareaFinalizada(string titulo)
    {
        int idUsuario = GetTarea(titulo);
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE Tareas SET finalizada = 1 WHERE IDUsuario = @pIdUsuario";
            connection.Execute(query, new {pIdUsuario = idUsuario});
        }
    }
        public static int GetTarea(string titulo)
    {
        int tareaBuscada = -1;
         using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT Tareas.IDUsuario FROM Tareas WHERE titulo = @pTitulo";
            tareaBuscada = connection.QueryFirstOrDefault<Usuario>(query, new { pTitulo = titulo});
        }

        return tareaBuscada;
    }
}

