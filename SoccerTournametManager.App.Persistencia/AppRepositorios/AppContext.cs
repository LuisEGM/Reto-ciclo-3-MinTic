using Microsoft.EntityFrameworkCore;
using SoccerTournametManager.App.Dominio;

namespace SoccerTournametManager.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas {get; set;}
        public DbSet<Jugador> Jugadores {get; set;}
        public DbSet<DirectorTecnico> DirectoresTecnicos {get; set;}
        public DbSet<Arbitro> Arbitros {get; set;}
        public DbSet<Equipo> Equipos {get; set;}
        public DbSet<Partido> Partidos {get; set;}
        public DbSet<Estadio> Estadios {get; set;}
        public DbSet<DesempeñoEquipo> DesempeñosDeEquipos {get; set;}
        public DbSet<NovedadPartido> NovedadesDePartidos {get; set;}
        public DbSet<Municipio> Municipios {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data source  = (localdb)\\MSSQLLocalDB; Initial Catalog = SoccerTournametManager");
            }
        }
    }
}