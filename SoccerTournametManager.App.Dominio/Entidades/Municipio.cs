using System.ComponentModel.DataAnnotations;
namespace SoccerTournametManager.App.Dominio
{
    /// <summary>Class <c>Municipio</c>
    /// Modela un municipio en general en el sistema 
    /// </summary>
    public class Municipio
    {
        // Identificador único de cada municipio
        [Display(Name = "Numero del Estadio")]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}