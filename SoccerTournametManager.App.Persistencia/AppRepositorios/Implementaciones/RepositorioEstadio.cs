 using System.Collections.Generic;
 using SoccerTournametManager.App.Dominio;
 using System.Linq;
 using Microsoft.EntityFrameworkCore;

 namespace SoccerTournametManager.App.Persistencia
 {
     public class RepositorioEstadio : IRepositorioEstadio
     {

         /// <sumary>
         /// Referencia al contexto de los estadios
         /// </sumary>
         private readonly AppContext _appContext = new AppContext();

         Estadio IRepositorioEstadio.addEstadio(Estadio estadio)
         {
             var estadioAdicionado = _appContext.Estadios.Add(estadio);
             _appContext.SaveChanges();

             return estadioAdicionado.Entity;
         }

         void IRepositorioEstadio.DeleteEstadio(int idEstadio)
         {
             var estadioEncontrado = _appContext.Estadios.FirstOrDefault(p => p.Id == idEstadio);
             if (estadioEncontrado == null) return;
             _appContext.Estadios.Remove(estadioEncontrado);
             _appContext.SaveChanges();
         }

         IEnumerable<Estadio> IRepositorioEstadio.getAllEstadios()
         {
             return _appContext.Estadios.Include(e => e.Municipio);
         }

         Estadio IRepositorioEstadio.GetEstadio(int idEstadio)
         {
            var estadioEncontrado = _appContext.Estadios
            .Where(e => e.Id == idEstadio)
            .Include(e => e.Municipio)
            .SingleOrDefault();
            return estadioEncontrado;
         }

         Estadio IRepositorioEstadio.updateEstadio(Estadio estadio)
         {
             var estadioEncontrado = _appContext.Estadios.FirstOrDefault(p => p.Id == estadio.Id);
             if (estadioEncontrado != null)
             {
                 estadioEncontrado.Nombre = estadio.Nombre;
                 estadioEncontrado.Direccion = estadio.Direccion;
                 estadioEncontrado.Municipio = estadio.Municipio;
                 _appContext.SaveChanges();
             }
             return estadioEncontrado;
         }

        Municipio IRepositorioEstadio.asignarMunicipio(int idEstadio, int idMunicipio)
        {
            var estadioEncontrado = _appContext.Estadios.Find(idEstadio);
            if (estadioEncontrado != null)
            {
                var municipioEncontrado = _appContext.Municipios.Find(idMunicipio);
                if (municipioEncontrado != null)
                {
                    estadioEncontrado.Municipio = municipioEncontrado;
                    _appContext.SaveChanges();
                }
                return municipioEncontrado;
            }
            return null;
        }
     }
 }