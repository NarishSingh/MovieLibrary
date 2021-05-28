using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using MovieLibrary.Models.Db;

namespace MovieLibrary.Data
{
    public class MovieRepoImpl : IMovieRepo
    {
        public Movie CreateMovie(Movie movie)
        {
            using (SqlConnection c = new SqlConnection(Settings.GetConnString()))
            {
                DynamicParameters param = new DynamicParameters();

                //output
                param.Add(
                    "MovieId",
                    dbType: DbType.Int32,
                    direction: ParameterDirection.Output
                );

                //input
                param.Add("@MovieTitle", movie.MovieTitle);
                param.Add("@Likes", movie.Likes);
                param.Add("@Dislikes", movie.Dislikes);

                //execute and retrieve Id
                c.Execute("MovieInsert", param, commandType: CommandType.StoredProcedure);

                movie.MovieId = param.Get<int>("@MovieId");
            }

            return movie;
        }

        public Movie ReadMovieById(int movieId)
        {
            using (SqlConnection c = new SqlConnection(Settings.GetConnString()))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MovieId", movieId);

                return c.Query<Movie>("MovieSelect", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public Movie UpdateMovie(Movie update)
        {
            using (SqlConnection c = new SqlConnection(Settings.GetConnString()))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MovieId", update.MovieId);
                param.Add("@MovieTitle", update.MovieTitle);
                param.Add("@Likes", update.Likes);
                param.Add("@Dislikes", update.Dislikes);

                int persisted = c.Execute("MovieUpdate", param, commandType: CommandType.StoredProcedure);

                return persisted == 1 ? update : null;
            }
        }

        public bool DeleteMovie(int movieId)
        {
            using (SqlConnection c = new SqlConnection(Settings.GetConnString()))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MovieId", movieId);

                int delete = c.Execute("MovieDelete", param, commandType: CommandType.StoredProcedure);

                return delete == 1;
            }
        }
    }
}