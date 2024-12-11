using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace CineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private static List<Factura> facturas = new List<Factura>();

        [HttpGet]
        public ActionResult<IEnumerable<Factura>> GetFacturas()
        {
            return Ok(facturas);
        }

        [HttpGet("{numeroPedido}")]
        public ActionResult<Factura> GetFactura(int numeroPedido)
        {
            var factura = facturas.FirstOrDefault(f => f.NumeroPedido == numeroPedido);
            if (factura == null)
            {
                return NotFound($"No se encontró ninguna factura con el número de pedido {numeroPedido}.");
            }
            return Ok(factura);
        }

        [HttpPost]
        public ActionResult<Factura> CreateFactura([FromBody] Factura factura)
        {
            // Log de los datos recibidos
            Console.WriteLine($"Datos recibidos: Nombre={factura.Nombre}, Correo={factura.Correo}, Precio={factura.Precio}, Fecha={factura.Fecha}, Asiento={factura.Asiento}");

            // Validaciones adicionales
            if (string.IsNullOrEmpty(factura.Nombre) || string.IsNullOrEmpty(factura.Correo))
            {
                return BadRequest("El nombre y el correo son obligatorios.");
            }

            if (factura.Precio <= 0)
            {
                return BadRequest("El precio debe ser mayor a 0.");
            }

            // Asigna un número de pedido único
            factura.NumeroPedido = Factura.NextNumeroPedido++;
            facturas.Add(factura);

            return CreatedAtAction(nameof(GetFactura), new { numeroPedido = factura.NumeroPedido }, factura);
        }

        [HttpPut("{numeroPedido}")]
        public IActionResult UpdateFactura(int numeroPedido, Factura updatedFactura)
        {
            var factura = facturas.FirstOrDefault(f => f.NumeroPedido == numeroPedido);
            if (factura == null)
            {
                return NotFound($"No se encontró ninguna factura con el número de pedido {numeroPedido}.");
            }

            // Actualiza los campos
            factura.Nombre = updatedFactura.Nombre;
            factura.Correo = updatedFactura.Correo;
            factura.Telefono = updatedFactura.Telefono;
            factura.Fecha = updatedFactura.Fecha;
            factura.Precio = updatedFactura.Precio;
            factura.Asiento = updatedFactura.Asiento;

            return NoContent();
        }

        [HttpDelete("{numeroPedido}")]
        public IActionResult DeleteFactura(int numeroPedido)
        {
            var factura = facturas.FirstOrDefault(f => f.NumeroPedido == numeroPedido);
            if (factura == null)
            {
                return NotFound($"No se encontró ninguna factura con el número de pedido {numeroPedido}.");
            }

            facturas.Remove(factura);
            return NoContent();
        }

        // Método para inicializar datos
        public static void InicializarDatos()
        {
            facturas.Add(new Factura("Juan", "juan.perez@example.com", "123456789", 100.50m, "2024-12-01", "B2"));
            facturas.Add(new Factura("Ana", "ana.lopez@example.com", "987654321", 150.75m, "2024-12-02", "B4"));
            facturas.Add(new Factura("Luis", "luis.martinez@example.com", "456789123", 200.00m, "2024-12-03", "B5"));
        }
    }
}
