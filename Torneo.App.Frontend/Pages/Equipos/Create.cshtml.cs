using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Equipos
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioMunicipio _repoMunicipio;
        private readonly IRepositorioDT _repoDT;
        
        public Equipo equipo {get; set;}
        public IEnumerable<Municipio> municipios { get; set; }
        public IEnumerable<DirectorTecnico> dts { get; set; }

        public CreateModel(IRepositorioEquipo repoEquipo, IRepositorioMunicipio
        repoMunicipio, IRepositorioDT repoDT)
        {
            _repoEquipo = repoEquipo;
            _repoMunicipio = repoMunicipio;
            _repoDT = repoDT;
        }

        public void OnGet()
        {
            equipo = new Equipo();
            municipios = _repoMunicipio.GetAllMunicipios();
            dts = _repoDT.GetAllDTs();
        }

        public IActionResult OnPost(Equipo equipo, int idMunicipio, int idDT)
        {
            _repoEquipo.AddEquipo(equipo, idMunicipio, idDT);
            return RedirectToPage("Index");
        }
    }
}
