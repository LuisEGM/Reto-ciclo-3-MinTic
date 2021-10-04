using SoccerTournametManager.App.Persistencia;
using SoccerTournametManager.App.Dominio;
using Newtonsoft.Json.Linq;
using System;

namespace SoccerTournametManager.App.Consola
{
    class Program
    {
        private static IRepositorioNovedadPartido _repoNovedad = new RepositorioNovedadPartido();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to < soccer tournament manager >...!");
            /// CRUD TEST PARA DIRECTOR TECNICO
            /// DESCOMENTE PARA PROBAR UNO POR UNO
            /// >> El test consiste en descomentar la opcion del crud que se quier probar.
            //var dtCrudTest = new DirectorTecnicoCRUD();

            // Se agrega un director tecnico
            //dtCrudTest.añadirDT();
            // dtCrudTest.añadirDT();

            /// se obtiene y se muestra en json el tecnico agregado
            // dtCrudTest.obtenerDt(1);

            /// se actualizar el dt agregado
            // dtCrudTest.actualizarDT(1);

            /// obtener todos los DTs
            // dtCrudTest.obtenerTodosDTs();

            /// se elimina el dt
            // dtCrudTest.EliminarDt(1);

// ---------------------------------------------------------------------------------

            /// CRUD TEST PARA ARBITRO
            /// DESCOMENTE PARA PROBAR UNO POR UNO
            /// >> El test consiste en descomentar la opcion del crud que se quier probar.
            //var arbitroCrudTest = new ArbitroCRUD();

            // Se agrega un arbitro
            //arbitroCrudTest.añadirArbitro();
            //arbitroCrudTest.añadirArbitro();

            /// se obtiene y se muestra en json el arbitro agregado
            // arbitroCrudTest.obtenerArbitro(1);

            /// se actualizar el arbitro agregado
            // arbitroCrudTest.actualizarArbitro(1);

            /// obtener todos los arbitros
            // arbitroCrudTest.obtenerTodosArbitros();

            /// se elimina el arbitro
            // arbitroCrudTest.EliminarArbitro(1);

// ---------------------------------------------------------------------------------

            /// CRUD TEST PARA ESTADIO
            /// DESCOMENTE PARA PROBAR UNO POR UNO
            /// >> EL ID DEL PRIMER ESTADIO QUE SE AGREGA ES 1
            /// >> El test consiste en descomentar la opcion del crud que se quier probar.
            //var estadioCrudTest = new EstadioCRUD();
            // Se agrega un estadio
            //estadioCrudTest.añadirEstadio();
            //estadioCrudTest.asignarMunicipio(3,2);

            /// se obtiene y se muestra en json el estadio agregado
            //estadioCrudTest.obtenerEstadio(1);

            /// se actualizar el estadio agregado
            //estadioCrudTest.actualizarEstadio(1);

            /// obtener todos los estadios
            //estadioCrudTest.obtenerTodosEstadios();

            /// se elimina el estadio
            // estadioCrudTest.EliminarEstadio(1);

// ---------------------------------------------------------------------------------

            /// CRUD TEST PARA JUGADOR
            /// DESCOMENTE PARA PROBAR UNO POR UNO
            /// >> EL ID DEL PRIMER jUGADOR QUE SE AGREGA ES 1
            /// >> El test consiste en descomentar la opcion del crud que se quier probar.
            //var jugadorCrudTest = new JugadorCRUD();
            
            // Se agrega un jugador
            //jugadorCrudTest.añadirJugador();
            //jugadorCrudTest.añadirJugador();

            /// se obtiene y se muestra en json el jugador agregado
            //jugadorCrudTest.obtenerJugador(3);
            
            /// se actualizar el jugador agregado
            // jugadorCrudTest.actualizarJugador(1);
            
            /// obtener todos los jugadores
            //jugadorCrudTest.obtenerTodosJugadores();
            
            /// se elimina el jugador
            // jugadorCrudTest.EliminarJugador(1);
             var idNovedad = 5;
             var novedadOpcional = _repoNovedad.getNovedadDePartido(idNovedad);
             if (novedadOpcional == null)
             {   
                 throw new Exception($"The jugador with id <{idNovedad}> was not found");
             }
             Console.Write($"\n\n>> Se obtuvo el Jugador con id <{idNovedad}>...!\n");
             Console.Write(JObject.FromObject(novedadOpcional));
        }
    }
}
