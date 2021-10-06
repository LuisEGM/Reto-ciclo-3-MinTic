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
    public class AddJugadorInvolucradoModel : PageModel
    {
        private readonly IRepositorioNovedadPartido _repoNovedades;
        private readonly IRepositorioJugador _repoJugador;
        public IEnumerable<Jugador> jugadores {get; set;}
        public NovedadPartido novedadPartido {get; set;}
        public AddJugadorInvolucradoModel(IRepositorioNovedadPartido repoNovedades, IRepositorioJugador repoJugador)
        {
            _repoNovedades = repoNovedades;
            _repoJugador = repoJugador;
        }
        public void OnGet(int id)
        {
            novedadPartido = _repoNovedades.getNovedadDePartido(id);
            jugadores = _repoJugador.getAllJugadores();
        }

        public IActionResult OnPost(int idNovedad, int idJugador)
        {
            _repoNovedades.asignarJugador(idNovedad, idJugador);
            return RedirectToPage("Details", new {id=idNovedad});
        }
    }
}
