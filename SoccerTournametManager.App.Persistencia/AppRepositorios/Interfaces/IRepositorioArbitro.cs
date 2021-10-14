using System.Collections.Generic;
using SoccerTournametManager.App.Dominio;

namespace SoccerTournametManager.App.Persistencia
{
    public interface IRepositorioArbitro
    {
        IEnumerable<Arbitro> getAllArbitros();
        Arbitro addArbitro(Arbitro arbitro);
        Arbitro updateArbitro(Arbitro arbitro);
        void DeleteArbitro(int idArbitro);
        Arbitro GetArbitro(int idArbitro); 
        IEnumerable<Arbitro> SearchArbitros(string nombre);
    }
}