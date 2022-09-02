using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public interface IRepositorioMunicipio
    {
        public Municipio AddMunicipio(Municipio municipio);
        public IEnumerable<Municipio> GetAllMunicipios();
    }
}