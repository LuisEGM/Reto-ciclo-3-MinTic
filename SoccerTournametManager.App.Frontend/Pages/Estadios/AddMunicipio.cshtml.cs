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
    public class AddMunicipioModel : PageModel
    {
        private readonly IRepositorioEstadio _repoEstadio;
        private readonly IRepositorioMunicipio _repoMunicipio;
        public IEnumerable<Municipio> municipios {get; set;}
        public Estadio estadio { get; set; }

        public AddMunicipioModel(IRepositorioEstadio repoEstadio, IRepositorioMunicipio repoMunicipio)
        {
            _repoEstadio = repoEstadio;
            _repoMunicipio = repoMunicipio;
        }

        public void OnGet(int id)
        {
            estadio = _repoEstadio.GetEstadio(id);
            municipios =  _repoMunicipio.getAllMunicipios();
        }

        public IActionResult OnPost(int idEstadio, int idMunicipio)
        {
            _repoEstadio.asignarMunicipio(idEstadio, idMunicipio);
            return RedirectToPage("Index");
        }
    }
}
