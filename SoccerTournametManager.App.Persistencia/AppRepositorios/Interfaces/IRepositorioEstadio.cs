using System.Collections.Generic;
using SoccerTournametManager.App.Dominio;

namespace SoccerTournametManager.App.Persistencia
{
    public interface IRepositorioEstadio
    {
        IEnumerable<Estadio> getAllEstadios();
        Estadio addEstadio(Estadio estadio);
        Estadio updateEstadio(int idEstadio, string nombre, string direccion);
        void DeleteEstadio(int idEstadio);
        Estadio GetEstadio(int idEstadio);
        Municipio asignarMunicipio(int idEstadio, int idMunicipio); 
    }
}