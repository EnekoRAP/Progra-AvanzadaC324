using Laboratorio_Autenticacion.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ReenviarPasswordModel : PageModel
{
    private readonly ApiService _apiService;

    [BindProperty]
    public string Email { get; set; }

    public string Mensaje { get; set; }

    public ReenviarPasswordModel(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrEmpty(Email))
        {
            Mensaje = "Ingrese la dirección de su correo electrónico. ";
            return Page();
        }

        bool result = await _apiService.SendPasswordAsync(Email);

        if (result)
        {
            Mensaje = "Enlace de recuperación de contraseña, enviado correctamente. ";
        }
        else
        {
            Mensaje = "Error al enviar el enlace de recuperació. Inténtelo de nuevo";
        }

        return Page();
    }
}

