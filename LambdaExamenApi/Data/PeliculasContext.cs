using Microsoft.EntityFrameworkCore;

namespace LambdaExamenApi.Data
{
    public class PeliculasContext : DbContext
    {
        public PeliculasContext(DbContextOptions<PeliculasContext> options) : base(options) { }

        public DbSet<Models.Pelicula> Peliculas { get; set; }
    }
}
