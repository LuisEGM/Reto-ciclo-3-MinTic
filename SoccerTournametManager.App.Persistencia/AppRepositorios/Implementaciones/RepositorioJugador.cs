 using System.Collections.Generic;
 using SoccerTournametManager.App.Dominio;
 using System.Linq;

 namespace SoccerTournametManager.App.Persistencia
 {
     public class RepositorioJugador : IRepositorioJugador
     {

         /// <sumary>
         /// Referencia al contexto de los jugadores
         /// </sumary>
         private readonly AppContext _appContext;

         /// <sumary>
         /// Metodo constructor utiliza
         /// inyeccion de dependencias para indicar el contexto a utilizar
         /// </sumary>
         /// <param name="appContext"></param>
         public RepositorioJugador(AppContext appContext)
         {
             _appContext=appContext;
         }

         Jugador IRepositorioJugador.addJugador(Jugador jugador)
         {
             var jugadorAdicionado = _appContext.Jugadores.Add(jugador);
             _appContext.SaveChanges();

             return jugadorAdicionado.Entity;
         }

         void IRepositorioJugador.DeleteJugador(int idJugador)
         {
             var jugadorEncontrado = _appContext.Jugadores.FirstOrDefault(p => p.Id == idJugador);
             if (jugadorEncontrado == null) return;
             _appContext.Jugadores.Remove(jugadorEncontrado);
             _appContext.SaveChanges();
         }

         IEnumerable<Jugador> IRepositorioJugador.getAllJugadores()
         {
             return _appContext.Jugadores;
         }

         Jugador IRepositorioJugador.GetJugador(int idJugador)
         {
             return _appContext.Jugadores.FirstOrDefault(p => p.Id == idJugador);
         }

         Jugador IRepositorioJugador.updateJugador(Jugador jugador)
         {
             var jugadorEncontrado = _appContext.Jugadores.FirstOrDefault(p => p.Id == jugador.Id);
             if (jugadorEncontrado != null)
             {
                 jugadorEncontrado.Nombre = jugador.Nombre;
                 jugadorEncontrado.Documento = jugador.Documento;
                 jugadorEncontrado.Telefono = jugador.Telefono;
                 jugadorEncontrado.Numero = jugador.Numero;
                 jugadorEncontrado.Posicion = jugador.Posicion;
                 jugadorEncontrado.Equipo = jugador.Equipo;
                 _appContext.SaveChanges();
             }
             return jugadorEncontrado;
         }
     }
 }