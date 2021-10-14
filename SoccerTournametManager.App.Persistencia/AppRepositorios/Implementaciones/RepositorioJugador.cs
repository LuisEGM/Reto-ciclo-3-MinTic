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

         Jugador IRepositorioJugador.updateJugador(int idJugador, string nombre, string documento, string telefono, int numero, string posicion)
         {
             var jugadorEncontrado = _appContext.Jugadores.FirstOrDefault(p => p.Id == idJugador);
             if (jugadorEncontrado != null)
             {
                 jugadorEncontrado.Nombre = nombre;
                 jugadorEncontrado.Documento = documento;
                 jugadorEncontrado.Telefono = telefono;
                 jugadorEncontrado.Numero = numero;
                 jugadorEncontrado.Posicion = posicion;
                 //jugadorEncontrado.Equipo = jugador.Equipo;
                 _appContext.SaveChanges();
             }
             return jugadorEncontrado;
         }

         Equipo IRepositorioJugador.asignarEquipo(int idJugador, int idEquipo)
        {
            var jugadorEncontrado = _appContext.Jugadores.Find(idJugador);
            if (jugadorEncontrado != null)
            {
                var equipoEncontrado = _appContext.Equipos.Find(idEquipo);
                if (equipoEncontrado != null)
                {
                    jugadorEncontrado.Equipo = equipoEncontrado;
                    _appContext.SaveChanges();
                }
                return equipoEncontrado;
            }
            return null;
        }
        IEnumerable<Jugador> IRepositorioJugador.SearchJugadores(string nombre)
        {
            return _appContext.Jugadores.Where(j => j.Nombre.Contains(nombre));
        }
     }
     
 }