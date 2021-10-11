using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SoccerTournametManager.App.Dominio;
using SoccerTournametManager.App.Persistencia;

namespace SoccerTournametManager.App.Frontend.Pages.Arbitros
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioArbitro _repoArbitro;
        public Arbitro arbitro {get; set;}
        public EditModel(IRepositorioArbitro repoArbitro)
        {
            _repoArbitro = repoArbitro;
        }
        public void OnGet(int id)
        {
            arbitro = _repoArbitro.GetArbitro(id);
        }
        public IActionResult OnPost(Arbitro arbitro)
        {
            _repoArbitro.updateArbitro(arbitro);
            return RedirectToPage("Index");
        }
    }
}
