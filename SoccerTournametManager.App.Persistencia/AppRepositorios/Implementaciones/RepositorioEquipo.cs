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

        Equipo IRepositorioEquipo.updateEquipo(int idEquipo, string nombre)
        {
            var equipoEncontrado = _appContext.Equipos.FirstOrDefault(p => p.Id == idEquipo);
            if (equipoEncontrado != null)
            {
                equipoEncontrado.Nombre = nombre;
                //equipoEncontrado.Municipio = equipo.Municipio;
                //equipoEncontrado.DirectorTecnico = equipo.DirectorTecnico;
                // equipoEncontrado.DesempeñoEquipo = idDesempeñoEquipo;
                _appContext.SaveChanges();
            }
            return equipoEncontrado;
        }

        Municipio IRepositorioEquipo.addMunicipio(int idEquipo, int idMunicipio)
        {
            var equipoEncontrado = _appContext.Equipos.Find(idEquipo);
            if (equipoEncontrado != null)
            {
                var municipioEncontrado = _appContext.Municipios.Find(idMunicipio);
                if (municipioEncontrado != null)
                {
                    equipoEncontrado.Municipio = municipioEncontrado;
                    _appContext.SaveChanges();
                }
                return municipioEncontrado;
            }
            return null;
        }

        DirectorTecnico IRepositorioEquipo.addDT(int idEquipo, int idDT)
        {
            var equipoEncontrado = _appContext.Equipos.Find(idEquipo);
            if (equipoEncontrado != null)
            {
                var dtEncontrado = _appContext.DirectoresTecnicos.Find(idDT);
                if (dtEncontrado != null)
                {
                    equipoEncontrado.DirectorTecnico = dtEncontrado;
                    _appContext.SaveChanges();
                }
                return dtEncontrado;
            }
            return null;
        }

        IEnumerable<Equipo> IRepositorioEquipo.SearchEquipos(string nombre)
        {
            return _appContext.Equipos.Where(e => e.Nombre.Contains(nombre));
        }

    }
}