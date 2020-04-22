using CreatingARestAPI_Lab15._2.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CreatingARestAPI_Lab15._2.Services
{
    public class DALSqlServer : IDAL
    {
        private string connectionString;

        public DALSqlServer(IConfiguration config)
        {
            connectionString = config.GetConnectionString("movieDB");
        }

        public string[] GetMovieCategories()
        {
            SqlConnection connection = null;
            string queryString = "SELECT DISTINCT Category FROM MovieDB";
            IEnumerable<Movie> Movies = null;

            try
            {
                connection = new SqlConnection(connectionString);
                Movies = connection.Query<Movie>(queryString);
            }
            catch (Exception e)
            {
                //log the error
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            if (Movies == null)
            {
                return null;
            }
            else
            {
                string[] categories = new string[Movies.Count()];
                int count = 0;

                foreach (Movie m in Movies)
                {
                    categories[count] = m.Category;
                    count++;
                }

                return categories;
            }
        }

        public IEnumerable<Movie> GetMoviesAll()
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM Movies";
            IEnumerable<Movie> Movies = null;

            try
            {
                connection = new SqlConnection(connectionString);
                Movies = connection.Query<Movie>(queryString);
            }
            catch (Exception e)
            {
                //log error
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return Movies;
        }

        public IEnumerable<Movie> GetMoviesByCategory(string category)
        {
            SqlConnection connection = null;
            string squeryString = "SELECT * FROM Movies WHERE Category = @category";
            IEnumerable<Movie> Movies = null;

            try
            {
                connection = new SqlConnection(connectionString);
                Movies = connection.Query<Movie>(squeryString, new { category = category });
            }
            catch (Exception e)
            {
                //log error
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return Movies;
        }

        public Movie GetMovieById(int id)
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM Movies WHERE Id = @id";
            Movie SingleMovie = null;

            try
            {
                connection = new SqlConnection(connectionString);
                SingleMovie = connection.QueryFirstOrDefault<Movie>(queryString, new { id = id });
            }
            catch (Exception e)
            {
                //log error
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return SingleMovie;
        }

        public Movie GetRandomMovie()
        {
            SqlConnection connection = null;
            string queryString = "SELECT TOP 1 FROM Movies ORDER BY NEWID()";
            Movie SingleMovie = null;

            try
            {
                connection = new SqlConnection(connectionString);
                SingleMovie = connection.QueryFirstOrDefault<Movie>(queryString);
            }
            catch (Exception e)
            {
                //log error
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return SingleMovie;
        }

        public Movie GetRandomMovieByCategory(string category)
        {
            SqlConnection connection = null;
            string queryString = "SELECT TOP 1 FROM Movies WHERE Category = @category ORDER BY NEWID()";
            Movie SingleMovie = null;

            try
            {
                connection = new SqlConnection(connectionString);
                SingleMovie = connection.QueryFirstOrDefault<Movie>(queryString, new { category = category });
            }
            catch (Exception e)
            {
                //log error
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return SingleMovie;
        }
    }
}
