using System.ComponentModel.DataAnnotations;
namespace SoccerTournametManager.App.Dominio
{
    /// <summary>Class <c>Arbitro</c>
    /// Modela una arbitro en general en el sistema 
    /// </summary>
    public class Arbitro: Persona
    {
        [Required(ErrorMessage = "Colegio Requerido")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Colegio { get; set; }
    }
}