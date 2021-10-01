using System.Collections.Generic;
using SoccerTournametManager.App.Dominio;
using System.Linq;

namespace SoccerTournametManager.App.Persistencia
{
    public class RepositorioMunicipio : IRepositorioMunicipio
    {

        /// <sumary>
        /// Referencia al contexto del municipio
        /// </sumary>
        private readonly AppContext _appContext = new AppContext();

        /// <sumary>
        /// Metodo constructor utiliza
        /// inyeccion de dependencias para indicar el contexto a utilizar
        /// </sumary>
        /// <param name="appContext"></param>
        // public RepositorioMunicipio(AppContext appContext)
        // {
        //     _appContext=appContext;
        // }

        Municipio IRepositorioMunicipio.addMunicipio(Municipio municipio)
        {
            var municipioAdicionado = _appContext.Municipios.Add(municipio);
            _appContext.SaveChanges();

            return municipioAdicionado.Entity;
        }

        void IRepositorioMunicipio.DeleteMunicipio(int idMunicipio)
        {
            var municipioEncontrado = _appContext.Municipios.FirstOrDefault(p => p.Id == idMunicipio);
            if (municipioEncontrado == null) return;
            _appContext.Municipios.Remove(municipioEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Municipio> IRepositorioMunicipio.getAllMunicipios()
        {
            return _appContext.Municipios;
        }

        Municipio IRepositorioMunicipio.GetMunicipio(int idMunicipio)
        {
            return _appContext.Municipios.FirstOrDefault(p => p.Id == idMunicipio);
        }

        Municipio IRepositorioMunicipio.updateMunicipio(Municipio municipio)
        {
            var municipioEncontrado = _appContext.Municipios.FirstOrDefault(p => p.Id == municipio.Id);
            if (municipioEncontrado != null)
            {
                municipioEncontrado.Nombre = municipio.Nombre;
                _appContext.SaveChanges();
            }
            return municipioEncontrado;
        }
    }
}