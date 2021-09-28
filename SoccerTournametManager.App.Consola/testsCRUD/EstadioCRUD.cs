using System;
using SoccerTournametManager.App.Persistencia;
using SoccerTournametManager.App.Dominio;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace SoccerTournametManager.App.Consola
{
    public class EstadioCRUD
    {
        private static IRepositorioEstadio _repoEstadio = new RepositorioEstadio();
        public void añadirEstadio() {
            var estadio = new Estadio(){
                Nombre="test_name",
                Direccion="Calle 123",
               
            };
            _repoEstadio.addEstadio(estadio);
            Console.Write("\n\n>> Se agrego el Estadio...!");
        }

        public void obtenerEstadio(int idEstadio) {
            var estadioOpcional = _repoEstadio.GetEstadio(idEstadio);
            if (estadioOpcional == null)
            {   
                throw new Exception($"The Estadio with id <{idEstadio}> was not found");
            }
            Console.Write($"\n\n>> Se obtuvo el Estadio con id <{idEstadio}>...!\n");
            Console.Write(JObject.FromObject(estadioOpcional));
        }

        public void EliminarEstadio(int idEstadio) {
            _repoEstadio.DeleteEstadio(idEstadio);
            Console.Write($"\n\n>> Se elimino el Estadio con id <{idEstadio}>...!");
        }

        public void actualizarEstadio(int idEstadio) {
            var estadio = new Estadio(){
                Id=idEstadio,
                Nombre="update_test_name",
                Direccion="Carrera 456",
            };
            _repoEstadio.updateEstadio(estadio);
            Console.Write($"\n\n>> Se actualizo el estadio con id <{idEstadio}>...!");
        }       

        public void obtenerTodosEstadios() {
            List<Estadio> estadios = Enumerable.ToList(_repoEstadio.getAllEstadios());
            Console.Write("\n\n-------------------- Todos los Estadios -----------------------\n\n");
            foreach (var estadio in estadios)
            {
                Console.Write(JObject.FromObject(estadio));
            }
            Console.Write("\n\n---------------------------------------------------------");
        }

    }
}