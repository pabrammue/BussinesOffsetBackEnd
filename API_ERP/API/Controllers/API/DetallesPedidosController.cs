using ENT;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesPedidosController : ControllerBase
    {
        // GET: api/DetallesPedidos
        // Método para obtener todos los detalles de pedidos.
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult respuesta = null;  // Variable para almacenar la respuesta.
            try
            {
                // Simula la obtención de una lista de detalles de pedidos desde la capa DAL (acceso a datos).
                List<String> listadoCompleto = new List<string>(); // ClsManejadoraDetalesPedidosDAL.getListadoDetallesPedidosDAL();

                // Si la lista está vacía, retorna un 404 Not Found.
                if (listadoCompleto.Count == 0)
                {
                    respuesta = NotFound("No se encontraron Detalles del pedido.");
                }

                // Si hay datos, retorna un 200 OK con la lista.
                respuesta = Ok(listadoCompleto);
            }
            catch
            {
                // Si ocurre un error inesperado, retorna un 500 Internal Server Error.
                respuesta = StatusCode(500, "Error interno del servidor.");
            }

            // Retorna la respuesta generada.
            return respuesta;
        }

        // POST: api/DetallesPedidos
        // Método para crear un nuevo detalle de pedido.
        [HttpPost]
        public IActionResult Post([FromBody] DetallesPedidos detallePed)
        {
            IActionResult respuesta = null;  // Variable para almacenar la respuesta.

            // Valida si el cuerpo de la solicitud es nulo.
            if (detallePed == null)
            {
                respuesta = BadRequest("Datos de pedido no válidos.");
            }

            try
            {
                // Simula el guardado de un detalle de pedido en la capa de negocio/DAL.
                bool guardadoCorrectamente = true; // ClsManejadoraPersonaBL.CreaPersonaBL(persona);

                if (guardadoCorrectamente)
                {
                    // Si el guardado es exitoso, retorna un 201 Created con el objeto creado.
                    respuesta = Created("Detalle pedido creado correctamente", detallePed);
                }

                // Si no se guarda correctamente, retorna un 400 Bad Request.
                respuesta = BadRequest("No se pudo crear el detalle pedido.");
            }
            catch
            {
                // Si ocurre un error inesperado, retorna un 500 Internal Server Error.
                respuesta = StatusCode(500, "Error interno del servidor.");
            }

            // Retorna la respuesta generada.
            return respuesta;
        }
    }
}
