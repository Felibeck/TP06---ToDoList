public class Tarea
{
    public int ID {get; private set;}
    public string titulo {get; private set;}
    public string descripcion {get; private set;}
    public DateTime fecha {get; private set;}
    public bool finalizada {get; private set;}
    public int IDUsuario {get; private set;}

    public Tarea(int ID, string titulo, string descripcion, DateTime fecha, bool finalizada, int IDUsuario){}
}