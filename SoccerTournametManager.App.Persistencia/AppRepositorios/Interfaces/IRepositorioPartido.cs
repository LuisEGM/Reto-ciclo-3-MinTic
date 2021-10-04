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
        Partido updatePartido(Partido partido);
        void DeletePartido(int idPartido);
        Partido GetPartido(int idPartido);
    }
}