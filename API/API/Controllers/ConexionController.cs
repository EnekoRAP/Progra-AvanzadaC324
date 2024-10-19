using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConexionController : ControllerBase
    {
        //Ocupo la config, el appsettings???
        //Como se declaran variables???????????
        private readonly IConfiguration _configuration;

        public ConexionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Que nos falta para probar la conexion????
        //????
        [HttpGet]
        public ActionResult Conectar()
        {
            string connectionString = _configuration.GetConnectionString("Minombredeconexion");//????

            //???que uso para que ne caiga el sistema???
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
                //como regreso
                return StatusCode(500, ex.Message);
            }

        }
    }
}
