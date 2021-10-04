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

        NovedadPartido IRepositorioNovedadPartido.updateNovedadDePartido(NovedadPartido novedadPartido)
        {
            var novedadEncontrada = _appContext.NovedadesDePartidos.FirstOrDefault(n => n.Id == novedadPartido.Id);
            if (novedadEncontrada != null)
            {
                novedadEncontrada.JugadorInvolucrado = novedadPartido.JugadorInvolucrado;
                novedadEncontrada.Minuto = novedadPartido.Minuto;
                novedadEncontrada.Novedad = novedadPartido.Novedad;
                novedadEncontrada.Partido = novedadPartido.Partido;
                _appContext.SaveChanges();
            }
            return novedadEncontrada;
        }
    }
}