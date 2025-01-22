using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MSSQLApp.Data
{
    public class AppDbContext : DbContext
    {
        // Constructor for Dependency Injection (DI)
        public IConfiguration _config { get; set; }

        public AppDbContext(IConfiguration config)
        {
            _config = config;
        }

        // Configuring the DbContext to use SQL Server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
        }

        // DbSets for different entities in the database
        public DbSet<Employee> Employees { get; set; }
        public DbSet<AudioFile> AudioFiles { get; set; } // Ajout de la table AudioFile
    }

    // Classe pour la table AudioFile
    public class AudioFile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string FileName { get; set; }

        [Required]
        public string ContentType { get; set; } // Type MIME, ex: "audio/mpeg"

        [Required]
        public byte[] Data { get; set; } // Contenu du fichier audio
    }
}
