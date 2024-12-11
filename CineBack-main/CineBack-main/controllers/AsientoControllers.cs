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
    // Letras de las filas de A a I
    var filas = new Dictionary<string, string>
    {
        { "A", "Disponible" },
        { "B", "Disponible" },
        { "C", "Disponible" },
        { "D", "Disponible" },
        { "E", "VIP" },
        { "F", "VIP" },
        { "G", "Disponible" },
        { "H", "Disponible" },
        { "I", "Disponible" }
    };

    foreach (var fila in filas)
    {
        for (int numero = 1; numero <= 10; numero++)
        {
            asientos.Add(new Asiento(numero, fila.Key, fila.Value));
        }
    }
}
}
}

