using DAL;
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
            List<PedidosConNombreProveedor> listadoCompleto = new List<PedidosConNombreProveedor>();
            try
            {
                
                listadoCompleto = ManejadoraPedidosDAL.ObtenerPedidosConNombreProveedor();
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
            PedidosConDetallesProductos pedidoFinal = new PedidosConDetallesProductos();
            PedidosConNombreProveedor pedido = new PedidosConNombreProveedor();
            List<DetallesPedidosConNombreProducto> detallesPedidos = new List<DetallesPedidosConNombreProducto>();
            List<PedidosConNombreProveedor> listaPedidos = new List<PedidosConNombreProveedor>();
            try
            {
                listaPedidos = ManejadoraPedidosDAL.ObtenerPedidosConNombreProveedor();

                pedido = listaPedidos.Find(x => x.Id == id);

                detallesPedidos = ManejadoraPedidosDAL.ObtenerDetallesPedidoPorPedido(id);
                pedidoFinal = new PedidosConDetallesProductos(pedido, detallesPedidos);
                return Ok(pedidoFinal);
            }
            catch
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        // POST api/pedido
        /* [HttpPost]
         public IActionResult Post([FromBody] Pedidos pedido,List<DetallesPedidos> listaProductos)
         {
             if (pedido == null || listaProductos==null)
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
         }*/

        [HttpPost]
        public IActionResult Post([FromBody] PedidosConDetallesProductos pedido)
        {
            if (pedido.Pedido == null || pedido.ListaProductos == null)
            {
                return BadRequest("Datos de pedido no válidos.");
            }
            try
            {
                bool guardadoCorrectamente = true;

                PedidosConNombreProveedor ped = pedido.Pedido;
                List<DetallesPedidosConNombreProducto> listaP = pedido.ListaProductos;
                int idPedido = ManejadoraPedidosDAL.creaccionPedidoDAL(ped);

                List<DetallesPedidos> nuevaLista = new List<DetallesPedidos>();

                
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

                guardadoCorrectamente = ManejadoraPedidosDAL.creaccionListaProductosDelPedidoDAL(nuevaLista, idPedido);
                


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
                bool borradoCorrectamente;

                borradoCorrectamente = ManejadoraPedidosDAL.desactivarPedido(id);

                if (borradoCorrectamente)
                {
                    return Ok(borradoCorrectamente);
                }
                else
                {
                    return NotFound(borradoCorrectamente);
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
