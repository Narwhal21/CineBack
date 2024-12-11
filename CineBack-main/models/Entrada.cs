public class Entrada
{
    public static int nextId = 1;
    public int Id { get; private set; }
    public string Fecha { get; set; }
    public double Precio { get; set; }
    public string Tipo { get; set; } // Nueva propiedad

    public Entrada(string fecha, double precio, string tipo)
    {
        Id = nextId++;
        Fecha = fecha;
        Precio = precio;
        Tipo = tipo; // Inicializar la nueva propiedad
    }
}