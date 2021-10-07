using System.Collections.Generic;
using SoccerTournametManager.App.Dominio;
using System.Linq;
using System;
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

        Partido IRepositorioPartido.updatePartido(int idPartido, string fechaHora)
        {
            var partidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.Id == idPartido);
            if (partidoEncontrado != null)
            {
                Console.Write(fechaHora);
                if (fechaHora == null)
                {
                    partidoEncontrado.FechaHora = DateTime.Today;
                }
                else
                {
                    partidoEncontrado.FechaHora = Convert.ToDateTime(fechaHora);
                    // partidoEncontrado.FechaHora = DateTime.ParseExact(fechaHora, "'\"'yyyy-MM-dd'T'HH:mm:ss.fff'Z\"'", null);
                
                }
                // partidoEncontrado.EquipoLocal = partido.EquipoLocal;
                // partidoEncontrado.EquipoVisitante = partido.EquipoVisitante;
                // partidoEncontrado.Estadio = partido.Estadio;
                // partidoEncontrado.Arbitro = partido.Arbitro;
                _appContext.SaveChanges();
            }
            return partidoEncontrado;
        }

        Equipo IRepositorioPartido.addEquipo(string tipoEquipo, int idPartido, int idEquipo)
        {
            var partidoEncontrado = _appContext.Partidos.Find(idPartido);
            if (partidoEncontrado != null)
            {
                var equipoEncontrado = _appContext.Equipos.Find(idEquipo);
                if (equipoEncontrado != null)
                {
                    if (tipoEquipo == "visitante")
                    {
                        partidoEncontrado.EquipoVisitante = equipoEncontrado;
                    }
                    else
                    {
                        partidoEncontrado.EquipoLocal = equipoEncontrado;
                    }
                    _appContext.SaveChanges();
                }
                return equipoEncontrado;
            }
            return null;
        }

        Estadio IRepositorioPartido.addEstadio(int idPartido, int idEstadio)
        {
            var partidoEncontrado = _appContext.Partidos.Find(idPartido);
            if (partidoEncontrado != null)
            {
                var estadioEncontrado = _appContext.Estadios.Find(idEstadio);
                if (estadioEncontrado != null)
                {
                    partidoEncontrado.Estadio = estadioEncontrado;
                    _appContext.SaveChanges();
                }
                return estadioEncontrado;
            }
            return null;
        }
        Arbitro IRepositorioPartido.addArbitro(int idPartido, int idArbitro)
        {
            var partidoEncontrado = _appContext.Partidos.Find(idPartido);
            if (partidoEncontrado != null)
            {
                var arbitroEncontrado = _appContext.Arbitros.Find(idArbitro);
                if (arbitroEncontrado != null)
                {
                    partidoEncontrado.Arbitro = arbitroEncontrado;
                    _appContext.SaveChanges();
                }
                return arbitroEncontrado;
            }
            return null;
        }
    }
}