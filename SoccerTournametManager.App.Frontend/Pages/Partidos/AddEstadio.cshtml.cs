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
    public class AddEstadioModel : PageModel
    {
        private readonly IRepositorioPartido _repoPartido;
        private readonly IRepositorioEstadio _repoEstadio;
        public IEnumerable<Estadio> estadios {get; set;}
        public Partido partido { get; set; }
        public AddEstadioModel(IRepositorioPartido repoPartido, IRepositorioEstadio repoEstadio)
        {
            _repoPartido = repoPartido;
            _repoEstadio = repoEstadio;
        }
        public void OnGet(int id)
        {
            partido = _repoPartido.GetPartido(id);
            estadios =  _repoEstadio.getAllEstadios();
        }

        public IActionResult OnPost(int idPartido, int idEstadio)
        {
            _repoPartido.addEstadio(idPartido, idEstadio);
            return RedirectToPage("Details", new {id=idPartido});
        }
    }
}
