
using Laboratorio_Autenticacion.Pages.Models;
using Microsoft.Win32;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Laboratorio_Autenticacion.Pages.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<bool> RegisterUserAsync(UserModel user)
        {
            // {
            // "name": "nombre_usuarios",
            // "password": "1234567890",
            // "email": "correo1@ejemplo.com"
            // }

            var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://paginas-web-cr.com/Api/apis/InsertarUsuarios.php", content);

            return response.IsSuccessStatusCode;

        }

        // Páginas a desarrollar:

        // Página de Registro de Usuario:
        // Formulario para ingresar el nombre, correo electrónico y contraseña.
        // Los datos deben enviarse a la API:
        // https://paginas-web-cr.com/Api/apis/InsertarUsuarios.php
        // Ejemplo de JSON:

        // {
        // "name": "nombre_usuario",
        // "password": "contraseña",
        // "email": "correo@ejemplo.com"
        // }

        // {
        // "name": "nombre_usuarios",
        // "password": "1234567890",
        // "email": "correo1@ejemplo.com"
        // }

        // Página de Reenvío de Contraseña:

        // Formulario para ingresar el correo electrónico del usuario que desea recuperar su contraseña.
        // Los datos deben enviarse a la API:
        // https://paginas-web-cr.com/Api/apis/SendPassword.php
        // Ejemplo de JSON:

        // {
        // "email": "correo@ejemplo.com"
        // }

        // Página de Autenticación:

        // Formulario para ingresar el correo electrónico y la contraseña.
        // Los datos deben enviarse a la API:
        // https://paginas-web-cr.com/Api/apis/AutenticarUsuario.php
        // Ejemplo de JSON:

        // {
        // "email": "correo@ejemplo.com",
        // "password": "contraseña_encriptada"
        // }
    }
}
