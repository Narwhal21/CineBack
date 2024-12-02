namespace Models
{
    public class PeliculaPrincipal
    {
        public static int nextId = 1;
        public int Id { get; private set; }
        public string Titulo { get; set; }
        public int Duracion { get; set; } // En minutos
        public string Director { get; set; }
        public string ImagenUrl { get; set; } // URL de la imagen
        public string VideoUrl { get; set; }  // Nueva propiedad para el video

        public PeliculaPrincipal(string titulo, int duracion, string director, string imagenUrl, string videoUrl)
        {
            Id = nextId++;
            Titulo = titulo;
            Duracion = duracion;
            Director = director;
            ImagenUrl = imagenUrl;
            VideoUrl = videoUrl;

            if (string.IsNullOrEmpty(titulo) || string.IsNullOrEmpty(director) || string.IsNullOrEmpty(imagenUrl) || string.IsNullOrEmpty(videoUrl))
            {
                throw new ArgumentException("El título, director, imagen y video URL no pueden estar vacíos");
            }

            if (duracion <= 0)
            {
                throw new ArgumentException("La duración debe ser mayor a 0");
            }
        }

        public void MostrarDetalles()
        {
            Console.WriteLine($"Película: {Titulo}, Duración: {Duracion} minutos, Director: {Director}, Imagen: {ImagenUrl}, Video: {VideoUrl}");
        }
    }
}
