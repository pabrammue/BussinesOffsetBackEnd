using DAL;
using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.API
{
    [Route("api/proveedor")]
    [ApiController]
    public class ProveedorController : ControllerBase
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

        // GET api/proovedor/5/categorias
        [HttpGet("{id}/categorias")]
        public IActionResult Get(int id)
        {
            List<Categorias> listadoCategorias = ManejadoraCategoriasDAL.ListadoCategoriasPorProveedorDAL(id);
            try
            {
                //ClsPersona persona = ClsManejadoraPersonaBL.BuscaPersonaBL(id);
                if (listadoCategorias.Count==0)
                {
                    return NotFound($"No se ha asociado productos al proveedor: {id}.");
                }
                return Ok(listadoCategorias);
            }
            catch
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        // GET api/proovedor/5/categorias/2
        [HttpGet("{idProveedor}/categorias/{idCategoria}")]
        public IActionResult Get(int idProveedor,int idCategoria)
        {
            List<ProductosPorProveedorYCategorias> listadoCategorias =
                ManejadoraProductosDAL.ObtenerProductosPorProveedorYCategoria(idProveedor, idCategoria);
            try
            {
                //ClsPersona persona = ClsManejadoraPersonaBL.BuscaPersonaBL(id);
                if (listadoCategorias.Count == 0)
                {
                    return NotFound($"No se ha asociado productos al proveedor: {idProveedor}.");
                }
                return Ok(listadoCategorias);
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
