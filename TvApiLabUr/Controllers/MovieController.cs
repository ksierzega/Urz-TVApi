using System.Collections.Generic;
using System.Web.Http;
using TvApiLabUr.Filters;
using TvApiLabUr.Models;
using TvApiLabUr.Services;

namespace TvApiLabUr.Controllers
{
    public class MovieController : ApiController
    {
        private MoviesService _moviesService;

        public MovieController()
        {
            _moviesService = new MoviesService();
        }

        [ExecutionTime]
        [HttpGet, Route("movies")]
        public IHttpActionResult GetAllMovies()
        {
            List<MovieResponse> movies = _moviesService.GetAll();
            return Ok(movies);
        }

        [HttpGet, Route("movies/{movieId:int}")]
        public IHttpActionResult Get(int movieId)
        {
            MovieResponse movie = _moviesService.GetById(movieId);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPost, Route("movies")]
        [ModelValidation]
        public IHttpActionResult Post([FromBody]MovieRequest movie)
        {
            _moviesService.AddNewMovie(movie);

            return Ok();
        }

        [HttpDelete, Route("movies/{movieId}")]
        public IHttpActionResult Delete(int movieId)
        {
            _moviesService.Remove(movieId);
            return Ok();
        }
    }
}
