using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SoccerTournametManager.App.Dominio;
using SoccerTournametManager.App.Persistencia;

namespace SoccerTournametManager.App.Frontend.Pages.Estadios
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioEstadio _repoEstadio;
        private readonly IRepositorioMunicipio _repoMunicipio;
       
        public Estadio estadio { get; set; }
        
        public IEnumerable<Municipio> municipios {get; set;}
        public EditModel(IRepositorioEstadio repoEstadio, IRepositorioMunicipio repoMunicipio)
        {
            _repoEstadio = repoEstadio;
            _repoMunicipio = repoMunicipio;
        }
        public IActionResult OnGet(int id)
        {
            estadio = _repoEstadio.GetEstadio(id);
            municipios =  _repoMunicipio.getAllMunicipios();
            if (estadio == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(int idEstadio, string nombre, int idMunicipio, string direccion)
        {
            _repoEstadio.updateEstadio(idEstadio, nombre, direccion);
            _repoEstadio.asignarMunicipio(idEstadio, idMunicipio);
            return RedirectToPage("Index");
        }
    }
}
