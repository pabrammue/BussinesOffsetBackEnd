using DAL;
using DTO;
using ENT;  
using Microsoft.AspNetCore.Mvc;  

namespace API.Controllers.API
{
    
    [Route("api/pedido")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        // GET: api/pedido
        // Obtiene todos los pedidos con el nombre del proveedor asociado.
        [HttpGet]
        public IActionResult Get()
        {
            List<PedidosConNombreProveedor> listadoCompleto = new List<PedidosConNombreProveedor>();
            try
            {
                // Obtiene la lista de pedidos desde la capa DAL.
                listadoCompleto = ManejadoraPedidosDAL.ObtenerPedidosConNombreProveedor();

                // Si la lista está vacía, retorna un 404 Not Found.
                if (listadoCompleto.Count == 0)
                {
                    return NotFound("No se encontraron pedidos.");
                }

                // Retorna un 200 OK con la lista de pedidos.
                return Ok(listadoCompleto);
            }
            catch
            {
                // Manejo de errores inesperados.
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        // GET api/pedido/5
        // Obtiene un pedido específico junto con sus detalles de productos.
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            PedidosConDetallesProductos pedidoFinal = new PedidosConDetallesProductos();
            PedidosConNombreProveedor pedido = new PedidosConNombreProveedor();
            List<DetallesPedidosConNombreProducto> detallesPedidos = new List<DetallesPedidosConNombreProducto>();
            List<PedidosConNombreProveedor> listaPedidos = new List<PedidosConNombreProveedor>();
            try
            {
                // Obtiene la lista de pedidos y busca el pedido con el ID solicitado.
                listaPedidos = ManejadoraPedidosDAL.ObtenerPedidosConNombreProveedor();
                pedido = listaPedidos.Find(x => x.Id == id);

                // Obtiene los detalles de productos asociados al pedido.
                detallesPedidos = ManejadoraPedidosDAL.ObtenerDetallesPedidoPorPedido(id);

                // Crea un objeto que combina el pedido y sus detalles.
                pedidoFinal = new PedidosConDetallesProductos(pedido, detallesPedidos);

                // Retorna el pedido con detalles.
                return Ok(pedidoFinal);
            }
            catch
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        // POST api/pedido
        // Crea un nuevo pedido con sus detalles de productos.
        [HttpPost]
        public IActionResult Post([FromBody] PedidosConDetallesProductos pedido)
        {
            // Valida si el pedido o la lista de productos son nulos.
            if (pedido.Pedido == null || pedido.ListaProductos == null)
            {
                return BadRequest("Datos de pedido no válidos.");
            }
            try
            {
                bool guardadoCorrectamente = true;  // Variable para verificar si se guarda correctamente.

                // Obtiene el pedido y la lista de productos desde el objeto recibido.
                PedidosConNombreProveedor ped = pedido.Pedido;
                List<DetallesPedidosConNombreProducto> listaP = pedido.ListaProductos;

                // Crea el pedido en la base de datos y obtiene su ID.
                int idPedido = ManejadoraPedidosDAL.creaccionPedidoDAL(ped);

                List<DetallesPedidos> nuevaLista = new List<DetallesPedidos>();

                // Mapea los productos recibidos a la estructura necesaria para guardarlos en la base de datos.
                foreach (var item in listaP)
                {
                    nuevaLista.Add(new DetallesPedidos
                    {
                        IdPedido = idPedido,
                        IdProducto = item.IdProducto,
                        PrecioTotal = item.PrecioTotal,
                        CuotaIva = item.CuotaIva,
                        PrecioBruto = item.PrecioBruto,
                        Cantidad = item.Cantidad
                    });
                }

                // Guarda la lista de productos asociados al pedido.
                guardadoCorrectamente = ManejadoraPedidosDAL.creaccionListaProductosDelPedidoDAL(nuevaLista, idPedido);

                if (guardadoCorrectamente)
                {
                    // Retorna un 201 Created si se guardó correctamente.
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
        // Actualiza un pedido existente.
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pedidos pedido)
        {
            // Valida si el cuerpo de la solicitud es nulo.
            if (pedido == null)
            {
                return BadRequest("Datos de pedido no válidos.");
            }
            try
            {
                bool actualizado = true;  // Simula la actualización.

                if (actualizado)
                {
                    // Retorna un 202 Accepted si se actualizó correctamente.
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
        // Elimina o desactiva un pedido por ID.    
        [HttpPatch("{id}")]
        public IActionResult Patch(int id)
        {
            try
            {
                // Intenta desactivar el pedido en la base de datos.
                bool canceladoCorrectamente = ManejadoraPedidosDAL.desactivarPedido(id);

                if (canceladoCorrectamente)
                {
                    // Retorna un 200 OK si se desactivó correctamente.
                    return Ok(canceladoCorrectamente);
                }
                else
                {
                    // Retorna un 404 Not Found si el pedido no existe.
                    return NotFound(canceladoCorrectamente);
                }
            }
            catch
            {
                // Retorna un 500 Internal Server Error si ocurre un error inesperado.
                return StatusCode(500);
            }
        }
    }
}
