using System.ComponentModel.DataAnnotations;
namespace SoccerTournametManager.App.Dominio
{
    /// <summary>Class <c>Jugador</c>
    /// Modela un jugador en general en el sistema 
    /// </summary>
    public class Jugador : Persona
    {
        [Display(Name = "Numero del Jugador")]
        public int Numero { get; set; }
        public string Posicion { get; set; }
        public Equipo Equipo { get; set; }
    }
}