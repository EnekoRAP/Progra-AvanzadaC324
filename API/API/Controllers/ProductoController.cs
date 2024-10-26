using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        // Variables
        private static List<string> _productos = new List<string>
        {
            "TV","Itachi","Venom","laptop","monitor"
        };


        [HttpGet]
        public IActionResult ObtenerProductos()
        {
            return Ok(_productos);
        }


        [HttpGet("{id}")]
        public IActionResult ObtenerProductos(int id)
        {

            if (id >= _productos.Count || id < 0)
            {
                return NotFound("El id no esta en el sistema.");
            }

            return Ok(_productos[id]);
        }
        
        /// <summary>
        /// Métodos CRUD
        /// </summary>

        // POST
        [HttpPost]
        public IActionResult AgregarProducto([FromBody] string _nuevoProducto)
        {

            if (string.IsNullOrWhiteSpace(_nuevoProducto) ||
                 string.IsNullOrEmpty(_nuevoProducto))
            {
                return BadRequest("El nombre no es valido.");
            }

            _productos.Add(_nuevoProducto);
            return CreatedAtAction(
                nameof(ObtenerProductos),
                new { id = _productos.Count - 1 }
            );
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult BorrarProductos(int id)
        {

            if (id >= _productos.Count || id < 0)
            {
                return NotFound("El id no esta en el sistema.");
            }
            _productos.RemoveAt(id);

            return NoContent();
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult ActualizarProducto(int id, [FromBody] string _nuevoProducto)
        {

            if (id >= _productos.Count || id < 0)
            {
                return NotFound("El id no esta en el sistema.");
            }

            if (string.IsNullOrWhiteSpace(_nuevoProducto) ||
                string.IsNullOrEmpty(_nuevoProducto))
            {
                return BadRequest("El nombre no es valido.");
            }

            // Actualizar
            _productos[id] = _nuevoProducto;


            return Ok($"Producto modificado, id: {id} , {_productos[id]} ");
        }
    }
}
