using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Persistencia;
using Torneo.App.Dominio;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Torneo.App.Frontend.Pages.Equipos
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioMunicipio _repoMunicipio;
        public IEnumerable<Equipo> equipos { get; set; }
        public SelectList MunicipioOptions { get; set; }
        public int MunicipioSelected { get; set; }

        public IndexModel(IRepositorioEquipo repoEquipo, IRepositorioMunicipio repoMunicipio)
        {
            _repoEquipo = repoEquipo;
            _repoMunicipio = repoMunicipio;
        }
        public void OnGet()
        {
            equipos = _repoEquipo.GetAllEquipos();
            MunicipioOptions = new SelectList(_repoMunicipio.GetAllMunicipios(), "Id", "Nombre");
            MunicipioSelected = -1;
        }

        public void OnPostFiltro(int idMunicipio)
        {
            MunicipioOptions = new SelectList(_repoMunicipio.GetAllMunicipios(), "Id", "Nombre");
            if (idMunicipio != -1)
            {
                MunicipioSelected = idMunicipio;
                equipos = _repoEquipo.GetEquiposMunicipio(MunicipioSelected);
            }
            else
            {
                equipos = _repoEquipo.GetAllEquipos();
                MunicipioSelected = -1;
            }
        }
    }
}
