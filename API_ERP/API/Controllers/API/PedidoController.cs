using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.API
{
    [Route("api/pedido")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        // GET: api/pedido
        [HttpGet]
        public IActionResult Get()
        {
            List<String> listadoCompleto = new List<String>();
            try
            {
                //List<String> listadoCompleto = "ClsListadoPersonaBL.ListaPersonasBL()"
                if (listadoCompleto.Count == 0)
                {
                    return NotFound("No se encontraron pedidos.");
                }
                return Ok(listadoCompleto);
            }
            catch
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        // GET api/pedido/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            String persona = null;
            try
            {
                //ClsPersona persona = ClsManejadoraPersonaBL.BuscaPersonaBL(id);
                if (persona == null)
                {
                    return NotFound($"No se encontró el pedido con el id: {id}.");
                }
                return Ok(persona);
            }
            catch
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        // POST api/pedido
        [HttpPost]
        public IActionResult Post([FromBody] Pedidos pedido)
        {
            if (pedido == null)
            {
                return BadRequest("Datos de pedido no válidos.");
            }
            try
            {
                bool guardadoCorrectamente = true;//ClsManejadoraPersonaBL.CreaPersonaBL(persona);
                if (guardadoCorrectamente)
                {
                    return Created("Pedido creado correctamente", pedido);
                }
                return BadRequest("No se pudo crear el pedido.");
            }
            catch
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        // PUT api/pedido/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pedidos pedido)
        {
            if (pedido == null)
            {
                return BadRequest("Datos de pedido no válidos.");
            }
            try
            {
                bool actualizado = true;//ClsManejadoraPersonaBL.EditaPersonaBL(persona);
                if (actualizado)
                {
                    return Accepted("Se ha modificado correctamente", pedido);
                }
                else
                {
                    return NotFound($"No se encontró el pedido con ID {pedido.IdPedidos} para actualizar.");
                }
            }
            catch
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        // DELETE api/pedido/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool seBorra = true;/*ClsManejadoraPersonaBL.BorraPersonaBL(id);*/
                if (!seBorra)
                {
                    return Accepted("Se ha borrado correctamente");
                }
                else
                {
                    return NotFound($"No se encontró el pedido con ID {id} para eliminar.");
                }
            }
            catch
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }
}
