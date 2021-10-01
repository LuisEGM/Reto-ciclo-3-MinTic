using System;
using SoccerTournametManager.App.Persistencia;
using SoccerTournametManager.App.Dominio;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace SoccerTournametManager.App.Consola
{
    public class JugadorCRUD
    {
        private static IRepositorioJugador _repoJugador = new RepositorioJugador();
        public void añadirJugador() {
            var jugador = new Jugador(){
                Nombre="test_name",
                Numero= 11,
                Posicion= "Delantero"
            };
            _repoJugador.addJugador(jugador);
            Console.Write("\n\n>> Se agrego el jugador...!");
        }

        public void obtenerJugador(int idJugador) {
            var jugadorOpcional = _repoJugador.GetJugador(idJugador);
            if (jugadorOpcional == null)
            {   
                throw new Exception($"The jugador with id <{idJugador}> was not found");
            }
            Console.Write($"\n\n>> Se obtuvo el Jugador con id <{idJugador}>...!\n");
            Console.Write(JObject.FromObject(jugadorOpcional));
        }

        public void EliminarJugador(int idJugador) {
            _repoJugador.DeleteJugador(idJugador);
            Console.Write($"\n\n>> Se elimino el Jugador con id <{idJugador}>...!");
        }

        public void actualizarJugador(int idJugador) {
            var jugador = new Jugador(){
                Id=idJugador,
                Nombre="update_test_name",
                Numero=22,
                Posicion="Defensa"
            };
            _repoJugador.updateJugador(jugador);
            Console.Write($"\n\n>> Se actualizo el Jugador con id <{idJugador}>...!");
        }       

        public void obtenerTodosJugadores() {
            List<Jugador> jugadores = Enumerable.ToList(_repoJugador.getAllJugadores());
            Console.Write("\n\n-------------------- Todos los Jugadores -----------------------\n\n");
            foreach (var jugador in jugadores)
            {
                Console.Write(JObject.FromObject(jugador));
            }
            Console.Write("\n\n---------------------------------------------------------");
        }

    }
}