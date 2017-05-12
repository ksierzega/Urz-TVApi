using System.Collections.Generic;
using System.Linq;
using TvApiLabUr.Common;
using TvApiLabUr.DAL;
using TvApiLabUr.Filters;
using TvApiLabUr.Models;

namespace TvApiLabUr.Services
{
    public class ReviewService
    {
        public void AddReviewToMovie(int movieId, ReviewRequest request)
        {
            using (var ctx = new MoviesContext())
            {
                var movie = ctx.Movies.Find(movieId);

                if (movie == null)
                {
                    throw new TvApiException("Invalid movie id");
                }

                movie.Reviews.Add(new Review()
                {
                    Comment = request.Comment,
                    Rate = request.Rate
                });

                ctx.SaveChanges();
            }
        }

        public IEnumerable<ReviewResponse> GetReviewsForMovie(int movieId)
        {
            using (var ctx = new MoviesContext())
            {
                var movie = ctx.Movies.Find(movieId);
                return movie.Reviews.Select(x => new ReviewResponse()
                {
                    Id = x.Id,
                    Comment = x.Comment,
                    Rate = x.Rate
                }).ToList();
            }
        }
    }
}