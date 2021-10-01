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
        private readonly AppContext _appContext = new AppContext();


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

        IEnumerable<Arbitro> IRepositorioArbitro.getAllArbitros()
        {
            return _appContext.Arbitros;
        }

        Arbitro IRepositorioArbitro.GetArbitro(int idArbitro)
        {
            return _appContext.Arbitros.FirstOrDefault(p => p.Id == idArbitro);
        }

        Arbitro IRepositorioArbitro.updateArbitro(Arbitro arbitro)
        {
            var arbitroEncontrado = _appContext.Arbitros.FirstOrDefault(p => p.Id == arbitro.Id);
            if (arbitroEncontrado != null)
            {
                arbitroEncontrado.Nombre = arbitro.Nombre;
                arbitroEncontrado.Documento = arbitro.Documento;
                arbitroEncontrado.Telefono = arbitro.Telefono;
                arbitroEncontrado.Colegio = arbitro.Colegio;
                _appContext.SaveChanges();
            }
            return arbitroEncontrado;
        }
    }
}