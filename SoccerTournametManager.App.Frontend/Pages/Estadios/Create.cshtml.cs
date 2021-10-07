using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SoccerTournametManager.App.Dominio;
using SoccerTournametManager.App.Persistencia;

namespace SoccerTournametManager.App.Frontend.Pages.Estadios
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioEstadio _repoEstadio;
        public Estadio estadio { get; set; }
        public CreateModel(IRepositorioEstadio repoEstadio)
        {
            _repoEstadio = repoEstadio;
        }

        public void OnGet()
        {
            estadio = new Estadio();
        }

        public IActionResult OnPost(Estadio estadio)
        {
            if (ModelState.IsValid)
            {
                _repoEstadio.addEstadio(estadio);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
