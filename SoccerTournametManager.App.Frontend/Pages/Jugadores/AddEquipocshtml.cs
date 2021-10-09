using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SoccerTournametManager.App.Dominio;
using SoccerTournametManager.App.Persistencia;

namespace SoccerTournametManager.App.Frontend.Pages.Jugadores
{
    public class AddEquipoModel : PageModel
    {
        private readonly IRepositorioJugador _repoJugador;
        private readonly IRepositorioEquipo _repoEquipo;
        public IEnumerable<Equipo> equipos {get; set;}
        public Jugador jugador { get; set; }

        public AddEquipoModel(IRepositorioJugador repoJugador, IRepositorioEquipo repoEquipo)
        {
            _repoJugador = repoJugador;
            _repoEquipo = repoEquipo;
        }

        public void OnGet(int id)
        {
            jugador = _repoJugador.GetJugador(id);
            equipos =  _repoEquipo.getAllEquipos();
        }

        public IActionResult OnPost(int idJugador, int idEquipo)
        {
            _repoJugador.asignarEquipo(idJugador, idEquipo);
            return RedirectToPage("Index");
        }
    }
}
