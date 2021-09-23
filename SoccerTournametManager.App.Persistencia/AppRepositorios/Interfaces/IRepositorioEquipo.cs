using System.Collections.Generic;
using SoccerTournametManager.App.Dominio;

namespace SoccerTournametManager.App.Persistencia
{
    public interface IRepositorioEquipo
    {
        IEnumerable<Equipo> getAllEquipos();
        Equipo addEquipo(Equipo equipo);
        Equipo updateEquipo(Equipo equipo);
        void DeleteEquipo(int idEquipo);
        Equipo GetEquipo(int idEquipo);
    }
}