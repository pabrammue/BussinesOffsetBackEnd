using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.API
{
    [Route("api/producto")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        // GET: api/producto
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<String> listadoCompleto = new List<string>();//ClsListadoPersonaBL.ListaPersonasBL();
                if (listadoCompleto.Count == 0)
                {
                    return NotFound("No se encontraron productos.");
                }
                return Ok(listadoCompleto);
            }
            catch
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        // GET api/producto/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            String persona = null;
            try
            {
                //ClsPersona persona = ClsManejadoraPersonaBL.BuscaPersonaBL(id);
                if (persona == null)
                {
                    return NotFound($"No se encontró el producto con el id: {id}.");
                }
                return Ok(persona);
            }
            catch
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
