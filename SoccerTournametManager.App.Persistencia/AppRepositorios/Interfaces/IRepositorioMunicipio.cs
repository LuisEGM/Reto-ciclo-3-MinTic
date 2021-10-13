using System.Collections.Generic;
using SoccerTournametManager.App.Dominio;

namespace SoccerTournametManager.App.Persistencia
{
    public interface IRepositorioMunicipio
    {
        IEnumerable<Municipio> getAllMunicipios();
        Municipio addMunicipio(Municipio municipio);
        Municipio updateMunicipio(Municipio municipio);
        void DeleteMunicipio(int idMunicipio);
        Municipio GetMunicipio(int idMunicipio);
        IEnumerable<Municipio> SearchMunicipios(string nombre);
    }
}