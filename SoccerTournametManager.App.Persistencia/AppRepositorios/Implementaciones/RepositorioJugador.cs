 using System.Collections.Generic;
 using SoccerTournametManager.App.Dominio;
 using System.Linq;
 using Microsoft.EntityFrameworkCore;

 namespace SoccerTournametManager.App.Persistencia
 {
     public class RepositorioJugador : IRepositorioJugador
     {

         /// <sumary>
         /// Referencia al contexto de los jugadores
         /// </sumary>
         private readonly AppContext _appContext = new AppContext();

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
             return _appContext.Jugadores.Include(j => j.Equipo);
         }

         IEnumerable<Jugador> IRepositorioJugador.getAllJugadoresByEquipo(int idEquipo)
         {
             return _appContext.Jugadores.Include(j => j.Equipo).Where(j => j.Equipo.Id == idEquipo);
         }

         Jugador IRepositorioJugador.GetJugador(int idJugador)
         {
            var jugadorEncontrado = _appContext.Jugadores
            .Where(j => j.Id == idJugador)
            .Include(j => j.Equipo)
            .ThenInclude(e => e.DirectorTecnico)
            .SingleOrDefault();
            return jugadorEncontrado;
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