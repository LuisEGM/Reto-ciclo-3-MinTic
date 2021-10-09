using System.ComponentModel.DataAnnotations;
namespace SoccerTournametManager.App.Dominio
{
    /// <summary>Class <c>Jugador</c>
    /// Modela un jugador en general en el sistema 
    /// </summary>
    public class Jugador : Persona
    {
        [Display(Name = "Numero del Jugador")]
        [Required(ErrorMessage = "El numero es obligatorio")]
        [Range(1, 30, ErrorMessage = "Un numero entre 1 y 30")]
        public int Numero { get; set; }
        [Display(Name = "Posicion del jugador")]
        [Required(ErrorMessage = "La posicion es obligatoria")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Posicion { get; set; }
        public Equipo Equipo { get; set; }
    }
}