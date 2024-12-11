using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace CineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpinionController : ControllerBase
    { 
         private static List<Opinion> opiniones = new List<Opinion>();

        [HttpGet]
        public ActionResult<IEnumerable<Opinion>> GetOpiniones()
        {
            return Ok(opiniones);
        }

        [HttpGet("{id}")]
        public ActionResult<Opinion> GetOpinion(int id)
        {
            var opinion = opiniones.FirstOrDefault(h => h.Id == id);
            if (opinion == null)
            {
                return NotFound($"No se encontró ninguna opinion");
            }
            return Ok(opinion);
        }
         [HttpPost]
        public ActionResult<Opinion> CreateOpinion(Opinion opinion)
        {
            opiniones.Add(opinion);
            return CreatedAtAction(nameof(GetOpinion), new { id = opinion.Id }, opinion);
        }
     public static void InicializarDatos()
        {
            opiniones.Add(new Opinion("Alfonso Coro", "La pelicula trata sobre un ser maligno, mucha intriga","2 Estrellas" ));
            opiniones.Add(new Opinion("Juan", "Peper y sus amigos aprneden a hacer magia muy buena","2 Estrellas" ));
        }
    }
}


