using System.ComponentModel.DataAnnotations;
namespace SoccerTournametManager.App.Dominio
{
    /// <summary>Class <c>Estadio</c>
    /// Modela un estadio en general en el sistema 
    /// </summary>
    public class Estadio
    {
        // Identificador único de cada estadio
        public int Id { get; set; }
        [Display(Name = "Nombre del estadio")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
        public string Nombre { get; set; }
        [Display(Name = "Direccion del estadio")]
        [Required(ErrorMessage = "La direccion es obligatoria")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Direccion { get; set; }
        public Municipio Municipio { get; set; }
    }
}