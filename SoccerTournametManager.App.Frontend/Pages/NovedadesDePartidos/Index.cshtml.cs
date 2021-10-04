using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SoccerTournametManager.App.Persistencia;
using SoccerTournametManager.App.Dominio;

namespace SoccerTournametManager.App.Frontend.Pages.NovedadesDePartidos
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioNovedadPartido  _repoNovedadPartido;

        public IEnumerable<NovedadPartido> novedades {get; set;}

        public IndexModel(IRepositorioNovedadPartido repoNovedadPartido)
        {
            _repoNovedadPartido = repoNovedadPartido;
        }
        public void OnGet()
        {
            novedades = _repoNovedadPartido.getAllNovedadesDePartidos();
        }
    }
}
