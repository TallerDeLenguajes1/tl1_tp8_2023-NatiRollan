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
        //Console.WriteLine("Ingrese la ruta de una carpeta: ");
        //string ruta = Console.ReadLine();
        string rutaCarpeta = @"c:\tl1_tp8_2023-NatiRollan";

        if (Directory.Exists(rutaCarpeta))
        {
            //Listar archivos
            List<string> listadoDeArchivos = Directory.GetFiles(rutaCarpeta).ToList();
            Console.WriteLine("Archivos en carpeta - " + rutaCarpeta);

            foreach (string archivos in listadoDeArchivos)
            {
                Console.WriteLine(archivos);
            }
            
            string nombreArchivo = @"\index.csv";
            string nuevoArchivo = rutaCarpeta + nombreArchivo;

            using (StreamWriter sw = new StreamWriter(nuevoArchivo))
            {
                for (int i = 0; i < listadoDeArchivos.Count; i++)
                {
                    string extension = Path.GetExtension(listadoDeArchivos[i]);
                    string nombre = Path.GetFileNameWithoutExtension(listadoDeArchivos[i]);
                    sw.WriteLine(i + ";" + nombre + ";" + extension);
                }
            }

        } else
        {
            Console.WriteLine("No se encontró la carpeta");
        }

    }

}