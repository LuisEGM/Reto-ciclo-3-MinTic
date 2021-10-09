using System.ComponentModel.DataAnnotations;
namespace SoccerTournametManager.App.Dominio
{
    /// <summary>Class <c>Municipio</c>
    /// Modela un municipio en general en el sistema 
    /// </summary>
    public class Municipio
    {
        // Identificador único de cada municipio
        public int Id { get; set; }

        [Display(Name = "Nombre del municipio")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Nombre { get; set; }
    }
}