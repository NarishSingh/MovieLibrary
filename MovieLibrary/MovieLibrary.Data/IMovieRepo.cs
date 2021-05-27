using MovieLibrary.Models.Db;

namespace MovieLibrary.Data
{
    /// <summary>
    /// Will handle CRUD to the database
    /// </summary>
    public interface IMovieRepo
    {
        /// <summary>
        /// When a movie record receives >0 likes or dislikes, persist to db
        /// </summary>
        /// <param name="movie">well form Movie obj</param>
        void CreateMovie(Movie movie);

        /// <summary>
        /// Read a movie obj from db
        /// </summary>
        /// <param name="movieId">int for a valid movie id</param>
        /// <returns>Movie obj corresponding to that id</returns>
        Movie ReadMovieById(int movieId);

        /// <summary>
        /// If a movie gets a like or dislike, update record in db
        /// </summary>
        /// <param name="update">well formed Movie obj to be updated</param>
        void UpdateMovie(Movie update);

        /// <summary>
        /// When a movie's likes and dislikes both reach 0, delete from db
        /// </summary>
        /// <param name="movieId">valid id for a movie record in db</param>
        void DeleteMovie(int movieId);
    }
}