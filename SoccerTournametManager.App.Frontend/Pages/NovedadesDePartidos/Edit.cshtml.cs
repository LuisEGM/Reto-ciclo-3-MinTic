using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SoccerTournametManager.App.Dominio;
using SoccerTournametManager.App.Persistencia;

namespace SoccerTournametManager.App.Frontend.Pages.NovedadesDePartidos
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioNovedadPartido _repoNovedades;
        private readonly IRepositorioJugador _repoJugador;
        private readonly IRepositorioPartido _repoPartido;
        public NovedadPartido novedadPartido {get; set;}
        public IEnumerable<Jugador> jugadores {get; set;}
        public IEnumerable<Partido> partidos {get; set;}
        public EditModel(IRepositorioNovedadPartido repoNovedades, IRepositorioJugador repoJugador, IRepositorioPartido repoPartido)
        {
            _repoNovedades = repoNovedades;
            _repoJugador = repoJugador;
            _repoPartido = repoPartido;
        }
        public void OnGet(int id)
        {
            novedadPartido = _repoNovedades.getNovedadDePartido(id);
            jugadores = _repoJugador.getAllJugadores();
            partidos = _repoPartido.getAllPartidos();
        }

        public IActionResult OnPost(int idNovedad, int minuto, string novedad, int idJugador, int idPartido)
        {

            var nuevaNovedad = new NovedadPartido(){
                Id = idNovedad,
                Minuto = minuto,
            };
            if (novedad == "0")
            {
                nuevaNovedad.Novedad = Novedad.TarjetaAmarilla;
            }
            else if (novedad == "1")
            {
                nuevaNovedad.Novedad = Novedad.TarjetaRoja;
            }
            else if (novedad == "2")
            {
                nuevaNovedad.Novedad = Novedad.Anotacion;
            }
            _repoNovedades.updateNovedadDePartido(nuevaNovedad);
            _repoNovedades.asignarJugador(idNovedad, idJugador);
            _repoNovedades.asignarPartido(idNovedad, idPartido);
            return RedirectToPage("Index");
        }
    }
}
