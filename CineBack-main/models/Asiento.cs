public class Asiento
{
    private static int nextId = 1;

    public int Id { get; private set; }
    public int Numero { get; set; }
    public string Fila { get; set; } = string.Empty; // Valor predeterminado
    public string Estado { get; set; } = "Disponible"; // Valor predeterminado

    public Asiento()
    {
        Id = nextId++;
    }

    public Asiento(int numero, string fila, string estado)
    {
        Id = nextId++;
        Numero = numero;
        Fila = fila ?? throw new ArgumentNullException(nameof(fila));
        Estado = estado ?? throw new ArgumentNullException(nameof(estado));
    }
}
