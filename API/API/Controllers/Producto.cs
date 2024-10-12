using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult obtenerProductos()
        {
            return Ok(_productos);
        }

        [HttpGet("{id}")]
        public IActionResult obtenerProductos(int id)
        {
            if (id >= _productos.Count || id <= 0)
            {
                return NotFound("El ID no está en el sistema. ");
            }

            return Ok(_productos[id]);
        }
        // GET

        // GET, POST, PUT, DELETE CRUD
        [HttpPost]
        public IActionResult agregarProductos([FromBody] string _nuevoProducto)
        {
            _productos.Add(_nuevoProducto);
            return CreatedAtAction(nameof(obtenerProductos), new { id = _productos });
        }

    }
}
