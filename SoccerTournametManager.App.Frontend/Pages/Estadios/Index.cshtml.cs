using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SoccerTournametManager.App.Persistencia;
using SoccerTournametManager.App.Dominio;

namespace SoccerTournametManager.App.Frontend.Pages.Estadios
{
    public class IndexModel : PageModel
    {
        public string bActual {get; set;}
        private readonly IRepositorioEstadio _repoEstadio;
        public IEnumerable<Estadio> estadios {get; set;}
        public IndexModel(IRepositorioEstadio repoEstadio)
        {
            _repoEstadio = repoEstadio;
        }

        public void OnGet(string b)
        {
            if (String.IsNullOrEmpty(b))
            {
                bActual = "";
                estadios = _repoEstadio.getAllEstadios();
            }
            else
            {
                bActual = b;
                estadios = _repoEstadio.SearchEstadio(b);
            }
        }
    }
}
