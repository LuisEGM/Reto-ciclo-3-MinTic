using System.Collections.Generic;
using SoccerTournametManager.App.Dominio;
using System.Linq;

namespace SoccerTournametManager.App.Persistencia
{
    public class RepositorioDT : IRepositorioDT
    {

        /// <sumary>
        /// Referencia al contexto del director tecnico
        /// </sumary>
        private readonly AppContext _appContext;

        /// <sumary>
        /// Metodo constructor utiliza
        /// inyeccion de dependencias para indicar el contexto a utilizar
        /// </sumary>
        /// <param name="appContext"></param>
        public RepositorioDT(AppContext appContext)
        {
            _appContext=appContext;
        }

        DirectorTecnico IRepositorioDT.addDirectorTecnico(DirectorTecnico directorTecnico)
        {
            var dtAdicionado = _appContext.DirectoresTecnicos.Add(directorTecnico);
            _appContext.SaveChanges();

            return dtAdicionado.Entity;
        }

        void IRepositorioDT.DeleteDirectorTecnico(int idDirectorTecnico)
        {
            var dtEncontrado = _appContext.DirectoresTecnicos.FirstOrDefault(p => p.Id == idDirectorTecnico);
            if (dtEncontrado == null) return;
            _appContext.DirectoresTecnicos.Remove(dtEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<DirectorTecnico> IRepositorioDT.getAllDTs()
        {
            return _appContext.DirectoresTecnicos;
        }

        DirectorTecnico IRepositorioDT.GetDirectorTecnico(int idDirectorTecnico)
        {
            return _appContext.DirectoresTecnicos.FirstOrDefault(p => p.Id == idDirectorTecnico);
        }

        DirectorTecnico IRepositorioDT.updateDirectorTecnico(DirectorTecnico directorTecnico)
        {
            var dtEncontrado = _appContext.DirectoresTecnicos.FirstOrDefault(p => p.Id == directorTecnico.Id);
            if (dtEncontrado != null)
            {
                dtEncontrado.Nombre = directorTecnico.Nombre;
                dtEncontrado.Telefono = directorTecnico.Telefono;
                dtEncontrado.Documento = directorTecnico.Documento;
                _appContext.SaveChanges();
            }
            return dtEncontrado;
        }
    }
}