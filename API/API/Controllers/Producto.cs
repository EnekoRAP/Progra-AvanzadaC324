using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Producto : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Saludos clase");
        }
        //GET, POST, PUT, DELETE CRUD

    }
}
