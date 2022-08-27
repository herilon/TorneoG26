using Torneo.App.Dominio;
using Torneo.App.Persistencia;
namespace Torneo.App.Consola
{
    class Program
    {
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio();

        static void Main(string[] args)
        {
            AddMunicipio();
        }

        private static void AddMunicipio()
        {
            var municipio = new Municipio
            {
                Nombre = "Manizales",
            };
            _repoMunicipio.AddMunicipio(municipio);
        }
    }
}