 using System.Collections.Generic;
 using SoccerTournametManager.App.Dominio;
 using System.Linq;
 using Microsoft.EntityFrameworkCore;

namespace SoccerTournametManager.App.Persistencia
{
    public class RepositorioNovedadPartido : IRepositorioNovedadPartido
    {
        
        /// <sumary>
        /// Referencia al contexto de los partidos
        /// </sumary>
        private readonly AppContext _appContext = new AppContext();

        NovedadPartido IRepositorioNovedadPartido.addNovedadDePartido(NovedadPartido novedadPartido)
        {
            var novedadAdicionada = _appContext.NovedadesDePartidos.Add(novedadPartido);
            _appContext.SaveChanges();

            return novedadAdicionada.Entity;
        }

        void IRepositorioNovedadPartido.deleteNovedadDePartido(int idNovedadPartido)
        {
            var novedadEncontrada = _appContext.NovedadesDePartidos.FirstOrDefault(n => n.Id == idNovedadPartido);
            if (novedadEncontrada == null) return;
            _appContext.NovedadesDePartidos.Remove(novedadEncontrada);
            _appContext.SaveChanges();
        }

        IEnumerable<NovedadPartido> IRepositorioNovedadPartido.getAllNovedadesByPartido(int idPartido)
        {
             return _appContext.NovedadesDePartidos
             .Include(n => n.JugadorInvolucrado)
             .Include(n => n.Partido)
             .Where(n => n.Partido.Id == idPartido);
            
        }

        IEnumerable<NovedadPartido> IRepositorioNovedadPartido.getAllNovedadesDePartidos()
        {
            return _appContext.NovedadesDePartidos
            .Include("Partido.EquipoLocal")
            .Include("Partido.EquipoVisitante")
            .Include(n => n.JugadorInvolucrado);
            
        }

        NovedadPartido IRepositorioNovedadPartido.getNovedadDePartido(int idNovedadPartido)
        {
            var novedadEncontrada = _appContext.NovedadesDePartidos
            .Where(n => n.Id == idNovedadPartido)
            .Include("Partido.EquipoLocal")
            .Include("Partido.EquipoVisitante")
            .Include(n => n.JugadorInvolucrado)
            .SingleOrDefault();
            return novedadEncontrada;
        }

        NovedadPartido IRepositorioNovedadPartido.updateNovedadDePartido(NovedadPartido novedad)
        {
            
            var novedadEncontrada = _appContext.NovedadesDePartidos.FirstOrDefault(n => n.Id == novedad.Id);
            if (novedadEncontrada != null)
            {
                novedadEncontrada.Minuto = novedad.Minuto;
                novedadEncontrada.Novedad = novedad.Novedad;
                // novedadEncontrada.JugadorInvolucrado = novedad.JugadorInvolucrado;
                // novedadEncontrada.Partido = novedad.Partido;
                _appContext.SaveChanges();
            }
            return novedadEncontrada;
        }

        Jugador IRepositorioNovedadPartido.asignarJugador(int idNovedad, int idJugador)
        {
            var novedadEncontrada = _appContext.NovedadesDePartidos.Find(idNovedad);
            if (novedadEncontrada != null)
            {
                var jugadorEncontrado = _appContext.Jugadores.Find(idJugador);
                if (jugadorEncontrado != null)
                {
                    novedadEncontrada.JugadorInvolucrado = jugadorEncontrado;
                    _appContext.SaveChanges();
                }
                return jugadorEncontrado;
            }
            return null;
        }
        Partido IRepositorioNovedadPartido.asignarPartido(int idNovedad, int idPartido)
        {
            var novedadEncontrada = _appContext.NovedadesDePartidos.Find(idNovedad);
            if (novedadEncontrada != null)
            {
                var partidoEncontrado = _appContext.Partidos.Find(idPartido);
                if (partidoEncontrado != null)
                {
                    novedadEncontrada.Partido = partidoEncontrado;
                    _appContext.SaveChanges();
                }
                return partidoEncontrado;
            }
            return null;
        }

    }
}