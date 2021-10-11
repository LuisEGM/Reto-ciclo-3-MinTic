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
        private readonly IRepositorioArbitro _repoArbitros;
        public Arbitro Arbitro {get; set;}
        public CreateModel(IRepositorioArbitro repoArbitros)
        {
            _repoArbitros = repoArbitros;
        }
        public void OnGet()
        {
            Arbitro = new Arbitro();
        }
        public IActionResult OnPost(Arbitro arbitro)
        {   
            if (ModelState.IsValid)
            {
                _repoArbitros.addArbitro(arbitro);
                 return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
            
        }
    }
}
