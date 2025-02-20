using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.API
{
    [Route("api/proovedor")]
    [ApiController]
    public class ProovedorController : ControllerBase
    {
        // GET: api/proovedor
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<String> listadoCompleto = ClsListadoPersonaBL.ListaPersonasBL();
                if (listadoCompleto.Count == 0)
                {
                    return NotFound("No se encontraron proovedores.");
                }
                return Ok(listadoCompleto);
            }
            catch
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        // GET api/proovedor/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            String proovedor = null;
            try
            {
                //ClsPersona persona = ClsManejadoraPersonaBL.BuscaPersonaBL(id);
                if (proovedor == null)
                {
                    return NotFound($"No se encontró el proovedor con el id: {id}.");
                }
                return Ok(proovedor);
            }
            catch
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        // POST api/<ProovedorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProovedorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProovedorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
