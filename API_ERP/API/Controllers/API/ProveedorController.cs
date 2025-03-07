using DAL;
using ENT;
using DTO;

using Microsoft.AspNetCore.Mvc;


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
                // Se obtiene la lista de proveedores desde la capa de acceso a datos (DAL)
                List<Proveedores> listadoProveedores = ManejadoraProveedoresDAL.ObtenerProveedores();
                // Se verifica si la lista está vacía
                if (listadoProveedores.Count == 0)
                {
                    // Retorna un código 404 (Not Found) con un mensaje indicando que no se encontraron proveedores
                    return NotFound("No se encontraron proovedores.");
                }
                // Retorna un código 200 (OK) con la lista de proveedores
                return Ok(listadoProveedores);
            }
            catch
            {
                // En caso de error, se retorna un código 500 (Internal Server Error) con un mensaje de error genérico
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        // GET api/proovedor/5/productos
        [HttpGet("{idProveedor}/productos")]
        public IActionResult GetProductos(int idProveedor)
        {
            // Se obtiene la lista de productos asociados a un proveedor específico desde la capa de acceso a datos (DAL)
            List<ProductosPorProveedorYCategorias> listadoProductos = ManejadoraProductosDAL.ObtenerProductosPorProveedor(idProveedor);
            try
            {
                // Se verifica si la lista de productos está vacía
                if (listadoProductos.Count == 0)
                {
                    // Retorna un código 404 (Not Found) con un mensaje indicando que no hay productos asociados al proveedor
                    return NotFound($"No se ha asociado productos al proveedor: {idProveedor}.");
                }
                // Retorna un código 200 (OK) con la lista de productos asociados al proveedor
                return Ok(listadoProductos);
            }
            catch
            {
                // En caso de error, se retorna un código 500 (Internal Server Error) con un mensaje de error genérico
                return StatusCode(500, "Error interno del servidor.");
            }
        }


        // GET api/proovedor/5/categorias
        [HttpGet("{id}/categorias")]
        public IActionResult GetCategorias(int id)
        {
            //Creamos listado de categorias por el id del proveedor
            List<Categorias> listadoCategorias = ManejadoraCategoriasDAL.ListadoCategoriasPorProveedorDAL(id);
            try
            {
                //ClsPersona persona = ClsManejadoraPersonaBL.BuscaPersonaBL(id);
                //Si la lista esta vacia
                if (listadoCategorias.Count==0)
                {
                    //Indicamos que no se ha podido encontrar productos de x proveedor
                    return NotFound($"No se ha asociado productos al proveedor: {id}.");
                }
                //Si hay, indicamos que se ha realizado correctamente la peticion y mostramos el listado de categorias
                return Ok(listadoCategorias);
            }
            catch
            {
                //Si hay algun error, lo indicamos y mostramos mensaje de error
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        // GET api/proovedor/5/categorias/2
        [HttpGet("{idProveedor}/categorias/{idCategoria}")]
        public IActionResult Get(int idProveedor,int idCategoria)
        {
            //Creamos lista de productos con id de proveedor y categorias
            List<ProductosPorProveedorYCategorias> listadoCategorias =
                ManejadoraProductosDAL.ObtenerProductosPorProveedorYCategoria(idProveedor, idCategoria);
            try
            {
                //ClsPersona persona = ClsManejadoraPersonaBL.BuscaPersonaBL(id);
                if (listadoCategorias.Count == 0)
                {
                    //Si la lista esta vacia, indicamos que no se ha encontrado el proveedor
                    return NotFound($"No se ha asociado productos al proveedor: {idProveedor}.");
                }
                //Si la lista esta bien, indicamos que se ha realizado correctamente y mandamos la lista de categorias
                return Ok(listadoCategorias);
            }
            catch
            {
                //Si hay algun error, lo indicamos en pantalla
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
