namespace API.Models
{
    public class UsuarioModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int estado { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string provincia { get; set; }
        public string direccion { get; set; }
        public DateTime fechanacimiento { get; set; }
    }
}
