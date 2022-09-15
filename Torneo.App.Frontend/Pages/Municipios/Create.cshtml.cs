using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Municipios
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioMunicipio _repoMunicipio;
        public Municipio municipio { get; set; }

        public CreateModel(IRepositorioMunicipio repoMunicipio)
        {
            _repoMunicipio = repoMunicipio;
        }

        public void OnGet()
        {
            municipio = new Municipio();
        }

        public IActionResult OnPost(Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                _repoMunicipio.AddMunicipio(municipio);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
