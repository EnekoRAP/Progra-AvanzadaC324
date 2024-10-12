using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Producto : ControllerBase
    {
        // Variables
        private static List<string> _productos = new List<string>
        {
            "TV", "Itachi", "Venom", "Laptop", "Monitor"
        };

        /// <summary>
        /// Métodos CRUD - GET, POST, PUT, DELETE
        /// </summary>
        /// <returns></returns>

        // GET
        [HttpGet]
        public IActionResult obtenerProductos()
        {
            return Ok(_productos);
        }

        // GET by id
        [HttpGet("{id}")]
        public IActionResult obtenerProductos(int id)
        {
            if (id >= _productos.Count || id <= 0)
            {
                return NotFound("El id no está en el sistema. ");
            }

            return Ok(_productos[id]);
        }

        // POST
        [HttpPost]
        public IActionResult agregarProductos([FromBody] string _nuevoProducto)
        {
            if (string.IsNullOrWhiteSpace(_nuevoProducto) || 
                string.IsNullOrEmpty(_nuevoProducto))
            {
                return BadRequest("El nombre no es válido. ");
            }

            _productos.Add(_nuevoProducto);
            return CreatedAtAction(
                nameof(obtenerProductos),
                new { id = _productos.Count - 1 }
            );
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult borrarProductos(int id)
        {
            return NotFound("El id no está en el sistema. ");
            _productos.RemoveAt(id);

            return NoContent();
        }

        // PUT


    }
}
