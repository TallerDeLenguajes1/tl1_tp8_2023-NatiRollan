namespace EspacioTarea;

public class Tareas{

    private int tareaID;
    private string? descripcion;
    private TimeSpan duracion;

    //propiedades
    public int TareaID { get => tareaID; set => tareaID = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public TimeSpan Duracion { get => duracion; set => duracion = value; }

    //constructor
    public Tareas(int tareaID, string? descripcion, TimeSpan duracion)
    {
        TareaID = tareaID;
        Descripcion = descripcion;
        Duracion = duracion;
    }

    public string mostrarTarea(){
        string texto = $"ID:{TareaID} \n descripcion: {Descripcion} \n duracion: {Duracion} minutos"; //interpolación de cadenas
        return texto;
    }

}