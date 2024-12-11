using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace CineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private static List<Sala> salas = new List<Sala>();

        [HttpGet]
        public ActionResult<IEnumerable<Sala>> GetSalas()
        {
            return Ok(salas);
        }

        [HttpGet("{id}")]
        public ActionResult<Sala> GetSala(int id)
        {
            var sala = salas.FirstOrDefault(s => s.Id == id);
            if (sala == null)
            {
                return NotFound();
            }
            return Ok(sala);
        }

        [HttpPost]
        public ActionResult<Sala> CreateSala(Sala sala)
        {
            salas.Add(sala);
            return CreatedAtAction(nameof(GetSala), new { id = sala.Id }, sala);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSala(int id, Sala updatedSala)
        {
            var sala = salas.FirstOrDefault(s => s.Id == id);
            if (sala == null)
            {
                return NotFound();
            }
            sala.Numero = updatedSala.Numero;
            sala.Capacidad = updatedSala.Capacidad;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSala(int id)
        {
            var sala = salas.FirstOrDefault(s => s.Id == id);
            if (sala == null)
            {
                return NotFound();
            }
            salas.Remove(sala);
            return NoContent();
        }

        public static void InicializarDatos()
        {
            salas.Add(new Sala(1, 100));
            salas.Add(new Sala(2, 100));
            salas.Add(new Sala(3, 100));
            salas.Add(new Sala(4, 100));
        }
    }
}
