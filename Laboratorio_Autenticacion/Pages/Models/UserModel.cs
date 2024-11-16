namespace Laboratorio_Autenticacion.Pages.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        // Ejemplo de JSON
        // {
        // "name": "nombre_usuario",
        // "password": contraseña,
        // "email": "correo@ejemplo.com"
        // }
    }
}
