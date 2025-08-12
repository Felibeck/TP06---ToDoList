using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06_ToDoList.Models;

namespace TP06_ToDoList.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult guardarLogin(string username, string password)
    { 
        int idUsuario = BD.Login(username,password);
        BD.getFechaUltIngr(idUsuario);
        HttpContext.Session.SetString("ID",idUsuario.ToString());
        return View();
        //Falta Return a la home
    }

    public IActionResult Registro()
    {
        return View();
    }

    public IActionResult guardarRegistro(string username, string password, string nombre, string apellido, string foto)
    {
        BD.SignIn(username,password,nombre,apellido,foto,(DateTime.Today));
        Usuario usuario = BD.GetUsuario(username,password);
        HttpContext.Session.SetString("ID", usuario.ID.ToString());
        return View();
        //Falta return a la home
    }

    public IActionResult logOut()
    {
        Session.Remove("ID");
    }
}