using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoccerTournametManager.App.Dominio
{
    /// <summary>Class <c>Equipo</c>
    /// Modela un equipo en general en el sistema 
    /// </summary>
    public class Equipo
    {
        // Identificador único de cada equipo
        public int Id { get; set; }
        [Display(Name = "Nombre del equipo")]
        [Required(ErrorMessage = "El nombre el obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Nombre { get; set; }
        public Municipio Municipio { get; set; }
        public DirectorTecnico DirectorTecnico { get; set; }
        public DesempeñoEquipo DesempeñoEquipo { get; set; }
    }
}