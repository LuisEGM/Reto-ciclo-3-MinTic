using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SoccerTournametManager.App.Persistencia;
using SoccerTournametManager.App.Dominio;

namespace SoccerTournametManager.App.Frontend.Pages.DirectoresTecnicos
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioDT _repoDT;
        public IEnumerable<DirectorTecnico> directorestecnicos {get; set;}
        public IndexModel(IRepositorioDT repoDT)
        {
            _repoDT = repoDT;
        }

        public void OnGet()
        {
            directorestecnicos = _repoDT.getAllDTs(); 
        }
    }
}
