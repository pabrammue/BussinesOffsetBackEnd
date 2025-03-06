using DAL;
using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
       /* // GET: api/<CategoriaController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult respuesta = null;

            List<Categorias> listadoCompleto = ManejadoraCategoriasDAL.ListadoCategoriasPorProveedorDAL();

            try
            {
                if (listadoCompleto.Count == 0)
                {
                    return NotFound("No se encontraron Categorias.");
                }
                return Ok(listadoCompleto);
            }
            catch
            {
                return StatusCode(500, "Error interno del servidor.");
            }
       
        }*/
    }
}
