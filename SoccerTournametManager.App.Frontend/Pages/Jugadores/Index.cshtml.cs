using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SoccerTournametManager.App.Persistencia;
using SoccerTournametManager.App.Dominio;
namespace SoccerTournametManager.App.Frontend.Pages.Jugadores
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioJugador _repoJugador;
        public string bActual {get;set;}
        public IEnumerable<Jugador> jugadores {get; set;}
        public IndexModel(IRepositorioJugador repoJugador)
        {
            _repoJugador = repoJugador;
        }
        public void OnGet(string b)
        {
            if(String.IsNullOrEmpty(b))
            {
                bActual = "";
                jugadores = _repoJugador.getAllJugadores();
            }
            else
            {
                bActual = b;
                jugadores = _repoJugador.SearchJugadores(b);
            }
        }
    }
}
