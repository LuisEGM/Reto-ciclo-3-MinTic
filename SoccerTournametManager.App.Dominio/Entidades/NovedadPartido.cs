using System.ComponentModel.DataAnnotations;
namespace SoccerTournametManager.App.Dominio
{
    /// <summary>Class <c>NovedadPartido</c>
    /// Modela una novedad de partido en general en el sistema 
    /// </summary>
    public class NovedadPartido
    {
        // Identificador único de cada novedad de partido
        public int Id { get; set; }
        [Display(Name = "Tipo de novedad")]
        public Novedad Novedad { get; set; }
        [Display(Name = "Minuto de la novedad")]
        [Range(0, 120, ErrorMessage = "Un numero entre 0 y 120 min")]
        public int Minuto { get; set; }
        public Jugador JugadorInvolucrado { get; set; }
        public Partido Partido { get; set; }
    }
}