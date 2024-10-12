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
        public IActionResult Index()
        {
            return Ok(_productos);
        }
        // GET, POST, PUT, DELETE CRUD

    }
}
