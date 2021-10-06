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
    public class AddPartidoModel : PageModel
    {
        private readonly IRepositorioNovedadPartido _repoNovedades;
        private readonly IRepositorioPartido _repoPartido;
        public IEnumerable<Partido> partidos {get; set;}
        public NovedadPartido novedadPartido {get; set;}
        public AddPartidoModel(IRepositorioNovedadPartido repoNovedades, IRepositorioPartido repoPartido)
        {
            _repoNovedades = repoNovedades;
            _repoPartido = repoPartido;
        }
        public void OnGet(int id)
        {
            novedadPartido = _repoNovedades.getNovedadDePartido(id);
            partidos = _repoPartido.getAllPartidos();
        }

        public IActionResult OnPost(int idNovedad, int idPartido)
        {
            _repoNovedades.asignarPartido(idNovedad, idPartido);
            return RedirectToPage("Details", new {id=idNovedad});
        }
    }
}
