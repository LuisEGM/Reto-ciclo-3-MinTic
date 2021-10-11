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
    public class EditModel : PageModel
    {
        private readonly IRepositorioDT _repoDirectoresTecnicos;

        public DirectorTecnico directortecnico {get; set;}
        public EditModel(IRepositorioDT repoDirectoresTecnicos)
        {
            _repoDirectoresTecnicos = repoDirectoresTecnicos;
        }
        public void OnGet(int id)
        {
            directortecnico = _repoDirectoresTecnicos.GetDirectorTecnico(id);
        }
        public IActionResult OnPost(DirectorTecnico directorTecnico)
        {
            _repoDirectoresTecnicos.updateDirectorTecnico(directorTecnico);
            return RedirectToPage("Index");
        }

    }
}
