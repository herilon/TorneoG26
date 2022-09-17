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
            var municipios = _dataContext.Municipios
                .Include(m => m.Equipos)
                .ToList();
            return municipios;
        }

        public Municipio GetMunicipio(int idMunicipio)
        {
            var municipioEncontrado = _dataContext.Municipios.Find(idMunicipio);
            return municipioEncontrado;
        }

        public Municipio UpdateMunicipio(Municipio municipio)
        {
            var municipioEncontrado = _dataContext.Municipios.Find(municipio.Id);
            if (municipioEncontrado != null)
            {
                municipioEncontrado.Nombre = municipio.Nombre;
                _dataContext.SaveChanges();
            }
            return municipioEncontrado;
        }

        public Municipio DeleteMunicipio(int idMunicipio)
        {
            var municipioEncontrado = _dataContext.Municipios.Find(idMunicipio);
            if (municipioEncontrado != null)
            {
                _dataContext.Municipios.Remove(municipioEncontrado);
                _dataContext.SaveChanges();
            }
            return municipioEncontrado;
        }

    }
}