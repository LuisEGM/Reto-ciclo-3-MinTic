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
    public class EditModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioMunicipio _repoMunicipio;
        private readonly IRepositorioDT _repoDT;
        public Equipo equipo { get; set; }
        public IEnumerable<DirectorTecnico> DTs {get; set;}
        public IEnumerable<Municipio> municipios {get; set;}
        public EditModel(IRepositorioEquipo repoEquipo, IRepositorioMunicipio repoMunicipio, IRepositorioDT repoDT)
        {
            _repoEquipo = repoEquipo;
            _repoMunicipio = repoMunicipio;
            _repoDT = repoDT;
        }
        public IActionResult OnGet(int id)
        {
            equipo = _repoEquipo.GetEquipo(id);
            municipios =  _repoMunicipio.getAllMunicipios();
            DTs =  _repoDT.getAllDTs();
            if (equipo == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(int idEquipo, string nombre, int idMunicipio, int idDT)
        {
            _repoEquipo.updateEquipo(idEquipo, nombre);
            _repoEquipo.addMunicipio(idEquipo, idMunicipio);
            _repoEquipo.addDT(idEquipo, idDT);
            return RedirectToPage("Index");
        }
    }
}
