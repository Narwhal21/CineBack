using System;

public class Entrada
{
    public static int nextId = 1;
    public int Id { get; private set; }
    public string Fecha { get; set; }
    public double Precio { get; set; }
    public int SalaId { get; set; }
    public string Tipo { get; set; } // Nueva propiedad

    public Entrada(string fecha, double precio, int salaId, string tipo)
    {
        Id = nextId++;
        Fecha = fecha;
        Precio = precio;
        SalaId = salaId;
        Tipo = tipo; // Inicializar la nueva propiedad
    }
}

