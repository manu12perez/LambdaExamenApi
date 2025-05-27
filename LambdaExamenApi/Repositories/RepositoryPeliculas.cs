using LambdaExamenApi.Data;
using LambdaExamenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LambdaExamenApi.Repositories
{
    public class RepositoryPeliculas
    {
        private PeliculasContext context;

        public RepositoryPeliculas(PeliculasContext context)
        {
            this.context = context;
        }

        public async Task<List<Pelicula>> GetPeliculasAsync()
        {
            return await this.context.Peliculas.ToListAsync();
        }

        public async Task<Pelicula> FindPelciulaAsync(int idPelicula)
        {
            return await this.context.Peliculas.FirstOrDefaultAsync(x => x.IdPelicula == idPelicula);
        }

        private async Task<int> GetMaxIdPeliculaAsync()
        {
            return await this.context.Peliculas.MaxAsync(x => x.IdPelicula) + 1;
        }

        public async Task CreatePeliculaAsync(string genero, string titulo, string nacionalidad, string argumento, string actores, int duracion, int precio, string youtube)
        {
            Pelicula pelicula = new Pelicula();
            pelicula.IdPelicula = await this.GetMaxIdPeliculaAsync();
            pelicula.Genero = genero;
            pelicula.Titulo = titulo;
            pelicula.Nacionalidad = nacionalidad;
            pelicula.Argumento = argumento;
            pelicula.Actores = actores;
            pelicula.Duracion = duracion;
            pelicula.Precio = precio;
            pelicula.Youtube = youtube;
            await this.context.Peliculas.AddAsync(pelicula);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePeliculaAsync(int idPelicula, string genero, string titulo, string nacionalidad, string argumento, string actores, int duracion, int precio, string youtube)
        {
            Pelicula pelicula = await this.FindPelciulaAsync(idPelicula);
            pelicula.Genero = genero;
            pelicula.Titulo = titulo;
            pelicula.Nacionalidad = nacionalidad;
            pelicula.Argumento = argumento;
            pelicula.Actores = actores;
            pelicula.Duracion = duracion;
            pelicula.Precio = precio;
            pelicula.Youtube = youtube;
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePeliculasAsync(int idPelicula)
        {
            Pelicula pelicula = await this.FindPelciulaAsync(idPelicula);
            this.context.Peliculas.Remove(pelicula);
            await this.context.SaveChangesAsync();
        }
    }
}
