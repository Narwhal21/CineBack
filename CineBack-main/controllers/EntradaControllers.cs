using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace CineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaController : ControllerBase
    {
        private static List<Entrada> entradas = new List<Entrada>();

        public EntradaController()
        {
            // Inicializar datos si la lista está vacía
            if (!entradas.Any())
            {
                InicializarDatos();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Entrada>> GetEntradas()
        {
            return Ok(entradas);
        }

        [HttpGet("{id}")]
        public ActionResult<Entrada> GetEntrada(int id)
        {
            var entrada = entradas.FirstOrDefault(e => e.Id == id);
            if (entrada == null)
            {
                return NotFound();
            }
            return Ok(entrada);
        }

        [HttpPost]
        public ActionResult<Entrada> CreateEntrada(Entrada entrada)
        {
            entradas.Add(entrada);
            return CreatedAtAction(nameof(GetEntrada), new { id = entrada.Id }, entrada);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEntrada(int id, Entrada updatedEntrada)
        {
            var entrada = entradas.FirstOrDefault(e => e.Id == id);
            if (entrada == null)
            {
                return NotFound();
            }
            entrada.Fecha = updatedEntrada.Fecha;
            entrada.Precio = updatedEntrada.Precio;
            entrada.Tipo = updatedEntrada.Tipo;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEntrada(int id)
        {
            var entrada = entradas.FirstOrDefault(e => e.Id == id);
            if (entrada == null)
            {
                return NotFound();
            }
            entradas.Remove(entrada);
            return NoContent();
        }

        public static void InicializarDatos()
        {
            entradas.Clear(); // Limpiar entradas existentes
            entradas.Add(new Entrada("2024-12-02", 8.90, "Entrada Normal")); // Incluye Tipo
            entradas.Add(new Entrada("2024-12-02", 15.90, "Entrada VIP")); // Incluye Tipo
        }
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllOrigins");
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}