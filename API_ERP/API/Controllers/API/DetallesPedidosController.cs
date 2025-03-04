using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesPedidosController : ControllerBase
    {
        // GET: api/<DetallesPedidosController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult respuesta = null;
            try
            {
                List<String> listadoCompleto = new List<string>(); // ClsManejadoraDetalesPedidosDAL.getListadoDetallesPedidosDAL();
                if (listadoCompleto.Count == 0)
                {
                    respuesta= NotFound("No se encontraron Detalles del pedido.");
                }
                respuesta = Ok(listadoCompleto);
            }
            catch
            {
                respuesta = StatusCode(500, "Error interno del servidor.");
            }
            return respuesta;
        }

        // POST api/<DetallesPedidosController>
        [HttpPost]
        public IActionResult Post([FromBody] DetallesPedidos detallePed)
        {
            IActionResult respuesta = null;
            if (detallePed == null)
            {
                respuesta= BadRequest("Datos de pedido no válidos.");
            }
            try
            {
                bool guardadoCorrectamente = true;//ClsManejadoraPersonaBL.CreaPersonaBL(persona);
                if (guardadoCorrectamente)
                {
                    respuesta= Created("Detalle pedido creado correctamente", detallePed);
                }
                respuesta= BadRequest("No se pudo crear el detalle pedido.");
            }
            catch
            {
                respuesta= StatusCode(500, "Error interno del servidor.");
            }
            return respuesta;
        }
    }
}
