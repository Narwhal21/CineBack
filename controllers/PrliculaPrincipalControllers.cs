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
            peliculas.Add(new PeliculaPrincipal("Robot Salvaje", 148, "Chris Sanders", "Peli-13", "https://youtu.be/VY9lcYA4RT4"));
            peliculas.Add(new PeliculaPrincipal("Red One", 136, "Jake Kasdan", "Peli-14", "https://youtu.be/IWDxw3aWymg"));
            peliculas.Add(new PeliculaPrincipal("Terrifier", 148, "Damien Leone", "Peli-15", "https://youtu.be/Lx48G7ehxIQ"));
            peliculas.Add(new PeliculaPrincipal("Señor de los anillos", 136, "Peter Jackson", "Peli-16", "https://youtu.be/HYp5w88tYrI"));
            peliculas.Add(new PeliculaPrincipal("Gladiator", 148, "Ridley Scott", "Peli-5", "https://youtu.be/-P4Vfj0Pu_o"));
            peliculas.Add(new PeliculaPrincipal("Nunca te sueltes", 136, "Alexandre Aja", "Peli-6", "https://youtu.be/example6"));
            peliculas.Add(new PeliculaPrincipal("Wicked", 148, "Jon M. Chu", "Peli-7", "https://youtu.be/example7"));
            peliculas.Add(new PeliculaPrincipal("Vaiana 2", 136, "Derrick Jr.", "Peli-8", "https://youtu.be/example8"));
            peliculas.Add(new PeliculaPrincipal("Guerrera Rohirrim", 148, "Kenji Kamiyama", "Peli-9", "https://youtu.be/example9"));
            peliculas.Add(new PeliculaPrincipal("El baño del diablo", 136, "Severin Fiala", "Peli-11", "https://youtu.be/example10"));
            peliculas.Add(new PeliculaPrincipal("Bitelchus", 148, "Tim Burton", "Peli-12", "https://youtu.be/example11"));
            peliculas.Add(new PeliculaPrincipal("El llanto", 136, "Pedro Martín-Calero", "01.jpg", "https://youtu.be/example12"));
        }
    }
}
