using System.Collections.Generic;
using SoccerTournametManager.App.Dominio;

namespace SoccerTournametManager.App.Persistencia
{
    public interface IRepositorioPartido
    {
        IEnumerable<Partido> getAllPartidos();
        IEnumerable<Partido> getAllPartidosByEstadio(int idEstadio);
        IEnumerable<Partido> getAllPartidosByArbitro(int idArbitro);
        Partido addPartido(Partido partido);
        Partido updatePartido(int idPartido, string fechaHora);
        void DeletePartido(int idPartido);
        Partido GetPartido(int idPartido);
        Equipo addEquipo(string tipoEquipo, int idPartido, int idEquipo);
        Estadio addEstadio(int idPartido, int idEstadio);
        Arbitro addArbitro(int idPartido, int idArbitro);
    }
}