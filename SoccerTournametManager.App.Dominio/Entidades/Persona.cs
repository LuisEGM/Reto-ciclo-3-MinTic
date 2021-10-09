using System.ComponentModel.DataAnnotations;
namespace SoccerTournametManager.App.Dominio
{
    /// <summary>Class <c>Persona</c>
    /// Modela una Persona en general en el sistema 
    /// </summary>
    public class Persona
    {
        // Identificador único de cada persona
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Nombre { get; set; }
        [Display(Name = "Documento")]
        [Required(ErrorMessage = "El documento es obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Documento { get; set; }
        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "El telefono es obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Telefono { get; set; }
    }
}