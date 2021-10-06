using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SoccerTournametManager.App.Dominio;
using SoccerTournametManager.App.Persistencia;

namespace SoccerTournametManager.App.Frontend.Pages.Equipos
{
    public class AddDirectorTecnicoModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioDT _repoDT;
        public IEnumerable<DirectorTecnico> DTs {get; set;}
        public Equipo equipo { get; set; }

        public AddDirectorTecnicoModel(IRepositorioEquipo repoEquipo, IRepositorioDT repoDT)
        {
            _repoEquipo = repoEquipo;
            _repoDT = repoDT;
        }
        public void OnGet(int id)
        {
            equipo = _repoEquipo.GetEquipo(id);
            DTs =  _repoDT.getAllDTs();
        }

        public IActionResult OnPost(int idEquipo, int idDT)
        {
            _repoEquipo.addDT(idEquipo, idDT);
            return RedirectToPage("Details", new {id=idEquipo});
        }

    }
}
