using System.Collections.Generic;
using SoccerTournametManager.App.Dominio;
using System.Linq;
 using Microsoft.EntityFrameworkCore;
namespace SoccerTournametManager.App.Persistencia
{
    public class RepositorioEquipo : IRepositorioEquipo
    {

        /// <sumary>
        /// Referencia al contexto del equipo
        /// </sumary>
        private readonly AppContext _appContext = new AppContext();

        Equipo IRepositorioEquipo.addEquipo(Equipo equipo)
        {
            var equipoAdicionado = _appContext.Equipos.Add(equipo);
            _appContext.SaveChanges();

            return equipoAdicionado.Entity;
        }

        void IRepositorioEquipo.DeleteEquipo(int idEquipo)
        {
            var equipoEncontrado = _appContext.Equipos.FirstOrDefault(p => p.Id == idEquipo);
            if (equipoEncontrado == null) return;
            _appContext.Equipos.Remove(equipoEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Equipo> IRepositorioEquipo.getAllEquipos()
        {
            return _appContext.Equipos
            .Include(e => e.Municipio)
            .Include(e => e.DirectorTecnico);
        }

        Equipo IRepositorioEquipo.GetEquipo(int idEquipo)
        {
            var equipoEncontrado = _appContext.Equipos
            .Where(e => e.Id == idEquipo)
            .Include(e => e.Municipio)
            .Include(e => e.DirectorTecnico)
            .Include(e => e.DesempeñoEquipo)
            .SingleOrDefault();
            return equipoEncontrado;
        }

        Equipo IRepositorioEquipo.updateEquipo(Equipo equipo)
        {
            var equipoEncontrado = _appContext.Equipos.FirstOrDefault(p => p.Id == equipo.Id);
            if (equipoEncontrado != null)
            {
                equipoEncontrado.Nombre = equipo.Nombre;
                equipoEncontrado.Municipio = equipo.Municipio;
                equipoEncontrado.DirectorTecnico = equipo.DirectorTecnico;
                equipoEncontrado.DesempeñoEquipo = equipo.DesempeñoEquipo;
                _appContext.SaveChanges();
            }
            return equipoEncontrado;
        }
    }
}