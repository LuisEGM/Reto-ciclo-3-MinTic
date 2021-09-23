using System;
using SoccerTournametManager.App.Persistencia;
using SoccerTournametManager.App.Dominio;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace SoccerTournametManager.App.Consola
{
    public class DirectorTecnicoCRUD
    {
        private static IRepositorioDT _repoDT = new RepositorioDT(new Persistencia.AppContext());
        public void añadirDT() {
            var dt = new DirectorTecnico(){
                Nombre="test_name",
                Documento="11111111",
                Telefono="22222222"
            };
            _repoDT.addDirectorTecnico(dt);
            Console.Write("\n\n>> Se agrego el DT...!");
        }

        public void obtenerDt(int idDt) {
            var dtOpcional = _repoDT.GetDirectorTecnico(idDt);
            if (dtOpcional == null)
            {   
                throw new Exception($"The patient with id <{idDt}> was not found");
            }
            Console.Write($"\n\n>> Se obtuvo el DT con id <{idDt}>...!\n");
            Console.Write(JObject.FromObject(dtOpcional));
        }

        public void EliminarDt(int idDt) {
            _repoDT.DeleteDirectorTecnico(idDt);
            Console.Write($"\n\n>> Se elimino el DT con id <{idDt}>...!");
        }

        public void actualizarDT(int idDt) {
            var dt = new DirectorTecnico(){
                Id=idDt,
                Nombre="update_test_name",
                Documento="3333333",
                Telefono="4444444"
            };
            _repoDT.updateDirectorTecnico(dt);
            Console.Write($"\n\n>> Se actualizo el DT con id <{idDt}>...!");
        }       

        public void obtenerTodosDTs() {
            List<DirectorTecnico> dts = Enumerable.ToList(_repoDT.getAllDTs());
            Console.Write("\n\n-------------------- Todos los DTs -----------------------\n\n");
            foreach (var dt in dts)
            {
                Console.Write(JObject.FromObject(dt));
            }
            Console.Write("\n\n---------------------------------------------------------");
        }

    }
}