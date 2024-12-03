using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsientoController : ControllerBase
    {
        private static List<Asiento> asientos = new List<Asiento>();

        // Constructor estático para inicializar datos
        static AsientoController()
        {
            InicializarDatos();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Asiento>> GetAsientos()
        {
            return Ok(asientos);
        }

        [HttpGet("{id}")]
        public ActionResult<Asiento> GetAsiento(int id)
        {
            var asiento = asientos.FirstOrDefault(a => a.Id == id);
            if (asiento == null)
            {
                return NotFound(new { Message = "Asiento no encontrado." });
            }
            return Ok(asiento);
        }

        [HttpPost]
        public ActionResult<Asiento> CreateAsiento([FromBody] Asiento asiento)
        {
            asiento = new Asiento(asiento.Numero, asiento.Fila, asiento.Estado);
            asientos.Add(asiento);
            return CreatedAtAction(nameof(GetAsiento), new { id = asiento.Id }, asiento);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAsiento(int id, [FromBody] Asiento updatedAsiento)
        {
            var asiento = asientos.FirstOrDefault(a => a.Id == id);
            if (asiento == null)
            {
                return NotFound(new { Message = "Asiento no encontrado." });
            }

            asiento.Numero = updatedAsiento.Numero;
            asiento.Fila = updatedAsiento.Fila;
            asiento.Estado = updatedAsiento.Estado;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAsiento(int id)
        {
            var asiento = asientos.FirstOrDefault(a => a.Id == id);
            if (asiento == null)
            {
                return NotFound(new { Message = "Asiento no encontrado." });
            }

            asientos.Remove(asiento);
            return NoContent();
        }

        [HttpPost("seleccionados")]
        public IActionResult SeleccionarAsientos([FromBody] List<Asiento> seleccionados)
        {
            if (seleccionados == null || !seleccionados.Any())
            {
                return BadRequest(new { Message = "La lista de asientos seleccionados está vacía." });
            }

            foreach (var seleccionado in seleccionados)
            {
                var asiento = asientos.FirstOrDefault(a =>
                    a.Numero == seleccionado.Numero && a.Fila == seleccionado.Fila);

                if (asiento != null && asiento.Estado == "Disponible")
                {
                    asiento.Estado = "Seleccionado";
                }
            }

            return Ok(new { Message = "Asientos seleccionados actualizados exitosamente." });
        }

       private static void InicializarDatos()
{
    asientos.Add(new Asiento(1, "A", "Disponible"));
    asientos.Add(new Asiento(2, "A", "Disponible"));
    asientos.Add(new Asiento(3, "A", "Disponible"));
    asientos.Add(new Asiento(4, "A", "Disponible"));
    asientos.Add(new Asiento(5, "A", "Disponible"));
    asientos.Add(new Asiento(6, "A", "Disponible"));
    asientos.Add(new Asiento(7, "A", "Disponible"));
    asientos.Add(new Asiento(8, "A", "Disponible"));
    asientos.Add(new Asiento(9, "A", "Disponible"));
    asientos.Add(new Asiento(10, "A", "Disponible"));
    asientos.Add(new Asiento(1, "B", "Disponible"));
    asientos.Add(new Asiento(2, "B", "Disponible"));
    asientos.Add(new Asiento(3, "B", "Disponible"));
    asientos.Add(new Asiento(4, "B", "Disponible"));
    asientos.Add(new Asiento(5, "B", "Disponible"));
    asientos.Add(new Asiento(6, "B", "Disponible"));
    asientos.Add(new Asiento(7, "B", "Disponible"));
    asientos.Add(new Asiento(8, "B", "Disponible"));
    asientos.Add(new Asiento(9, "B", "Disponible"));
    asientos.Add(new Asiento(10, "B", "Disponible"));
    asientos.Add(new Asiento(1, "C", "Disponible"));
    asientos.Add(new Asiento(2, "C", "Disponible"));
    asientos.Add(new Asiento(3, "C", "Disponible"));
    asientos.Add(new Asiento(4, "C", "Disponible"));
    asientos.Add(new Asiento(5, "C", "Disponible"));
    asientos.Add(new Asiento(6, "C", "Disponible"));
    asientos.Add(new Asiento(7, "C", "Disponible"));
    asientos.Add(new Asiento(8, "C", "Disponible"));
    asientos.Add(new Asiento(9, "C", "Disponible"));
    asientos.Add(new Asiento(10, "C", "Disponible"));
    asientos.Add(new Asiento(1, "D", "Disponible"));
    asientos.Add(new Asiento(2, "D", "Disponible"));
    asientos.Add(new Asiento(3, "D", "Disponible"));
    asientos.Add(new Asiento(4, "D", "Disponible"));
    asientos.Add(new Asiento(5, "D", "Disponible"));
    asientos.Add(new Asiento(6, "D", "Disponible"));
    asientos.Add(new Asiento(7, "D", "Disponible"));
    asientos.Add(new Asiento(8, "D", "Disponible"));
    asientos.Add(new Asiento(9, "D", "Disponible"));
    asientos.Add(new Asiento(10, "D", "Disponible"));
    asientos.Add(new Asiento(1, "E", "VIP"));
    asientos.Add(new Asiento(2, "E", "VIP"));
    asientos.Add(new Asiento(3, "E", "VIP"));
    asientos.Add(new Asiento(4, "E", "VIP"));
    asientos.Add(new Asiento(5, "E", "VIP"));
    asientos.Add(new Asiento(6, "E", "VIP"));
    asientos.Add(new Asiento(7, "E", "VIP"));
    asientos.Add(new Asiento(8, "E", "VIP"));
    asientos.Add(new Asiento(9, "E", "VIP"));
    asientos.Add(new Asiento(10, "E", "VIP"));
    asientos.Add(new Asiento(1, "F", "VIP"));
    asientos.Add(new Asiento(2, "F", "VIP"));
    asientos.Add(new Asiento(3, "F", "VIP"));
    asientos.Add(new Asiento(4, "F", "VIP"));
    asientos.Add(new Asiento(5, "F", "VIP"));
    asientos.Add(new Asiento(6, "F", "VIP"));
    asientos.Add(new Asiento(7, "F", "VIP"));
    asientos.Add(new Asiento(8, "F", "VIP"));
    asientos.Add(new Asiento(9, "F", "VIP"));
    asientos.Add(new Asiento(10, "F", "VIP"));
    asientos.Add(new Asiento(1, "G", "Disponible"));
    asientos.Add(new Asiento(2, "G", "Disponible"));
    asientos.Add(new Asiento(3, "G", "Disponible"));
    asientos.Add(new Asiento(4, "G", "Disponible"));
    asientos.Add(new Asiento(5, "G", "Disponible"));
    asientos.Add(new Asiento(6, "G", "Disponible"));
    asientos.Add(new Asiento(7, "G", "Disponible"));
    asientos.Add(new Asiento(8, "G", "Disponible"));
    asientos.Add(new Asiento(9, "G", "Disponible"));
    asientos.Add(new Asiento(10, "G", "Disponible"));
    asientos.Add(new Asiento(1, "H", "Disponible"));
    asientos.Add(new Asiento(2, "H", "Disponible"));
    asientos.Add(new Asiento(3, "H", "Disponible"));
    asientos.Add(new Asiento(4, "H", "Disponible"));
    asientos.Add(new Asiento(5, "H", "Disponible"));
    asientos.Add(new Asiento(6, "H", "Disponible"));
    asientos.Add(new Asiento(7, "H", "Disponible"));
    asientos.Add(new Asiento(8, "H", "Disponible"));
    asientos.Add(new Asiento(9, "H", "Disponible"));
    asientos.Add(new Asiento(10, "H", "Disponible"));
    asientos.Add(new Asiento(1, "I", "Disponible"));
    asientos.Add(new Asiento(2, "I", "Disponible"));
    asientos.Add(new Asiento(3, "I", "Disponible"));
    asientos.Add(new Asiento(4, "I", "Disponible"));
    asientos.Add(new Asiento(5, "I", "Disponible"));
    asientos.Add(new Asiento(6, "I", "Disponible"));
    asientos.Add(new Asiento(7, "I", "Disponible"));
    asientos.Add(new Asiento(8, "I", "Disponible"));
    asientos.Add(new Asiento(9, "I", "Disponible"));
    asientos.Add(new Asiento(10, "I", "Disponible"));
}
}
}

