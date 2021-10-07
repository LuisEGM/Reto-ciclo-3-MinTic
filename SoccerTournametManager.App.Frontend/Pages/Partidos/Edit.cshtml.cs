using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SoccerTournametManager.App.Dominio;
using SoccerTournametManager.App.Persistencia;

namespace SoccerTournametManager.App.Frontend.Pages.Partidos
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioPartido _repoPartido;
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioArbitro _repoArbitro;
        private readonly IRepositorioEstadio _repoEstadio;
        public IEnumerable<Estadio> estadios {get; set;}
        public IEnumerable<Arbitro> arbitros {get; set;}
        public IEnumerable<Equipo> equipos {get; set;}
        public Partido partido { get; set; }

        public EditModel(IRepositorioPartido repoPartido, IRepositorioEquipo repoEquipo, IRepositorioArbitro repoArbitro, IRepositorioEstadio repoEstadio)
        {
            _repoPartido = repoPartido;
            _repoEquipo = repoEquipo;
            _repoArbitro = repoArbitro;
            _repoEstadio = repoEstadio;
        }
        public IActionResult OnGet(int id)
        {
            partido = _repoPartido.GetPartido(id);
            equipos =  _repoEquipo.getAllEquipos();
            arbitros =  _repoArbitro.getAllArbitros();
            estadios =  _repoEstadio.getAllEstadios();
            if (partido == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(int idPartido, string fechaHora, int idEquipoLocal, int idEquipoVisitante, int idEstadio, int idArbitro)
        {
            _repoPartido.updatePartido(idPartido, fechaHora);
            _repoPartido.addEquipo("local", idPartido, idEquipoLocal);
            _repoPartido.addEquipo("visitante", idPartido, idEquipoVisitante);
            _repoPartido.addEstadio(idPartido, idEstadio);
            _repoPartido.addArbitro(idPartido, idArbitro);
            return RedirectToPage("Index");
        }
    }
}
