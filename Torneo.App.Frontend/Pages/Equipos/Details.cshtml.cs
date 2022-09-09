using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Equipos
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        public Equipo equipo { get; set; }

        public DetailsModel(IRepositorioEquipo repoEquipo)
        {
            _repoEquipo = repoEquipo;
        }

        public IActionResult OnGet(int id)
        {
            equipo = _repoEquipo.GetEquipo(id);
            if (equipo == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
    }
}
