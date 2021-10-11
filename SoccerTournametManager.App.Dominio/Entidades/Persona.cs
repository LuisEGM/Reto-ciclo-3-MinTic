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
        [Required(ErrorMessage = "Nombre Requerido")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Documento Requerido")]
        [StringLength(12, ErrorMessage = "Maximo 12 caracteres")]
        public string Documento { get; set; }
        [Required(ErrorMessage = "Telefono Requerido")]
        [StringLength(15, ErrorMessage = "Maximo 15 caracteres")]
        public string Telefono { get; set; }
    }
}