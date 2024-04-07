using Microsoft.EntityFrameworkCore;
using FilmsApi.Models;

namespace FilmsApi.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<FilmsDto> FilmsVar { get; set; }
        public DbSet<SeriesDto> SeriesVar { get; set; }
        public DbSet<Genres> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;database=filmsDb;username=root;password=",
                new MySqlServerVersion(new Version(8, 0, 33))
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Films>()
                .HasMany(t => t.Genres)
                .WithMany(p => p.Films)
                .UsingEntity<FilmsGenres>();

            modelBuilder.Entity<Series>()
                .HasMany(t => t.Genres)
                .WithMany(p => p.Series)
                .UsingEntity<GenresSeries>();

            modelBuilder.Entity<Genres>().HasData(
                new Genres { Id = 1, Name = "action" },
                new Genres { Id = 2, Name = "Romance" },
                new Genres { Id = 3, Name = "mystery" },
                new Genres { Id = 4, Name = "fantasy" }
            );

            modelBuilder.Entity<GenresDto>().HasData(
                new GenresDto { Id = 1, Name = "action" },
                new GenresDto { Id = 2, Name = "Romance" },
                new GenresDto { Id = 3, Name = "mystery" },
                new GenresDto { Id = 4, Name = "fantasy" }
            );
        }

        public DbSet<FilmsApi.Models.Series> Series { get; set; } = default!;

        public DbSet<FilmsApi.Models.FilmsGenres> FilmsGenres { get; set; } = default!;

        public DbSet<FilmsApi.Models.GenresSeries> GenresSeries { get; set; } = default!;
    }
}
