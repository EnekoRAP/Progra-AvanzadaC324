using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConexionController : ControllerBase
    {

        // Configurar el appsettings
        // Declarar variables
        private readonly IConfiguration _configuration;

        public ConexionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Probar la conexión
        [HttpGet]
        public ActionResult Conectar()
        {
            string connectionString = _configuration.GetConnectionString("Minombredeconexion");

            // Evitar que el sistema se caiga
            try
            {
                using (var conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();
                    return Ok("Conexión Exitosa. ");
                }
            }
            catch (Exception ex)
            {
                // Regresar
                return StatusCode(500, ex.Message);
            }

        }

    }
}
