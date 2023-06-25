// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using EspacioTarea;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

 internal class Program
{
    private static void Main(string[] args)
    {
        //1. Cree aleatoriamente N tareas pendientes.
        Random rand = new Random(); // creo una instancia de Random
        int cantidadTareas = rand.Next(1,6); // genera un nro aleatorio entre 1 y 5
        List<Tareas> TareasPendientes = new List<Tareas>();
        List<string> descripciones = new List<string>()
        {
            "Gestión de inventario",
            "Recepción y despacho de mercancías",
            "Etiquetado y empaquetado",
            "Control de calidad",
            "Carga y descarga de mercancías",
            "Atención al cliente",
            "Organización del almacén",
            "Actualización de sistemas informáticos",
            "Coordinar entrega de producto"
        };

        for (int i = 0; i < cantidadTareas; i++)
        {
            string descripcion = descripciones[rand.Next(descripciones.Count)];
            TimeSpan duracion = TimeSpan.FromMinutes(rand.Next(10, 101));
            Tareas tarea = new Tareas(i, descripcion, duracion);
            TareasPendientes.Add(tarea);
        }

        //Mostrar las tareas pendientes (creadas)
        Console.WriteLine("-------TAREAS PENDIENTES-------");
        foreach (Tareas item in TareasPendientes)
        {
            Console.WriteLine(item.mostrarTarea());
            Console.WriteLine();
        }
        
        //2. Desarrolle una interfaz para mover las tareas pendientes a realizadas.
        List<Tareas> TareasRealizadas = new List<Tareas>();
        moverTareas(TareasPendientes, TareasRealizadas);
        Console.WriteLine("-------TAREAS PENDIENTES-------");
        foreach (Tareas item in TareasPendientes)
        {
            Console.WriteLine(item.mostrarTarea());
            Console.WriteLine();
        }
        Console.WriteLine("-------TAREAS REALIZADAS-------");
        foreach (Tareas item in TareasRealizadas)
        {
            Console.WriteLine(item.mostrarTarea());
            Console.WriteLine();
        }

        //3. Desarrolle una interfaz para buscar tareas pendientes por descripción.
        string? descripBuscada;
        int bandera =0;
        Console.WriteLine("\nIngrese la descripcion de la tarea que quiere buscar: ");
        descripBuscada = Console.ReadLine();
        foreach (Tareas tarea in TareasPendientes)
        {
            if (tarea.Descripcion == descripBuscada)
            {
                bandera = 1;
                Console.WriteLine("*********** Tareas Pendientes **************");
                Console.Write(tarea.mostrarTarea());
            }
        }

        if (bandera == 0)
        {
            Console.WriteLine("No se encontro la tarea");
        }

        /*4. Guarde en un archivo de texto un sumario de las horas trabajadas por el empleado
        (sumatoria de la duración de las tareas).*/
        string rutaArchivo = @"C:\tl1_tp8_2023-NatiRollan\";
        string nombreArchivo = "horasTrabajadas.txt";
        string nuevoArchivo = rutaArchivo + nombreArchivo;

        using (StreamWriter sw = new StreamWriter(nuevoArchivo, true))
        {
            TimeSpan horasTrabajadas = CantidadHorasTrabajadas(TareasRealizadas);
            sw.WriteLine($"Horas trabajadas: {horasTrabajadas}");
        }

    }

    public static void moverTareas(List<Tareas> TareasPendientes, List<Tareas> TareasRealizadas)
    {
        int respuesta;
        Console.WriteLine("-------TAREAS PENDIENTES-------");
        for (int i = 0; i < TareasPendientes.Count; i++)
        {
            Console.Write(TareasPendientes[i].mostrarTarea());
            Console.WriteLine("\nRealizo la tarea?(1=si, 0=no): ");
            int.TryParse(Console.ReadLine(), out respuesta);
            if (respuesta == 1)
            {
                TareasRealizadas.Add(TareasPendientes[i]);
                TareasPendientes.RemoveAt(i);
                i--; 
            }
        }
    }
    public static TimeSpan CantidadHorasTrabajadas(List<Tareas> lista)
    {
        TimeSpan horasTrabajadas = TimeSpan.Zero;
        foreach (var tarea in lista)
        {
            horasTrabajadas = horasTrabajadas + tarea.Duracion;
            
        }
        return horasTrabajadas;
    }
}