namespace SoccerTournametManager.App.Dominio
{
    /// <summary>Class <c>DesempeñoEquipo</c>
    /// Modela el desempeño de un equipo en general en el sistema 
    /// </summary>
    public class DesempeñoEquipo
    {
        // Identificador único de cada desempeño
        public int Id { get; set; }
        public int PartidosJugados { get; set; }
        public int PartidosGanados { get; set; }
        public int PartidosEmpatados { get; set; }
        public int GolesAFavor { get; set; }
        public int GolesEnContra { get; set; }
        public int Puntos { get; set; }
    }
}