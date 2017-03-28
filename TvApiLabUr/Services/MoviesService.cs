using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TvApiLabUr.Models;

namespace TvApiLabUr.Services
{
    public class MoviesService
    {
        private static MoviesService _instance;
        private List<Movie> _movies;

        private MoviesService()
        {
            _movies = new List<Movie>
            {
                new Movie()
                {
                    Id = 1,
                    Author ="asd",
                    Title = "super film",
                    Year = 1998,
                    Comments = new  List<string> { "super", "ossommm"}
                 },
                new Movie()
                {
                    Id = 2,
                    Author ="asd2",
                    Title = "super film2",
                    Year = 1998,
                    Comments = new  List<string> { "super2", "ossommm2"}
                 },
            };
        }

        public static MoviesService Instace
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new MoviesService();
                }

                return _instance;
            }
        }

        

        public List<Movie> GetAll()
        {
            return _movies;
        }

        public Movie GetById(int id)
        {
            Movie foundMovie = _movies
                  .Where(movie => movie.Id == id)
                  .SingleOrDefault();

            return foundMovie;
        }

        public void AddNewMovie(Movie movie)
        {
            _movies.Add(movie);
        }

        public void Remove(int movieId)
        {
           Movie movie =  GetById(movieId);
            _movies.Remove(movie);
        }
    }
}