using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Municipios
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioMunicipio _repoMunicipio;
        public Municipio municipio { get; set; }

        public EditModel(IRepositorioMunicipio repoMunicipio)
        {
            _repoMunicipio = repoMunicipio;
        }

        public IActionResult OnGet(int id)
        {
            municipio = _repoMunicipio.GetMunicipio(id);
            if (municipio == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(Municipio municipio)
        {
            _repoMunicipio.UpdateMunicipio(municipio);
            return RedirectToPage("Index");
        }
    }

}
