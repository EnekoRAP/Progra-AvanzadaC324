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
            return Ok(id);
        }
        // GET, POST, PUT, DELETE CRUD

    }
}
