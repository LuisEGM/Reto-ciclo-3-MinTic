using System;

namespace SoccerTournametManager.App.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to < soccer tournament manager >...!");
            
            /// CRUD TEST PARA DIRECTOR TECNICO
            /// DESCOMENTE PARA PROBAR UNO POR UNO
            /// >> EL ID DEL PRIMER DT QUE SE AGREGA ES 1
            /// >> El test consiste en descomentar la opcion del crud que se quier probar.
            // var dtCrudTest = new DirectorTecnicoCRUD();

            /// CRUD TEST PARA ARBITRO
            /// DESCOMENTE PARA PROBAR UNO POR UNO
            /// >> EL ID DEL PRIMER ARBITRO QUE SE AGREGA ES 1
            /// >> El test consiste en descomentar la opcion del crud que se quier probar.
            // var arbitroCrudTest = new ArbitroCRUD();

            /// CRUD TEST PARA ESTADIO
            /// DESCOMENTE PARA PROBAR UNO POR UNO
            /// >> EL ID DEL PRIMER ESTADIO QUE SE AGREGA ES 1
            /// >> El test consiste en descomentar la opcion del crud que se quier probar.
            // var equipoCrudTest = new EstadioCRUD();

            /// CRUD TEST PARA JUGADOR
            /// DESCOMENTE PARA PROBAR UNO POR UNO
            /// >> EL ID DEL PRIMER jUGADOR QUE SE AGREGA ES 1
            /// >> El test consiste en descomentar la opcion del crud que se quier probar.
            var jugadorCrudTest = new JugadorCRUD();
            
            // Se agrega un director tecnico
            // dtCrudTest.añadirDT();
            // dtCrudTest.añadirDT();
            // Se agrega un arbitro
            //arbitroCrudTest.añadirArbitro();
            //arbitroCrudTest.añadirArbitro();
            // Se agrega un estadio
            //estadioCrudTest.añadirEstadio();
            //estadioCrudTest.añadirEstadio();
            // Se agrega un jugador
            jugadorCrudTest.añadirJugador();
            jugadorCrudTest.añadirJugador();

            /// se obtiene y se muestra en json el tecnico agregado
            // dtCrudTest.obtenerDt(1);
            /// se obtiene y se muestra en json el arbitro agregado
            // arbitroCrudTest.obtenerArbitro(1);
            /// se obtiene y se muestra en json el estadio agregado
            // estadioCrudTest.obtenerEstadio(1);
            /// se obtiene y se muestra en json el jugador agregado
            //jugadorCrudTest.obtenerJugador(3);
            
            /// se actualizar el dt agregado
            // dtCrudTest.actualizarDT(1);
            /// se actualizar el arbitro agregado
            // arbitroCrudTest.actualizarArbitro(1);
            /// se actualizar el estadio agregado
            // estadioCrudTest.actualizarEstadio(1);
            /// se actualizar el jugador agregado
            // jugadorCrudTest.actualizarJugador(1);

            /// obtener todos los DTs
            // dtCrudTest.obtenerTodosDTs();
            /// obtener todos los arbitros
            // arbitroCrudTest.obtenerTodosArbitros();
            /// obtener todos los estadios
            // estadioCrudTest.obtenerTodosEstadios();
            /// obtener todos los jugadores
            jugadorCrudTest.obtenerTodosJugadores();

            /// se elimina el dt
            // dtCrudTest.EliminarDt(1);
            /// se elimina el arbitro
            // arbitroCrudTest.EliminarArbitro(1);
            /// se elimina el estadio
            // estadioCrudTest.EliminarEstadio(1);
            /// se elimina el jugador
            // jugadorCrudTest.EliminarJugador(1);

        }
    }
}
