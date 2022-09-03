using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Persistencia;
using Torneo.App.Dominio;

namespace Torneo.App.Frontend.Pages.DTs
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioDT _repoDT;
        public IEnumerable<DirectorTecnico> dts { get; set; }

        public IndexModel(IRepositorioDT repoDT)
        {
            _repoDT = repoDT;
        }

        public void OnGet()
        {
            dts = _repoDT.GetAllDTs();
        }
    }
}
