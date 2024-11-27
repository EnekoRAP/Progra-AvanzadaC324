using Laboratorio_Autenticacion.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class AutenticacionModel : PageModel
{
    private readonly ApiService _apiService;

    [BindProperty]
    public string Email { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public string Mensaje { get; set; }

    public AutenticacionModel(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
        {
            Mensaje = "Ingrese su correo electrónico y contraseña. ";
            return Page();
        }

        bool isAuthenticated = await _apiService.AuthenticateUserAsync(Email, Password);

        if (isAuthenticated)
        {
            Mensaje = "Ha iniciado sesión correctamente. ";
            return RedirectToPage("/Index");
        } 
        else
        {
            Mensaje = "Fallo de inicio de sesión, correo o contraseña incorrecta. ";
            return Page();
        }
    }
}
