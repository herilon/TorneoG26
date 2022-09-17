using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Torneo.App.Frontend.Pages.Equipos
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioMunicipio _repoMunicipio;
        private readonly IRepositorioDT _repoDT;

        public Equipo equipo { get; set; }
        public SelectList MunicipioOptions { get; set; }
        public SelectList DTOptions { get; set; }
        public int MunicipioSelected { get; set; }
        public int DTSelected { get; set; }

        public EditModel(IRepositorioEquipo repoEquipo, IRepositorioMunicipio repoMunicipio, IRepositorioDT repoDT)
        {
            _repoEquipo = repoEquipo;
            _repoMunicipio = repoMunicipio;
            _repoDT = repoDT;
        }

        public IActionResult OnGet(int id)
        {
            equipo = _repoEquipo.GetEquipo(id);
            MunicipioOptions = new SelectList(_repoMunicipio.GetAllMunicipios(), "Id", "Nombre");
            MunicipioSelected = equipo.Municipio.Id;
            DTOptions = new SelectList(_repoDT.GetAllDTs(), "Id", "Nombre");
            DTSelected = equipo.DirectorTecnico.Id;
            if (equipo == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(Equipo equipo, int idMunicipio, int idDT)
        {
            _repoEquipo.UpdateEquipo(equipo, idMunicipio, idDT);
            return RedirectToPage("Index");
        }
    }
}
