using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SoccerTournametManager.App.Dominio;
using SoccerTournametManager.App.Persistencia;

namespace SoccerTournametManager.App.Frontend.Pages.NovedadesDePartidos
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioNovedadPartido _repoNovedades;
        public NovedadPartido novedadPartido {get; set;}
        public CreateModel(IRepositorioNovedadPartido repoNovedades)
        {
            _repoNovedades = repoNovedades;
        }

        public void OnGet()
        {
            novedadPartido = new NovedadPartido();
        }

        public IActionResult OnPost(NovedadPartido novedadPartido)
        {   
            if (ModelState.IsValid)
            {
                _repoNovedades.addNovedadDePartido(novedadPartido);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }

    }
}
