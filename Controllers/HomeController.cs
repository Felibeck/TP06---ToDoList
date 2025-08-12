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

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult verTareas()
    {
        int idUsuario = int.Parse(HttpContext.Session.GetString("ID"));
        ViewBag.listaTareas = BD.getListaTareas(idUsuario);
        return View();
    }

    public IActionResult verTarea(int idTarea)
    {
        ViewBag.Tarea = BD.verTarea(idTarea);
        return View();
    }

    public IActionResult agregarTarea()
    {
        return View();
    }

    [HttpPost]
    public IActionResult agregarTarea(string titulo, string descripcion, DateTime fecha, bool finalizada)
    {
        int idUsuario = int.Parse(HttpContext.Session.GetString("ID"));
        BD.crearTarea(titulo, descripcion, fecha, finalizada,idUsuario);
        return RedirectToAction("verTareas");
    }

    public IActionResult modificarTarea()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult modificarTarea(string titulo, string descripcion, DateTime fecha, bool finalizada)
    {
        int idUsuario = int.Parse(HttpContext.Session.GetString("ID"));
        BD.editarTarea(titulo, descripcion, fecha, finalizada,idUsuario);
        return RedirectToAction("verTareas");
    }

    public IActionResult eliminarTarea(int idTarea)
    {
        BD.borrarTarea(idTarea);
        return RedirectToAction("verTareas");
    }

}
