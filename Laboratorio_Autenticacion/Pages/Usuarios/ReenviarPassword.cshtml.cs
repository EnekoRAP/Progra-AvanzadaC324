using Laboratorio_Autenticacion.Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class ReenviarPasswordModel : PageModel
{
    [BindProperty]
    public UserModel usuario { get; set; }
    public string mensaje { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var url = "https://paginas-web-cr.com/Api/apis/SendPassword.php";
        var carga = new { email = usuario.Email };
        var json = JsonSerializer.Serialize(carga);

        using var client = new HttpClient();
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var respuesta = await client.PostAsJsonAsync(url, content);

        mensaje = respuesta.IsSuccessStatusCode
            ? "Correo de recuperación enviado exitosamente."
            : "Hubo un problema al enviar el correo.";

        return Page();
    }
}

