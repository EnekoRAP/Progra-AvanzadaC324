using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConexionController : ControllerBase
    {
        // Variables declaradas
        private readonly IConfiguration _configuration;

        public ConexionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Métodos de conexión
        /// </summary>

        [HttpGet]
        public ActionResult Conectar()
        {
            string connectionString = _configuration.GetConnectionString("Minombredeconexion");//????

            try
            {
                using (var conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();
                    return Ok("Conexion Exitosa");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
