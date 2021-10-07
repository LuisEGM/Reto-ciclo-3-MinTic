using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SoccerTournametManager.App.Dominio;
using SoccerTournametManager.App.Persistencia;

namespace SoccerTournametManager.App.Frontend.Pages.Partidos
{
    public class AddEquipoLocalModel : PageModel
    {
        private readonly IRepositorioPartido _repoPartido;
        private readonly IRepositorioEquipo _repoEquipo;
        public IEnumerable<Equipo> equipos {get; set;}
        public Partido partido { get; set; }
        public AddEquipoLocalModel(IRepositorioPartido repoPartido, IRepositorioEquipo repoEquipo)
        {
            _repoPartido = repoPartido;
            _repoEquipo = repoEquipo;
        }
        public void OnGet(int id)
        {
            partido = _repoPartido.GetPartido(id);
            equipos =  _repoEquipo.getAllEquipos();
        }

        public IActionResult OnPost(int idPartido, int idEquipo)
        {
            _repoPartido.addEquipo("local", idPartido, idEquipo);
            return RedirectToPage("Details", new {id=idPartido});
        }
    }
}
