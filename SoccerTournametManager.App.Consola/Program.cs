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
            var dtCrudTest = new DirectorTecnicoCRUD();
            
            // Se agrega un director tecnico
            dtCrudTest.añadirDT();
            dtCrudTest.añadirDT();

            /// se obtiene y se muestra en json el tecnico agregado
            //dtCrudTest.obtenerDt(1);
            
            /// se actualizar el dt agregado
            //dtCrudTest.actualizarDT(1);

            /// obtener todos los DTs
            dtCrudTest.obtenerTodosDTs();

            /// se elimina el dt
            //dtCrudTest.EliminarDt(1);
        }
    }
}
