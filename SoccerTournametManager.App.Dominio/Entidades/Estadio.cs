namespace SoccerTournametManager.App.Dominio
{
    /// <summary>Class <c>Estadio</c>
    /// Modela un estadio en general en el sistema 
    /// </summary>
    public class Estadio
    {
        // Identificador único de cada estadio
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public Municipio Municipio { get; set; }
    }
}