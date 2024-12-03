using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace CineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaPrincipalController : ControllerBase
    {
        private static List<PeliculaPrincipal> peliculas = new List<PeliculaPrincipal>();

        [HttpGet]
        public ActionResult<IEnumerable<PeliculaPrincipal>> GetPeliculas()
        {
            return Ok(peliculas);
        }

        [HttpGet("{id}")]
        public ActionResult<PeliculaPrincipal> GetPelicula(int id)
        {
            var pelicula = peliculas.FirstOrDefault(p => p.Id == id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return Ok(pelicula);
        }

        [HttpPost]
        public ActionResult<PeliculaPrincipal> CreatePelicula(PeliculaPrincipal pelicula)
        {
            peliculas.Add(pelicula);
            return CreatedAtAction(nameof(GetPelicula), new { id = pelicula.Id }, pelicula);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePelicula(int id, PeliculaPrincipal updatedPelicula)
        {
            var pelicula = peliculas.FirstOrDefault(p => p.Id == id);
            if (pelicula == null)
            {
                return NotFound();
            }
            pelicula.Titulo = updatedPelicula.Titulo;
            pelicula.Duracion = updatedPelicula.Duracion;
            pelicula.Director = updatedPelicula.Director;
            pelicula.ImagenUrl = updatedPelicula.ImagenUrl;
            pelicula.VideoUrl = updatedPelicula.VideoUrl;
            pelicula.Sinopsis = updatedPelicula.Sinopsis;
            pelicula.Actores = updatedPelicula.Actores;
            pelicula.FechaEstreno = updatedPelicula.FechaEstreno;
            pelicula.Genero = updatedPelicula.Genero;
            pelicula.Clasificacion = updatedPelicula.Clasificacion;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePelicula(int id)
        {
            var pelicula = peliculas.FirstOrDefault(p => p.Id == id);
            if (pelicula == null)
            {
                return NotFound();
            }
            peliculas.Remove(pelicula);
            return NoContent();
        }

        // Método para inicializar datos
        public static void InicializarDatos()
        {
            peliculas.Add(new PeliculaPrincipal("Robot Salvaje", 148, "Chris Sanders", "Peli-13", "https://youtu.be/VY9lcYA4RT4",
                "Un robot de última generación desarrolla una inesperada conexión con un grupo de humanos y se ve forzado a protegerlos de una amenaza que se avecina.", "Chris Pratt, Zoe Saldana", "2023-06-15", "Acción, Ciencia Ficción", "PG-13"));
            peliculas.Add(new PeliculaPrincipal("Red One", 136, "Jake Kasdan", "Peli-14", "https://youtu.be/IWDxw3aWymg",
                "Un emocionante viaje lleno de acción que involucra a un equipo especializado en la misión de salvar al mundo de un inminente desastre.", "Dwayne Johnson, Chris Evans", "2023-12-01", "Acción, Aventura", "PG-13"));
            peliculas.Add(new PeliculaPrincipal("Terrifier", 148, "Damien Leone", "Peli-15", "https://youtu.be/Lx48G7ehxIQ",
                "Art the Clown regresa para aterrorizar a una pequeña ciudad durante la noche de Halloween. Terror y locura en su máxima expresión.", "David Howard Thornton, Jenna Kanell", "2022-10-31", "Terror", "Terror"));
            peliculas.Add(new PeliculaPrincipal("Señor de los anillos", 136, "Peter Jackson", "Peli-16", "https://youtu.be/HYp5w88tYrI",
                "Una épica aventura donde un joven hobbit debe destruir un poderoso anillo que podría significar la salvación o la perdición del mundo.", "Elijah Wood, Ian McKellen", "2001-12-19", "Fantasía, Aventura", "PG-13"));
            peliculas.Add(new PeliculaPrincipal("Gladiator", 148, "Ridley Scott", "Peli-5", "https://youtu.be/-P4Vfj0Pu_o",
                "Un general romano traicionado lucha como gladiador para vengar la muerte de su familia y restaurar su honor.", "Russell Crowe, Joaquin Phoenix", "2000-05-05", "Acción, Drama", "Terror"));
            peliculas.Add(new PeliculaPrincipal("Nunca te sueltes", 136, "Alexandre Aja", "Peli-6", "https://youtu.be/example6",
                "Una pareja de alpinistas se enfrenta a desafíos extremos al quedar atrapados en la cima de una montaña remota.", "Emma Stone, Ryan Gosling", "2023-02-10", "Drama, Aventura", "PG-13"));
            peliculas.Add(new PeliculaPrincipal("Wicked", 148, "Jon M. Chu", "Peli-7", "https://youtu.be/example7",
                "Una historia no contada de las brujas de Oz, explorando sus orígenes y cómo se convirtieron en quienes conocemos.", "Cynthia Erivo, Ariana Grande", "2024-11-27", "Fantasía, Musical", "PG"));
            peliculas.Add(new PeliculaPrincipal("Vaiana 2", 136, "Derrick Jr.", "Peli-8", "https://youtu.be/example8",
                "Vaiana regresa para una nueva aventura a través del océano, enfrentándose a criaturas mágicas y desafíos inesperados.", "Auli'i Cravalho, Dwayne Johnson", "2024-07-10", "Animación, Aventura", "PG"));
            peliculas.Add(new PeliculaPrincipal("Guerrera Rohirrim", 148, "Kenji Kamiyama", "Peli-9", "https://youtu.be/example9",
                "La historia épica de Helm Hammerhand y la creación del Abismo de Helm, un lugar legendario en la Tierra Media.", "Miranda Otto, Brian Cox", "2023-11-20", "Animación, Fantasía", "PG-13"));
            peliculas.Add(new PeliculaPrincipal("El baño del diablo", 136, "Severin Fiala", "Peli-11", "https://youtu.be/example10",
                "Un misterioso baño público parece esconder oscuros secretos que cambiarán la vida de sus visitantes para siempre.", "Riley Keough, Jaeden Martell", "2023-08-15", "Terror, Suspenso", "Terror"));
            peliculas.Add(new PeliculaPrincipal("Bitelchus", 148, "Tim Burton", "Peli-12", "https://youtu.be/example11",
                "Un fantasma excéntrico es contratado para ahuyentar a los vivos, pero las cosas se salen de control en esta comedia de terror.", "Michael Keaton, Winona Ryder", "1988-03-30", "Comedia, Terror", "PG"));
            peliculas.Add(new PeliculaPrincipal("El llanto", 136, "Pedro Martín-Calero", "01.jpg", "https://youtu.be/example12",
                "Un joven debe enfrentar sus peores miedos mientras intenta entender una antigua maldición que amenaza a su familia y a su pueblo.", "Javier Bardem, Ana de Armas", "2023-09-01", "Terror, Drama", "Terror"));
        }
    }
}
