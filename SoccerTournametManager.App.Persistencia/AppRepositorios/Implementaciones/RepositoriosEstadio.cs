 using System.Collections.Generic;
 using SoccerTournametManager.App.Dominio;
 using System.Linq;

 namespace SoccerTournametManager.App.Persistencia
 {
     public class RepositorioEstadio : IRepositorioEstadio
     {

         /// <sumary>
         /// Referencia al contexto de los estadios
         /// </sumary>
         private readonly AppContext _appContext;

         /// <sumary>
         /// Metodo constructor utiliza
         /// inyeccion de dependencias para indicar el contexto a utilizar
         /// </sumary>
         /// <param name="appContext"></param>
         public RepositorioEstadio(AppContext appContext)
         {
             _appContext=appContext;
         }

         Estadio IRepositorioEstadio.addEstadio(Estadio estadio )
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
             return _appContext.Estadios;
         }

         Estadio IRepositorioEstadio.GetEstadio(int idEstadio)
         {
             return _appContext.Estadios.FirstOrDefault(p => p.Id == idEstadio);
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
     }
 }