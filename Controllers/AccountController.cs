using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06_ToDoList.Models;

namespace TP06_ToDoList.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult guardarLogin(string username, string password)
    { 
        int idUsuario = BD.Login(username,password);
        BD.getFechaUltIngr(idUsuario);
        HttpContext.Session.SetString("ID",idUsuario.ToString());
        return View("verTareas");
    }

    public IActionResult Registro()
    {
        return View();
    }

    [HttpPost]
    public IActionResult guardarRegistro(string username, string password, string nombre, string apellido, string foto)
    {
        BD.SignIn(username,password,nombre,apellido,foto,(DateTime.Today));
        Usuario usuario = BD.GetUsuario(username,password);
        HttpContext.Session.SetString("ID", usuario.ID.ToString());
        return View("verTareas");
    }

    public IActionResult logOut()
    {
        HttpContext.Session.Remove("ID");
        return RedirectToAction("Index");
    }
}