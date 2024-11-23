using Laboratorio_Autenticacion.Pages.Models;
using Laboratorio_Autenticacion.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Laboratorio_Autenticacion.Pages.Usuarios
{
    public class RegistroModel : PageModel
    {
        private readonly ApiService _ppiService;

        public RegistroModel(ApiService ppiService)
        {
            _ppiService = ppiService;
        }

        // Las propiedades o los binds, estos ser�n mensaje de intercambio hacia el usuario
        [BindProperty]
        public UserModel User { get; set; }

        public string Mensaje { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var resultado = await _ppiService.RegisterUserAsync(User);

            // if ternario

            Mensaje = resultado ? "Se ingres� los datos " : "No se ingres� los datos ";

            return Page();
        }
    }
}
