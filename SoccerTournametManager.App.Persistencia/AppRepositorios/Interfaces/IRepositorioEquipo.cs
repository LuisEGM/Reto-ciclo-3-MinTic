using System.Collections.Generic;
using SoccerTournametManager.App.Dominio;

namespace SoccerTournametManager.App.Persistencia
{
    public interface IRepositorioEquipo
    {
        IEnumerable<Equipo> getAllEquipos();
        Equipo addEquipo(Equipo equipo);
        Equipo updateEquipo(int idEquipo, string nombre);

        Municipio addMunicipio(int idEquipo, int idMunicipio);

        DirectorTecnico addDT(int idEquipo, int idDT);
        void DeleteEquipo(int idEquipo);
        Equipo GetEquipo(int idEquipo);

        IEnumerable<Equipo> SearchEquipos(string nombre);
    }
}