namespace Models
{
    public class Factura
    {
        public static int NextNumeroPedido = 1;
        public int NumeroPedido { get; private set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Fecha { get; set; }
        public decimal Precio { get; set; }

        // Método para asignar el número de pedido
        public void AsignarNumeroPedido(int numero)
        {
            NumeroPedido = numero;
        }

        // Constructor sin parámetros requerido por el deserializador
        public Factura() { }

        // Constructor principal con validaciones
        public Factura(string nombre, string correo, string telefono, decimal precio, string fecha)
        {
            ValidarDatos(nombre, correo, precio);

            NumeroPedido = NextNumeroPedido++;
            Nombre = nombre;
            Correo = correo;
            Telefono = telefono;
            Fecha = fecha;
            Precio = precio;
        }

        // Método de validación
        private void ValidarDatos(string nombre, string correo, decimal precio)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(correo))
            {
                throw new ArgumentException("El nombre y el correo no pueden estar vacíos.");
            }

            if (precio <= 0)
            {
                throw new ArgumentException("El precio debe ser mayor a 0.");
            }
        }
    }
}
