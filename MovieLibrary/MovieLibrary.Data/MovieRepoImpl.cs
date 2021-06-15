using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using MovieLibrary.Models.Db;

namespace MovieLibrary.Data
{
    public class MovieRepoImpl : IMovieRepo
    {
        public MovieDb CreateMovie(MovieDb movie)
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

        public MovieDb ReadMovieById(int id)
        {
            using (SqlConnection c = new SqlConnection(Settings.GetConnString()))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MovieId", id);

                return c.Query<MovieDb>("MovieSelectById", param, commandType: CommandType.StoredProcedure)
                    .FirstOrDefault();
            }
        }

        public MovieDb ReadMovieByTitle(string title)
        {
            using (SqlConnection c = new SqlConnection(Settings.GetConnString()))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MovieTitle", title);

                return c.Query<MovieDb>("MovieSelectByTitle", param, commandType: CommandType.StoredProcedure)
                    .FirstOrDefault();
            }
        }

        public IEnumerable<MovieDb> ReadAllMovies()
        {
            using (SqlConnection c = new SqlConnection(Settings.GetConnString()))
            {
                return c.Query<MovieDb>("MovieSelectAll", commandType: CommandType.StoredProcedure);
            }
        }

        public MovieDb UpdateMovie(MovieDb update)
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

        public bool DeleteMovie(int id)
        {
            using (SqlConnection c = new SqlConnection(Settings.GetConnString()))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MovieId", id);

                int delete = c.Execute("MovieDelete", param, commandType: CommandType.StoredProcedure);

                return delete == 1;
            }
        }
    }
}