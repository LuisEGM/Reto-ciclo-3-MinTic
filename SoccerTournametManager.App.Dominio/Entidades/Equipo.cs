using System.Collections.Generic;

namespace SoccerTournametManager.App.Dominio
{
    /// <summary>Class <c>Equipo</c>
    /// Modela un equipo en general en el sistema 
    /// </summary>
    public class Equipo
    {
        // Identificador único de cada equipo
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Municipio Municipio { get; set; }
        public DirectorTecnico DirectorTecnico { get; set; }
        public DesempeñoEquipo DesempeñoEquipo { get; set; }
    }
}