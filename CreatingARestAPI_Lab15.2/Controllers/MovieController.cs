using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreatingARestAPI_Lab15._2.Models;
using CreatingARestAPI_Lab15._2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CreatingARestAPI_Lab15._2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private IDAL dal;

        public MovieController(IDAL dalObject)
        {
            dal = dalObject;
        }

        public Movie GetSingleMovie(int id)
        {
            Movie SingleMovie = dal.GetMovieById(id);
            return SingleMovie;
        }

        [HttpGet("categories")]
        public string[] GetAllMovieCategories()
        {
            return dal.GetMovieCategories();
        }

        [HttpGet]
        public IEnumerable<Movie> Get(string category = null)
        {
            if (category == null)
            {
                return dal.GetMoviesAll();
            }
            else
            {
                return dal.GetMoviesByCategory(category);
            }
        }

        [HttpGet]
        public Movie GetRandom(string category = null)
        {
            if (category == null)
            {
                return dal.GetRandomMovie();
            }
            else
            {
                return dal.GetRandomMovieByCategory(category);
            }
        }

        private readonly ILogger<WeatherForecastController> _logger;

        public MovieController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
    }
}
