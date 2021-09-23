using System.Collections.Generic;
using SoccerTournametManager.App.Dominio;
using System.Linq;

namespace SoccerTournametManager.App.Persistencia
{
    public class RepositorioArbitro : IRepositorioArbitro
    {

        /// <sumary>
        /// Referencia al contexto del Arbitro
        /// </sumary>
        private readonly AppContext _appContext;

        /// <sumary>
        /// Metodo constructor utiliza
        /// inyeccion de dependencias para indicar el contexto a utilizar
        /// </sumary>
        /// <param name="appContext"></param>
        public RepositorioArbitro(AppContext appContext)
        {
            _appContext=appContext;
        }

        Arbitro IRepositorioArbitro.addArbitro(Arbitro arbitro)
        {
            var arbitroAdicionado = _appContext.Arbitros.Add(arbitro);
            _appContext.SaveChanges();

            return arbitroAdicionado.Entity;
        }

        void IRepositorioArbitro.DeleteArbitro(int idArbitro)
        {
            var arbitroEncontrado = _appContext.Arbitros.FirstOrDefault(p => p.Id == idArbitro);
            if (arbitroEncontrado == null) return;
            _appContext.Arbitros.Remove(arbitroEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Arbitro> IRepositorioArbitro.getAllDTs()
        {
            return _appContext.Arbitros;
        }

        Arbitros IRepositorioArbitro.GetArbitro(int idArbitro)
        {
            return _appContext.Arbitros.FirstOrDefault(p => p.Id == idArbitro);
        }

        Arbitros IRepositorioArbitro.updateArbitro(Arbitro arbitro)
        {
            var arbitroEncontrado = _appContext.Arbitros.FirstOrDefault(p => p.Id == arbitro.Id);
            if (arbitroEncontrado != null)
            {
                arbitroEncontrado.Nombre = Arbitro.Nombre;
                arbitroEncontrado.Documento = Arbitro.Documento;
                arbitroEncontrado.Telefono = Arbitro.Telefono;
                arbitroEncontrado.Colegio = Arbitro.Colegio;
                _appContext.SaveChanges();
            }
            return arbitroEncontrado;
        }
    }
}