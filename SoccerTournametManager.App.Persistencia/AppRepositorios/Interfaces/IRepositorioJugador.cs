using System.Collections.Generic;
using SoccerTournametManager.App.Dominio;

namespace SoccerTournametManager.App.Persistencia
{
    public interface IRepositorioJugador
    {
        IEnumerable<Jugador> getAllJugadores();
        IEnumerable<Jugador> getAllJugadoresByEquipo(int idEquipo);
        Jugador addJugador(Jugador jugador);
        Jugador updateJugador(int idJugador, string nombre, string documento, string telefono, int numero, string posicion);
        void DeleteJugador(int idJugador);
        Jugador GetJugador(int idJugador);
        Equipo asignarEquipo(int idJugador, int idEquipo);
        IEnumerable<Jugador> SearchJugadores(string nombre);
    }
}