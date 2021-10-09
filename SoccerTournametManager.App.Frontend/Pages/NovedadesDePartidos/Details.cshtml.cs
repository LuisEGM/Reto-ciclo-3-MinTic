using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SoccerTournametManager.App.Dominio;
using SoccerTournametManager.App.Persistencia;

namespace SoccerTournametManager.App.Frontend.Pages.NovedadesDePartidos
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioNovedadPartido _repoNovedadPartido;
        public NovedadPartido novedad {get; set;}
        public DetailsModel(IRepositorioNovedadPartido repoNovedadPartido)
        {
            _repoNovedadPartido = repoNovedadPartido;
        }
        public IActionResult OnGet(int id)
        {
            novedad = _repoNovedadPartido.getNovedadDePartido(id);
            Console.Write(JObject.FromObject(novedad));
            if(novedad == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
    }
}
