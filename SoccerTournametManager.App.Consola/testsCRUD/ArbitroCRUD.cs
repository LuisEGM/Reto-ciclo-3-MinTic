using System;
using SoccerTournametManager.App.Persistencia;
using SoccerTournametManager.App.Dominio;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace SoccerTournametManager.App.Consola
{
    public class ArbitroCRUD
    {
        private static IRepositorioArbitro _repoArbitro = new RepositorioArbitro();
        public void añadirArbitro() {
            var arbitro = new Arbitro(){
                Nombre="test_name",
                Documento="11111111",
                Telefono="22222222",
                Colegio="Colegio N1"
            };
            _repoArbitro.addArbitro(arbitro);
            Console.Write("\n\n>> Se agrego el Arbitro...!");
        }

        public void obtenerArbitro(int idArbitro) {
            var arbitroOpcional = _repoArbitro.GetArbitro(idArbitro);
            if (arbitroOpcional == null)
            {   
                throw new Exception($"The Arbitro with id <{idArbitro}> was not found");
            }
            Console.Write($"\n\n>> Se obtuvo el Arbitro con id <{idArbitro}>...!\n");
            Console.Write(JObject.FromObject(arbitroOpcional));
        }

        public void EliminarArbitro(int idArbitro) {
            _repoArbitro.DeleteArbitro(idArbitro);
            Console.Write($"\n\n>> Se elimino el Arbitro con id <{idArbitro}>...!");
        }

        public void actualizarArbitro(int idArbitro) {
            var arbitro = new Arbitro(){
                Id=idArbitro,
                Nombre="update_test_name",
                Documento="3333333",
                Telefono="4444444",
                Colegio="Colegio 2222"
            };
            _repoArbitro.updateArbitro(arbitro);
            Console.Write($"\n\n>> Se actualizo el Arbitro con id <{idArbitro}>...!");
        }       

        public void obtenerTodosArbitros() {
            List<Arbitro> arbitros = Enumerable.ToList(_repoArbitro.getAllArbitros());
            Console.Write("\n\n-------------------- Todos los Arbitros -----------------------\n\n");
            foreach (var arbitro in arbitros)
            {
                Console.Write(JObject.FromObject(arbitro));
            }
            Console.Write("\n\n---------------------------------------------------------");
        }

    }
}