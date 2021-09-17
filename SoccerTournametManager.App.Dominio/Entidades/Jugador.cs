namespace SoccerTournametManager.App.Dominio
{
    /// <summary>Class <c>Jugador</c>
    /// Modela un jugador en general en el sistema 
    /// </summary>
    public class Jugador: Persona
    {
        public int Numero { get; set; }
        public string Posicion { get; set; }
    }
}