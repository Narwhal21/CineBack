using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController : ControllerBase
    {
        private static List<Horario> horarios = new List<Horario>();

        [HttpGet]
        public ActionResult<IEnumerable<Horario>> GetHorarios()
        {
            return Ok(horarios);
        }

        [HttpGet("{id}")]
        public ActionResult<Horario> GetHorario(int id)
        {
            var horario = horarios.FirstOrDefault(h => h.Id == id);
            if (horario == null)
            {
                return NotFound();
            }
            return Ok(horario);
        }

        [HttpPost]
        public ActionResult<Horario> CreateHorario(Horario horario)
        {
            horarios.Add(horario);
            return CreatedAtAction(nameof(GetHorario), new { id = horario.Id }, horario);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHorario(int id, Horario updatedHorario)
        {
            var horario = horarios.FirstOrDefault(h => h.Id == id);
            if (horario == null)
            {
                return NotFound();
            }
            horario.HoraInicio = updatedHorario.HoraInicio;
            horario.HoraFin = updatedHorario.HoraFin;
            horario.Dia = updatedHorario.Dia;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHorario(int id)
        {
            var horario = horarios.FirstOrDefault(h => h.Id == id);
            if (horario == null)
            {
                return NotFound();
            }
            horarios.Remove(horario);
            return NoContent();
        }

        public static void InicializarDatos()
        {
            horarios.Add(new Horario("08:00", "10:00", 5));
            horarios.Add(new Horario("10:00", "12:00", 5));
            horarios.Add(new Horario("12:00", "14:00", 5));
            horarios.Add(new Horario("14:00", "16:00", 5));
            horarios.Add(new Horario("16:00", "18:00", 5));
            horarios.Add(new Horario("18:00", "20:00", 5));
        }
    }
}
