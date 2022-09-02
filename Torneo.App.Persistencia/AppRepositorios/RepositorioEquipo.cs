using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioEquipo : IRepositorioEquipo
    {
        private readonly DataContext _dataContext = new DataContext();

        public Equipo AddEquipo(Equipo equipo, int idMunicipio, int idDT)
        {
            var municipioEncontrado = _dataContext.Municipios.Find(idMunicipio);
            var DTEncontrado = _dataContext.DirectoresTecnicos.Find(idDT);
            equipo.Municipio = municipioEncontrado;
            equipo.DirectorTecnico = DTEncontrado;
            var equipoInsertado = _dataContext.Equipos.Add(equipo);
            _dataContext.SaveChanges();
            return equipoInsertado.Entity;
        }

        public IEnumerable<Equipo> GetAllEquipos()
        {
            var equipos = _dataContext.Equipos
                .Include(e => e.Municipio)
                .Include(e => e.DirectorTecnico)
                .ToList();
            return equipos;
        }
    }
}