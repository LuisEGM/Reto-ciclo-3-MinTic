using System.Collections.Generic;
using SoccerTournametManager.App.Dominio;

namespace SoccerTournametManager.App.Persistencia
{
    public interface IRepositorioEstadio
    {
        IEnumerable<Estadio> getAllEstadios();
        Estadio addEstadio(Estadio estadio);
        Estadio updateEstadio(Estadio estadio);
        void DeleteEstadio(int idEstadio);
        Estadio GetEstadio(int idEstadio);  
    }
}