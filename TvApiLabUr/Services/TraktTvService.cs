using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TvApiLabUr.Models;

namespace TvApiLabUr.Services
{
    public class TraktTvService
    {
        private MoviesService _movieService = new MoviesService();

        public async Task DownloadMovies()
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://api.trakt.tv/movies/popular");
                //request.Headers.Add("Content-type", "application/json");
                //request.Headers.Add("trakt-api-key", "enter api key here");
                //request.Headers.Add("trakt-api-version", "2");

                var response = await client.SendAsync(request);
                var movies = await response.Content.ReadAsAsync<IEnumerable<TraktTvMovie>>();
                foreach (TraktTvMovie movie in movies)
                {
                    _movieService.AddNewMovie(new MovieRequest
                    {
                        Title = movie.Title,
                        Year = movie.Year
                    });
                }
            }
        }
    }
}