using System.Collections.Generic;
using SoccerTournametManager.App.Dominio;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SoccerTournametManager.App.Persistencia
{
    public class RepositorioPartido : IRepositorioPartido
    {

        /// <sumary>
        /// Referencia al contexto de los partidos
        /// </sumary>
        private readonly AppContext _appContext = new AppContext();

        Partido IRepositorioPartido.addPartido(Partido partido)
        {
            var partidoAdicionado = _appContext.Partidos.Add(partido);
            _appContext.SaveChanges();

            return partidoAdicionado.Entity;
        }

        void IRepositorioPartido.DeletePartido(int idPartido)
        {
            var partidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.Id == idPartido);
            if (partidoEncontrado == null) return;
            _appContext.Partidos.Remove(partidoEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Partido> IRepositorioPartido.getAllPartidos()
        {
            return _appContext.Partidos
            .Include(p => p.EquipoLocal)
            .Include(p => p.EquipoVisitante)
            .Include(p => p.Estadio)
            .Include(p => p.Arbitro);
        }
        IEnumerable<Partido> IRepositorioPartido.getAllPartidosByEstadio(int idEstadio)
         {
             return _appContext.Partidos.Include(p => p.Estadio).Where(p => p.Estadio.Id == idEstadio);
         }
        IEnumerable<Partido> IRepositorioPartido.getAllPartidosByArbitro(int idArbitro)
         {
             return _appContext.Partidos.Include(p => p.Arbitro).Where(p => p.Arbitro.Id == idArbitro);
         }
        Partido IRepositorioPartido.GetPartido(int idPartido)
        {
            var partidoEncontrado = _appContext.Partidos
            .Where(p => p.Id == idPartido)
            .Include(p => p.EquipoLocal)
            .Include(p => p.EquipoVisitante)
            .Include(p => p.Estadio)
            .Include(p => p.Arbitro)
            .SingleOrDefault();
            return partidoEncontrado;
        }

        Partido IRepositorioPartido.updatePartido(Partido partido)
        {
            var partidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.Id == partido.Id);
            if (partidoEncontrado != null)
            {
                partidoEncontrado.EquipoLocal = partido.EquipoLocal;
                partidoEncontrado.EquipoVisitante = partido.EquipoVisitante;
                partidoEncontrado.FechaHora = partido.FechaHora;
                partidoEncontrado.Estadio = partido.Estadio;
                partidoEncontrado.Arbitro = partido.Arbitro;
                _appContext.SaveChanges();
            }
            return partidoEncontrado;
        }
    }
}