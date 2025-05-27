using LambdaExamenApi.Models;
using LambdaExamenApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LambdaExamenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private RepositoryPeliculas repo;

        public PeliculasController(RepositoryPeliculas repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pelicula>>> GetPeliculas()
        {
            return await this.repo.GetPeliculasAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pelicula>> FindPelicula(int id)
        {
            return await this.repo.FindPelciulaAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Pelicula pelicula)
        {
            await this.repo.CreatePeliculaAsync(pelicula.Genero, pelicula.Titulo, pelicula.Nacionalidad, pelicula.Argumento, pelicula.Actores, pelicula.Duracion, pelicula.Precio, pelicula.Youtube);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Pelicula pelicula)
        {
            await this.repo.UpdatePeliculaAsync(pelicula.IdPelicula, pelicula.Genero, pelicula.Titulo, pelicula.Nacionalidad, pelicula.Argumento, pelicula.Actores, pelicula.Duracion, pelicula.Precio, pelicula.Youtube);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await this.repo.DeletePeliculasAsync(id);
            return Ok();
        }
    }
}
