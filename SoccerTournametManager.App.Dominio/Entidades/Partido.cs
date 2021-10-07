using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace SoccerTournametManager.App.Dominio
{
    /// <summary>Class <c>Partido</c>
    /// Modela una partido en general en el sistema 
    /// </summary>
    public class Partido
    {
        // Identificador único de cada partido
        public int Id { get; set; }
        public Equipo EquipoLocal { get; set; }
        public Equipo EquipoVisitante { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Fecha y hora del encuentro")]
        public DateTime FechaHora { get; set; }
        public Estadio Estadio { get; set; }
        public Arbitro Arbitro { get; set; }
    }
}