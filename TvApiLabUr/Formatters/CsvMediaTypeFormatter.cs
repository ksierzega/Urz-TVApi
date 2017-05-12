using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;
using TvApiLabUr.Models;

namespace TvApiLabUr.Formatters
{
   public class CsvMediaTypeFormatter : BufferedMediaTypeFormatter
   {
      public CsvMediaTypeFormatter()
      {
         SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/csv"));
      }

      public override bool CanReadType(Type type)
      {
         if (type == typeof(MovieRequest))
         {
            return true;
         }
         return false;
      }

      public override bool CanWriteType(Type type)
      {
         if (type == typeof (MovieResponse)
            || type == typeof(List<MovieResponse>))
         {
            return true;
         }

         return false;
      }

      public override object ReadFromStream(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
      {
         MovieRequest request = new MovieRequest();

         using (var reader = new StreamReader(readStream))
         {
            try
            {
               var line = reader.ReadLine();
               var stringValues = line.Split(';');
               
               request.Title = stringValues[0];
               request.Year = int.Parse(stringValues[1]);
            }
            catch 
            {
               request = null;
            }
         }
         return request;
      }

      public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
      {
         var movieList = value as List<MovieResponse>;

         using(var streamWriter = new StreamWriter(writeStream))
         {
            if (movieList != null)
            {
               foreach (var movie in movieList)
               {
                  streamWriter.WriteLine(movie.Id + ";" + movie.Title + "; " + movie.Year + ";");
               }
            }
            else
            {
               var movie = value as MovieResponse;
               if (movie != null)
               {
                  streamWriter.WriteLine(movie.Id + ";" + movie.Title + "; " + movie.Year + ";");
               }
            }
         }
      }
   }
}