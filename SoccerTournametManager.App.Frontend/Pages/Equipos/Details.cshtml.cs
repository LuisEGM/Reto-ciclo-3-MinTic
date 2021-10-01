using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SoccerTournametManager.App.Dominio;
using SoccerTournametManager.App.Persistencia;

namespace SoccerTournametManager.App.Frontend.Pages.Equipos
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioJugador _repoJugador;
        public Equipo equipo { get; set; }
        public IEnumerable<Jugador> listaJugadores { get; set; }
        public DetailsModel(IRepositorioEquipo repoEquipo, IRepositorioJugador repoJugador)
        {
            _repoEquipo = repoEquipo;
            _repoJugador = repoJugador;
        }
        public IActionResult OnGet(int id)
        {
            equipo = _repoEquipo.GetEquipo(id);
            listaJugadores = _repoJugador.getAllJugadoresByEquipo(id);
            if (equipo == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
    }
}
