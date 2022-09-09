using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public interface IRepositorioEquipo
    {
        public Equipo AddEquipo(Equipo equipo, int idMunicipio, int idDT);
        public IEnumerable<Equipo> GetAllEquipos();
        public Equipo GetEquipo(int idEquipo);
    }
}