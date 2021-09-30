using System.Collections.Generic;
using SoccerTournametManager.App.Dominio;
using System.Linq;

namespace SoccerTournametManager.App.Persistencia
{
    public class RepositorioEquipo : IRepositorioEquipo
    {

        /// <sumary>
        /// Referencia al contexto del equipo
        /// </sumary>
        private readonly AppContext _appContext;

        /// <sumary>
        /// Metodo constructor utiliza
        /// inyeccion de dependencias para indicar el contexto a utilizar
        /// </sumary>
        /// <param name="appContext"></param>
        public RepositorioEquipo(AppContext appContext)
        {
            _appContext=appContext;
        }

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
            return _appContext.Equipos;
        }

        Equipo IRepositorioEquipo.GetEquipo(int idEquipo)
        {
            return _appContext.Equipos.FirstOrDefault(p => p.Id == idEquipo);
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