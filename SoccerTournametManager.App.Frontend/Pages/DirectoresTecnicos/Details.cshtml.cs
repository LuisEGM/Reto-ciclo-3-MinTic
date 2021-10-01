using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SoccerTournametManager.App.Dominio;
using SoccerTournametManager.App.Persistencia;

namespace SoccerTournametManager.App.Frontend.Pages.DirectoresTecnicos
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioDT _repoDT;
        public DirectorTecnico directorTecnico {get; set;}
        public DetailsModel(IRepositorioDT repoDT)
        {
            _repoDT = repoDT;
        }
        public IActionResult OnGet(int id)
        {
            directorTecnico = _repoDT.GetDirectorTecnico(id);
            if(directorTecnico == null)
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
