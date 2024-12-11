using System;

public class Opinion
{
    public static int nextId = 1;
    public int Id { get; private set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Calificacion { get; set; } // Nueva propiedad

    public Opinion(string nombre, string descripcion, string calificacion)
    {
        Id = nextId++;
        Nombre = nombre;
        Descripcion = descripcion;
        Calificacion = calificacion; // Inicializar la nueva propiedad
    }

   public void MostrarDetalles()
        {
            Console.WriteLine($"Nombre: {Nombre}, Descripcion: {Descripcion}, Calificacion: {Calificacion}");
        }
}
