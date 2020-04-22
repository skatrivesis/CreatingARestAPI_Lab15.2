using CreatingARestAPI_Lab15._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatingARestAPI_Lab15._2.Services
{
    public interface IDAL
    {
        Movie GetMovieById(int id);
        string[] GetMovieCategories();
        IEnumerable<Movie> GetMoviesAll();
        IEnumerable<Movie> GetMoviesByCategory(string category);
        Movie GetRandomMovie();
        Movie GetRandomMovieByCategory(string category);
    }
}
