using System;

public class Entrada
{
    public static int nextId = 1;
    public int Id { get; private set; }
    public string Fecha { get; set; }
    public double Precio { get; set; }
    public int SalaId { get; set; }

    public Entrada(string fecha, double precio, int salaId)
    {
        Id = nextId++;
        Fecha = fecha;
        Precio = precio;
        SalaId = salaId;
    }
}
