using System.Collections.Generic;
using SoccerTournametManager.App.Dominio;

namespace SoccerTournametManager.App.Persistencia
{
    public interface IRepositorioDT
    {
        IEnumerable<DirectorTecnico> getAllDTs();
        DirectorTecnico addDirectorTecnico(DirectorTecnico directorTecnico);
        DirectorTecnico updateDirectorTecnico(DirectorTecnico directorTecnico);
        void DeleteDirectorTecnico(int idDirectorTecnico);
        DirectorTecnico GetDirectorTecnico(int idDirectorTecnico);
    }
}