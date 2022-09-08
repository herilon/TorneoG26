using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioMunicipio : IRepositorioMunicipio
    {
        private readonly DataContext _dataContext = new DataContext();

        public Municipio AddMunicipio(Municipio municipio)
        {
            var municipioInsertado = _dataContext.Municipios.Add(municipio);
            _dataContext.SaveChanges();
            return municipioInsertado.Entity;
        }

        public IEnumerable<Municipio> GetAllMunicipios()
        {
            return _dataContext.Municipios;
        }

        public Municipio GetMunicipio(int idMunicipio)
        {
            var municipioEncontrado = _dataContext.Municipios.Find(idMunicipio);
            return municipioEncontrado;
        }
    }
}