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
    public class EditModel : PageModel
    {
        private readonly IRepositorioJugador _repoJugador;
        private readonly IRepositorioEquipo _repoEquipo;
       
        public Jugador jugador { get; set; }
        
        public IEnumerable<Equipo> equipos {get; set;}
        public EditModel(IRepositorioJugador repoJugador, IRepositorioEquipo repoEquipo)
        {
            _repoJugador = repoJugador;
            _repoEquipo = repoEquipo;
        }
        public IActionResult OnGet(int id)
        {
            jugador = _repoJugador.GetJugador(id);
            equipos =  _repoEquipo.getAllEquipos();
            if (jugador == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(int idJugador, string nombre, int idEquipo, string documento, string telefono, int numero, string posicion)
        {
            _repoJugador.updateJugador(idJugador, nombre, documento, telefono ,numero, posicion);
            _repoJugador.asignarEquipo(idJugador, idEquipo);
            return RedirectToPage("Index");
        }
    }
}
