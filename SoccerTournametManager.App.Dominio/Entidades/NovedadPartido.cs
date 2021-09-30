namespace SoccerTournametManager.App.Dominio
{
    /// <summary>Class <c>NovedadPartido</c>
    /// Modela una novedad de partido en general en el sistema 
    /// </summary>
    public class NovedadPartido
    {
        // Identificador único de cada novedad de partido
        public int Id { get; set; }
        public Novedad Novedad { get; set; }
        public int minuto { get; set; }
        public Jugador JugadorInvolucrado { get; set; }
        public Partido Partido { get; set; }
    }
}