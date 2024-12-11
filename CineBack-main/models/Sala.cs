public class Sala
{
    public static int nextId = 1;
    public int Id { get; private set; }
    public int Numero { get; set; }
    public int Capacidad { get; set; }

    public Sala(int numero, int capacidad)
    {
        Id = nextId++;
        Numero = numero;
        Capacidad = capacidad;
    }
}
