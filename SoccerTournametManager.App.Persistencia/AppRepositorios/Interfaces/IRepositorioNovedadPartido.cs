using System.Collections.Generic;
using SoccerTournametManager.App.Dominio;

namespace SoccerTournametManager.App.Persistencia
{
    public interface IRepositorioNovedadPartido
    {
        IEnumerable<NovedadPartido> getAllNovedadesDePartidos();
        IEnumerable<NovedadPartido> getAllNovedadesByPartido(int idPartido);
        NovedadPartido addNovedadDePartido(NovedadPartido novedadPartido);
        Jugador asignarJugador(int idNovedad, int idJugador);
        Partido asignarPartido(int idNovedad, int idPartido);
        NovedadPartido updateNovedadDePartido(NovedadPartido novedadPartido);
        void deleteNovedadDePartido(int idNovedadPartido);
        NovedadPartido getNovedadDePartido(int idNovedadPartido);
    }
}