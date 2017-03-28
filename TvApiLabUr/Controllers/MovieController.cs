using System.Collections.Generic;
using System.Web.Http;
using TvApiLabUr.Models;
using TvApiLabUr.Services;

namespace TvApiLabUr.Controllers
{
    public class MovieController : ApiController
    {
        private MoviesService _moviesService;

        public MovieController()
        {
            _moviesService = MoviesService.Instace;
        }

        [HttpGet, Route("movies")]
        public IHttpActionResult GetAllMovies()
        {
            List<Movie> movies = _moviesService.GetAll();
            return Ok(movies);
        }

        [HttpGet, Route("movies/{movieId:int}")]
        public IHttpActionResult Get(int movieId)
        {
            Movie movie = _moviesService.GetById(movieId);

            if (movie == null)
            {
                return NotFound();                
            }

            return Ok(movie);
        }

        [HttpPost, Route("movies")]
        public IHttpActionResult Post([FromBody]Movie movie)
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
