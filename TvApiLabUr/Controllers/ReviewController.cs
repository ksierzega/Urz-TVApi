using System.Web.Http;
using TvApiLabUr.Filters;
using TvApiLabUr.Models;
using TvApiLabUr.Services;

namespace TvApiLabUr.Controllers
{
    [TvApiExceptionFilter]
    public class ReviewController : ApiController
    {
        private ReviewService _reviewService;

        public ReviewController()
        {
            _reviewService = new ReviewService();
        }

        [HttpPost, Route("movies/{movieId:int}/reviews")]
        public IHttpActionResult AddReviewToMovie(int movieId, ReviewRequest request)
        {
            _reviewService.AddReviewToMovie(movieId, request);
            return Ok();
        }

        [HttpGet, Route("movies/{movieId:int}/reviews")]
        public IHttpActionResult GetReviewsForMovie(int movieId)
        {
            return Ok(_reviewService.GetReviewsForMovie(movieId));
        }
    }
}
