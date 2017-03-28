using System.Collections.Generic;

namespace TvApiLabUr.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public List<string> Comments { get; set; }
    }
}