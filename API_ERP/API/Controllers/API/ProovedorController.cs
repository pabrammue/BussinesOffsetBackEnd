using DAL;
using ENT;
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
                List<Proveedores> listadoProveedores = ManejadoraProveedoresDAL.ObtenerProveedores();

                if (listadoProveedores.Count == 0)
                {
                    return NotFound("No se encontraron proovedores.");
                }
                return Ok(listadoProveedores);
            }
            catch
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        // GET api/proovedor/5
        [HttpGet("{id}/productos")]
        public IActionResult Get(int id)
        {
            List<ProductosPorProveedorYCategorias> listadoProductos = ManejadoraProductosDAL.ObtenerProductosPorProveedor(id);
            try
            {
                //ClsPersona persona = ClsManejadoraPersonaBL.BuscaPersonaBL(id);
                if (listadoProductos.Count==0)
                {
                    return NotFound($"No se ha asociado productos al proveedor: {id}.");
                }
                return Ok(listadoProductos);
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
