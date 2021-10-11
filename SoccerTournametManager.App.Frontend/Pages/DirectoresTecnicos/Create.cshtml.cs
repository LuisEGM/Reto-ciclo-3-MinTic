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
    public class CreateModel : PageModel
    {
        private readonly IRepositorioDT _repoDirectoresTecnicos;
        public DirectorTecnico directortecnico {get; set;}
        public CreateModel(IRepositorioDT repoDirectoresTecnicos)
        {
            _repoDirectoresTecnicos = repoDirectoresTecnicos;
        }
        public void OnGet()
        {
            directortecnico = new DirectorTecnico(); 
        }
        public IActionResult OnPost(DirectorTecnico directorTecnico)
        {   
            if (ModelState.IsValid)
            {
                _repoDirectoresTecnicos.addDirectorTecnico(directorTecnico);
                 return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
            
        }
        
    }
}
