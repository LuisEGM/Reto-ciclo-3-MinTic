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
    public class CreateModel : PageModel
    {
        private readonly IRepositorioArbitro _repoArbitro;
        public Arbitro arbitro { get; set; }
        public CreateModel(IRepositorioArbitro repoArbitro)
        {
            _repoArbitro = repoArbitro;
        }

        public void OnGet()
        {
            arbitro = new Arbitro();
        }

        public IActionResult OnPost(Arbitro arbitro)
        {
            if (ModelState.IsValid)
            {
                _repoArbitro.addArbitro(arbitro);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
