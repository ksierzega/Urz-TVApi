using System.ComponentModel.DataAnnotations;

namespace TvApiLabUr.Models
{
   public class MovieRequest
   {
      [Required]
      public string Title { get; set; }

      [Range(1888, int.MaxValue, ErrorMessage = "Incorrect Year!")]
      public int Year { get; set; }
   }
}