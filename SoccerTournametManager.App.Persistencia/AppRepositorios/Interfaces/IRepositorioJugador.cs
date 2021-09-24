using System.Collections.Generic;
using SoccerTournametManager.App.Dominio;

namespace SoccerTournametManager.App.Persistencia
{
    public interface IRepositorioJugador
    {
        IEnumerable<Jugador> getAllJugadores();
        Jugador addJugador(Jugador jugador);
        Jugador updateJugador(Jugador jugador);
        void DeleteJugador(int idJugador);
        Jugador GetJugador(int idJugador);
    }
}