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
    public class AddArbitroModel : PageModel
    {
        private readonly IRepositorioPartido _repoPartido;
        private readonly IRepositorioArbitro _repoArbitro;
        public IEnumerable<Arbitro> arbitros {get; set;}
        public Partido partido { get; set; }
        public AddArbitroModel(IRepositorioPartido repoPartido, IRepositorioArbitro repoArbitro)
        {
            _repoPartido = repoPartido;
            _repoArbitro = repoArbitro;
        }
        public void OnGet(int id)
        {
            partido = _repoPartido.GetPartido(id);
            arbitros =  _repoArbitro.getAllArbitros();
        }

        public IActionResult OnPost(int idPartido, int idArbitro)
        {
            _repoPartido.addArbitro(idPartido, idArbitro);
            return RedirectToPage("Details", new {id=idPartido});
        }
    }
}
